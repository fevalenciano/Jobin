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
	public partial class Fornecedores : IEqualityComparer<Fornecedores>
	{
		private FornecedoresVO valueObject;

		internal bool _isChanged = false;
		public Fornecedores(FornecedoresVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Fornecedores()
		{
			this.valueObject = new FornecedoresVO();
			this.valueObject.IsPersisted = false;
			FornecedoresPartial();
		}
		partial void FornecedoresPartial();

		private static FornecedoresFactory factoryInstance = null;
		public static FornecedoresFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<FornecedoresFactory>();
				return factoryInstance;
			}
		}
		private static FornecedoresFactory factoryInstanceNoCache = null;
		public static FornecedoresFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<FornecedoresFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static FornecedoresTransaction transactionInstance = null;
		public static FornecedoresTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<FornecedoresTransaction>();
				return transactionInstance;
			}
		}

		internal FornecedoresVO ValueObject
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
		public int? IdFornecedor
		{
			get
			{
				return this.valueObject.IdFornecedor;
			}
			set
			{
				_isChanged |= (valueObject.IdFornecedor != value);
				this.valueObject.IdFornecedor = value;
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
		public int? IdEndereco
		{
			get
			{
				return this.valueObject.IdEndereco;
			}
			set
			{
				if (IdEndereco != value)
					this._endereco = null;
				_isChanged |= (valueObject.IdEndereco != value);
				this.valueObject.IdEndereco = value;
			}
		}
		private Endereco _endereco = null;
		public Endereco Endereco
		{
			get
			{
				if (IdEndereco == null) return null;
				if (_endereco == null)
				  _endereco = Endereco.FactoryInstance.Get(IdEndereco.Value);
				return _endereco;
			}
			set
			{
				_endereco = value;
				if (value == null)
					this.IdEndereco = null;
				else
					this.IdEndereco = value.IdEndereco;
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
					return Oportunidades.FactoryInstance.GetByFornecedores(this.valueObject.IdFornecedor.Value);
				return _oportunidadess;
			}
			set
			{
				_oportunidadess = value;
			}
		}

		private PessoaFisicaCollection _pessoafisicas = null;
		public PessoaFisicaCollection PessoaFisicas
		{
			get
			{
				if (_pessoafisicas == null)
					return PessoaFisica.FactoryInstance.GetByFornecedores(this.valueObject.IdFornecedor.Value);
				return _pessoafisicas;
			}
			set
			{
				_pessoafisicas = value;
			}
		}

		private PessoaJuridicaCollection _pessoajuridicas = null;
		public PessoaJuridicaCollection PessoaJuridicas
		{
			get
			{
				if (_pessoajuridicas == null)
					return PessoaJuridica.FactoryInstance.GetByFornecedores(this.valueObject.IdFornecedor.Value);
				return _pessoajuridicas;
			}
			set
			{
				_pessoajuridicas = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Fornecedores a, Fornecedores b)
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

		public static bool operator !=(Fornecedores a, Fornecedores b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Fornecedores typedInstance = obj as Fornecedores;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdFornecedor == null) return 0;
			else return valueObject.IdFornecedor.GetHashCode();
		}

		#region IEqualityComparer<Fornecedores> Members
		public bool Equals(Fornecedores x, Fornecedores y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Fornecedores obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class FornecedoresCollection : List<Fornecedores>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public FornecedoresCollection() { }
		public FornecedoresCollection(IEnumerable<Fornecedores> collection) : base(collection) { }
		public FornecedoresCollection(FornecedoresVOCollection dataCollection)
		{
			foreach (FornecedoresVO item in dataCollection)
			{
				this.Add(Fornecedores.FactoryInstance.NewFornecedores(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public FornecedoresVOCollection DataCollection
		{
			get
			{
				FornecedoresVOCollection dataCollection = new FornecedoresVOCollection();
				foreach (Fornecedores item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class FornecedoresFactory : ESContextBoundObject
	{
		public FornecedoresFactory()
		{
			
		}

		public FornecedoresFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Fornecedores NewFornecedores()
		{
			return new Fornecedores();
		}
		internal Fornecedores NewFornecedores(FornecedoresVO vo)
		{
			return new Fornecedores(vo);
		}

		[Cache("Jobin.Model")]
		public Fornecedores Get(int idFornecedor)
		{
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			FornecedoresVO vo = dalc.Get(idFornecedor);
			if (vo != null) return NewFornecedores(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public FornecedoresCollection GetAll()
		{
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			return new FornecedoresCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public FornecedoresCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public FornecedoresCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			FornecedoresCollection list = new FornecedoresCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public FornecedoresCollection GetByEndereco(int idEndereco)
		{
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			return new FornecedoresCollection(dalc.GetByEndereco(idEndereco));
		}
		public FornecedoresCollection GetByUsuarios(int idUsuario)
		{
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			return new FornecedoresCollection(dalc.GetByUsuarios(idUsuario));
		}
	}

	[Serializable]
	public partial class FornecedoresTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Fornecedores bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(FornecedoresVO fornecedoresVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(fornecedoresVO, false);
			ValidateInsertPartial(fornecedoresVO);

			return ex;
		}
		partial void ValidateInsertPartial(FornecedoresVO fornecedoresVO);
		public ValidationException ValidateUpdate(FornecedoresVO fornecedoresVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(fornecedoresVO, true);
			ValidateUpdatePartial(fornecedoresVO);

			return ex;
		}
		partial void ValidateUpdatePartial(FornecedoresVO fornecedoresVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Fornecedores bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdFornecedor);
			ThrowIfError();
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			dalc.Delete(bo.IdFornecedor.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idFornecedor)
		{
			ClearErrors();
			RemoveValidationPartial(idFornecedor);
			ThrowIfError();
			IFornecedoresDalc dalc = DataStore.Factory.Get().Resolve<IFornecedoresDalc>();
			dalc.Delete(idFornecedor);
		}
		public ValidationException RemoveValidation(int? idFornecedor)
		{
			ClearErrors();
			if (idFornecedor == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Fornecedores.IdFornecedor"));

			RemoveValidationPartial(idFornecedor);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idFornecedor);
		public ValidationException ValidateAttributesNotNull(FornecedoresVO fornecedoresVO, bool validateGuidOnPK)
		{
			if (fornecedoresVO.IdFornecedor == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Fornecedores.IdFornecedor"));
			if (fornecedoresVO.IdUsuario == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Fornecedores.IdUsuario"));
			if (fornecedoresVO.IdEndereco == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Fornecedores.IdEndereco"));
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
