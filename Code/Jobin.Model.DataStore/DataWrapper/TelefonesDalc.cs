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
	public partial class TelefonesDalc : ITelefonesDalc
	{
		private Database db;

		public TelefonesDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region ITelefonesDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(TelefonesVO telefonesVO, bool validateGuidOnPK)
		{
			if (telefonesVO.IdTelefone == null)
				RegisterCriticalMessageRequiredField("IdTelefone");
			if (telefonesVO.IdUsuario == null)
				RegisterCriticalMessageRequiredField("IdUsuario");
			if (telefonesVO.Telefone == null)
				RegisterCriticalMessageRequiredField("Telefone");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(TelefonesVO telefonesVO)
		{
			ValidateRequiredAttributes(telefonesVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesInsert");
			db.AddInParameter(command, "@IdTelefone", DbType.Int32, telefonesVO.IdTelefone);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, telefonesVO.IdUsuario);
			db.AddInParameter(command, "@Telefone", DbType.Binary, telefonesVO.Telefone);
			db.ExecuteNonQuery(command);
		}
		public void Update(TelefonesVO telefonesVO)
		{
			ValidateRequiredAttributes(telefonesVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesUpdate");
			db.AddInParameter(command, "@IdTelefone", DbType.Int32, telefonesVO.IdTelefone);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, telefonesVO.IdUsuario);
			db.AddInParameter(command, "@Telefone", DbType.Binary, telefonesVO.Telefone);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idTelefone)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesDelete");
			db.AddInParameter(command, "@IdTelefone", DbType.Int32, idTelefone);
			db.ExecuteNonQuery(command);
		}
		public TelefonesVO Get(int idTelefone)
		{
			TelefonesVO telefonesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesSelect");
			db.AddInParameter(command, "@IdTelefone", DbType.Int32, idTelefone);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					telefonesVO = new TelefonesVO();
					telefonesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdTelefone")))
						telefonesVO.IdTelefone = reader.GetInt32(reader.GetOrdinal("IdTelefone"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						telefonesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
						telefonesVO.Telefone = reader.GetString(reader.GetOrdinal("Telefone")).Trim();
				}
			}

			return telefonesVO;
		}
		public TelefonesVOCollection GetAll()
		{
			TelefonesVOCollection listaTelefonesVO = new TelefonesVOCollection();
			TelefonesVO telefonesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					telefonesVO = new TelefonesVO();
					telefonesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdTelefone")))
						telefonesVO.IdTelefone = reader.GetInt32(reader.GetOrdinal("IdTelefone"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						telefonesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                        telefonesVO.Telefone = reader.GetString(reader.GetOrdinal("Telefone")).Trim();
					listaTelefonesVO.Add(telefonesVO);
				}
			}

			return listaTelefonesVO;
		}
		public TelefonesVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			TelefonesVOCollection listaTelefonesVO = new TelefonesVOCollection();
			TelefonesVO telefonesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaTelefonesVO.Count == 0) listaTelefonesVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					telefonesVO = new TelefonesVO();
					telefonesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdTelefone")))
						telefonesVO.IdTelefone = reader.GetInt32(reader.GetOrdinal("IdTelefone"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						telefonesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                        telefonesVO.Telefone = reader.GetString(reader.GetOrdinal("Telefone")).Trim();
					listaTelefonesVO.Add(telefonesVO);
				}
			}

			listaTelefonesVO.PageSize = maximumRows;

			return listaTelefonesVO;
		}
		public TelefonesVOCollection GetByUsuarios(int idUsuario)
		{
			TelefonesVOCollection listaTelefonesVO = new TelefonesVOCollection();
			TelefonesVO telefonesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_TelefonesSelectByUsuarios");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					telefonesVO = new TelefonesVO();
					telefonesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdTelefone")))
						telefonesVO.IdTelefone = reader.GetInt32(reader.GetOrdinal("IdTelefone"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						telefonesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("Telefone")))
                        telefonesVO.Telefone = reader.GetString(reader.GetOrdinal("Telefone")).Trim();
					listaTelefonesVO.Add(telefonesVO);
				}
			}

			return listaTelefonesVO;
		}

		#endregion
	}
}
