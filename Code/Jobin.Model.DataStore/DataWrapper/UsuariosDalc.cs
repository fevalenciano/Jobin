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
	public partial class UsuariosDalc : IUsuariosDalc
	{
		private Database db;

		public UsuariosDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IUsuariosDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(UsuariosVO usuariosVO, bool validateGuidOnPK)
		{
			if (usuariosVO.IdUsuario == null && (validateGuidOnPK))
				RegisterCriticalMessageRequiredField("IdUsuario");
			if (string.IsNullOrEmpty(usuariosVO.Email))
				RegisterCriticalMessageRequiredField("Email");
			if (string.IsNullOrEmpty(usuariosVO.Senha))
				RegisterCriticalMessageRequiredField("Senha");
			if (usuariosVO.DataInclusao == null)
				RegisterCriticalMessageRequiredField("DataInclusao");
			if (string.IsNullOrEmpty(usuariosVO.Nome))
				RegisterCriticalMessageRequiredField("Nome");
			if (string.IsNullOrEmpty(usuariosVO.Sobrenome))
				RegisterCriticalMessageRequiredField("Sobrenome");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public UsuariosVO Insert(UsuariosVO usuariosVO)
		{
			ValidateRequiredAttributes(usuariosVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosInsert");
			db.AddInParameter(command, "@Email", DbType.AnsiString, usuariosVO.Email);
			db.AddInParameter(command, "@Senha", DbType.AnsiString, usuariosVO.Senha);
			db.AddInParameter(command, "@DataInclusao", DbType.DateTime, usuariosVO.DataInclusao);

			if (usuariosVO.DataAlteracao != null)
				db.AddInParameter(command, "@DataAlteracao", DbType.DateTime, usuariosVO.DataAlteracao);
			else
				db.AddInParameter(command, "@DataAlteracao", DbType.DateTime, DBNull.Value);

			db.AddInParameter(command, "@Nome", DbType.AnsiString, usuariosVO.Nome);
			db.AddInParameter(command, "@Sobrenome", DbType.AnsiString, usuariosVO.Sobrenome);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					usuariosVO.IdUsuario = Int32.Parse(reader["uniqueIdUsuario"].ToString());
				}
			}

			return usuariosVO;
		}
		public void Update(UsuariosVO usuariosVO)
		{
			ValidateRequiredAttributes(usuariosVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosUpdate");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, usuariosVO.IdUsuario);
			db.AddInParameter(command, "@Email", DbType.AnsiString, usuariosVO.Email);
			db.AddInParameter(command, "@Senha", DbType.AnsiString, usuariosVO.Senha);
			db.AddInParameter(command, "@DataInclusao", DbType.DateTime, usuariosVO.DataInclusao);
			if (usuariosVO.DataAlteracao != null)
				db.AddInParameter(command, "@DataAlteracao", DbType.DateTime, usuariosVO.DataAlteracao);
			else
				db.AddInParameter(command, "@DataAlteracao", DbType.DateTime, DBNull.Value);
			db.AddInParameter(command, "@Nome", DbType.AnsiString, usuariosVO.Nome);
			db.AddInParameter(command, "@Sobrenome", DbType.AnsiString, usuariosVO.Sobrenome);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idUsuario)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosDelete");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);
			db.ExecuteNonQuery(command);
		}
		public UsuariosVO Get(int idUsuario)
		{
			UsuariosVO usuariosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosSelect");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					usuariosVO = new UsuariosVO();
					usuariosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						usuariosVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Email")))
						usuariosVO.Email = reader.GetString(reader.GetOrdinal("Email")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
						usuariosVO.Senha = reader.GetString(reader.GetOrdinal("Senha")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DataInclusao")))
						usuariosVO.DataInclusao = reader.GetDateTime(reader.GetOrdinal("DataInclusao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAlteracao")))
						usuariosVO.DataAlteracao = reader.GetDateTime(reader.GetOrdinal("DataAlteracao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						usuariosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Sobrenome")))
						usuariosVO.Sobrenome = reader.GetString(reader.GetOrdinal("Sobrenome")).Trim();
				}
			}

			return usuariosVO;
		}
		public UsuariosVOCollection GetAll()
		{
			UsuariosVOCollection listaUsuariosVO = new UsuariosVOCollection();
			UsuariosVO usuariosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					usuariosVO = new UsuariosVO();
					usuariosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						usuariosVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Email")))
						usuariosVO.Email = reader.GetString(reader.GetOrdinal("Email")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
						usuariosVO.Senha = reader.GetString(reader.GetOrdinal("Senha")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DataInclusao")))
						usuariosVO.DataInclusao = reader.GetDateTime(reader.GetOrdinal("DataInclusao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAlteracao")))
						usuariosVO.DataAlteracao = reader.GetDateTime(reader.GetOrdinal("DataAlteracao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						usuariosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Sobrenome")))
						usuariosVO.Sobrenome = reader.GetString(reader.GetOrdinal("Sobrenome")).Trim();
					listaUsuariosVO.Add(usuariosVO);
				}
			}

			return listaUsuariosVO;
		}
		public UsuariosVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			UsuariosVOCollection listaUsuariosVO = new UsuariosVOCollection();
			UsuariosVO usuariosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_UsuariosSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaUsuariosVO.Count == 0) listaUsuariosVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					usuariosVO = new UsuariosVO();
					usuariosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						usuariosVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Email")))
						usuariosVO.Email = reader.GetString(reader.GetOrdinal("Email")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Senha")))
						usuariosVO.Senha = reader.GetString(reader.GetOrdinal("Senha")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DataInclusao")))
						usuariosVO.DataInclusao = reader.GetDateTime(reader.GetOrdinal("DataInclusao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAlteracao")))
						usuariosVO.DataAlteracao = reader.GetDateTime(reader.GetOrdinal("DataAlteracao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						usuariosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Sobrenome")))
						usuariosVO.Sobrenome = reader.GetString(reader.GetOrdinal("Sobrenome")).Trim();
					listaUsuariosVO.Add(usuariosVO);
				}
			}

			listaUsuariosVO.PageSize = maximumRows;

			return listaUsuariosVO;
		}

		#endregion
	}
}
