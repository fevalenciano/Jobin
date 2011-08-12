namespace Jobin.Model.DataStoreInterface
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using Jobin.Model.ValueObjects;

	public partial interface ISegmentosDalc
	{
		void Insert(SegmentosVO segmentosVO);
		void Update(SegmentosVO segmentosVO);
		void Delete(int idSegmento);
		SegmentosVO Get(int idSegmento);
		SegmentosVOCollection GetAll();
		SegmentosVOCollection GetAllPaged(long startRowIndex, int maximumRows);
	}
}
