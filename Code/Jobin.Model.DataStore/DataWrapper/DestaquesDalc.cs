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
	public partial class DestaquesDalc : IDestaquesDalc
	{
		private Database db;

		public DestaquesDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IDestaquesDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(DestaquesVO destaquesVO, bool validateGuidOnPK)
		{
			if (destaquesVO.IdDestaque == null)
				RegisterCriticalMessageRequiredField("IdDestaque");
			if (string.IsNullOrEmpty(destaquesVO.Destaque))
				RegisterCriticalMessageRequiredField("Destaque");
			if (string.IsNullOrEmpty(destaquesVO.DescricaoSimples))
				RegisterCriticalMessageRequiredField("DescricaoSimples");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(DestaquesVO destaquesVO)
		{
			ValidateRequiredAttributes(destaquesVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesInsert");
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, destaquesVO.IdDestaque);
			db.AddInParameter(command, "@Destaque", DbType.AnsiString, destaquesVO.Destaque);
			db.AddInParameter(command, "@DescricaoSimples", DbType.AnsiString, destaquesVO.DescricaoSimples);

			if (destaquesVO.DescricaoComplexa != null)
				db.AddInParameter(command, "@DescricaoComplexa", DbType.AnsiString, destaquesVO.DescricaoComplexa);
			else
				db.AddInParameter(command, "@DescricaoComplexa", DbType.AnsiString, DBNull.Value);

			db.ExecuteNonQuery(command);
		}
		public void Update(DestaquesVO destaquesVO)
		{
			ValidateRequiredAttributes(destaquesVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesUpdate");
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, destaquesVO.IdDestaque);
			db.AddInParameter(command, "@Destaque", DbType.AnsiString, destaquesVO.Destaque);
			db.AddInParameter(command, "@DescricaoSimples", DbType.AnsiString, destaquesVO.DescricaoSimples);
			if (destaquesVO.DescricaoComplexa != null)
				db.AddInParameter(command, "@DescricaoComplexa", DbType.AnsiString, destaquesVO.DescricaoComplexa);
			else
				db.AddInParameter(command, "@DescricaoComplexa", DbType.AnsiString, DBNull.Value);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idDestaque)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesDelete");
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, idDestaque);
			db.ExecuteNonQuery(command);
		}
		public DestaquesVO Get(int idDestaque)
		{
			DestaquesVO destaquesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesSelect");
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, idDestaque);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					destaquesVO = new DestaquesVO();
					destaquesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						destaquesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("Destaque")))
						destaquesVO.Destaque = reader.GetString(reader.GetOrdinal("Destaque")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoSimples")))
						destaquesVO.DescricaoSimples = reader.GetString(reader.GetOrdinal("DescricaoSimples")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoComplexa")))
						destaquesVO.DescricaoComplexa = reader.GetString(reader.GetOrdinal("DescricaoComplexa")).Trim();
				}
			}

			return destaquesVO;
		}
		public DestaquesVOCollection GetAll()
		{
			DestaquesVOCollection listaDestaquesVO = new DestaquesVOCollection();
			DestaquesVO destaquesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					destaquesVO = new DestaquesVO();
					destaquesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						destaquesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("Destaque")))
						destaquesVO.Destaque = reader.GetString(reader.GetOrdinal("Destaque")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoSimples")))
						destaquesVO.DescricaoSimples = reader.GetString(reader.GetOrdinal("DescricaoSimples")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoComplexa")))
						destaquesVO.DescricaoComplexa = reader.GetString(reader.GetOrdinal("DescricaoComplexa")).Trim();
					listaDestaquesVO.Add(destaquesVO);
				}
			}

			return listaDestaquesVO;
		}
		public DestaquesVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			DestaquesVOCollection listaDestaquesVO = new DestaquesVOCollection();
			DestaquesVO destaquesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_DestaquesSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaDestaquesVO.Count == 0) listaDestaquesVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					destaquesVO = new DestaquesVO();
					destaquesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						destaquesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("Destaque")))
						destaquesVO.Destaque = reader.GetString(reader.GetOrdinal("Destaque")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoSimples")))
						destaquesVO.DescricaoSimples = reader.GetString(reader.GetOrdinal("DescricaoSimples")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("DescricaoComplexa")))
						destaquesVO.DescricaoComplexa = reader.GetString(reader.GetOrdinal("DescricaoComplexa")).Trim();
					listaDestaquesVO.Add(destaquesVO);
				}
			}

			listaDestaquesVO.PageSize = maximumRows;

			return listaDestaquesVO;
		}

		#endregion
	}
}
