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
	public partial class ExperienciaDalc : IExperienciaDalc
	{
		private Database db;

		public ExperienciaDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IExperienciaDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(ExperienciaVO experienciaVO, bool validateGuidOnPK)
		{
			if (experienciaVO.IdExperiencia == null)
				RegisterCriticalMessageRequiredField("IdExperiencia");
			if (string.IsNullOrEmpty(experienciaVO.Funcao))
				RegisterCriticalMessageRequiredField("Funcao");
			if (string.IsNullOrEmpty(experienciaVO.Descricao))
				RegisterCriticalMessageRequiredField("Descricao");
			if (experienciaVO.PeriodoDe == null)
				RegisterCriticalMessageRequiredField("PeriodoDe");
			if (experienciaVO.PeriodoAte == null)
				RegisterCriticalMessageRequiredField("PeriodoAte");
			if (string.IsNullOrEmpty(experienciaVO.Empresa))
				RegisterCriticalMessageRequiredField("Empresa");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(ExperienciaVO experienciaVO)
		{
			ValidateRequiredAttributes(experienciaVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaInsert");
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, experienciaVO.IdExperiencia);
			db.AddInParameter(command, "@Funcao", DbType.AnsiString, experienciaVO.Funcao);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, experienciaVO.Descricao);
			db.AddInParameter(command, "@PeriodoDe", DbType.DateTime, experienciaVO.PeriodoDe);
			db.AddInParameter(command, "@PeriodoAte", DbType.DateTime, experienciaVO.PeriodoAte);
			db.AddInParameter(command, "@Empresa", DbType.AnsiString, experienciaVO.Empresa);
			db.ExecuteNonQuery(command);
		}
		public void Update(ExperienciaVO experienciaVO)
		{
			ValidateRequiredAttributes(experienciaVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaUpdate");
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, experienciaVO.IdExperiencia);
			db.AddInParameter(command, "@Funcao", DbType.AnsiString, experienciaVO.Funcao);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, experienciaVO.Descricao);
			db.AddInParameter(command, "@PeriodoDe", DbType.DateTime, experienciaVO.PeriodoDe);
			db.AddInParameter(command, "@PeriodoAte", DbType.DateTime, experienciaVO.PeriodoAte);
			db.AddInParameter(command, "@Empresa", DbType.AnsiString, experienciaVO.Empresa);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idExperiencia)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaDelete");
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, idExperiencia);
			db.ExecuteNonQuery(command);
		}
		public ExperienciaVO Get(int idExperiencia)
		{
			ExperienciaVO experienciaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaSelect");
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, idExperiencia);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					experienciaVO = new ExperienciaVO();
					experienciaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						experienciaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					if (!reader.IsDBNull(reader.GetOrdinal("Funcao")))
						experienciaVO.Funcao = reader.GetString(reader.GetOrdinal("Funcao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						experienciaVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoDe")))
						experienciaVO.PeriodoDe = reader.GetDateTime(reader.GetOrdinal("PeriodoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						experienciaVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
					if (!reader.IsDBNull(reader.GetOrdinal("Empresa")))
						experienciaVO.Empresa = reader.GetString(reader.GetOrdinal("Empresa")).Trim();
				}
			}

			return experienciaVO;
		}
		public ExperienciaVOCollection GetAll()
		{
			ExperienciaVOCollection listaExperienciaVO = new ExperienciaVOCollection();
			ExperienciaVO experienciaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					experienciaVO = new ExperienciaVO();
					experienciaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						experienciaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					if (!reader.IsDBNull(reader.GetOrdinal("Funcao")))
						experienciaVO.Funcao = reader.GetString(reader.GetOrdinal("Funcao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						experienciaVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoDe")))
						experienciaVO.PeriodoDe = reader.GetDateTime(reader.GetOrdinal("PeriodoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						experienciaVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
					if (!reader.IsDBNull(reader.GetOrdinal("Empresa")))
						experienciaVO.Empresa = reader.GetString(reader.GetOrdinal("Empresa")).Trim();
					listaExperienciaVO.Add(experienciaVO);
				}
			}

			return listaExperienciaVO;
		}
		public ExperienciaVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			ExperienciaVOCollection listaExperienciaVO = new ExperienciaVOCollection();
			ExperienciaVO experienciaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_ExperienciaSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaExperienciaVO.Count == 0) listaExperienciaVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					experienciaVO = new ExperienciaVO();
					experienciaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						experienciaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					if (!reader.IsDBNull(reader.GetOrdinal("Funcao")))
						experienciaVO.Funcao = reader.GetString(reader.GetOrdinal("Funcao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						experienciaVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoDe")))
						experienciaVO.PeriodoDe = reader.GetDateTime(reader.GetOrdinal("PeriodoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						experienciaVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
					if (!reader.IsDBNull(reader.GetOrdinal("Empresa")))
						experienciaVO.Empresa = reader.GetString(reader.GetOrdinal("Empresa")).Trim();
					listaExperienciaVO.Add(experienciaVO);
				}
			}

			listaExperienciaVO.PageSize = maximumRows;

			return listaExperienciaVO;
		}

		#endregion
	}
}
