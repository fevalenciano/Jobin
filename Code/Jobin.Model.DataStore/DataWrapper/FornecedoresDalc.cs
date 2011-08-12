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
	public partial class FornecedoresDalc : IFornecedoresDalc
	{
		private Database db;

		public FornecedoresDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IFornecedoresDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(FornecedoresVO fornecedoresVO, bool validateGuidOnPK)
		{
			if (fornecedoresVO.IdFornecedor == null)
				RegisterCriticalMessageRequiredField("IdFornecedor");
			if (fornecedoresVO.IdUsuario == null)
				RegisterCriticalMessageRequiredField("IdUsuario");
			if (fornecedoresVO.IdEndereco == null)
				RegisterCriticalMessageRequiredField("IdEndereco");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(FornecedoresVO fornecedoresVO)
		{
			ValidateRequiredAttributes(fornecedoresVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresInsert");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, fornecedoresVO.IdFornecedor);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, fornecedoresVO.IdUsuario);
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, fornecedoresVO.IdEndereco);
			db.ExecuteNonQuery(command);
		}
		public void Update(FornecedoresVO fornecedoresVO)
		{
			ValidateRequiredAttributes(fornecedoresVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresUpdate");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, fornecedoresVO.IdFornecedor);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, fornecedoresVO.IdUsuario);
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, fornecedoresVO.IdEndereco);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idFornecedor)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresDelete");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, idFornecedor);
			db.ExecuteNonQuery(command);
		}
		public FornecedoresVO Get(int idFornecedor)
		{
			FornecedoresVO fornecedoresVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresSelect");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, idFornecedor);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					fornecedoresVO = new FornecedoresVO();
					fornecedoresVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						fornecedoresVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						fornecedoresVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						fornecedoresVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
				}
			}

			return fornecedoresVO;
		}
		public FornecedoresVOCollection GetAll()
		{
			FornecedoresVOCollection listaFornecedoresVO = new FornecedoresVOCollection();
			FornecedoresVO fornecedoresVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					fornecedoresVO = new FornecedoresVO();
					fornecedoresVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						fornecedoresVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						fornecedoresVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						fornecedoresVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					listaFornecedoresVO.Add(fornecedoresVO);
				}
			}

			return listaFornecedoresVO;
		}
		public FornecedoresVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			FornecedoresVOCollection listaFornecedoresVO = new FornecedoresVOCollection();
			FornecedoresVO fornecedoresVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaFornecedoresVO.Count == 0) listaFornecedoresVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					fornecedoresVO = new FornecedoresVO();
					fornecedoresVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						fornecedoresVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						fornecedoresVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						fornecedoresVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					listaFornecedoresVO.Add(fornecedoresVO);
				}
			}

			listaFornecedoresVO.PageSize = maximumRows;

			return listaFornecedoresVO;
		}
		public FornecedoresVOCollection GetByEndereco(int idEndereco)
		{
			FornecedoresVOCollection listaFornecedoresVO = new FornecedoresVOCollection();
			FornecedoresVO fornecedoresVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresSelectByEndereco");
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, idEndereco);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					fornecedoresVO = new FornecedoresVO();
					fornecedoresVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						fornecedoresVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						fornecedoresVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						fornecedoresVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					listaFornecedoresVO.Add(fornecedoresVO);
				}
			}

			return listaFornecedoresVO;
		}
		public FornecedoresVOCollection GetByUsuarios(int idUsuario)
		{
			FornecedoresVOCollection listaFornecedoresVO = new FornecedoresVOCollection();
			FornecedoresVO fornecedoresVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FornecedoresSelectByUsuarios");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					fornecedoresVO = new FornecedoresVO();
					fornecedoresVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						fornecedoresVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						fornecedoresVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						fornecedoresVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					listaFornecedoresVO.Add(fornecedoresVO);
				}
			}

			return listaFornecedoresVO;
		}

		#endregion
	}
}
