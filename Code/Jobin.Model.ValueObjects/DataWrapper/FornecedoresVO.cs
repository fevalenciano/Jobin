namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class FornecedoresVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdFornecedor { get; set; }

		[DataMember]
		public int? IdUsuario { get; set; }

		[DataMember]
		public int? IdEndereco { get; set; }

		#region Comparadores
		public static bool operator ==(FornecedoresVO a, FornecedoresVO b)
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
				resultEqual = resultEqual && ((a.IdFornecedor == null && b.IdFornecedor == null) || (a.IdFornecedor == b.IdFornecedor));
				resultEqual = resultEqual && ((a.IdUsuario == null && b.IdUsuario == null) || (a.IdUsuario == b.IdUsuario));
				resultEqual = resultEqual && ((a.IdEndereco == null && b.IdEndereco == null) || (a.IdEndereco == b.IdEndereco));
				return resultEqual;
			}
		}

		public static bool operator !=(FornecedoresVO a, FornecedoresVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			FornecedoresVO typedInstance = obj as FornecedoresVO;
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

	public class FornecedoresVOCollection : List<FornecedoresVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
