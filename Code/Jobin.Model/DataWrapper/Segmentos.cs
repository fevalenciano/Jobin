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
	public partial class Segmentos : IEqualityComparer<Segmentos>
	{
		private SegmentosVO valueObject;

		internal bool _isChanged = false;
		public Segmentos(SegmentosVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Segmentos()
		{
			this.valueObject = new SegmentosVO();
			this.valueObject.IsPersisted = false;
			SegmentosPartial();
		}
		partial void SegmentosPartial();

		private static SegmentosFactory factoryInstance = null;
		public static SegmentosFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<SegmentosFactory>();
				return factoryInstance;
			}
		}
		private static SegmentosFactory factoryInstanceNoCache = null;
		public static SegmentosFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<SegmentosFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static SegmentosTransaction transactionInstance = null;
		public static SegmentosTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<SegmentosTransaction>();
				return transactionInstance;
			}
		}

		internal SegmentosVO ValueObject
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
		public int? IdSegmento
		{
			get
			{
				return this.valueObject.IdSegmento;
			}
			set
			{
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
		private CategoriasCollection _categoriass = null;
		public CategoriasCollection Categoriass
		{
			get
			{
				if (_categoriass == null)
					return Categorias.FactoryInstance.GetBySegmentos(this.valueObject.IdSegmento.Value);
				return _categoriass;
			}
			set
			{
				_categoriass = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Segmentos a, Segmentos b)
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

		public static bool operator !=(Segmentos a, Segmentos b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Segmentos typedInstance = obj as Segmentos;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdSegmento == null) return 0;
			else return valueObject.IdSegmento.GetHashCode();
		}

		#region IEqualityComparer<Segmentos> Members
		public bool Equals(Segmentos x, Segmentos y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Segmentos obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class SegmentosCollection : List<Segmentos>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public SegmentosCollection() { }
		public SegmentosCollection(IEnumerable<Segmentos> collection) : base(collection) { }
		public SegmentosCollection(SegmentosVOCollection dataCollection)
		{
			foreach (SegmentosVO item in dataCollection)
			{
				this.Add(Segmentos.FactoryInstance.NewSegmentos(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public SegmentosVOCollection DataCollection
		{
			get
			{
				SegmentosVOCollection dataCollection = new SegmentosVOCollection();
				foreach (Segmentos item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class SegmentosFactory : ESContextBoundObject
	{
		public SegmentosFactory()
		{
			
		}

		public SegmentosFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Segmentos NewSegmentos()
		{
			return new Segmentos();
		}
		internal Segmentos NewSegmentos(SegmentosVO vo)
		{
			return new Segmentos(vo);
		}

		[Cache("Jobin.Model")]
		public Segmentos Get(int idSegmento)
		{
			ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
			SegmentosVO vo = dalc.Get(idSegmento);
			if (vo != null) return NewSegmentos(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public SegmentosCollection GetAll()
		{
			ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
			return new SegmentosCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public SegmentosCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public SegmentosCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
			SegmentosCollection list = new SegmentosCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class SegmentosTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Segmentos bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(SegmentosVO segmentosVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(segmentosVO, false);
			ValidateInsertPartial(segmentosVO);

			return ex;
		}
		partial void ValidateInsertPartial(SegmentosVO segmentosVO);
		public ValidationException ValidateUpdate(SegmentosVO segmentosVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(segmentosVO, true);
			ValidateUpdatePartial(segmentosVO);

			return ex;
		}
		partial void ValidateUpdatePartial(SegmentosVO segmentosVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Segmentos bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdSegmento);
			ThrowIfError();
			ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
			dalc.Delete(bo.IdSegmento.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idSegmento)
		{
			ClearErrors();
			RemoveValidationPartial(idSegmento);
			ThrowIfError();
			ISegmentosDalc dalc = DataStore.Factory.Get().Resolve<ISegmentosDalc>();
			dalc.Delete(idSegmento);
		}
		public ValidationException RemoveValidation(int? idSegmento)
		{
			ClearErrors();
			if (idSegmento == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Segmentos.IdSegmento"));

			RemoveValidationPartial(idSegmento);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idSegmento);
		public ValidationException ValidateAttributesNotNull(SegmentosVO segmentosVO, bool validateGuidOnPK)
		{
			if (segmentosVO.IdSegmento == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Segmentos.IdSegmento"));
			if (string.IsNullOrEmpty(segmentosVO.Nome))
				RegisterMessageValidationNotNull(NameConvert.GetName("Segmentos.Nome"));
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
