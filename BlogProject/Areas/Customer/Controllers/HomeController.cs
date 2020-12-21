using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Core;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly IPostManager _postManager;
        private readonly PostViewModelMapper _postViewModelMapper;

        public HomeController(IPostManager postManager, PostViewModelMapper postViewModelMapper)
        {
            _postManager = postManager;
            _postViewModelMapper = postViewModelMapper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Post()
        {
            var postDtos = await _postManager.GetAllPostAsync();
            var postViewModel = _postViewModelMapper.Map(postDtos);
            return View(postViewModel);
        }
    }
}
