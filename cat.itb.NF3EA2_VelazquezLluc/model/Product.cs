﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
    [Serializable]
	public class Product
    {
		public string name { get; set; }
		public int price { get; set; }
		public int stock { get; set; }
		public string picture { get; set; }
		public List<string> categories { get; set; }
	}
}
