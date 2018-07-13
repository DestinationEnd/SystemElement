using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemElement.Models
{
    public class Element
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
    }
}