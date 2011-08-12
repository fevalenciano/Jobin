namespace Jobin.Model.DataStore
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Data.Common;
	using System.Data;
	using Microsoft.Practices.EnterpriseLibrary.Data;
	using Jobin.Model.ValueObjects;
	using Jobin.Model.DataStoreInterface;
	using ES.Practices.ExceptionHandling;
	using System.Configuration;

	[Serializable]
	public partial class CategoriasDalc : ICategoriasDalc
	{
		private Database db;

		public CategoriasDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region ICategoriasDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(CategoriasVO categoriasVO, bool validateGuidOnPK)
		{
			if (categoriasVO.IdCategoria == null && (validateGuidOnPK))
				RegisterCriticalMessageRequiredField("IdCategoria");
			if (categoriasVO.IdSegmento == null)
				RegisterCriticalMessageRequiredField("IdSegmento");
			if (string.IsNullOrEmpty(categoriasVO.Nome))
				RegisterCriticalMessageRequiredField("Nome");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public CategoriasVO Insert(CategoriasVO categoriasVO)
		{
			ValidateRequiredAttributes(categoriasVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasInsert");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, categoriasVO.IdSegmento);
			db.AddInParameter(command, "@Nome", DbType.AnsiString, categoriasVO.Nome);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					categoriasVO.IdCategoria = Int32.Parse(reader["uniqueIdCategoria"].ToString());
				}
			}

			return categoriasVO;
		}
		public void Update(CategoriasVO categoriasVO)
		{
			ValidateRequiredAttributes(categoriasVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasUpdate");
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, categoriasVO.IdCategoria);
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, categoriasVO.IdSegmento);
			db.AddInParameter(command, "@Nome", DbType.AnsiString, categoriasVO.Nome);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idCategoria)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasDelete");
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, idCategoria);
			db.ExecuteNonQuery(command);
		}
		public CategoriasVO Get(int idCategoria)
		{
			CategoriasVO categoriasVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasSelect");
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, idCategoria);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					categoriasVO = new CategoriasVO();
					categoriasVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						categoriasVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						categoriasVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						categoriasVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
				}
			}

			return categoriasVO;
		}
		public CategoriasVOCollection GetAll()
		{
			CategoriasVOCollection listaCategoriasVO = new CategoriasVOCollection();
			CategoriasVO categoriasVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					categoriasVO = new CategoriasVO();
					categoriasVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						categoriasVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						categoriasVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						categoriasVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					listaCategoriasVO.Add(categoriasVO);
				}
			}

			return listaCategoriasVO;
		}
		public CategoriasVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			CategoriasVOCollection listaCategoriasVO = new CategoriasVOCollection();
			CategoriasVO categoriasVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaCategoriasVO.Count == 0) listaCategoriasVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					categoriasVO = new CategoriasVO();
					categoriasVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						categoriasVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						categoriasVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						categoriasVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					listaCategoriasVO.Add(categoriasVO);
				}
			}

			listaCategoriasVO.PageSize = maximumRows;

			return listaCategoriasVO;
		}
		public CategoriasVOCollection GetBySegmentos(int idSegmento)
		{
			CategoriasVOCollection listaCategoriasVO = new CategoriasVOCollection();
			CategoriasVO categoriasVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_CategoriasSelectBySegmentos");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, idSegmento);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					categoriasVO = new CategoriasVO();
					categoriasVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						categoriasVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						categoriasVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						categoriasVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					listaCategoriasVO.Add(categoriasVO);
				}
			}

			return listaCategoriasVO;
		}

		#endregion
	}
}
