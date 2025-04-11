using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class AddressR
    {
		public string building { get; set; }
		public List<double> coord { get; set; }
		public string street { get; set; }
		public string zipcode { get; set; }
	}
}
