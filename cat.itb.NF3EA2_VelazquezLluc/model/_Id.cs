﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class _Id
    {
		[JsonProperty("$oid")]
		public String oid { get; set; }
	}
}
