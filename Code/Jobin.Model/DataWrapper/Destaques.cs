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
	public partial class Destaques : IEqualityComparer<Destaques>
	{
		private DestaquesVO valueObject;

		internal bool _isChanged = false;
		public Destaques(DestaquesVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Destaques()
		{
			this.valueObject = new DestaquesVO();
			this.valueObject.IsPersisted = false;
			DestaquesPartial();
		}
		partial void DestaquesPartial();

		private static DestaquesFactory factoryInstance = null;
		public static DestaquesFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<DestaquesFactory>();
				return factoryInstance;
			}
		}
		private static DestaquesFactory factoryInstanceNoCache = null;
		public static DestaquesFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<DestaquesFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static DestaquesTransaction transactionInstance = null;
		public static DestaquesTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<DestaquesTransaction>();
				return transactionInstance;
			}
		}

		internal DestaquesVO ValueObject
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
		public int? IdDestaque
		{
			get
			{
				return this.valueObject.IdDestaque;
			}
			set
			{
				_isChanged |= (valueObject.IdDestaque != value);
				this.valueObject.IdDestaque = value;
			}
		}
		public string Destaque
		{
			get
			{
				return this.valueObject.Destaque;
			}
			set
			{
				_isChanged |= (valueObject.Destaque != value);
				this.valueObject.Destaque = value;
			}
		}
		public string DescricaoSimples
		{
			get
			{
				return this.valueObject.DescricaoSimples;
			}
			set
			{
				_isChanged |= (valueObject.DescricaoSimples != value);
				this.valueObject.DescricaoSimples = value;
			}
		}
		public string DescricaoComplexa
		{
			get
			{
				return this.valueObject.DescricaoComplexa;
			}
			set
			{
				_isChanged |= (valueObject.DescricaoComplexa != value);
				this.valueObject.DescricaoComplexa = value;
			}
		}
		private OportunidadesCollection _oportunidadess = null;
		public OportunidadesCollection Oportunidadess
		{
			get
			{
				if (_oportunidadess == null)
					return Oportunidades.FactoryInstance.GetByDestaques(this.valueObject.IdDestaque.Value);
				return _oportunidadess;
			}
			set
			{
				_oportunidadess = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Destaques a, Destaques b)
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

		public static bool operator !=(Destaques a, Destaques b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Destaques typedInstance = obj as Destaques;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdDestaque == null) return 0;
			else return valueObject.IdDestaque.GetHashCode();
		}

		#region IEqualityComparer<Destaques> Members
		public bool Equals(Destaques x, Destaques y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Destaques obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class DestaquesCollection : List<Destaques>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public DestaquesCollection() { }
		public DestaquesCollection(IEnumerable<Destaques> collection) : base(collection) { }
		public DestaquesCollection(DestaquesVOCollection dataCollection)
		{
			foreach (DestaquesVO item in dataCollection)
			{
				this.Add(Destaques.FactoryInstance.NewDestaques(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public DestaquesVOCollection DataCollection
		{
			get
			{
				DestaquesVOCollection dataCollection = new DestaquesVOCollection();
				foreach (Destaques item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class DestaquesFactory : ESContextBoundObject
	{
		public DestaquesFactory()
		{
			
		}

		public DestaquesFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Destaques NewDestaques()
		{
			return new Destaques();
		}
		internal Destaques NewDestaques(DestaquesVO vo)
		{
			return new Destaques(vo);
		}

		[Cache("Jobin.Model")]
		public Destaques Get(int idDestaque)
		{
			IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
			DestaquesVO vo = dalc.Get(idDestaque);
			if (vo != null) return NewDestaques(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public DestaquesCollection GetAll()
		{
			IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
			return new DestaquesCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public DestaquesCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public DestaquesCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
			DestaquesCollection list = new DestaquesCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class DestaquesTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Destaques bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(DestaquesVO destaquesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(destaquesVO, false);
			ValidateInsertPartial(destaquesVO);

			return ex;
		}
		partial void ValidateInsertPartial(DestaquesVO destaquesVO);
		public ValidationException ValidateUpdate(DestaquesVO destaquesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(destaquesVO, true);
			ValidateUpdatePartial(destaquesVO);

			return ex;
		}
		partial void ValidateUpdatePartial(DestaquesVO destaquesVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Destaques bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdDestaque);
			ThrowIfError();
			IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
			dalc.Delete(bo.IdDestaque.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idDestaque)
		{
			ClearErrors();
			RemoveValidationPartial(idDestaque);
			ThrowIfError();
			IDestaquesDalc dalc = DataStore.Factory.Get().Resolve<IDestaquesDalc>();
			dalc.Delete(idDestaque);
		}
		public ValidationException RemoveValidation(int? idDestaque)
		{
			ClearErrors();
			if (idDestaque == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Destaques.IdDestaque"));

			RemoveValidationPartial(idDestaque);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idDestaque);
		public ValidationException ValidateAttributesNotNull(DestaquesVO destaquesVO, bool validateGuidOnPK)
		{
			if (destaquesVO.IdDestaque == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Destaques.IdDestaque"));
			if (string.IsNullOrEmpty(destaquesVO.Destaque))
				RegisterMessageValidationNotNull(NameConvert.GetName("Destaques.Destaque"));
			if (string.IsNullOrEmpty(destaquesVO.DescricaoSimples))
				RegisterMessageValidationNotNull(NameConvert.GetName("Destaques.DescricaoSimples"));
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
