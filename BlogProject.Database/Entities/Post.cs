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
        public byte[] Image { get; set; }

        public string Description { get; set; }
        public string Tags { get; set; }
        public string Category { get; set; }
    }
}
