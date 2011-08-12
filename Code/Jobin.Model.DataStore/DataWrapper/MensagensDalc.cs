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
	public partial class MensagensDalc : IMensagensDalc
	{
		private Database db;

		public MensagensDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IMensagensDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(MensagensVO mensagensVO, bool validateGuidOnPK)
		{
			if (mensagensVO.IdMensagem == null)
				RegisterCriticalMessageRequiredField("IdMensagem");
			if (string.IsNullOrEmpty(mensagensVO.Mensagem))
				RegisterCriticalMessageRequiredField("Mensagem");
			if (mensagensVO.IdUsuarioOrigem == null)
				RegisterCriticalMessageRequiredField("IdUsuarioOrigem");
			if (mensagensVO.IdUsuarioDestino == null)
				RegisterCriticalMessageRequiredField("IdUsuarioDestino");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(MensagensVO mensagensVO)
		{
			ValidateRequiredAttributes(mensagensVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensInsert");
			db.AddInParameter(command, "@IdMensagem", DbType.Int32, mensagensVO.IdMensagem);
			db.AddInParameter(command, "@Mensagem", DbType.AnsiString, mensagensVO.Mensagem);
			db.AddInParameter(command, "@IdUsuarioOrigem", DbType.Int32, mensagensVO.IdUsuarioOrigem);
			db.AddInParameter(command, "@IdUsuarioDestino", DbType.Int32, mensagensVO.IdUsuarioDestino);
			db.ExecuteNonQuery(command);
		}
		public void Update(MensagensVO mensagensVO)
		{
			ValidateRequiredAttributes(mensagensVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensUpdate");
			db.AddInParameter(command, "@IdMensagem", DbType.Int32, mensagensVO.IdMensagem);
			db.AddInParameter(command, "@Mensagem", DbType.AnsiString, mensagensVO.Mensagem);
			db.AddInParameter(command, "@IdUsuarioOrigem", DbType.Int32, mensagensVO.IdUsuarioOrigem);
			db.AddInParameter(command, "@IdUsuarioDestino", DbType.Int32, mensagensVO.IdUsuarioDestino);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idMensagem)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensDelete");
			db.AddInParameter(command, "@IdMensagem", DbType.Int32, idMensagem);
			db.ExecuteNonQuery(command);
		}
		public MensagensVO Get(int idMensagem)
		{
			MensagensVO mensagensVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensSelect");
			db.AddInParameter(command, "@IdMensagem", DbType.Int32, idMensagem);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					mensagensVO = new MensagensVO();
					mensagensVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						mensagensVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("Mensagem")))
						mensagensVO.Mensagem = reader.GetString(reader.GetOrdinal("Mensagem")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioOrigem")))
						mensagensVO.IdUsuarioOrigem = reader.GetInt32(reader.GetOrdinal("IdUsuarioOrigem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioDestino")))
						mensagensVO.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("IdUsuarioDestino"));
				}
			}

			return mensagensVO;
		}
		public MensagensVOCollection GetAll()
		{
			MensagensVOCollection listaMensagensVO = new MensagensVOCollection();
			MensagensVO mensagensVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					mensagensVO = new MensagensVO();
					mensagensVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						mensagensVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("Mensagem")))
						mensagensVO.Mensagem = reader.GetString(reader.GetOrdinal("Mensagem")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioOrigem")))
						mensagensVO.IdUsuarioOrigem = reader.GetInt32(reader.GetOrdinal("IdUsuarioOrigem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioDestino")))
						mensagensVO.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("IdUsuarioDestino"));
					listaMensagensVO.Add(mensagensVO);
				}
			}

			return listaMensagensVO;
		}
		public MensagensVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			MensagensVOCollection listaMensagensVO = new MensagensVOCollection();
			MensagensVO mensagensVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaMensagensVO.Count == 0) listaMensagensVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					mensagensVO = new MensagensVO();
					mensagensVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						mensagensVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("Mensagem")))
						mensagensVO.Mensagem = reader.GetString(reader.GetOrdinal("Mensagem")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioOrigem")))
						mensagensVO.IdUsuarioOrigem = reader.GetInt32(reader.GetOrdinal("IdUsuarioOrigem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioDestino")))
						mensagensVO.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("IdUsuarioDestino"));
					listaMensagensVO.Add(mensagensVO);
				}
			}

			listaMensagensVO.PageSize = maximumRows;

			return listaMensagensVO;
		}
		public MensagensVOCollection GetByOportunidades(int idUsuarioDestino)
		{
			MensagensVOCollection listaMensagensVO = new MensagensVOCollection();
			MensagensVO mensagensVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensSelectByOportunidades");
			db.AddInParameter(command, "@IdUsuarioDestino", DbType.Int32, idUsuarioDestino);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					mensagensVO = new MensagensVO();
					mensagensVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						mensagensVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("Mensagem")))
						mensagensVO.Mensagem = reader.GetString(reader.GetOrdinal("Mensagem")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioOrigem")))
						mensagensVO.IdUsuarioOrigem = reader.GetInt32(reader.GetOrdinal("IdUsuarioOrigem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioDestino")))
						mensagensVO.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("IdUsuarioDestino"));
					listaMensagensVO.Add(mensagensVO);
				}
			}

			return listaMensagensVO;
		}
		public MensagensVOCollection GetByUsuarios(int idUsuarioOrigem)
		{
			MensagensVOCollection listaMensagensVO = new MensagensVOCollection();
			MensagensVO mensagensVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_MensagensSelectByUsuarios");
			db.AddInParameter(command, "@IdUsuarioOrigem", DbType.Int32, idUsuarioOrigem);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					mensagensVO = new MensagensVO();
					mensagensVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						mensagensVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("Mensagem")))
						mensagensVO.Mensagem = reader.GetString(reader.GetOrdinal("Mensagem")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioOrigem")))
						mensagensVO.IdUsuarioOrigem = reader.GetInt32(reader.GetOrdinal("IdUsuarioOrigem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuarioDestino")))
						mensagensVO.IdUsuarioDestino = reader.GetInt32(reader.GetOrdinal("IdUsuarioDestino"));
					listaMensagensVO.Add(mensagensVO);
				}
			}

			return listaMensagensVO;
		}

		#endregion
	}
}
