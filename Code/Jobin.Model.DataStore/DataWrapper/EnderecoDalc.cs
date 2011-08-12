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
	public partial class EnderecoDalc : IEnderecoDalc
	{
		private Database db;

		public EnderecoDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IEnderecoDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(EnderecoVO enderecoVO, bool validateGuidOnPK)
		{
			if (enderecoVO.IdEndereco == null)
				RegisterCriticalMessageRequiredField("IdEndereco");
			if (string.IsNullOrEmpty(enderecoVO.Logradouro))
				RegisterCriticalMessageRequiredField("Logradouro");
			if (string.IsNullOrEmpty(enderecoVO.Numero))
				RegisterCriticalMessageRequiredField("Numero");
			if (string.IsNullOrEmpty(enderecoVO.Estado))
				RegisterCriticalMessageRequiredField("Estado");
			if (string.IsNullOrEmpty(enderecoVO.Cidade))
				RegisterCriticalMessageRequiredField("Cidade");
			if (string.IsNullOrEmpty(enderecoVO.CEP))
				RegisterCriticalMessageRequiredField("CEP");
			if (string.IsNullOrEmpty(enderecoVO.Bairro))
				RegisterCriticalMessageRequiredField("Bairro");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(EnderecoVO enderecoVO)
		{
			ValidateRequiredAttributes(enderecoVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoInsert");
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, enderecoVO.IdEndereco);
			db.AddInParameter(command, "@Logradouro", DbType.AnsiString, enderecoVO.Logradouro);

			if (enderecoVO.Complemento != null)
				db.AddInParameter(command, "@Complemento", DbType.AnsiString, enderecoVO.Complemento);
			else
				db.AddInParameter(command, "@Complemento", DbType.AnsiString, DBNull.Value);

			db.AddInParameter(command, "@Numero", DbType.AnsiString, enderecoVO.Numero);
			db.AddInParameter(command, "@Estado", DbType.AnsiString, enderecoVO.Estado);
			db.AddInParameter(command, "@Cidade", DbType.AnsiString, enderecoVO.Cidade);
			db.AddInParameter(command, "@CEP", DbType.AnsiString, enderecoVO.CEP);
			db.AddInParameter(command, "@Bairro", DbType.AnsiString, enderecoVO.Bairro);
			db.ExecuteNonQuery(command);
		}
		public void Update(EnderecoVO enderecoVO)
		{
			ValidateRequiredAttributes(enderecoVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoUpdate");
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, enderecoVO.IdEndereco);
			db.AddInParameter(command, "@Logradouro", DbType.AnsiString, enderecoVO.Logradouro);
			if (enderecoVO.Complemento != null)
				db.AddInParameter(command, "@Complemento", DbType.AnsiString, enderecoVO.Complemento);
			else
				db.AddInParameter(command, "@Complemento", DbType.AnsiString, DBNull.Value);
			db.AddInParameter(command, "@Numero", DbType.AnsiString, enderecoVO.Numero);
			db.AddInParameter(command, "@Estado", DbType.AnsiString, enderecoVO.Estado);
			db.AddInParameter(command, "@Cidade", DbType.AnsiString, enderecoVO.Cidade);
			db.AddInParameter(command, "@CEP", DbType.AnsiString, enderecoVO.CEP);
			db.AddInParameter(command, "@Bairro", DbType.AnsiString, enderecoVO.Bairro);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idEndereco)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoDelete");
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, idEndereco);
			db.ExecuteNonQuery(command);
		}
		public EnderecoVO Get(int idEndereco)
		{
			EnderecoVO enderecoVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoSelect");
			db.AddInParameter(command, "@IdEndereco", DbType.Int32, idEndereco);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					enderecoVO = new EnderecoVO();
					enderecoVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						enderecoVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					if (!reader.IsDBNull(reader.GetOrdinal("Logradouro")))
						enderecoVO.Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Complemento")))
						enderecoVO.Complemento = reader.GetString(reader.GetOrdinal("Complemento")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
						enderecoVO.Numero = reader.GetString(reader.GetOrdinal("Numero")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Estado")))
						enderecoVO.Estado = reader.GetString(reader.GetOrdinal("Estado")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Cidade")))
						enderecoVO.Cidade = reader.GetString(reader.GetOrdinal("Cidade")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("CEP")))
						enderecoVO.CEP = reader.GetString(reader.GetOrdinal("CEP")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
						enderecoVO.Bairro = reader.GetString(reader.GetOrdinal("Bairro")).Trim();
				}
			}

			return enderecoVO;
		}
		public EnderecoVOCollection GetAll()
		{
			EnderecoVOCollection listaEnderecoVO = new EnderecoVOCollection();
			EnderecoVO enderecoVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					enderecoVO = new EnderecoVO();
					enderecoVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						enderecoVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					if (!reader.IsDBNull(reader.GetOrdinal("Logradouro")))
						enderecoVO.Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Complemento")))
						enderecoVO.Complemento = reader.GetString(reader.GetOrdinal("Complemento")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
						enderecoVO.Numero = reader.GetString(reader.GetOrdinal("Numero")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Estado")))
						enderecoVO.Estado = reader.GetString(reader.GetOrdinal("Estado")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Cidade")))
						enderecoVO.Cidade = reader.GetString(reader.GetOrdinal("Cidade")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("CEP")))
						enderecoVO.CEP = reader.GetString(reader.GetOrdinal("CEP")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
						enderecoVO.Bairro = reader.GetString(reader.GetOrdinal("Bairro")).Trim();
					listaEnderecoVO.Add(enderecoVO);
				}
			}

			return listaEnderecoVO;
		}
		public EnderecoVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			EnderecoVOCollection listaEnderecoVO = new EnderecoVOCollection();
			EnderecoVO enderecoVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_EnderecoSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaEnderecoVO.Count == 0) listaEnderecoVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					enderecoVO = new EnderecoVO();
					enderecoVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdEndereco")))
						enderecoVO.IdEndereco = reader.GetInt32(reader.GetOrdinal("IdEndereco"));
					if (!reader.IsDBNull(reader.GetOrdinal("Logradouro")))
						enderecoVO.Logradouro = reader.GetString(reader.GetOrdinal("Logradouro")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Complemento")))
						enderecoVO.Complemento = reader.GetString(reader.GetOrdinal("Complemento")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Numero")))
						enderecoVO.Numero = reader.GetString(reader.GetOrdinal("Numero")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Estado")))
						enderecoVO.Estado = reader.GetString(reader.GetOrdinal("Estado")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Cidade")))
						enderecoVO.Cidade = reader.GetString(reader.GetOrdinal("Cidade")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("CEP")))
						enderecoVO.CEP = reader.GetString(reader.GetOrdinal("CEP")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Bairro")))
						enderecoVO.Bairro = reader.GetString(reader.GetOrdinal("Bairro")).Trim();
					listaEnderecoVO.Add(enderecoVO);
				}
			}

			listaEnderecoVO.PageSize = maximumRows;

			return listaEnderecoVO;
		}

		#endregion
	}
}
