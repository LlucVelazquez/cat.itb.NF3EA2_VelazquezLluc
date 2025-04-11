using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class LanguagesC
    {
		public string iso639_1 { get; set; }
		public string iso639_2 { get; set; }
		public string name { get; set; }
		public string nativeName { get; set; }
	}
}
