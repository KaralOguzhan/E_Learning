using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyElearningProject.DAL.Entities
{
	public class Contact
	{
        public int ContactID { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
    }
}