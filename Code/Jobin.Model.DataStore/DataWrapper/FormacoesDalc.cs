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
	public partial class FormacoesDalc : IFormacoesDalc
	{
		private Database db;

		public FormacoesDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IFormacoesDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(FormacoesVO formacoesVO, bool validateGuidOnPK)
		{
			if (formacoesVO.IdFormacao == null)
				RegisterCriticalMessageRequiredField("IdFormacao");
			if (string.IsNullOrEmpty(formacoesVO.Curso))
				RegisterCriticalMessageRequiredField("Curso");
			if (string.IsNullOrEmpty(formacoesVO.Descricao))
				RegisterCriticalMessageRequiredField("Descricao");
			if (string.IsNullOrEmpty(formacoesVO.Instituicao))
				RegisterCriticalMessageRequiredField("Instituicao");
			if (formacoesVO.PeridoDe == null)
				RegisterCriticalMessageRequiredField("PeridoDe");
			if (formacoesVO.PeriodoAte == null)
				RegisterCriticalMessageRequiredField("PeriodoAte");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(FormacoesVO formacoesVO)
		{
			ValidateRequiredAttributes(formacoesVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesInsert");
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, formacoesVO.IdFormacao);
			db.AddInParameter(command, "@Curso", DbType.AnsiString, formacoesVO.Curso);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, formacoesVO.Descricao);
			db.AddInParameter(command, "@Instituicao", DbType.AnsiString, formacoesVO.Instituicao);
			db.AddInParameter(command, "@PeridoDe", DbType.DateTime, formacoesVO.PeridoDe);
			db.AddInParameter(command, "@PeriodoAte", DbType.DateTime, formacoesVO.PeriodoAte);
			db.ExecuteNonQuery(command);
		}
		public void Update(FormacoesVO formacoesVO)
		{
			ValidateRequiredAttributes(formacoesVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesUpdate");
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, formacoesVO.IdFormacao);
			db.AddInParameter(command, "@Curso", DbType.AnsiString, formacoesVO.Curso);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, formacoesVO.Descricao);
			db.AddInParameter(command, "@Instituicao", DbType.AnsiString, formacoesVO.Instituicao);
			db.AddInParameter(command, "@PeridoDe", DbType.DateTime, formacoesVO.PeridoDe);
			db.AddInParameter(command, "@PeriodoAte", DbType.DateTime, formacoesVO.PeriodoAte);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idFormacao)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesDelete");
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, idFormacao);
			db.ExecuteNonQuery(command);
		}
		public FormacoesVO Get(int idFormacao)
		{
			FormacoesVO formacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesSelect");
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, idFormacao);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					formacoesVO = new FormacoesVO();
					formacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						formacoesVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Curso")))
						formacoesVO.Curso = reader.GetString(reader.GetOrdinal("Curso")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						formacoesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Instituicao")))
						formacoesVO.Instituicao = reader.GetString(reader.GetOrdinal("Instituicao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeridoDe")))
						formacoesVO.PeridoDe = reader.GetDateTime(reader.GetOrdinal("PeridoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						formacoesVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
				}
			}

			return formacoesVO;
		}
		public FormacoesVOCollection GetAll()
		{
			FormacoesVOCollection listaFormacoesVO = new FormacoesVOCollection();
			FormacoesVO formacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					formacoesVO = new FormacoesVO();
					formacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						formacoesVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Curso")))
						formacoesVO.Curso = reader.GetString(reader.GetOrdinal("Curso")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						formacoesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Instituicao")))
						formacoesVO.Instituicao = reader.GetString(reader.GetOrdinal("Instituicao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeridoDe")))
						formacoesVO.PeridoDe = reader.GetDateTime(reader.GetOrdinal("PeridoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						formacoesVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
					listaFormacoesVO.Add(formacoesVO);
				}
			}

			return listaFormacoesVO;
		}
		public FormacoesVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			FormacoesVOCollection listaFormacoesVO = new FormacoesVOCollection();
			FormacoesVO formacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_FormacoesSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaFormacoesVO.Count == 0) listaFormacoesVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					formacoesVO = new FormacoesVO();
					formacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						formacoesVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Curso")))
						formacoesVO.Curso = reader.GetString(reader.GetOrdinal("Curso")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						formacoesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Instituicao")))
						formacoesVO.Instituicao = reader.GetString(reader.GetOrdinal("Instituicao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("PeridoDe")))
						formacoesVO.PeridoDe = reader.GetDateTime(reader.GetOrdinal("PeridoDe"));
					if (!reader.IsDBNull(reader.GetOrdinal("PeriodoAte")))
						formacoesVO.PeriodoAte = reader.GetDateTime(reader.GetOrdinal("PeriodoAte"));
					listaFormacoesVO.Add(formacoesVO);
				}
			}

			listaFormacoesVO.PageSize = maximumRows;

			return listaFormacoesVO;
		}

		#endregion
	}
}
