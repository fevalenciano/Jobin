namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class TelefonesVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdTelefone { get; set; }

		[DataMember]
		public int? IdUsuario { get; set; }

		[DataMember]
		public string Telefone { get; set; }

		#region Comparadores
		public static bool operator ==(TelefonesVO a, TelefonesVO b)
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
				resultEqual = resultEqual && ((a.IdTelefone == null && b.IdTelefone == null) || (a.IdTelefone == b.IdTelefone));
				resultEqual = resultEqual && ((a.IdUsuario == null && b.IdUsuario == null) || (a.IdUsuario == b.IdUsuario));
				resultEqual = resultEqual && ((a.Telefone == null && b.Telefone == null) || (a.Telefone == b.Telefone));
				return resultEqual;
			}
		}

		public static bool operator !=(TelefonesVO a, TelefonesVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			TelefonesVO typedInstance = obj as TelefonesVO;
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

	public class TelefonesVOCollection : List<TelefonesVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
