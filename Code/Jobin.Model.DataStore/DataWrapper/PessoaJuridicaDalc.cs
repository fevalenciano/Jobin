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
	public partial class PessoaJuridicaDalc : IPessoaJuridicaDalc
	{
		private Database db;

		public PessoaJuridicaDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IPessoaJuridicaDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(PessoaJuridicaVO pessoaJuridicaVO, bool validateGuidOnPK)
		{
			if (pessoaJuridicaVO.IdPessoaJuridica == null)
				RegisterCriticalMessageRequiredField("IdPessoaJuridica");
			if (pessoaJuridicaVO.IdFornecedor == null)
				RegisterCriticalMessageRequiredField("IdFornecedor");
			if (string.IsNullOrEmpty(pessoaJuridicaVO.CNPJ))
				RegisterCriticalMessageRequiredField("CNPJ");
			if (string.IsNullOrEmpty(pessoaJuridicaVO.RazaoSocial))
				RegisterCriticalMessageRequiredField("RazaoSocial");
			if (string.IsNullOrEmpty(pessoaJuridicaVO.Site))
				RegisterCriticalMessageRequiredField("Site");
			if (string.IsNullOrEmpty(pessoaJuridicaVO.Responsavel))
				RegisterCriticalMessageRequiredField("Responsavel");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(PessoaJuridicaVO pessoaJuridicaVO)
		{
			ValidateRequiredAttributes(pessoaJuridicaVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaInsert");
			db.AddInParameter(command, "@IdPessoaJuridica", DbType.Int32, pessoaJuridicaVO.IdPessoaJuridica);
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, pessoaJuridicaVO.IdFornecedor);
			db.AddInParameter(command, "@CNPJ", DbType.AnsiString, pessoaJuridicaVO.CNPJ);
			db.AddInParameter(command, "@RazaoSocial", DbType.AnsiString, pessoaJuridicaVO.RazaoSocial);
			db.AddInParameter(command, "@Site", DbType.AnsiString, pessoaJuridicaVO.Site);
			db.AddInParameter(command, "@Responsavel", DbType.AnsiString, pessoaJuridicaVO.Responsavel);
			db.ExecuteNonQuery(command);
		}
		public void Update(PessoaJuridicaVO pessoaJuridicaVO)
		{
			ValidateRequiredAttributes(pessoaJuridicaVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaUpdate");
			db.AddInParameter(command, "@IdPessoaJuridica", DbType.Int32, pessoaJuridicaVO.IdPessoaJuridica);
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, pessoaJuridicaVO.IdFornecedor);
			db.AddInParameter(command, "@CNPJ", DbType.AnsiString, pessoaJuridicaVO.CNPJ);
			db.AddInParameter(command, "@RazaoSocial", DbType.AnsiString, pessoaJuridicaVO.RazaoSocial);
			db.AddInParameter(command, "@Site", DbType.AnsiString, pessoaJuridicaVO.Site);
			db.AddInParameter(command, "@Responsavel", DbType.AnsiString, pessoaJuridicaVO.Responsavel);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idPessoaJuridica)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaDelete");
			db.AddInParameter(command, "@IdPessoaJuridica", DbType.Int32, idPessoaJuridica);
			db.ExecuteNonQuery(command);
		}
		public PessoaJuridicaVO Get(int idPessoaJuridica)
		{
			PessoaJuridicaVO pessoaJuridicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaSelect");
			db.AddInParameter(command, "@IdPessoaJuridica", DbType.Int32, idPessoaJuridica);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					pessoaJuridicaVO = new PessoaJuridicaVO();
					pessoaJuridicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaJuridica")))
						pessoaJuridicaVO.IdPessoaJuridica = reader.GetInt32(reader.GetOrdinal("IdPessoaJuridica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaJuridicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CNPJ")))
						pessoaJuridicaVO.CNPJ = reader.GetString(reader.GetOrdinal("CNPJ")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("RazaoSocial")))
						pessoaJuridicaVO.RazaoSocial = reader.GetString(reader.GetOrdinal("RazaoSocial")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Site")))
						pessoaJuridicaVO.Site = reader.GetString(reader.GetOrdinal("Site")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Responsavel")))
						pessoaJuridicaVO.Responsavel = reader.GetString(reader.GetOrdinal("Responsavel")).Trim();
				}
			}

			return pessoaJuridicaVO;
		}
		public PessoaJuridicaVOCollection GetAll()
		{
			PessoaJuridicaVOCollection listaPessoaJuridicaVO = new PessoaJuridicaVOCollection();
			PessoaJuridicaVO pessoaJuridicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaJuridicaVO = new PessoaJuridicaVO();
					pessoaJuridicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaJuridica")))
						pessoaJuridicaVO.IdPessoaJuridica = reader.GetInt32(reader.GetOrdinal("IdPessoaJuridica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaJuridicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CNPJ")))
						pessoaJuridicaVO.CNPJ = reader.GetString(reader.GetOrdinal("CNPJ")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("RazaoSocial")))
						pessoaJuridicaVO.RazaoSocial = reader.GetString(reader.GetOrdinal("RazaoSocial")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Site")))
						pessoaJuridicaVO.Site = reader.GetString(reader.GetOrdinal("Site")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Responsavel")))
						pessoaJuridicaVO.Responsavel = reader.GetString(reader.GetOrdinal("Responsavel")).Trim();
					listaPessoaJuridicaVO.Add(pessoaJuridicaVO);
				}
			}

			return listaPessoaJuridicaVO;
		}
		public PessoaJuridicaVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			PessoaJuridicaVOCollection listaPessoaJuridicaVO = new PessoaJuridicaVOCollection();
			PessoaJuridicaVO pessoaJuridicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaPessoaJuridicaVO.Count == 0) listaPessoaJuridicaVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					pessoaJuridicaVO = new PessoaJuridicaVO();
					pessoaJuridicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaJuridica")))
						pessoaJuridicaVO.IdPessoaJuridica = reader.GetInt32(reader.GetOrdinal("IdPessoaJuridica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaJuridicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CNPJ")))
						pessoaJuridicaVO.CNPJ = reader.GetString(reader.GetOrdinal("CNPJ")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("RazaoSocial")))
						pessoaJuridicaVO.RazaoSocial = reader.GetString(reader.GetOrdinal("RazaoSocial")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Site")))
						pessoaJuridicaVO.Site = reader.GetString(reader.GetOrdinal("Site")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Responsavel")))
						pessoaJuridicaVO.Responsavel = reader.GetString(reader.GetOrdinal("Responsavel")).Trim();
					listaPessoaJuridicaVO.Add(pessoaJuridicaVO);
				}
			}

			listaPessoaJuridicaVO.PageSize = maximumRows;

			return listaPessoaJuridicaVO;
		}
		public PessoaJuridicaVOCollection GetByFornecedores(int idFornecedor)
		{
			PessoaJuridicaVOCollection listaPessoaJuridicaVO = new PessoaJuridicaVOCollection();
			PessoaJuridicaVO pessoaJuridicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaJuridicaSelectByFornecedores");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, idFornecedor);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaJuridicaVO = new PessoaJuridicaVO();
					pessoaJuridicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaJuridica")))
						pessoaJuridicaVO.IdPessoaJuridica = reader.GetInt32(reader.GetOrdinal("IdPessoaJuridica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaJuridicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CNPJ")))
						pessoaJuridicaVO.CNPJ = reader.GetString(reader.GetOrdinal("CNPJ")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("RazaoSocial")))
						pessoaJuridicaVO.RazaoSocial = reader.GetString(reader.GetOrdinal("RazaoSocial")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Site")))
						pessoaJuridicaVO.Site = reader.GetString(reader.GetOrdinal("Site")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Responsavel")))
						pessoaJuridicaVO.Responsavel = reader.GetString(reader.GetOrdinal("Responsavel")).Trim();
					listaPessoaJuridicaVO.Add(pessoaJuridicaVO);
				}
			}

			return listaPessoaJuridicaVO;
		}

		#endregion
	}
}
