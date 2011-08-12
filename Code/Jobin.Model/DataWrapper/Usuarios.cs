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
	public partial class Usuarios : IEqualityComparer<Usuarios>
	{
		private UsuariosVO valueObject;

		internal bool _isChanged = false;
		public Usuarios(UsuariosVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Usuarios()
		{
			this.valueObject = new UsuariosVO();
			this.valueObject.IsPersisted = false;
			UsuariosPartial();
		}
		partial void UsuariosPartial();

		private static UsuariosFactory factoryInstance = null;
		public static UsuariosFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<UsuariosFactory>();
				return factoryInstance;
			}
		}
		private static UsuariosFactory factoryInstanceNoCache = null;
		public static UsuariosFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<UsuariosFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static UsuariosTransaction transactionInstance = null;
		public static UsuariosTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<UsuariosTransaction>();
				return transactionInstance;
			}
		}

		internal UsuariosVO ValueObject
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
		public int? IdUsuario
		{
			get
			{
				return this.valueObject.IdUsuario;
			}
			set
			{
				_isChanged |= (valueObject.IdUsuario != value);
				this.valueObject.IdUsuario = value;
			}
		}
		public string Email
		{
			get
			{
				return this.valueObject.Email;
			}
			set
			{
				_isChanged |= (valueObject.Email != value);
				this.valueObject.Email = value;
			}
		}
		public string Senha
		{
			get
			{
				return this.valueObject.Senha;
			}
			set
			{
				_isChanged |= (valueObject.Senha != value);
				this.valueObject.Senha = value;
			}
		}
		public DateTime? DataInclusao
		{
			get
			{
				return this.valueObject.DataInclusao;
			}
			set
			{
				_isChanged |= (valueObject.DataInclusao != value);
				this.valueObject.DataInclusao = value;
			}
		}
		public DateTime? DataAlteracao
		{
			get
			{
				return this.valueObject.DataAlteracao;
			}
			set
			{
				_isChanged |= (valueObject.DataAlteracao != value);
				this.valueObject.DataAlteracao = value;
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
		public string Sobrenome
		{
			get
			{
				return this.valueObject.Sobrenome;
			}
			set
			{
				_isChanged |= (valueObject.Sobrenome != value);
				this.valueObject.Sobrenome = value;
			}
		}
		private AvaliacoesCollection _avaliacoess = null;
		public AvaliacoesCollection Avaliacoess
		{
			get
			{
				if (_avaliacoess == null)
					return Avaliacoes.FactoryInstance.GetByUsuarios(this.valueObject.IdUsuario.Value);
				return _avaliacoess;
			}
			set
			{
				_avaliacoess = value;
			}
		}

		private FornecedoresCollection _fornecedoress = null;
		public FornecedoresCollection Fornecedoress
		{
			get
			{
				if (_fornecedoress == null)
					return Fornecedores.FactoryInstance.GetByUsuarios(this.valueObject.IdUsuario.Value);
				return _fornecedoress;
			}
			set
			{
				_fornecedoress = value;
			}
		}

		private MensagensCollection _mensagenss = null;
		public MensagensCollection Mensagenss
		{
			get
			{
				if (_mensagenss == null)
					return Mensagens.FactoryInstance.GetByUsuarios(this.valueObject.IdUsuario.Value);
				return _mensagenss;
			}
			set
			{
				_mensagenss = value;
			}
		}

		private TelefonesCollection _telefoness = null;
		public TelefonesCollection Telefoness
		{
			get
			{
				if (_telefoness == null)
					return Telefones.FactoryInstance.GetByUsuarios(this.valueObject.IdUsuario.Value);
				return _telefoness;
			}
			set
			{
				_telefoness = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Usuarios a, Usuarios b)
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

		public static bool operator !=(Usuarios a, Usuarios b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Usuarios typedInstance = obj as Usuarios;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdUsuario == null) return 0;
			else return valueObject.IdUsuario.GetHashCode();
		}

		#region IEqualityComparer<Usuarios> Members
		public bool Equals(Usuarios x, Usuarios y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Usuarios obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class UsuariosCollection : List<Usuarios>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public UsuariosCollection() { }
		public UsuariosCollection(IEnumerable<Usuarios> collection) : base(collection) { }
		public UsuariosCollection(UsuariosVOCollection dataCollection)
		{
			foreach (UsuariosVO item in dataCollection)
			{
				this.Add(Usuarios.FactoryInstance.NewUsuarios(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public UsuariosVOCollection DataCollection
		{
			get
			{
				UsuariosVOCollection dataCollection = new UsuariosVOCollection();
				foreach (Usuarios item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class UsuariosFactory : ESContextBoundObject
	{
		public UsuariosFactory()
		{
			
		}

		public UsuariosFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Usuarios NewUsuarios()
		{
			return new Usuarios();
		}
		internal Usuarios NewUsuarios(UsuariosVO vo)
		{
			return new Usuarios(vo);
		}

		[Cache("Jobin.Model")]
		public Usuarios Get(int idUsuario)
		{
			IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
			UsuariosVO vo = dalc.Get(idUsuario);
			if (vo != null) return NewUsuarios(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public UsuariosCollection GetAll()
		{
			IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
			return new UsuariosCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public UsuariosCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public UsuariosCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
			UsuariosCollection list = new UsuariosCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
	}

	[Serializable]
	public partial class UsuariosTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Usuarios bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
				bo.ValueObject = dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(UsuariosVO usuariosVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(usuariosVO, false);
			ValidateInsertPartial(usuariosVO);

			return ex;
		}
		partial void ValidateInsertPartial(UsuariosVO usuariosVO);
		public ValidationException ValidateUpdate(UsuariosVO usuariosVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(usuariosVO, true);
			ValidateUpdatePartial(usuariosVO);

			return ex;
		}
		partial void ValidateUpdatePartial(UsuariosVO usuariosVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Usuarios bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdUsuario);
			ThrowIfError();
			IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
			dalc.Delete(bo.IdUsuario.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idUsuario)
		{
			ClearErrors();
			RemoveValidationPartial(idUsuario);
			ThrowIfError();
			IUsuariosDalc dalc = DataStore.Factory.Get().Resolve<IUsuariosDalc>();
			dalc.Delete(idUsuario);
		}
		public ValidationException RemoveValidation(int? idUsuario)
		{
			ClearErrors();
			if (idUsuario == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.IdUsuario"));

			RemoveValidationPartial(idUsuario);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idUsuario);
		public ValidationException ValidateAttributesNotNull(UsuariosVO usuariosVO, bool validateGuidOnPK)
		{
			if (usuariosVO.IdUsuario == null && (validateGuidOnPK))
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.IdUsuario"));
			if (string.IsNullOrEmpty(usuariosVO.Email))
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.Email"));
			if (string.IsNullOrEmpty(usuariosVO.Senha))
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.Senha"));
			if (usuariosVO.DataInclusao == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.DataInclusao"));
			if (string.IsNullOrEmpty(usuariosVO.Nome))
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.Nome"));
			if (string.IsNullOrEmpty(usuariosVO.Sobrenome))
				RegisterMessageValidationNotNull(NameConvert.GetName("Usuarios.Sobrenome"));
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
