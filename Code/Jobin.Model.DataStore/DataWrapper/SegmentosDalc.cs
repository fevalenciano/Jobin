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
	public partial class SegmentosDalc : ISegmentosDalc
	{
		private Database db;

		public SegmentosDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region ISegmentosDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(SegmentosVO segmentosVO, bool validateGuidOnPK)
		{
			if (segmentosVO.IdSegmento == null)
				RegisterCriticalMessageRequiredField("IdSegmento");
			if (string.IsNullOrEmpty(segmentosVO.Nome))
				RegisterCriticalMessageRequiredField("Nome");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(SegmentosVO segmentosVO)
		{
			ValidateRequiredAttributes(segmentosVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosInsert");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, segmentosVO.IdSegmento);
			db.AddInParameter(command, "@Nome", DbType.AnsiString, segmentosVO.Nome);
			db.ExecuteNonQuery(command);
		}
		public void Update(SegmentosVO segmentosVO)
		{
			ValidateRequiredAttributes(segmentosVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosUpdate");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, segmentosVO.IdSegmento);
			db.AddInParameter(command, "@Nome", DbType.AnsiString, segmentosVO.Nome);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idSegmento)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosDelete");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, idSegmento);
			db.ExecuteNonQuery(command);
		}
		public SegmentosVO Get(int idSegmento)
		{
			SegmentosVO segmentosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosSelect");
			db.AddInParameter(command, "@IdSegmento", DbType.Int32, idSegmento);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					segmentosVO = new SegmentosVO();
					segmentosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						segmentosVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						segmentosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
				}
			}

			return segmentosVO;
		}
		public SegmentosVOCollection GetAll()
		{
			SegmentosVOCollection listaSegmentosVO = new SegmentosVOCollection();
			SegmentosVO segmentosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					segmentosVO = new SegmentosVO();
					segmentosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						segmentosVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						segmentosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					listaSegmentosVO.Add(segmentosVO);
				}
			}

			return listaSegmentosVO;
		}
		public SegmentosVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			SegmentosVOCollection listaSegmentosVO = new SegmentosVOCollection();
			SegmentosVO segmentosVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_SegmentosSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaSegmentosVO.Count == 0) listaSegmentosVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					segmentosVO = new SegmentosVO();
					segmentosVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdSegmento")))
						segmentosVO.IdSegmento = reader.GetInt32(reader.GetOrdinal("IdSegmento"));
					if (!reader.IsDBNull(reader.GetOrdinal("Nome")))
						segmentosVO.Nome = reader.GetString(reader.GetOrdinal("Nome")).Trim();
					listaSegmentosVO.Add(segmentosVO);
				}
			}

			listaSegmentosVO.PageSize = maximumRows;

			return listaSegmentosVO;
		}

		#endregion
	}
}
