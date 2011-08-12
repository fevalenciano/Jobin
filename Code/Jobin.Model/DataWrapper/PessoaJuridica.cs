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
	public partial class PessoaJuridica : IEqualityComparer<PessoaJuridica>
	{
		private PessoaJuridicaVO valueObject;

		internal bool _isChanged = false;
		public PessoaJuridica(PessoaJuridicaVO vo) : this()
		{
			this.valueObject = vo;
		}
		public PessoaJuridica()
		{
			this.valueObject = new PessoaJuridicaVO();
			this.valueObject.IsPersisted = false;
			PessoaJuridicaPartial();
		}
		partial void PessoaJuridicaPartial();

		private static PessoaJuridicaFactory factoryInstance = null;
		public static PessoaJuridicaFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<PessoaJuridicaFactory>();
				return factoryInstance;
			}
		}
		private static PessoaJuridicaFactory factoryInstanceNoCache = null;
		public static PessoaJuridicaFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<PessoaJuridicaFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static PessoaJuridicaTransaction transactionInstance = null;
		public static PessoaJuridicaTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<PessoaJuridicaTransaction>();
				return transactionInstance;
			}
		}

		internal PessoaJuridicaVO ValueObject
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
		public int? IdPessoaJuridica
		{
			get
			{
				return this.valueObject.IdPessoaJuridica;
			}
			set
			{
				_isChanged |= (valueObject.IdPessoaJuridica != value);
				this.valueObject.IdPessoaJuridica = value;
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
		public string CNPJ
		{
			get
			{
				return this.valueObject.CNPJ;
			}
			set
			{
				_isChanged |= (valueObject.CNPJ != value);
				this.valueObject.CNPJ = value;
			}
		}
		public string RazaoSocial
		{
			get
			{
				return this.valueObject.RazaoSocial;
			}
			set
			{
				_isChanged |= (valueObject.RazaoSocial != value);
				this.valueObject.RazaoSocial = value;
			}
		}
		public string Site
		{
			get
			{
				return this.valueObject.Site;
			}
			set
			{
				_isChanged |= (valueObject.Site != value);
				this.valueObject.Site = value;
			}
		}
		public string Responsavel
		{
			get
			{
				return this.valueObject.Responsavel;
			}
			set
			{
				_isChanged |= (valueObject.Responsavel != value);
				this.valueObject.Responsavel = value;
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
		#region Comparadores
		public static bool operator ==(PessoaJuridica a, PessoaJuridica b)
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

		public static bool operator !=(PessoaJuridica a, PessoaJuridica b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			PessoaJuridica typedInstance = obj as PessoaJuridica;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdPessoaJuridica == null) return 0;
			else return valueObject.IdPessoaJuridica.GetHashCode();
		}

		#region IEqualityComparer<PessoaJuridica> Members
		public bool Equals(PessoaJuridica x, PessoaJuridica y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(PessoaJuridica obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class PessoaJuridicaCollection : List<PessoaJuridica>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public PessoaJuridicaCollection() { }
		public PessoaJuridicaCollection(IEnumerable<PessoaJuridica> collection) : base(collection) { }
		public PessoaJuridicaCollection(PessoaJuridicaVOCollection dataCollection)
		{
			foreach (PessoaJuridicaVO item in dataCollection)
			{
				this.Add(PessoaJuridica.FactoryInstance.NewPessoaJuridica(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public PessoaJuridicaVOCollection DataCollection
		{
			get
			{
				PessoaJuridicaVOCollection dataCollection = new PessoaJuridicaVOCollection();
				foreach (PessoaJuridica item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class PessoaJuridicaFactory : ESContextBoundObject
	{
		public PessoaJuridicaFactory()
		{
			
		}

		public PessoaJuridicaFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public PessoaJuridica NewPessoaJuridica()
		{
			return new PessoaJuridica();
		}
		internal PessoaJuridica NewPessoaJuridica(PessoaJuridicaVO vo)
		{
			return new PessoaJuridica(vo);
		}

		[Cache("Jobin.Model")]
		public PessoaJuridica Get(int idPessoaJuridica)
		{
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			PessoaJuridicaVO vo = dalc.Get(idPessoaJuridica);
			if (vo != null) return NewPessoaJuridica(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public PessoaJuridicaCollection GetAll()
		{
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			return new PessoaJuridicaCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public PessoaJuridicaCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public PessoaJuridicaCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			PessoaJuridicaCollection list = new PessoaJuridicaCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public PessoaJuridicaCollection GetByFornecedores(int idFornecedor)
		{
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			return new PessoaJuridicaCollection(dalc.GetByFornecedores(idFornecedor));
		}
	}

	[Serializable]
	public partial class PessoaJuridicaTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(PessoaJuridica bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(PessoaJuridicaVO pessoaJuridicaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(pessoaJuridicaVO, false);
			ValidateInsertPartial(pessoaJuridicaVO);

			return ex;
		}
		partial void ValidateInsertPartial(PessoaJuridicaVO pessoaJuridicaVO);
		public ValidationException ValidateUpdate(PessoaJuridicaVO pessoaJuridicaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(pessoaJuridicaVO, true);
			ValidateUpdatePartial(pessoaJuridicaVO);

			return ex;
		}
		partial void ValidateUpdatePartial(PessoaJuridicaVO pessoaJuridicaVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(PessoaJuridica bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdPessoaJuridica);
			ThrowIfError();
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			dalc.Delete(bo.IdPessoaJuridica.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idPessoaJuridica)
		{
			ClearErrors();
			RemoveValidationPartial(idPessoaJuridica);
			ThrowIfError();
			IPessoaJuridicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaJuridicaDalc>();
			dalc.Delete(idPessoaJuridica);
		}
		public ValidationException RemoveValidation(int? idPessoaJuridica)
		{
			ClearErrors();
			if (idPessoaJuridica == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.IdPessoaJuridica"));

			RemoveValidationPartial(idPessoaJuridica);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idPessoaJuridica);
		public ValidationException ValidateAttributesNotNull(PessoaJuridicaVO pessoaJuridicaVO, bool validateGuidOnPK)
		{
			if (pessoaJuridicaVO.IdPessoaJuridica == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.IdPessoaJuridica"));
			if (pessoaJuridicaVO.IdFornecedor == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.IdFornecedor"));
			if (string.IsNullOrEmpty(pessoaJuridicaVO.CNPJ))
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.CNPJ"));
			if (string.IsNullOrEmpty(pessoaJuridicaVO.RazaoSocial))
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.RazaoSocial"));
			if (string.IsNullOrEmpty(pessoaJuridicaVO.Site))
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.Site"));
			if (string.IsNullOrEmpty(pessoaJuridicaVO.Responsavel))
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaJuridica.Responsavel"));
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
