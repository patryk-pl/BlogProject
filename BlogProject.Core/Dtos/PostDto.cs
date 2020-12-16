using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
    }
}
