namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class AvaliacoesVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdAvaliacao { get; set; }

		[DataMember]
		public int? IdUsuario { get; set; }

		[DataMember]
		public bool? TipoAvaliacao { get; set; }

		[DataMember]
		public DateTime? DataAvaliacao { get; set; }

		#region Comparadores
		public static bool operator ==(AvaliacoesVO a, AvaliacoesVO b)
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
				resultEqual = resultEqual && ((a.IdAvaliacao == null && b.IdAvaliacao == null) || (a.IdAvaliacao == b.IdAvaliacao));
				resultEqual = resultEqual && ((a.IdUsuario == null && b.IdUsuario == null) || (a.IdUsuario == b.IdUsuario));
				resultEqual = resultEqual && ((a.TipoAvaliacao == null && b.TipoAvaliacao == null) || (a.TipoAvaliacao == b.TipoAvaliacao));
				resultEqual = resultEqual && ((a.DataAvaliacao == null && b.DataAvaliacao == null) || (a.DataAvaliacao == b.DataAvaliacao));
				return resultEqual;
			}
		}

		public static bool operator !=(AvaliacoesVO a, AvaliacoesVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			AvaliacoesVO typedInstance = obj as AvaliacoesVO;
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

	public class AvaliacoesVOCollection : List<AvaliacoesVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
