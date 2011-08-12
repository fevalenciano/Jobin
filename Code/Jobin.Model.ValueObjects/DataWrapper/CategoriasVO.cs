namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class CategoriasVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdCategoria { get; set; }

		[DataMember]
		public int? IdSegmento { get; set; }

		[DataMember]
		public string Nome { get; set; }

		#region Comparadores
		public static bool operator ==(CategoriasVO a, CategoriasVO b)
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
				resultEqual = resultEqual && ((a.IdCategoria == null && b.IdCategoria == null) || (a.IdCategoria == b.IdCategoria));
				resultEqual = resultEqual && ((a.IdSegmento == null && b.IdSegmento == null) || (a.IdSegmento == b.IdSegmento));
				resultEqual = resultEqual && ((a.Nome == null && b.Nome == null) || (a.Nome == b.Nome));
				return resultEqual;
			}
		}

		public static bool operator !=(CategoriasVO a, CategoriasVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			CategoriasVO typedInstance = obj as CategoriasVO;
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

	public class CategoriasVOCollection : List<CategoriasVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
