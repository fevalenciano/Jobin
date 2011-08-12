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
	public partial class Categorias : IEqualityComparer<Categorias>
	{
		private CategoriasVO valueObject;

		internal bool _isChanged = false;
		public Categorias(CategoriasVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Categorias()
		{
			this.valueObject = new CategoriasVO();
			this.valueObject.IsPersisted = false;
			CategoriasPartial();
		}
		partial void CategoriasPartial();

		private static CategoriasFactory factoryInstance = null;
		public static CategoriasFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<CategoriasFactory>();
				return factoryInstance;
			}
		}
		private static CategoriasFactory factoryInstanceNoCache = null;
		public static CategoriasFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<CategoriasFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static CategoriasTransaction transactionInstance = null;
		public static CategoriasTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<CategoriasTransaction>();
				return transactionInstance;
			}
		}

		internal CategoriasVO ValueObject
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
		public int? IdCategoria
		{
			get
			{
				return this.valueObject.IdCategoria;
			}
			set
			{
				_isChanged |= (valueObject.IdCategoria != value);
				this.valueObject.IdCategoria = value;
			}
		}
		public int? IdSegmento
		{
			get
			{
				return this.valueObject.IdSegmento;
			}
			set
			{
				if (IdSegmento != value)
					this._segmentos = null;
				_isChanged |= (valueObject.IdSegmento != value);
				this.valueObject.IdSegmento = value;
			}
		}
		public string Nome
		{
			get
			{
				return this.valueObject.Nome;
			}
			set
			{
				_isChanged |= (valueObject.Nome != value);
				this.valueObject.Nome = value;
			}
		}
		private Segmentos _segmentos = null;
		public Segmentos Segmentos
		{
			get
			{
				if (IdSegmento == null) return null;
				if (_segmentos == null)
				  _segmentos = Segmentos.FactoryInstance.Get(IdSegmento.Value);
				return _segmentos;
			}
			set
			{
				_segmentos = value;
				if (value == null)
					this.IdSegmento = null;
				else
					this.IdSegmento = value.IdSegmento;
			}
		}
		private OportunidadesCollection _oportunidadess = null;
		public OportunidadesCollection Oportunidadess
		{
			get
			{
				if (_oportunidadess == null)
					return Oportunidades.FactoryInstance.GetByCategorias(this.valueObject.IdCategoria.Value);
				return _oportunidadess;
			}
			set
			{
				_oportunidadess = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Categorias a, Categorias b)
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

		public static bool operator !=(Categorias a, Categorias b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Categorias typedInstance = obj as Categorias;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdCategoria == null) return 0;
			else return valueObject.IdCategoria.GetHashCode();
		}

		#region IEqualityComparer<Categorias> Members
		public bool Equals(Categorias x, Categorias y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Categorias obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class CategoriasCollection : List<Categorias>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public CategoriasCollection() { }
		public CategoriasCollection(IEnumerable<Categorias> collection) : base(collection) { }
		public CategoriasCollection(CategoriasVOCollection dataCollection)
		{
			foreach (CategoriasVO item in dataCollection)
			{
				this.Add(Categorias.FactoryInstance.NewCategorias(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public CategoriasVOCollection DataCollection
		{
			get
			{
				CategoriasVOCollection dataCollection = new CategoriasVOCollection();
				foreach (Categorias item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class CategoriasFactory : ESContextBoundObject
	{
		public CategoriasFactory()
		{
			
		}

		public CategoriasFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Categorias NewCategorias()
		{
			return new Categorias();
		}
		internal Categorias NewCategorias(CategoriasVO vo)
		{
			return new Categorias(vo);
		}

		[Cache("Jobin.Model")]
		public Categorias Get(int idCategoria)
		{
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			CategoriasVO vo = dalc.Get(idCategoria);
			if (vo != null) return NewCategorias(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public CategoriasCollection GetAll()
		{
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			return new CategoriasCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public CategoriasCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public CategoriasCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			CategoriasCollection list = new CategoriasCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public CategoriasCollection GetBySegmentos(int idSegmento)
		{
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			return new CategoriasCollection(dalc.GetBySegmentos(idSegmento));
		}
	}

	[Serializable]
	public partial class CategoriasTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Categorias bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
				bo.ValueObject = dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(CategoriasVO categoriasVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(categoriasVO, false);
			ValidateInsertPartial(categoriasVO);

			return ex;
		}
		partial void ValidateInsertPartial(CategoriasVO categoriasVO);
		public ValidationException ValidateUpdate(CategoriasVO categoriasVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(categoriasVO, true);
			ValidateUpdatePartial(categoriasVO);

			return ex;
		}
		partial void ValidateUpdatePartial(CategoriasVO categoriasVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Categorias bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdCategoria);
			ThrowIfError();
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			dalc.Delete(bo.IdCategoria.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idCategoria)
		{
			ClearErrors();
			RemoveValidationPartial(idCategoria);
			ThrowIfError();
			ICategoriasDalc dalc = DataStore.Factory.Get().Resolve<ICategoriasDalc>();
			dalc.Delete(idCategoria);
		}
		public ValidationException RemoveValidation(int? idCategoria)
		{
			ClearErrors();
			if (idCategoria == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Categorias.IdCategoria"));

			RemoveValidationPartial(idCategoria);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idCategoria);
		public ValidationException ValidateAttributesNotNull(CategoriasVO categoriasVO, bool validateGuidOnPK)
		{
			if (categoriasVO.IdCategoria == null && (validateGuidOnPK))
				RegisterMessageValidationNotNull(NameConvert.GetName("Categorias.IdCategoria"));
			if (categoriasVO.IdSegmento == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Categorias.IdSegmento"));
			if (string.IsNullOrEmpty(categoriasVO.Nome))
				RegisterMessageValidationNotNull(NameConvert.GetName("Categorias.Nome"));
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
