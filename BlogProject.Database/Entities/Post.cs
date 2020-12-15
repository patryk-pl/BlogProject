using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Database
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = "";
        public string Body { get; set; } = "";
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
