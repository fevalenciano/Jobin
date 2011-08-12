namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class MensagensVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdMensagem { get; set; }

		[DataMember]
		public string Mensagem { get; set; }

		[DataMember]
		public int? IdUsuarioOrigem { get; set; }

		[DataMember]
		public int? IdUsuarioDestino { get; set; }

		#region Comparadores
		public static bool operator ==(MensagensVO a, MensagensVO b)
		{
			if ( Object.ReferenceEquals(a, b)) // Optimization for a common success case.
				return true;
			else if (Object.ReferenceEquals(a, null) ^ Object.ReferenceEquals(b, null))
				return false;
			else if (Object.ReferenceEquals(a, null) && Object.ReferenceEquals(b, null))
				return true;
			else
			{
				bool resultEqual = true;
				resultEqual = resultEqual && ((a.IdMensagem == null && b.IdMensagem == null) || (a.IdMensagem == b.IdMensagem));
				resultEqual = resultEqual && ((a.Mensagem == null && b.Mensagem == null) || (a.Mensagem == b.Mensagem));
				resultEqual = resultEqual && ((a.IdUsuarioOrigem == null && b.IdUsuarioOrigem == null) || (a.IdUsuarioOrigem == b.IdUsuarioOrigem));
				resultEqual = resultEqual && ((a.IdUsuarioDestino == null && b.IdUsuarioDestino == null) || (a.IdUsuarioDestino == b.IdUsuarioDestino));
				return resultEqual;
			}
		}

		public static bool operator !=(MensagensVO a, MensagensVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			MensagensVO typedInstance = obj as MensagensVO;
			if (obj == null)
				return false;
			else
				return (this == typedInstance);
		}

 		public int GetHashCode(Object obj)
 		{
  			return obj.GetHashCode();
 		}

		#endregion
	}

	public class MensagensVOCollection : List<MensagensVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
