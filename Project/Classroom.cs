using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project
{
    public class Classroom
    {
        public int ClassId {  get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public int UserId { get; set; }
        public string ClassCode { get; set; }
        public DateTime CreationDate { get; set; }

    }
}