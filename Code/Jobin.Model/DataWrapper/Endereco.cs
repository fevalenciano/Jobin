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
	public partial class Endereco : IEqualityComparer<Endereco>
	{
		private EnderecoVO valueObject;

		internal bool _isChanged = false;
		public Endereco(EnderecoVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Endereco()
		{
			this.valueObject = new EnderecoVO();
			this.valueObject.IsPersisted = false;
			EnderecoPartial();
		}
		partial void EnderecoPartial();

		private static EnderecoFactory factoryInstance = null;
		public static EnderecoFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<EnderecoFactory>();
				return factoryInstance;
			}
		}
		private static EnderecoFactory factoryInstanceNoCache = null;
		public static EnderecoFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<EnderecoFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static EnderecoTransaction transactionInstance = null;
		public static EnderecoTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<EnderecoTransaction>();
				return transactionInstance;
			}
		}

		internal EnderecoVO ValueObject
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
		public int? IdEndereco
		{
			get
			{
				return this.valueObject.IdEndereco;
			}
			set
			{
				_isChanged |= (valueObject.IdEndereco != value);
				this.valueObject.IdEndereco = value;
			}
		}
		public string Logradouro
		{
			get
			{
				return this.valueObject.Logradouro;
			}
			set
			{
				_isChanged |= (valueObject.Logradouro != value);
				this.valueObject.Logradouro = value;
			}
		}
		public string Complemento
		{
			get
			{
				return this.valueObject.Complemento;
			}
			set
			{
				_isChanged |= (valueObject.Complemento != value);
				this.valueObject.Complemento = value;
			}
		}
		public string Numero
		{
			get
			{
				return this.valueObject.Numero;
			}
			set
			{
				_isChanged |= (valueObject.Numero != value);
				this.valueObject.Numero = value;
			}
		}
		public string Estado
		{
			get
			{
				return this.valueObject.Estado;
			}
			set
			{
				_isChanged |= (valueObject.Estado != value);
				this.valueObject.Estado = value;
			}
		}
		public string Cidade
		{
			get
			{
				return this.valueObject.Cidade;
			}
			set
			{
				_isChanged |= (valueObject.Cidade != value);
				this.valueObject.Cidade = value;
			}
		}
		public string CEP
		{
			get
			{
				return this.valueObject.CEP;
			}
			set
			{
				_isChanged |= (valueObject.CEP != value);
				this.valueObject.CEP = value;
			}
		}
		public string Bairro
		{
			get
			{
				return this.valueObject.Bairro;
			}
			set
			{
				_isChanged |= (valueObject.Bairro != value);
				this.valueObject.Bairro = value;
			}
		}
		private FornecedoresCollection _fornecedoress = null;
		public FornecedoresCollection Fornecedoress
		{
			get
			{
				if (_fornecedoress == null)
					return Fornecedores.FactoryInstance.GetByEndereco(this.valueObject.IdEndereco.Value);
				return _fornecedoress;
			}
			set
			{
				_fornecedoress = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Endereco a, Endereco b)
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

		public static bool operator !=(Endereco a, Endereco b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Endereco typedInstance = obj as Endereco;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdEndereco == null) return 0;
			else return valueObject.IdEndereco.GetHashCode();
		}

		#region IEqualityComparer<Endereco> Members
		public bool Equals(Endereco x, Endereco y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Endereco obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class EnderecoCollection : List<Endereco>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public EnderecoCollection() { }
		public EnderecoCollection(IEnumerable<Endereco> collection) : base(collection) { }
		public EnderecoCollection(EnderecoVOCollection dataCollection)
		{
			foreach (EnderecoVO item in dataCollection)
			{
				this.Add(Endereco.FactoryInstance.NewEndereco(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public EnderecoVOCollection DataCollection
		{
			get
			{
				EnderecoVOCollection dataCollection = new EnderecoVOCollection();
				foreach (Endereco item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class EnderecoFactory : ESContextBoundObject
	{
		public EnderecoFactory()
		{
			
		}

		public EnderecoFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Endereco NewEndereco()
		{
			return new Endereco();
		}
		internal Endereco NewEndereco(EnderecoVO vo)
		{
			return new Endereco(vo);
		}

		[Cache("Jobin.Model")]
		public Endereco Get(int idEndereco)
		{
			IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
			EnderecoVO vo = dalc.Get(idEndereco);
			if (vo != null) return NewEndereco(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public EnderecoCollection GetAll()
		{
			IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
			return new EnderecoCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public EnderecoCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public EnderecoCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
			EnderecoCollection list = new EnderecoCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class EnderecoTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Endereco bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(EnderecoVO enderecoVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(enderecoVO, false);
			ValidateInsertPartial(enderecoVO);

			return ex;
		}
		partial void ValidateInsertPartial(EnderecoVO enderecoVO);
		public ValidationException ValidateUpdate(EnderecoVO enderecoVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(enderecoVO, true);
			ValidateUpdatePartial(enderecoVO);

			return ex;
		}
		partial void ValidateUpdatePartial(EnderecoVO enderecoVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Endereco bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdEndereco);
			ThrowIfError();
			IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
			dalc.Delete(bo.IdEndereco.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idEndereco)
		{
			ClearErrors();
			RemoveValidationPartial(idEndereco);
			ThrowIfError();
			IEnderecoDalc dalc = DataStore.Factory.Get().Resolve<IEnderecoDalc>();
			dalc.Delete(idEndereco);
		}
		public ValidationException RemoveValidation(int? idEndereco)
		{
			ClearErrors();
			if (idEndereco == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.IdEndereco"));

			RemoveValidationPartial(idEndereco);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idEndereco);
		public ValidationException ValidateAttributesNotNull(EnderecoVO enderecoVO, bool validateGuidOnPK)
		{
			if (enderecoVO.IdEndereco == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.IdEndereco"));
			if (string.IsNullOrEmpty(enderecoVO.Logradouro))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.Logradouro"));
			if (string.IsNullOrEmpty(enderecoVO.Numero))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.Numero"));
			if (string.IsNullOrEmpty(enderecoVO.Estado))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.Estado"));
			if (string.IsNullOrEmpty(enderecoVO.Cidade))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.Cidade"));
			if (string.IsNullOrEmpty(enderecoVO.CEP))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.CEP"));
			if (string.IsNullOrEmpty(enderecoVO.Bairro))
				RegisterMessageValidationNotNull(NameConvert.GetName("Endereco.Bairro"));
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
