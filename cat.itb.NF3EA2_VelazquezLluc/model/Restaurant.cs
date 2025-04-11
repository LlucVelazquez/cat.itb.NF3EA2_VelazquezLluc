using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
    [Serializable]
	public class Restaurant
    {
        public AddressR address { get; set; }
        public string borought { get; set; }
		public string cuisine { get; set; }
        public List<GradesR> grades { get; set; }
		public string name { get; set; }
		public string restaurant_id { get; set; }
	}
}
