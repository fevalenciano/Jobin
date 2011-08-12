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
	public partial class Experiencia : IEqualityComparer<Experiencia>
	{
		private ExperienciaVO valueObject;

		internal bool _isChanged = false;
		public Experiencia(ExperienciaVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Experiencia()
		{
			this.valueObject = new ExperienciaVO();
			this.valueObject.IsPersisted = false;
			ExperienciaPartial();
		}
		partial void ExperienciaPartial();

		private static ExperienciaFactory factoryInstance = null;
		public static ExperienciaFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<ExperienciaFactory>();
				return factoryInstance;
			}
		}
		private static ExperienciaFactory factoryInstanceNoCache = null;
		public static ExperienciaFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<ExperienciaFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static ExperienciaTransaction transactionInstance = null;
		public static ExperienciaTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<ExperienciaTransaction>();
				return transactionInstance;
			}
		}

		internal ExperienciaVO ValueObject
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
		public int? IdExperiencia
		{
			get
			{
				return this.valueObject.IdExperiencia;
			}
			set
			{
				_isChanged |= (valueObject.IdExperiencia != value);
				this.valueObject.IdExperiencia = value;
			}
		}
		public string Funcao
		{
			get
			{
				return this.valueObject.Funcao;
			}
			set
			{
				_isChanged |= (valueObject.Funcao != value);
				this.valueObject.Funcao = value;
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
		public DateTime? PeriodoDe
		{
			get
			{
				return this.valueObject.PeriodoDe;
			}
			set
			{
				_isChanged |= (valueObject.PeriodoDe != value);
				this.valueObject.PeriodoDe = value;
			}
		}
		public DateTime? PeriodoAte
		{
			get
			{
				return this.valueObject.PeriodoAte;
			}
			set
			{
				_isChanged |= (valueObject.PeriodoAte != value);
				this.valueObject.PeriodoAte = value;
			}
		}
		public string Empresa
		{
			get
			{
				return this.valueObject.Empresa;
			}
			set
			{
				_isChanged |= (valueObject.Empresa != value);
				this.valueObject.Empresa = value;
			}
		}
		private PessoaFisicaCollection _pessoafisicas = null;
		public PessoaFisicaCollection PessoaFisicas
		{
			get
			{
				if (_pessoafisicas == null)
					return PessoaFisica.FactoryInstance.GetByExperiencia(this.valueObject.IdExperiencia.Value);
				return _pessoafisicas;
			}
			set
			{
				_pessoafisicas = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Experiencia a, Experiencia b)
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

		public static bool operator !=(Experiencia a, Experiencia b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Experiencia typedInstance = obj as Experiencia;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdExperiencia == null) return 0;
			else return valueObject.IdExperiencia.GetHashCode();
		}

		#region IEqualityComparer<Experiencia> Members
		public bool Equals(Experiencia x, Experiencia y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Experiencia obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class ExperienciaCollection : List<Experiencia>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public ExperienciaCollection() { }
		public ExperienciaCollection(IEnumerable<Experiencia> collection) : base(collection) { }
		public ExperienciaCollection(ExperienciaVOCollection dataCollection)
		{
			foreach (ExperienciaVO item in dataCollection)
			{
				this.Add(Experiencia.FactoryInstance.NewExperiencia(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public ExperienciaVOCollection DataCollection
		{
			get
			{
				ExperienciaVOCollection dataCollection = new ExperienciaVOCollection();
				foreach (Experiencia item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class ExperienciaFactory : ESContextBoundObject
	{
		public ExperienciaFactory()
		{
			
		}

		public ExperienciaFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Experiencia NewExperiencia()
		{
			return new Experiencia();
		}
		internal Experiencia NewExperiencia(ExperienciaVO vo)
		{
			return new Experiencia(vo);
		}

		[Cache("Jobin.Model")]
		public Experiencia Get(int idExperiencia)
		{
			IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
			ExperienciaVO vo = dalc.Get(idExperiencia);
			if (vo != null) return NewExperiencia(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public ExperienciaCollection GetAll()
		{
			IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
			return new ExperienciaCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public ExperienciaCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public ExperienciaCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
			ExperienciaCollection list = new ExperienciaCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class ExperienciaTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Experiencia bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(ExperienciaVO experienciaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(experienciaVO, false);
			ValidateInsertPartial(experienciaVO);

			return ex;
		}
		partial void ValidateInsertPartial(ExperienciaVO experienciaVO);
		public ValidationException ValidateUpdate(ExperienciaVO experienciaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(experienciaVO, true);
			ValidateUpdatePartial(experienciaVO);

			return ex;
		}
		partial void ValidateUpdatePartial(ExperienciaVO experienciaVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Experiencia bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdExperiencia);
			ThrowIfError();
			IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
			dalc.Delete(bo.IdExperiencia.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idExperiencia)
		{
			ClearErrors();
			RemoveValidationPartial(idExperiencia);
			ThrowIfError();
			IExperienciaDalc dalc = DataStore.Factory.Get().Resolve<IExperienciaDalc>();
			dalc.Delete(idExperiencia);
		}
		public ValidationException RemoveValidation(int? idExperiencia)
		{
			ClearErrors();
			if (idExperiencia == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.IdExperiencia"));

			RemoveValidationPartial(idExperiencia);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idExperiencia);
		public ValidationException ValidateAttributesNotNull(ExperienciaVO experienciaVO, bool validateGuidOnPK)
		{
			if (experienciaVO.IdExperiencia == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.IdExperiencia"));
			if (string.IsNullOrEmpty(experienciaVO.Funcao))
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.Funcao"));
			if (string.IsNullOrEmpty(experienciaVO.Descricao))
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.Descricao"));
			if (experienciaVO.PeriodoDe == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.PeriodoDe"));
			if (experienciaVO.PeriodoAte == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.PeriodoAte"));
			if (string.IsNullOrEmpty(experienciaVO.Empresa))
				RegisterMessageValidationNotNull(NameConvert.GetName("Experiencia.Empresa"));
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
