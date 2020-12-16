using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core
{
    public interface IPostManager
    {
        bool Add(PostDto postDto);
    }
}
