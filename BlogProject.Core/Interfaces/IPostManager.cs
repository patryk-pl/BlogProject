using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public interface IPostManager
    {
        Task<bool> Add(PostDto postDto);
    }
}
