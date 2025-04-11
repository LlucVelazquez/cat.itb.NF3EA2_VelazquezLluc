using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.NF3EA2_VelazquezLluc.model
{
	[Serializable]
	public class Grade
    {
		public _Id _id { get; set; }
		public Student_id student_id { get; set; }
		public List<ScoresG> scores { get; set; }
		public Class_id class_id { get; set; }
	}
}
