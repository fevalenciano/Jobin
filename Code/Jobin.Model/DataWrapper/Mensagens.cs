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
	public partial class Mensagens : IEqualityComparer<Mensagens>
	{
		private MensagensVO valueObject;

		internal bool _isChanged = false;
		public Mensagens(MensagensVO vo) : this()
		{
			this.valueObject = vo;
		}
		public Mensagens()
		{
			this.valueObject = new MensagensVO();
			this.valueObject.IsPersisted = false;
			MensagensPartial();
		}
		partial void MensagensPartial();

		private static MensagensFactory factoryInstance = null;
		public static MensagensFactory FactoryInstance
		{
			get
			{
				if (factoryInstance == null) factoryInstance = PolicyInjection.Create<MensagensFactory>();
				return factoryInstance;
			}
		}
		private static MensagensFactory factoryInstanceNoCache = null;
		public static MensagensFactory FactoryInstanceNoCache
		{
			get
			{
				if (factoryInstanceNoCache == null)
					factoryInstanceNoCache = PolicyInjection.Create<MensagensFactory>(new object[]{true});
				return factoryInstanceNoCache;
			}
		}
		private static MensagensTransaction transactionInstance = null;
		public static MensagensTransaction TransactionInstance
		{
			get
			{
				if (transactionInstance == null) transactionInstance = PolicyInjection.Create<MensagensTransaction>();
				return transactionInstance;
			}
		}

		internal MensagensVO ValueObject
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
		public int? IdMensagem
		{
			get
			{
				return this.valueObject.IdMensagem;
			}
			set
			{
				_isChanged |= (valueObject.IdMensagem != value);
				this.valueObject.IdMensagem = value;
			}
		}
		public string Mensagem
		{
			get
			{
				return this.valueObject.Mensagem;
			}
			set
			{
				_isChanged |= (valueObject.Mensagem != value);
				this.valueObject.Mensagem = value;
			}
		}
		public int? IdUsuarioOrigem
		{
			get
			{
				return this.valueObject.IdUsuarioOrigem;
			}
			set
			{
				if (IdUsuarioOrigem != value)
					this._usuarios = null;
				_isChanged |= (valueObject.IdUsuarioOrigem != value);
				this.valueObject.IdUsuarioOrigem = value;
			}
		}
		public int? IdUsuarioDestino
		{
			get
			{
				return this.valueObject.IdUsuarioDestino;
			}
			set
			{
				if (IdUsuarioDestino != value)
					this._oportunidades = null;
				_isChanged |= (valueObject.IdUsuarioDestino != value);
				this.valueObject.IdUsuarioDestino = value;
			}
		}
		private Oportunidades _oportunidades = null;
		public Oportunidades Oportunidades
		{
			get
			{
				if (IdUsuarioDestino == null) return null;
				if (_oportunidades == null)
				  _oportunidades = Oportunidades.FactoryInstance.Get(IdUsuarioDestino.Value);
				return _oportunidades;
			}
			set
			{
				_oportunidades = value;
				if (value == null)
					this.IdUsuarioDestino = null;
				else
					this.IdUsuarioDestino = value.IdOportunidade;
			}
		}
		private Usuarios _usuarios = null;
		public Usuarios Usuarios
		{
			get
			{
				if (IdUsuarioOrigem == null) return null;
				if (_usuarios == null)
				  _usuarios = Usuarios.FactoryInstance.Get(IdUsuarioOrigem.Value);
				return _usuarios;
			}
			set
			{
				_usuarios = value;
				if (value == null)
					this.IdUsuarioOrigem = null;
				else
					this.IdUsuarioOrigem = value.IdUsuario;
			}
		}
		private OportunidadesCollection _oportunidadess = null;
		public OportunidadesCollection Oportunidadess
		{
			get
			{
				if (_oportunidadess == null)
					return Oportunidades.FactoryInstance.GetByMensagens(this.valueObject.IdMensagem.Value);
				return _oportunidadess;
			}
			set
			{
				_oportunidadess = value;
			}
		}

		#region Comparadores
		public static bool operator ==(Mensagens a, Mensagens b)
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

		public static bool operator !=(Mensagens a, Mensagens b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			Mensagens typedInstance = obj as Mensagens;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}
		#endregion
		public override int GetHashCode()
		{
			if (valueObject == null || valueObject.IdMensagem == null) return 0;
			else return valueObject.IdMensagem.GetHashCode();
		}

		#region IEqualityComparer<Mensagens> Members
		public bool Equals(Mensagens x, Mensagens y)
		{
			return x.Equals(y);
		}
		public int GetHashCode(Mensagens obj)
		{
			return obj.GetHashCode();
		}
		#endregion
	}

	[Serializable]
	public partial class MensagensCollection : List<Mensagens>
	{
		public int? PageSize { get; private set; }
		public int? PageNumber { get; internal set; }
		public int TotalRows { get; private set; }

		public MensagensCollection() { }
		public MensagensCollection(IEnumerable<Mensagens> collection) : base(collection) { }
		public MensagensCollection(MensagensVOCollection dataCollection)
		{
			foreach (MensagensVO item in dataCollection)
			{
				this.Add(Mensagens.FactoryInstance.NewMensagens(item));
			}
			this.PageSize = dataCollection.PageSize;
			this.TotalRows = dataCollection.TotalRows;
		}

		public MensagensVOCollection DataCollection
		{
			get
			{
				MensagensVOCollection dataCollection = new MensagensVOCollection();
				foreach (Mensagens item in this)
				{
					dataCollection.Add(item.ValueObject);
				}
				return dataCollection;
			}
		}
	}

	[Serializable]
	public partial class MensagensFactory : ESContextBoundObject
	{
		public MensagensFactory()
		{
			
		}

		public MensagensFactory(bool cache)
		{
			Cache = cache;
		}

		private const int DEFAULT_PAGE_SIZE = 20;

		public Mensagens NewMensagens()
		{
			return new Mensagens();
		}
		internal Mensagens NewMensagens(MensagensVO vo)
		{
			return new Mensagens(vo);
		}

		[Cache("Jobin.Model")]
		public Mensagens Get(int idMensagem)
		{
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			MensagensVO vo = dalc.Get(idMensagem);
			if (vo != null) return NewMensagens(vo);
			return null;
		}
		[Cache("Jobin.Model")]
		public MensagensCollection GetAll()
		{
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			return new MensagensCollection(dalc.GetAll());
		}
		[Cache("Jobin.Model")]
		public MensagensCollection GetAllPaged(int? page)
		{
			return GetAllPaged(page, DEFAULT_PAGE_SIZE);
		}
		public MensagensCollection GetAllPaged(int? page, int pageSize)
		{
			int pageNo = page ?? 1;
			long startRowIndex = (pageNo * pageSize) - pageSize + 1;
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			MensagensCollection list = new MensagensCollection(dalc.GetAllPaged(startRowIndex, pageSize));
			list.PageNumber = pageNo;
			return list;
		}
		public MensagensCollection GetByOportunidades(int idUsuarioDestino)
		{
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			return new MensagensCollection(dalc.GetByOportunidades(idUsuarioDestino));
		}
		public MensagensCollection GetByUsuarios(int idUsuarioOrigem)
		{
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			return new MensagensCollection(dalc.GetByUsuarios(idUsuarioOrigem));
		}
	}

	[Serializable]
	public partial class MensagensTransaction : ESContextBoundObject
	{
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Save(Mensagens bo)
		{
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");

			if (!bo.ValueObject.IsPersisted)
			{
				ValidateInsert(bo.ValueObject);
				ThrowIfError();
				IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
				dalc.Insert(bo.ValueObject);
		   	    bo.ValueObject.IsPersisted = true;
			}
			else if (bo._isChanged)
			{
				ValidateUpdate(bo.ValueObject);
				ThrowIfError();
				IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
				dalc.Update(bo.ValueObject);
			}
			bo._isChanged = false;

		}
		public ValidationException ValidateInsert(MensagensVO mensagensVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(mensagensVO, false);
			ValidateInsertPartial(mensagensVO);

			return ex;
		}
		partial void ValidateInsertPartial(MensagensVO mensagensVO);
		public ValidationException ValidateUpdate(MensagensVO mensagensVO)
		{
			ClearErrors();
			ValidateAttributesNotNull(mensagensVO, true);
			ValidateUpdatePartial(mensagensVO);

			return ex;
		}
		partial void ValidateUpdatePartial(MensagensVO mensagensVO);
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(Mensagens bo)
		{
			ClearErrors();
			if (bo.ValueObject == null) throw new ValidationException("Objeto não instanciado!");
			RemoveValidation(bo.IdMensagem);
			ThrowIfError();
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			dalc.Delete(bo.IdMensagem.Value);
			bo.ValueObject = null;
		}
		[Transaction(ScopeOption = TransactionScopeOption.Required)]
		public void Remove(int idMensagem)
		{
			ClearErrors();
			RemoveValidationPartial(idMensagem);
			ThrowIfError();
			IMensagensDalc dalc = DataStore.Factory.Get().Resolve<IMensagensDalc>();
			dalc.Delete(idMensagem);
		}
		public ValidationException RemoveValidation(int? idMensagem)
		{
			ClearErrors();
			if (idMensagem == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Mensagens.IdMensagem"));

			RemoveValidationPartial(idMensagem);

			return ex;
		}
		static partial void RemoveValidationPartial(int? idMensagem);
		public ValidationException ValidateAttributesNotNull(MensagensVO mensagensVO, bool validateGuidOnPK)
		{
			if (mensagensVO.IdMensagem == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Mensagens.IdMensagem"));
			if (string.IsNullOrEmpty(mensagensVO.Mensagem))
				RegisterMessageValidationNotNull(NameConvert.GetName("Mensagens.Mensagem"));
			if (mensagensVO.IdUsuarioOrigem == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Mensagens.IdUsuarioOrigem"));
			if (mensagensVO.IdUsuarioDestino == null)
				RegisterMessageValidationNotNull(NameConvert.GetName("Mensagens.IdUsuarioDestino"));
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
