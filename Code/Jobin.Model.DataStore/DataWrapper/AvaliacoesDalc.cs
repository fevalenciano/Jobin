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
	public partial class AvaliacoesDalc : IAvaliacoesDalc
	{
		private Database db;

		public AvaliacoesDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IAvaliacoesDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(AvaliacoesVO avaliacoesVO, bool validateGuidOnPK)
		{
			if (avaliacoesVO.IdAvaliacao == null)
				RegisterCriticalMessageRequiredField("IdAvaliacao");
			if (avaliacoesVO.IdUsuario == null)
				RegisterCriticalMessageRequiredField("IdUsuario");
			if (avaliacoesVO.TipoAvaliacao == null)
				RegisterCriticalMessageRequiredField("TipoAvaliacao");
			if (avaliacoesVO.DataAvaliacao == null)
				RegisterCriticalMessageRequiredField("DataAvaliacao");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(AvaliacoesVO avaliacoesVO)
		{
			ValidateRequiredAttributes(avaliacoesVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesInsert");
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, avaliacoesVO.IdAvaliacao);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, avaliacoesVO.IdUsuario);
			db.AddInParameter(command, "@TipoAvaliacao", DbType.Boolean, avaliacoesVO.TipoAvaliacao);
			db.AddInParameter(command, "@DataAvaliacao", DbType.DateTime, avaliacoesVO.DataAvaliacao);
			db.ExecuteNonQuery(command);
		}
		public void Update(AvaliacoesVO avaliacoesVO)
		{
			ValidateRequiredAttributes(avaliacoesVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesUpdate");
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, avaliacoesVO.IdAvaliacao);
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, avaliacoesVO.IdUsuario);
			db.AddInParameter(command, "@TipoAvaliacao", DbType.Boolean, avaliacoesVO.TipoAvaliacao);
			db.AddInParameter(command, "@DataAvaliacao", DbType.DateTime, avaliacoesVO.DataAvaliacao);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idAvaliacao)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesDelete");
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, idAvaliacao);
			db.ExecuteNonQuery(command);
		}
		public AvaliacoesVO Get(int idAvaliacao)
		{
			AvaliacoesVO avaliacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesSelect");
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, idAvaliacao);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					avaliacoesVO = new AvaliacoesVO();
					avaliacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						avaliacoesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						avaliacoesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("TipoAvaliacao")))
						avaliacoesVO.TipoAvaliacao = reader.GetBoolean(reader.GetOrdinal("TipoAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAvaliacao")))
						avaliacoesVO.DataAvaliacao = reader.GetDateTime(reader.GetOrdinal("DataAvaliacao"));
				}
			}

			return avaliacoesVO;
		}
		public AvaliacoesVOCollection GetAll()
		{
			AvaliacoesVOCollection listaAvaliacoesVO = new AvaliacoesVOCollection();
			AvaliacoesVO avaliacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					avaliacoesVO = new AvaliacoesVO();
					avaliacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						avaliacoesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						avaliacoesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("TipoAvaliacao")))
						avaliacoesVO.TipoAvaliacao = reader.GetBoolean(reader.GetOrdinal("TipoAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAvaliacao")))
						avaliacoesVO.DataAvaliacao = reader.GetDateTime(reader.GetOrdinal("DataAvaliacao"));
					listaAvaliacoesVO.Add(avaliacoesVO);
				}
			}

			return listaAvaliacoesVO;
		}
		public AvaliacoesVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			AvaliacoesVOCollection listaAvaliacoesVO = new AvaliacoesVOCollection();
			AvaliacoesVO avaliacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaAvaliacoesVO.Count == 0) listaAvaliacoesVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					avaliacoesVO = new AvaliacoesVO();
					avaliacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						avaliacoesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						avaliacoesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("TipoAvaliacao")))
						avaliacoesVO.TipoAvaliacao = reader.GetBoolean(reader.GetOrdinal("TipoAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAvaliacao")))
						avaliacoesVO.DataAvaliacao = reader.GetDateTime(reader.GetOrdinal("DataAvaliacao"));
					listaAvaliacoesVO.Add(avaliacoesVO);
				}
			}

			listaAvaliacoesVO.PageSize = maximumRows;

			return listaAvaliacoesVO;
		}
		public AvaliacoesVOCollection GetByUsuarios(int idUsuario)
		{
			AvaliacoesVOCollection listaAvaliacoesVO = new AvaliacoesVOCollection();
			AvaliacoesVO avaliacoesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_AvaliacoesSelectByUsuarios");
			db.AddInParameter(command, "@IdUsuario", DbType.Int32, idUsuario);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					avaliacoesVO = new AvaliacoesVO();
					avaliacoesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						avaliacoesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdUsuario")))
						avaliacoesVO.IdUsuario = reader.GetInt32(reader.GetOrdinal("IdUsuario"));
					if (!reader.IsDBNull(reader.GetOrdinal("TipoAvaliacao")))
						avaliacoesVO.TipoAvaliacao = reader.GetBoolean(reader.GetOrdinal("TipoAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("DataAvaliacao")))
						avaliacoesVO.DataAvaliacao = reader.GetDateTime(reader.GetOrdinal("DataAvaliacao"));
					listaAvaliacoesVO.Add(avaliacoesVO);
				}
			}

			return listaAvaliacoesVO;
		}

		#endregion
	}
}
