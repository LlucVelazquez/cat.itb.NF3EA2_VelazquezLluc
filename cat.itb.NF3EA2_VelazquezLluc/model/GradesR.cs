using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class GradesR
    {
		public DateR date { get; set; }
		public string grade { get; set; }
		public int score { get; set; }
	}
}
