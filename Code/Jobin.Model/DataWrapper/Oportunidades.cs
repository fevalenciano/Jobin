namespace Jobin.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Transactions;
	using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
	using ES.Practices.Common;
	using ES.Practices.Caching;
	using ES.Practices.Transaction;
	using Jobin.Model.ValueObjects;
	using Jobin.Model.DataStoreInterface;
	using ES.Practices.ExceptionHandling;

	[Serializable]
	public partial class Oportunidades : IEqualityComparer<Oportunidades>
	{
		private OportunidadesVO valueObject;

		internal bool _isChanged = false;
		public Oportunidades(OportunidadesVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Oportunidades()
		{
			this.valueObject = new OportunidadesVO();
			this.valueObject.IsPersisted = false;
			OportunidadesPartial();
		}
		partial void OportunidadesPartial();

		private static OportunidadesFactory factoryInstance = null;
		public static OportunidadesFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<OportunidadesFactory>();
				return factoryInstance;
			}
		}
		private static OportunidadesFactory factoryInstanceNoCache = null;
		public static OportunidadesFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<OportunidadesFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static OportunidadesTransaction transactionInstance = null;
		public static OportunidadesTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<OportunidadesTransaction>();
				return transactionInstance;
			}
		}

		internal OportunidadesVO ValueObject
		{
			get
			{
				return this.valueObject;
			}
			set
			{
				this.valueObject = value;
			}
		}
		public bool IsPersisted
		{
			get
			{
				return valueObject.IsPersisted;
			}
			set
			{
				valueObject.IsPersisted = value;
			}
		}
		public bool IsRemoved
		{
			get
			{
				return valueObject.IsRemoved;
			}
			set
			{
				valueObject.IsRemoved = value;
			}
		}
		public int? IdOportunidade
		{
			get
			{
				return this.valueObject.IdOportunidade;
			}
			set
			{
				_isChanged |= (valueObject.IdOportunidade != value);
				this.valueObject.IdOportunidade = value;
			}
		}
		public int? IdCategoria
		{
			get
			{
				return this.valueObject.IdCategoria;
			}
			set
			{
				if (IdCategoria != value)
					this._categorias = null;
				_isChanged |= (valueObject.IdCategoria != value);
				this.valueObject.IdCategoria = value;
			}
		}
		public int? IdMensagem
		{
			get
			{
				return this.valueObject.IdMensagem;
			}
			set
			{
				if (IdMensagem != value)
					this._mensagens = null;
				_isChanged |= (valueObject.IdMensagem != value);
				this.valueObject.IdMensagem = value;
			}
		}
		public int? IdFornecedor
		{
			get
			{
				return this.valueObject.IdFornecedor;
			}
			set
			{
				if (IdFornecedor != value)
					this._fornecedores = null;
				_isChanged |= (valueObject.IdFornecedor != value);
				this.valueObject.IdFornecedor = value;
			}
		}
		public int? IdAvaliacao
		{
			get
			{
				return this.valueObject.IdAvaliacao;
			}
			set
			{
				if (IdAvaliacao != value)
					this._avaliacoes = null;
				_isChanged |= (valueObject.IdAvaliacao != value);
				this.valueObject.IdAvaliacao = value;
			}
		}
		public string Titulo
		{
			get
			{
				return this.valueObject.Titulo;
			}
			set
			{
				_isChanged |= (valueObject.Titulo != value);
				this.valueObject.Titulo = value;
			}
		}
		public string Subtitulo
		{
			get
			{
				return this.valueObject.Subtitulo;
			}
			set
			{
				_isChanged |= (valueObject.Subtitulo != value);
				this.valueObject.Subtitulo = value;
			}
		}
		public string Descricao
		{
			get
			{
				return this.valueObject.Descricao;
			}
			set
			{
				_isChanged |= (valueObject.Descricao != value);
				this.valueObject.Descricao = value;
			}
		}
		public int? IdDestaque
		{
			get
			{
				return this.valueObject.IdDestaque;
			}
			set
			{
				if (IdDestaque != value)
					this._destaques = null;
				_isChanged |= (valueObject.IdDestaque != value);
				this.valueObject.IdDestaque = value;
			}
		}
		public string GoogleMaps
		{
			get
			{
				return this.valueObject.GoogleMaps;
			}
			set
			{
				_isChanged |= (valueObject.GoogleMaps != value);
				this.valueObject.GoogleMaps = value;
			}
		}
		public string ImagemVideo
		{
			get
			{
				return this.valueObject.ImagemVideo;
			}
			set
			{
				_isChanged |= (valueObject.ImagemVideo != value);
				this.valueObject.ImagemVideo = value;
			}
		}
		private Avaliacoes _avaliacoes = null;
		public Avaliacoes Avaliacoes
		{
			get
			{
				if (IdAvaliacao == null) return null;
				if (_avaliacoes == null)
				  _avaliacoes = Avaliacoes.FactoryInstance.Get(IdAvaliacao.Value);
				return _avaliacoes;
			}
			set
			{
				_avaliacoes = value;
				if (value == null)
					this.IdAvaliacao = null;
				else
					this.IdAvaliacao = value.IdAvaliacao;
			}
		}
		private Categorias _categorias = null;
		public Categorias Categorias
		{
			get
			{
				if (IdCategoria == null) return null;
				if (_categorias == null)
				  _categorias = Categorias.FactoryInstance.Get(IdCategoria.Value);
				return _categorias;
			}
			set
			{
				_categorias = value;
				if (value == null)
					this.IdCategoria = null;
				else
					this.IdCategoria = value.IdCategoria;
			}
		}
		private Destaques _destaques = null;
		public Destaques Destaques
		{
			get
			{
				if (IdDestaque == null) return null;
				if (_destaques == null)
				  _destaques = Destaques.FactoryInstance.Get(IdDestaque.Value);
				return _destaques;
			}
			set
			{
				_destaques = value;
				if (value == null)
					this.IdDestaque = null;
				else
					this.IdDestaque = value.IdDestaque;
			}
		}
		private Fornecedores _fornecedores = null;
		public Fornecedores Fornecedores
		{
			get
			{
				if (IdFornecedor == null) return null;
				if (_fornecedores == null)
				  _fornecedores = Fornecedores.FactoryInstance.Get(IdFornecedor.Value);
				return _fornecedores;
			}
			set
			{
				_fornecedores = value;
				if (value == null)
					this.IdFornecedor = null;
				else
					this.IdFornecedor = value.IdFornecedor;
			}
		}
		private Mensagens _mensagens = null;
		public Mensagens Mensagens
		{
			get
			{
				if (IdMensagem == null) return null;
				if (_mensagens == null)
				  _mensagens = Mensagens.FactoryInstance.Get(IdMensagem.Value);
				return _mensagens;
			}
			set
			{
				_mensagens = value;
				if (value == null)
					this.IdMensagem = null;
				else
					this.IdMensagem = value.IdMensagem;
			}
		}
		private MensagensCollection _mensagenss = null;
		public MensagensCollection Mensagenss
		{
			get
			{
				if (_mensagenss == null)
					return Mensagens.FactoryInstance.GetByOportunidades(this.valueObject.IdOportunidade.Value);
				return _mensagenss;
			}
			set
			{
				_mensagenss = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Oportunidades a, Oportunidades b)
		{
			if ( Object.ReferenceEquals(a, b)) // Optimization for a common success case.
				return true;
			else if ( Object.ReferenceEquals(a, null) ^ Object.ReferenceEquals(b, null) )
				return false;
			else if ( Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null) )
				return true;
			else
			{
				if ((a.valueObject == null) && (b.valueObject == null)) return true;
				else if ((a.valueObject == null) || (b.valueObject == null)) return false;
				return (a.valueObject == b.valueObject);
			}
		}

		public static bool operator !=(Oportunidades a, Oportunidades b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Oportunidades typedInstance = obj as Oportunidades;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdOportunidade == null) return 0;
			else return valueObject.IdOportunidade.GetHashCode();
		}

		#region IEqualityComparer<Oportunidades> Members
		public bool Equals(Oportunidades x, Oportunidades y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Oportunidades obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class OportunidadesCollection : List<Oportunidades>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public OportunidadesCollection() { }
		public OportunidadesCollection(IEnumerable<Oportunidades> collection) : base(collection) { }
		public OportunidadesCollection(OportunidadesVOCollection dataCollection)
		{
			foreach (OportunidadesVO item in dataCollection)
			{
				this.Add(Oportunidades.FactoryInstance.NewOportunidades(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public OportunidadesVOCollection DataCollection
		{
			get
			{
				OportunidadesVOCollection dataCollection = new OportunidadesVOCollection();
				foreach (Oportunidades item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class OportunidadesFactory : ESContextBoundObject
	{
		public OportunidadesFactory()
		{
			
		}

		public OportunidadesFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Oportunidades NewOportunidades()
		{
			return new Oportunidades();
		}
		internal Oportunidades NewOportunidades(OportunidadesVO vo)
		{
			return new Oportunidades(vo);
		}

		[Cache("Jobin.Model")]
		public Oportunidades Get(int idOportunidade)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			OportunidadesVO vo = dalc.Get(idOportunidade);
			if (vo != null) return NewOportunidades(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public OportunidadesCollection GetAll()
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public OportunidadesCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public OportunidadesCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			OportunidadesCollection list = new OportunidadesCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public OportunidadesCollection GetByAvaliacoes(int idAvaliacao)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetByAvaliacoes(idAvaliacao));
		}
		public OportunidadesCollection GetByCategorias(int idCategoria)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetByCategorias(idCategoria));
		}
		public OportunidadesCollection GetByDestaques(int idDestaque)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetByDestaques(idDestaque));
		}
		public OportunidadesCollection GetByFornecedores(int idFornecedor)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetByFornecedores(idFornecedor));
		}
		public OportunidadesCollection GetByMensagens(int idMensagem)
		{
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			return new OportunidadesCollection(dalc.GetByMensagens(idMensagem));
		}
	}

	[Serializable]
	public partial class OportunidadesTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Oportunidades bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(OportunidadesVO oportunidadesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(oportunidadesVO, false);
			ValidateInsertPartial(oportunidadesVO);

			return ex;
		}
		partial void ValidateInsertPartial(OportunidadesVO oportunidadesVO);
		public ValidationException ValidateUpdate(OportunidadesVO oportunidadesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(oportunidadesVO, true);
			ValidateUpdatePartial(oportunidadesVO);

			return ex;
		}
		partial void ValidateUpdatePartial(OportunidadesVO oportunidadesVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Oportunidades bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdOportunidade);
			ThrowIfError();
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			dalc.Delete(bo.IdOportunidade.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idOportunidade)
		{
			ClearErrors();
			RemoveValidationPartial(idOportunidade);
			ThrowIfError();
			IOportunidadesDalc dalc = DataStore.Factory.Get().Resolve<IOportunidadesDalc>();
			dalc.Delete(idOportunidade);
		}
		public ValidationException RemoveValidation(int? idOportunidade)
		{
			ClearErrors();
			if (idOportunidade == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdOportunidade"));

			RemoveValidationPartial(idOportunidade);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idOportunidade);
		public ValidationException ValidateAttributesNotNull(OportunidadesVO oportunidadesVO, bool validateGuidOnPK)
		{
			if (oportunidadesVO.IdOportunidade == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdOportunidade"));
			if (oportunidadesVO.IdCategoria == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdCategoria"));
			if (oportunidadesVO.IdFornecedor == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdFornecedor"));
			if (oportunidadesVO.IdAvaliacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdAvaliacao"));
			if (string.IsNullOrEmpty(oportunidadesVO.Titulo))
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.Titulo"));
			if (string.IsNullOrEmpty(oportunidadesVO.Subtitulo))
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.Subtitulo"));
			if (string.IsNullOrEmpty(oportunidadesVO.Descricao))
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.Descricao"));
			if (oportunidadesVO.IdDestaque == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.IdDestaque"));
			if (string.IsNullOrEmpty(oportunidadesVO.ImagemVideo))
				RegisterMessageValidationNotNull(NameConvert.GetName("Oportunidades.ImagemVideo"));
			return ex;
		}

		private ValidationException ex = null;
		private void RegisterMessageValidation(string message)
		{
			RegisterMessageValidation(null, message);
		}
		private void RegisterMessageValidation(string fieldName, string message)
		{
			ValidationException validation = new ValidationException(message, fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		private void RegisterMessageValidationNotNull(string fieldName)
		{
			ValidationException validation = new ValidationException(string.Format("O campo {0} é obrigatório!", fieldName), fieldName);
			if (ex == null) ex = validation;
			else ex.AddValidationException(validation);
		}
		private void ClearErrors()
		{
			ex = null;
		}
		private void ThrowIfError()
		{
			if (ex != null)
				throw ex;
		}
		public ValidationException ValidationException
		{
			get
			{
				return ex;
			}
		}
		private void ConcatExceptions(ValidationException validation)
		{
			if (validation != null)
			{
				if (ex == null) ex = validation;
				else ex.AddValidationException(validation);
			}
		}

	}
}
