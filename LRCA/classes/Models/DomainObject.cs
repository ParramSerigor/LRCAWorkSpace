using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace LRCA.classes.Models
{
	public abstract class DomainObject
	{
		#region Constructor
		protected DomainObject() : this(0, DateTime.Now) { }
		protected DomainObject(int id, DateTime createdOn)
		{
			Id = id;
			UpdatedDate = CreatedDate = createdOn;
			UpdatedBy = CreatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
		}
		#endregion

		#region IsNull
		public virtual bool IsNull()
		{
			return false;
		}
		#endregion

		#region SetModified
		public void SetModified()
		{
			UpdatedBy = HttpContext.Current.Session["UserAuthId"].ToString();
			UpdatedDate = DateTime.Now;
		}
		#endregion

		public void SetCreatedOn(DateTime dateTime)
		{
			CreatedDate = dateTime;
		}

		#region Properties
		public int Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public string CreatedBy { get; private set; }
		public DateTime UpdatedDate { get; private set; }
		public string UpdatedBy { get; private set; }
		#endregion
	}
}