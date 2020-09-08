using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
	public class Audit
	{
		public int Id { get; set; }
		public string TableName { get; set; }
		public string RecordId { get; set; }
		public int ChangeType { get; set; }
		public string UserName { get; set; }
		public DateTime RecordedOn { get; set; }
		public Guid CommitId { get; set; }
		public string Data { get; set; }
	}
}