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
	public partial class PessoaFisica : IEqualityComparer<PessoaFisica>
	{
		private PessoaFisicaVO valueObject;

		internal bool _isChanged = false;
		public PessoaFisica(PessoaFisicaVO vo) : this()
		{
			this.valueObject = vo;
		}
		public PessoaFisica()
		{
			this.valueObject = new PessoaFisicaVO();
			this.valueObject.IsPersisted = false;
			PessoaFisicaPartial();
		}
		partial void PessoaFisicaPartial();

		private static PessoaFisicaFactory factoryInstance = null;
		public static PessoaFisicaFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<PessoaFisicaFactory>();
				return factoryInstance;
			}
		}
		private static PessoaFisicaFactory factoryInstanceNoCache = null;
		public static PessoaFisicaFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<PessoaFisicaFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static PessoaFisicaTransaction transactionInstance = null;
		public static PessoaFisicaTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<PessoaFisicaTransaction>();
				return transactionInstance;
			}
		}

		internal PessoaFisicaVO ValueObject
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
		public int? IdPessoaFisica
		{
			get
			{
				return this.valueObject.IdPessoaFisica;
			}
			set
			{
				_isChanged |= (valueObject.IdPessoaFisica != value);
				this.valueObject.IdPessoaFisica = value;
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
		public string CPF
		{
			get
			{
				return this.valueObject.CPF;
			}
			set
			{
				_isChanged |= (valueObject.CPF != value);
				this.valueObject.CPF = value;
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
				if (IdFormacao != value)
					this._formacoes = null;
				_isChanged |= (valueObject.IdFormacao != value);
				this.valueObject.IdFormacao = value;
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
				if (IdExperiencia != value)
					this._experiencia = null;
				_isChanged |= (valueObject.IdExperiencia != value);
				this.valueObject.IdExperiencia = value;
			}
		}
		private Experiencia _experiencia = null;
		public Experiencia Experiencia
		{
			get
			{
				if (IdExperiencia == null) return null;
				if (_experiencia == null)
				  _experiencia = Experiencia.FactoryInstance.Get(IdExperiencia.Value);
				return _experiencia;
			}
			set
			{
				_experiencia = value;
				if (value == null)
					this.IdExperiencia = null;
				else
					this.IdExperiencia = value.IdExperiencia;
			}
		}
		private Formacoes _formacoes = null;
		public Formacoes Formacoes
		{
			get
			{
				if (IdFormacao == null) return null;
				if (_formacoes == null)
				  _formacoes = Formacoes.FactoryInstance.Get(IdFormacao.Value);
				return _formacoes;
			}
			set
			{
				_formacoes = value;
				if (value == null)
					this.IdFormacao = null;
				else
					this.IdFormacao = value.IdFormacao;
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
		public static bool operator ==(PessoaFisica a, PessoaFisica b)
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

		public static bool operator !=(PessoaFisica a, PessoaFisica b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			PessoaFisica typedInstance = obj as PessoaFisica;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdPessoaFisica == null) return 0;
			else return valueObject.IdPessoaFisica.GetHashCode();
		}

		#region IEqualityComparer<PessoaFisica> Members
		public bool Equals(PessoaFisica x, PessoaFisica y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(PessoaFisica obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class PessoaFisicaCollection : List<PessoaFisica>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public PessoaFisicaCollection() { }
		public PessoaFisicaCollection(IEnumerable<PessoaFisica> collection) : base(collection) { }
		public PessoaFisicaCollection(PessoaFisicaVOCollection dataCollection)
		{
			foreach (PessoaFisicaVO item in dataCollection)
			{
				this.Add(PessoaFisica.FactoryInstance.NewPessoaFisica(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public PessoaFisicaVOCollection DataCollection
		{
			get
			{
				PessoaFisicaVOCollection dataCollection = new PessoaFisicaVOCollection();
				foreach (PessoaFisica item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class PessoaFisicaFactory : ESContextBoundObject
	{
		public PessoaFisicaFactory()
		{
			
		}

		public PessoaFisicaFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public PessoaFisica NewPessoaFisica()
		{
			return new PessoaFisica();
		}
		internal PessoaFisica NewPessoaFisica(PessoaFisicaVO vo)
		{
			return new PessoaFisica(vo);
		}

		[Cache("Jobin.Model")]
		public PessoaFisica Get(int idPessoaFisica)
		{
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			PessoaFisicaVO vo = dalc.Get(idPessoaFisica);
			if (vo != null) return NewPessoaFisica(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public PessoaFisicaCollection GetAll()
		{
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			return new PessoaFisicaCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public PessoaFisicaCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public PessoaFisicaCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			PessoaFisicaCollection list = new PessoaFisicaCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public PessoaFisicaCollection GetByExperiencia(int idExperiencia)
		{
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			return new PessoaFisicaCollection(dalc.GetByExperiencia(idExperiencia));
		}
		public PessoaFisicaCollection GetByFormacoes(int idFormacao)
		{
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			return new PessoaFisicaCollection(dalc.GetByFormacoes(idFormacao));
		}
		public PessoaFisicaCollection GetByFornecedores(int idFornecedor)
		{
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			return new PessoaFisicaCollection(dalc.GetByFornecedores(idFornecedor));
		}
	}

	[Serializable]
	public partial class PessoaFisicaTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(PessoaFisica bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(PessoaFisicaVO pessoaFisicaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(pessoaFisicaVO, false);
			ValidateInsertPartial(pessoaFisicaVO);

			return ex;
		}
		partial void ValidateInsertPartial(PessoaFisicaVO pessoaFisicaVO);
		public ValidationException ValidateUpdate(PessoaFisicaVO pessoaFisicaVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(pessoaFisicaVO, true);
			ValidateUpdatePartial(pessoaFisicaVO);

			return ex;
		}
		partial void ValidateUpdatePartial(PessoaFisicaVO pessoaFisicaVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(PessoaFisica bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdPessoaFisica);
			ThrowIfError();
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			dalc.Delete(bo.IdPessoaFisica.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idPessoaFisica)
		{
			ClearErrors();
			RemoveValidationPartial(idPessoaFisica);
			ThrowIfError();
			IPessoaFisicaDalc dalc = DataStore.Factory.Get().Resolve<IPessoaFisicaDalc>();
			dalc.Delete(idPessoaFisica);
		}
		public ValidationException RemoveValidation(int? idPessoaFisica)
		{
			ClearErrors();
			if (idPessoaFisica == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.IdPessoaFisica"));

			RemoveValidationPartial(idPessoaFisica);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idPessoaFisica);
		public ValidationException ValidateAttributesNotNull(PessoaFisicaVO pessoaFisicaVO, bool validateGuidOnPK)
		{
			if (pessoaFisicaVO.IdPessoaFisica == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.IdPessoaFisica"));
			if (pessoaFisicaVO.IdFornecedor == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.IdFornecedor"));
			if (string.IsNullOrEmpty(pessoaFisicaVO.CPF))
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.CPF"));
			if (pessoaFisicaVO.IdFormacao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.IdFormacao"));
			if (pessoaFisicaVO.IdExperiencia == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("PessoaFisica.IdExperiencia"));
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
