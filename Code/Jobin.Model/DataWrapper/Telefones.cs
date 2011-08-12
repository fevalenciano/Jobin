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
	public partial class Telefones : IEqualityComparer<Telefones>
	{
		private TelefonesVO valueObject;

		internal bool _isChanged = false;
		public Telefones(TelefonesVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Telefones()
		{
			this.valueObject = new TelefonesVO();
			this.valueObject.IsPersisted = false;
			TelefonesPartial();
		}
		partial void TelefonesPartial();

		private static TelefonesFactory factoryInstance = null;
		public static TelefonesFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<TelefonesFactory>();
				return factoryInstance;
			}
		}
		private static TelefonesFactory factoryInstanceNoCache = null;
		public static TelefonesFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<TelefonesFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static TelefonesTransaction transactionInstance = null;
		public static TelefonesTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<TelefonesTransaction>();
				return transactionInstance;
			}
		}

		internal TelefonesVO ValueObject
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
		public int? IdTelefone
		{
			get
			{
				return this.valueObject.IdTelefone;
			}
			set
			{
				_isChanged |= (valueObject.IdTelefone != value);
				this.valueObject.IdTelefone = value;
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
		public string Telefone
		{
			get
			{
				return this.valueObject.Telefone;
			}
			set
			{
				_isChanged |= (valueObject.Telefone != value);
				this.valueObject.Telefone = value;
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
		#region Comparadores
		public static bool operator ==(Telefones a, Telefones b)
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

		public static bool operator !=(Telefones a, Telefones b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Telefones typedInstance = obj as Telefones;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdTelefone == null) return 0;
			else return valueObject.IdTelefone.GetHashCode();
		}

		#region IEqualityComparer<Telefones> Members
		public bool Equals(Telefones x, Telefones y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Telefones obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class TelefonesCollection : List<Telefones>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public TelefonesCollection() { }
		public TelefonesCollection(IEnumerable<Telefones> collection) : base(collection) { }
		public TelefonesCollection(TelefonesVOCollection dataCollection)
		{
			foreach (TelefonesVO item in dataCollection)
			{
				this.Add(Telefones.FactoryInstance.NewTelefones(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public TelefonesVOCollection DataCollection
		{
			get
			{
				TelefonesVOCollection dataCollection = new TelefonesVOCollection();
				foreach (Telefones item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class TelefonesFactory : ESContextBoundObject
	{
		public TelefonesFactory()
		{
			
		}

		public TelefonesFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Telefones NewTelefones()
		{
			return new Telefones();
		}
		internal Telefones NewTelefones(TelefonesVO vo)
		{
			return new Telefones(vo);
		}

		[Cache("Jobin.Model")]
		public Telefones Get(int idTelefone)
		{
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			TelefonesVO vo = dalc.Get(idTelefone);
			if (vo != null) return NewTelefones(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public TelefonesCollection GetAll()
		{
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			return new TelefonesCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public TelefonesCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public TelefonesCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			TelefonesCollection list = new TelefonesCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public TelefonesCollection GetByUsuarios(int idUsuario)
		{
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			return new TelefonesCollection(dalc.GetByUsuarios(idUsuario));
		}
	}

	[Serializable]
	public partial class TelefonesTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Telefones bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(TelefonesVO telefonesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(telefonesVO, false);
			ValidateInsertPartial(telefonesVO);

			return ex;
		}
		partial void ValidateInsertPartial(TelefonesVO telefonesVO);
		public ValidationException ValidateUpdate(TelefonesVO telefonesVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(telefonesVO, true);
			ValidateUpdatePartial(telefonesVO);

			return ex;
		}
		partial void ValidateUpdatePartial(TelefonesVO telefonesVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Telefones bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdTelefone);
			ThrowIfError();
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			dalc.Delete(bo.IdTelefone.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idTelefone)
		{
			ClearErrors();
			RemoveValidationPartial(idTelefone);
			ThrowIfError();
			ITelefonesDalc dalc = DataStore.Factory.Get().Resolve<ITelefonesDalc>();
			dalc.Delete(idTelefone);
		}
		public ValidationException RemoveValidation(int? idTelefone)
		{
			ClearErrors();
			if (idTelefone == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Telefones.IdTelefone"));

			RemoveValidationPartial(idTelefone);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idTelefone);
		public ValidationException ValidateAttributesNotNull(TelefonesVO telefonesVO, bool validateGuidOnPK)
		{
			if (telefonesVO.IdTelefone == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Telefones.IdTelefone"));
			if (telefonesVO.IdUsuario == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Telefones.IdUsuario"));
			if (telefonesVO.Telefone == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Telefones.Telefone"));
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
