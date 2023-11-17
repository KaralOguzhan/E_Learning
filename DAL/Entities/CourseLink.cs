using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
    public class CourseLink
    {
        public int CourseLinkID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public string CourseUrl { get; set; }
        public string CourseVideoTitle { get; set; }


    }
}