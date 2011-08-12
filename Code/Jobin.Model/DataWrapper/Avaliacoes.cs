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
	public partial class Avaliacoes : IEqualityComparer<Avaliacoes>
	{
		private AvaliacoesVO valueObject;

		internal bool _isChanged = false;
		public Avaliacoes(AvaliacoesVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Avaliacoes()
		{
			this.valueObject = new AvaliacoesVO();
			this.valueObject.IsPersisted = false;
			AvaliacoesPartial();
		}
		partial void AvaliacoesPartial();

		private static AvaliacoesFactory factoryInstance = null;
		public static AvaliacoesFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<AvaliacoesFactory>();
				return factoryInstance;
			}
		}
		private static AvaliacoesFactory factoryInstanceNoCache = null;
		public static AvaliacoesFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<AvaliacoesFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static AvaliacoesTransaction transactionInstance = null;
		public static AvaliacoesTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<AvaliacoesTransaction>();
				return transactionInstance;
			}
		}

		internal AvaliacoesVO ValueObject
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
		public int? IdAvaliacao
		{
			get
			{
				return this.valueObject.IdAvaliacao;
			}
			set
			{
				_isChanged |= (valueObject.IdAvaliacao != value);
				this.valueObject.IdAvaliacao = value;
			}
		}
		public int? IdUsuario
		{
			get
			{
				return this.valueObject.IdUsuario;
			}
			set
			{
				if (IdUsuario != value)
					this._usuarios = null;
				_isChanged |= (valueObject.IdUsuario != value);
				this.valueObject.IdUsuario = value;
			}
		}
		public bool? TipoAvaliacao
		{
			get
			{
				return this.valueObject.TipoAvaliacao;
			}
			set
			{
				_isChanged |= (valueObject.TipoAvaliacao != value);
				this.valueObject.TipoAvaliacao = value;
			}
		}
		public DateTime? DataAvaliacao
		{
			get
			{
				return this.valueObject.DataAvaliacao;
			}
			set
			{
				_isChanged |= (valueObject.DataAvaliacao != value);
				this.valueObject.DataAvaliacao = value;
			}
		}
		private Usuarios _usuarios = null;
		public Usuarios Usuarios
		{
			get
			{
				if (IdUsuario == null) return null;
				if (_usuarios == null)
				  _usuarios = Usuarios.FactoryInstance.Get(IdUsuario.Value);
				return _usuarios;
			}
			set
			{
				_usuarios = value;
				if (value == null)
					this.IdUsuario = null;
				else
					this.IdUsuario = value.IdUsuario;
			}
		}
		private OportunidadesCollection _oportunidadess = null;
		public OportunidadesCollection Oportunidadess
		{
			get
			{
				if (_oportunidadess == null)
					return Oportunidades.FactoryInstance.GetByAvaliacoes(this.valueObject.IdAvaliacao.Value);
				return _oportunidadess;
			}
			set
			{
				_oportunidadess = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Avaliacoes a, Avaliacoes b)
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

		public static bool operator !=(Avaliacoes a, Avaliacoes b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Avaliacoes typedInstance = obj as Avaliacoes;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdAvaliacao == null) return 0;
			else return valueObject.IdAvaliacao.GetHashCode();
		}

		#region IEqualityComparer<Avaliacoes> Members
		public bool Equals(Avaliacoes x, Avaliacoes y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Avaliacoes obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class AvaliacoesCollection : List<Avaliacoes>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public AvaliacoesCollection() { }
		public AvaliacoesCollection(IEnumerable<Avaliacoes> collection) : base(collection) { }
		public AvaliacoesCollection(AvaliacoesVOCollection dataCollection)
		{
			foreach (AvaliacoesVO item in dataCollection)
			{
				this.Add(Avaliacoes.FactoryInstance.NewAvaliacoes(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public AvaliacoesVOCollection DataCollection
		{
			get
			{
				AvaliacoesVOCollection dataCollection = new AvaliacoesVOCollection();
				foreach (Avaliacoes item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class AvaliacoesFactory : ESContextBoundObject
	{
		public AvaliacoesFactory()
		{
			
		}

		public AvaliacoesFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Avaliacoes NewAvaliacoes()
		{
			return new Avaliacoes();
		}
		internal Avaliacoes NewAvaliacoes(AvaliacoesVO vo)
		{
			return new Avaliacoes(vo);
		}

		[Cache("Jobin.Model")]
		public Avaliacoes Get(int idAvaliacao)
		{
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			AvaliacoesVO vo = dalc.Get(idAvaliacao);
			if (vo != null) return NewAvaliacoes(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public AvaliacoesCollection GetAll()
		{
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			return new AvaliacoesCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public AvaliacoesCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public AvaliacoesCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			AvaliacoesCollection list = new AvaliacoesCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public AvaliacoesCollection GetByUsuarios(int idUsuario)
		{
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			return new AvaliacoesCollection(dalc.GetByUsuarios(idUsuario));
		}
	}

	[Serializable]
	public partial class AvaliacoesTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Avaliacoes bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(AvaliacoesVO avaliacoesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(avaliacoesVO, false);
			ValidateInsertPartial(avaliacoesVO);

			return ex;
		}
		partial void ValidateInsertPartial(AvaliacoesVO avaliacoesVO);
		public ValidationException ValidateUpdate(AvaliacoesVO avaliacoesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(avaliacoesVO, true);
			ValidateUpdatePartial(avaliacoesVO);

			return ex;
		}
		partial void ValidateUpdatePartial(AvaliacoesVO avaliacoesVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Avaliacoes bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdAvaliacao);
			ThrowIfError();
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			dalc.Delete(bo.IdAvaliacao.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idAvaliacao)
		{
			ClearErrors();
			RemoveValidationPartial(idAvaliacao);
			ThrowIfError();
			IAvaliacoesDalc dalc = DataStore.Factory.Get().Resolve<IAvaliacoesDalc>();
			dalc.Delete(idAvaliacao);
		}
		public ValidationException RemoveValidation(int? idAvaliacao)
		{
			ClearErrors();
			if (idAvaliacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Avaliacoes.IdAvaliacao"));

			RemoveValidationPartial(idAvaliacao);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idAvaliacao);
		public ValidationException ValidateAttributesNotNull(AvaliacoesVO avaliacoesVO, bool validateGuidOnPK)
		{
			if (avaliacoesVO.IdAvaliacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Avaliacoes.IdAvaliacao"));
			if (avaliacoesVO.IdUsuario == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Avaliacoes.IdUsuario"));
			if (avaliacoesVO.TipoAvaliacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Avaliacoes.TipoAvaliacao"));
			if (avaliacoesVO.DataAvaliacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Avaliacoes.DataAvaliacao"));
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
