using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class PublishedDate
    {
		[JsonProperty("$date")]
		public String date { get; set; }
	}
}
