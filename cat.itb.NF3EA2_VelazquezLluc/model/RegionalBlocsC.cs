using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
    [Serializable]
	public class RegionalBlocsC
    {
        public string acronym { get; set; }
		public string name { get; set; }
		public List<string>? otherAcronyms { get; set; }
		public List<string>? otherNames { get; set; }
	}
}
