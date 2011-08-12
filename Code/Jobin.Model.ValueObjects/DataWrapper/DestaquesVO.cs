namespace Jobin.Model.ValueObjects
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Runtime.Serialization;

	[DataContract]
	[Serializable]
	public class DestaquesVO
	{
		[DataMember]
		public bool IsPersisted { get; set; }
		public bool IsRemoved { get; set; }

		[DataMember]
		public int? IdDestaque { get; set; }

		[DataMember]
		public string Destaque { get; set; }

		[DataMember]
		public string DescricaoSimples { get; set; }

		[DataMember]
		public string DescricaoComplexa { get; set; }

		#region Comparadores
		public static bool operator ==(DestaquesVO a, DestaquesVO b)
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
				resultEqual = resultEqual && ((a.IdDestaque == null && b.IdDestaque == null) || (a.IdDestaque == b.IdDestaque));
				resultEqual = resultEqual && ((a.Destaque == null && b.Destaque == null) || (a.Destaque == b.Destaque));
				resultEqual = resultEqual && ((a.DescricaoSimples == null && b.DescricaoSimples == null) || (a.DescricaoSimples == b.DescricaoSimples));
				resultEqual = resultEqual && ((a.DescricaoComplexa == null && b.DescricaoComplexa == null) || (a.DescricaoComplexa == b.DescricaoComplexa));
				return resultEqual;
			}
		}

		public static bool operator !=(DestaquesVO a, DestaquesVO b)
		{
			return !(a == b);
		}

		public override bool Equals(Object obj)
		{
			DestaquesVO typedInstance = obj as DestaquesVO;
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

	public class DestaquesVOCollection : List<DestaquesVO>
	{
		public int TotalRows { get; set; }
		public int? PageSize { get; set; }
	}
}
