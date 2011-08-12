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
	public partial class Formacoes : IEqualityComparer<Formacoes>
	{
		private FormacoesVO valueObject;

		internal bool _isChanged = false;
		public Formacoes(FormacoesVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Formacoes()
		{
			this.valueObject = new FormacoesVO();
			this.valueObject.IsPersisted = false;
			FormacoesPartial();
		}
		partial void FormacoesPartial();

		private static FormacoesFactory factoryInstance = null;
		public static FormacoesFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<FormacoesFactory>();
				return factoryInstance;
			}
		}
		private static FormacoesFactory factoryInstanceNoCache = null;
		public static FormacoesFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<FormacoesFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static FormacoesTransaction transactionInstance = null;
		public static FormacoesTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<FormacoesTransaction>();
				return transactionInstance;
			}
		}

		internal FormacoesVO ValueObject
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
		public int? IdFormacao
		{
			get
			{
				return this.valueObject.IdFormacao;
			}
			set
			{
				_isChanged |= (valueObject.IdFormacao != value);
				this.valueObject.IdFormacao = value;
			}
		}
		public string Curso
		{
			get
			{
				return this.valueObject.Curso;
			}
			set
			{
				_isChanged |= (valueObject.Curso != value);
				this.valueObject.Curso = value;
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
		public string Instituicao
		{
			get
			{
				return this.valueObject.Instituicao;
			}
			set
			{
				_isChanged |= (valueObject.Instituicao != value);
				this.valueObject.Instituicao = value;
			}
		}
		public DateTime? PeridoDe
		{
			get
			{
				return this.valueObject.PeridoDe;
			}
			set
			{
				_isChanged |= (valueObject.PeridoDe != value);
				this.valueObject.PeridoDe = value;
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
		private PessoaFisicaCollection _pessoafisicas = null;
		public PessoaFisicaCollection PessoaFisicas
		{
			get
			{
				if (_pessoafisicas == null)
					return PessoaFisica.FactoryInstance.GetByFormacoes(this.valueObject.IdFormacao.Value);
				return _pessoafisicas;
			}
			set
			{
				_pessoafisicas = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Formacoes a, Formacoes b)
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

		public static bool operator !=(Formacoes a, Formacoes b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Formacoes typedInstance = obj as Formacoes;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdFormacao == null) return 0;
			else return valueObject.IdFormacao.GetHashCode();
		}

		#region IEqualityComparer<Formacoes> Members
		public bool Equals(Formacoes x, Formacoes y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Formacoes obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class FormacoesCollection : List<Formacoes>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public FormacoesCollection() { }
		public FormacoesCollection(IEnumerable<Formacoes> collection) : base(collection) { }
		public FormacoesCollection(FormacoesVOCollection dataCollection)
		{
			foreach (FormacoesVO item in dataCollection)
			{
				this.Add(Formacoes.FactoryInstance.NewFormacoes(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public FormacoesVOCollection DataCollection
		{
			get
			{
				FormacoesVOCollection dataCollection = new FormacoesVOCollection();
				foreach (Formacoes item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class FormacoesFactory : ESContextBoundObject
	{
		public FormacoesFactory()
		{
			
		}

		public FormacoesFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Formacoes NewFormacoes()
		{
			return new Formacoes();
		}
		internal Formacoes NewFormacoes(FormacoesVO vo)
		{
			return new Formacoes(vo);
		}

		[Cache("Jobin.Model")]
		public Formacoes Get(int idFormacao)
		{
			IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
			FormacoesVO vo = dalc.Get(idFormacao);
			if (vo != null) return NewFormacoes(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public FormacoesCollection GetAll()
		{
			IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
			return new FormacoesCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public FormacoesCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public FormacoesCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
			FormacoesCollection list = new FormacoesCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class FormacoesTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Formacoes bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(FormacoesVO formacoesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(formacoesVO, false);
			ValidateInsertPartial(formacoesVO);

			return ex;
		}
		partial void ValidateInsertPartial(FormacoesVO formacoesVO);
		public ValidationException ValidateUpdate(FormacoesVO formacoesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(formacoesVO, true);
			ValidateUpdatePartial(formacoesVO);

			return ex;
		}
		partial void ValidateUpdatePartial(FormacoesVO formacoesVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Formacoes bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdFormacao);
			ThrowIfError();
			IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
			dalc.Delete(bo.IdFormacao.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idFormacao)
		{
			ClearErrors();
			RemoveValidationPartial(idFormacao);
			ThrowIfError();
			IFormacoesDalc dalc = DataStore.Factory.Get().Resolve<IFormacoesDalc>();
			dalc.Delete(idFormacao);
		}
		public ValidationException RemoveValidation(int? idFormacao)
		{
			ClearErrors();
			if (idFormacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.IdFormacao"));

			RemoveValidationPartial(idFormacao);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idFormacao);
		public ValidationException ValidateAttributesNotNull(FormacoesVO formacoesVO, bool validateGuidOnPK)
		{
			if (formacoesVO.IdFormacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.IdFormacao"));
			if (string.IsNullOrEmpty(formacoesVO.Curso))
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.Curso"));
			if (string.IsNullOrEmpty(formacoesVO.Descricao))
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.Descricao"));
			if (string.IsNullOrEmpty(formacoesVO.Instituicao))
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.Instituicao"));
			if (formacoesVO.PeridoDe == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.PeridoDe"));
			if (formacoesVO.PeriodoAte == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Formacoes.PeriodoAte"));
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
