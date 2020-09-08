using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LRCA.classes.Models
{
    public class TC_Approval : DomainObject
    {
        #region Public Properties
        public int? MDETCourseApprId { get; set; }
        public int? TrainingCourseAppId { get; set; }
        public int? MDE_Owner_AuthorisedUserId { get; set; }
        public string Notes { get; set; }
        public int? IsActive { get; set; }
        public TrainingCourse TrainingCourseApp { get; internal set; }

        #endregion
    }
}