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
	public partial class PessoaFisicaDalc : IPessoaFisicaDalc
	{
		private Database db;

		public PessoaFisicaDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IPessoaFisicaDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(PessoaFisicaVO pessoaFisicaVO, bool validateGuidOnPK)
		{
			if (pessoaFisicaVO.IdPessoaFisica == null)
				RegisterCriticalMessageRequiredField("IdPessoaFisica");
			if (pessoaFisicaVO.IdFornecedor == null)
				RegisterCriticalMessageRequiredField("IdFornecedor");
			if (string.IsNullOrEmpty(pessoaFisicaVO.CPF))
				RegisterCriticalMessageRequiredField("CPF");
			if (pessoaFisicaVO.IdFormacao == null)
				RegisterCriticalMessageRequiredField("IdFormacao");
			if (pessoaFisicaVO.IdExperiencia == null)
				RegisterCriticalMessageRequiredField("IdExperiencia");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(PessoaFisicaVO pessoaFisicaVO)
		{
			ValidateRequiredAttributes(pessoaFisicaVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaInsert");
			db.AddInParameter(command, "@IdPessoaFisica", DbType.Int32, pessoaFisicaVO.IdPessoaFisica);
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, pessoaFisicaVO.IdFornecedor);
			db.AddInParameter(command, "@CPF", DbType.AnsiString, pessoaFisicaVO.CPF);
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, pessoaFisicaVO.IdFormacao);
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, pessoaFisicaVO.IdExperiencia);
			db.ExecuteNonQuery(command);
		}
		public void Update(PessoaFisicaVO pessoaFisicaVO)
		{
			ValidateRequiredAttributes(pessoaFisicaVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaUpdate");
			db.AddInParameter(command, "@IdPessoaFisica", DbType.Int32, pessoaFisicaVO.IdPessoaFisica);
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, pessoaFisicaVO.IdFornecedor);
			db.AddInParameter(command, "@CPF", DbType.AnsiString, pessoaFisicaVO.CPF);
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, pessoaFisicaVO.IdFormacao);
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, pessoaFisicaVO.IdExperiencia);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idPessoaFisica)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaDelete");
			db.AddInParameter(command, "@IdPessoaFisica", DbType.Int32, idPessoaFisica);
			db.ExecuteNonQuery(command);
		}
		public PessoaFisicaVO Get(int idPessoaFisica)
		{
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelect");
			db.AddInParameter(command, "@IdPessoaFisica", DbType.Int32, idPessoaFisica);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
				}
			}

			return pessoaFisicaVO;
		}
		public PessoaFisicaVOCollection GetAll()
		{
			PessoaFisicaVOCollection listaPessoaFisicaVO = new PessoaFisicaVOCollection();
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					listaPessoaFisicaVO.Add(pessoaFisicaVO);
				}
			}

			return listaPessoaFisicaVO;
		}
		public PessoaFisicaVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			PessoaFisicaVOCollection listaPessoaFisicaVO = new PessoaFisicaVOCollection();
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaPessoaFisicaVO.Count == 0) listaPessoaFisicaVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					listaPessoaFisicaVO.Add(pessoaFisicaVO);
				}
			}

			listaPessoaFisicaVO.PageSize = maximumRows;

			return listaPessoaFisicaVO;
		}
		public PessoaFisicaVOCollection GetByExperiencia(int idExperiencia)
		{
			PessoaFisicaVOCollection listaPessoaFisicaVO = new PessoaFisicaVOCollection();
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelectByExperiencia");
			db.AddInParameter(command, "@IdExperiencia", DbType.Int32, idExperiencia);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					listaPessoaFisicaVO.Add(pessoaFisicaVO);
				}
			}

			return listaPessoaFisicaVO;
		}
		public PessoaFisicaVOCollection GetByFormacoes(int idFormacao)
		{
			PessoaFisicaVOCollection listaPessoaFisicaVO = new PessoaFisicaVOCollection();
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelectByFormacoes");
			db.AddInParameter(command, "@IdFormacao", DbType.Int32, idFormacao);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					listaPessoaFisicaVO.Add(pessoaFisicaVO);
				}
			}

			return listaPessoaFisicaVO;
		}
		public PessoaFisicaVOCollection GetByFornecedores(int idFornecedor)
		{
			PessoaFisicaVOCollection listaPessoaFisicaVO = new PessoaFisicaVOCollection();
			PessoaFisicaVO pessoaFisicaVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_PessoaFisicaSelectByFornecedores");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, idFornecedor);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					pessoaFisicaVO = new PessoaFisicaVO();
					pessoaFisicaVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdPessoaFisica")))
						pessoaFisicaVO.IdPessoaFisica = reader.GetInt32(reader.GetOrdinal("IdPessoaFisica"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						pessoaFisicaVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("CPF")))
						pessoaFisicaVO.CPF = reader.GetString(reader.GetOrdinal("CPF")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdFormacao")))
						pessoaFisicaVO.IdFormacao = reader.GetInt32(reader.GetOrdinal("IdFormacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdExperiencia")))
						pessoaFisicaVO.IdExperiencia = reader.GetInt32(reader.GetOrdinal("IdExperiencia"));
					listaPessoaFisicaVO.Add(pessoaFisicaVO);
				}
			}

			return listaPessoaFisicaVO;
		}

		#endregion
	}
}
