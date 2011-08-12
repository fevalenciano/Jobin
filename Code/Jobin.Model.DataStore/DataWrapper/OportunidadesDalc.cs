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
	public partial class OportunidadesDalc : IOportunidadesDalc
	{
		private Database db;

		public OportunidadesDalc()
		{
			db = ConnectionFactory.CreateDatabase(DataBaseInformation.Name);
		}

		#region IOportunidadesDalc Members

		private ValidationException ex = null;
		private void ValidateRequiredAttributes(OportunidadesVO oportunidadesVO, bool validateGuidOnPK)
		{
			if (oportunidadesVO.IdOportunidade == null)
				RegisterCriticalMessageRequiredField("IdOportunidade");
			if (oportunidadesVO.IdCategoria == null)
				RegisterCriticalMessageRequiredField("IdCategoria");
			if (oportunidadesVO.IdFornecedor == null)
				RegisterCriticalMessageRequiredField("IdFornecedor");
			if (oportunidadesVO.IdAvaliacao == null)
				RegisterCriticalMessageRequiredField("IdAvaliacao");
			if (string.IsNullOrEmpty(oportunidadesVO.Titulo))
				RegisterCriticalMessageRequiredField("Titulo");
			if (string.IsNullOrEmpty(oportunidadesVO.Subtitulo))
				RegisterCriticalMessageRequiredField("Subtitulo");
			if (string.IsNullOrEmpty(oportunidadesVO.Descricao))
				RegisterCriticalMessageRequiredField("Descricao");
			if (oportunidadesVO.IdDestaque == null)
				RegisterCriticalMessageRequiredField("IdDestaque");
			if (string.IsNullOrEmpty(oportunidadesVO.ImagemVideo))
				RegisterCriticalMessageRequiredField("ImagemVideo");
			if (ex != null)
				throw ex;
		}
		private void RegisterCriticalMessageRequiredField(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		public void Insert(OportunidadesVO oportunidadesVO)
		{
			ValidateRequiredAttributes(oportunidadesVO, false);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesInsert");
			db.AddInParameter(command, "@IdOportunidade", DbType.Int32, oportunidadesVO.IdOportunidade);
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, oportunidadesVO.IdCategoria);

			if (oportunidadesVO.IdMensagem != null)
				db.AddInParameter(command, "@IdMensagem", DbType.Int32, oportunidadesVO.IdMensagem);
			else
				db.AddInParameter(command, "@IdMensagem", DbType.Int32, DBNull.Value);

			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, oportunidadesVO.IdFornecedor);
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, oportunidadesVO.IdAvaliacao);
			db.AddInParameter(command, "@Titulo", DbType.AnsiString, oportunidadesVO.Titulo);
			db.AddInParameter(command, "@Subtitulo", DbType.AnsiString, oportunidadesVO.Subtitulo);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, oportunidadesVO.Descricao);
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, oportunidadesVO.IdDestaque);

			if (oportunidadesVO.GoogleMaps != null)
				db.AddInParameter(command, "@GoogleMaps", DbType.AnsiString, oportunidadesVO.GoogleMaps);
			else
				db.AddInParameter(command, "@GoogleMaps", DbType.AnsiString, DBNull.Value);

			db.AddInParameter(command, "@ImagemVideo", DbType.AnsiString, oportunidadesVO.ImagemVideo);
			db.ExecuteNonQuery(command);
		}
		public void Update(OportunidadesVO oportunidadesVO)
		{
			ValidateRequiredAttributes(oportunidadesVO, true);
			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesUpdate");
			db.AddInParameter(command, "@IdOportunidade", DbType.Int32, oportunidadesVO.IdOportunidade);
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, oportunidadesVO.IdCategoria);
			if (oportunidadesVO.IdMensagem != null)
				db.AddInParameter(command, "@IdMensagem", DbType.Int32, oportunidadesVO.IdMensagem);
			else
				db.AddInParameter(command, "@IdMensagem", DbType.Int32, DBNull.Value);
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, oportunidadesVO.IdFornecedor);
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, oportunidadesVO.IdAvaliacao);
			db.AddInParameter(command, "@Titulo", DbType.AnsiString, oportunidadesVO.Titulo);
			db.AddInParameter(command, "@Subtitulo", DbType.AnsiString, oportunidadesVO.Subtitulo);
			db.AddInParameter(command, "@Descricao", DbType.AnsiString, oportunidadesVO.Descricao);
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, oportunidadesVO.IdDestaque);
			if (oportunidadesVO.GoogleMaps != null)
				db.AddInParameter(command, "@GoogleMaps", DbType.AnsiString, oportunidadesVO.GoogleMaps);
			else
				db.AddInParameter(command, "@GoogleMaps", DbType.AnsiString, DBNull.Value);
			db.AddInParameter(command, "@ImagemVideo", DbType.AnsiString, oportunidadesVO.ImagemVideo);
			db.ExecuteNonQuery(command);
		}
		public void Delete(int idOportunidade)
		{
			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesDelete");
			db.AddInParameter(command, "@IdOportunidade", DbType.Int32, idOportunidade);
			db.ExecuteNonQuery(command);
		}
		public OportunidadesVO Get(int idOportunidade)
		{
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelect");
			db.AddInParameter(command, "@IdOportunidade", DbType.Int32, idOportunidade);
			using (IDataReader reader = db.ExecuteReader(command))
			{
				if (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
				}
			}

			return oportunidadesVO;
		}
		public OportunidadesVOCollection GetAll()
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectAll");

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetAllPaged(long startRowIndex, int maximumRows)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectAllPaged");
			db.AddInParameter(command, "@startRowIndex", DbType.Int64, startRowIndex);
			db.AddInParameter(command, "@maximumRows", DbType.Int64, maximumRows);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					if (listaOportunidadesVO.Count == 0) listaOportunidadesVO.TotalRows = int.Parse(reader.GetValue(reader.GetOrdinal("TotalRows")).ToString());
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			listaOportunidadesVO.PageSize = maximumRows;

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetByAvaliacoes(int idAvaliacao)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectByAvaliacoes");
			db.AddInParameter(command, "@IdAvaliacao", DbType.Int32, idAvaliacao);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetByCategorias(int idCategoria)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectByCategorias");
			db.AddInParameter(command, "@IdCategoria", DbType.Int32, idCategoria);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetByDestaques(int idDestaque)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectByDestaques");
			db.AddInParameter(command, "@IdDestaque", DbType.Int32, idDestaque);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetByFornecedores(int idFornecedor)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectByFornecedores");
			db.AddInParameter(command, "@IdFornecedor", DbType.Int32, idFornecedor);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}
		public OportunidadesVOCollection GetByMensagens(int idMensagem)
		{
			OportunidadesVOCollection listaOportunidadesVO = new OportunidadesVOCollection();
			OportunidadesVO oportunidadesVO = null;

			DbCommand command = db.GetStoredProcCommand("dbo.DW_OportunidadesSelectByMensagens");
			db.AddInParameter(command, "@IdMensagem", DbType.Int32, idMensagem);

			using (IDataReader reader = db.ExecuteReader(command))
			{
				while (reader.Read())
				{
					oportunidadesVO = new OportunidadesVO();
					oportunidadesVO.IsPersisted = true;
					if (!reader.IsDBNull(reader.GetOrdinal("IdOportunidade")))
						oportunidadesVO.IdOportunidade = reader.GetInt32(reader.GetOrdinal("IdOportunidade"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdCategoria")))
						oportunidadesVO.IdCategoria = reader.GetInt32(reader.GetOrdinal("IdCategoria"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdMensagem")))
						oportunidadesVO.IdMensagem = reader.GetInt32(reader.GetOrdinal("IdMensagem"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdFornecedor")))
						oportunidadesVO.IdFornecedor = reader.GetInt32(reader.GetOrdinal("IdFornecedor"));
					if (!reader.IsDBNull(reader.GetOrdinal("IdAvaliacao")))
						oportunidadesVO.IdAvaliacao = reader.GetInt32(reader.GetOrdinal("IdAvaliacao"));
					if (!reader.IsDBNull(reader.GetOrdinal("Titulo")))
						oportunidadesVO.Titulo = reader.GetString(reader.GetOrdinal("Titulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Subtitulo")))
						oportunidadesVO.Subtitulo = reader.GetString(reader.GetOrdinal("Subtitulo")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("Descricao")))
						oportunidadesVO.Descricao = reader.GetString(reader.GetOrdinal("Descricao")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("IdDestaque")))
						oportunidadesVO.IdDestaque = reader.GetInt32(reader.GetOrdinal("IdDestaque"));
					if (!reader.IsDBNull(reader.GetOrdinal("GoogleMaps")))
						oportunidadesVO.GoogleMaps = reader.GetString(reader.GetOrdinal("GoogleMaps")).Trim();
					if (!reader.IsDBNull(reader.GetOrdinal("ImagemVideo")))
						oportunidadesVO.ImagemVideo = reader.GetString(reader.GetOrdinal("ImagemVideo")).Trim();
					listaOportunidadesVO.Add(oportunidadesVO);
				}
			}

			return listaOportunidadesVO;
		}

		#endregion
	}
}
