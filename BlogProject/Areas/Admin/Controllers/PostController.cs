using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Core;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject
{
    [Area("Admin")]
    public class PostController : Controller
    {
        private readonly IPostManager _postManager;
        private readonly PostViewModelMapper _postViewModelMapper;

        public PostController(IPostManager postManager, PostViewModelMapper postViewModelMapper)
        {
            _postManager = postManager;
            _postViewModelMapper = postViewModelMapper;
        }

        // GET - INDEX
        public async Task<IActionResult> Index()
        {
            var postDtos = await _postManager.GetAllPostAsync();
            var postViewModel = _postViewModelMapper.Map(postDtos);
            return View(postViewModel);
        }

        //GET - CREATE
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                var postDto = _postViewModelMapper.Map(postVm);
                await _postManager.Add(postDto);

                return RedirectToAction(nameof(Index));
            }
            return View(postVm);
        }
        //GET - EDIT
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postDto = await _postManager.GetSinglePostAsync(id);
            var postViewModel = _postViewModelMapper.Map(postDto);
            if (postViewModel == null)
            {
                return NotFound();
            }
            return View(postViewModel);
        }

        //POST - EDIT
        [HttpPost]
        public async Task<IActionResult> Edit(PostViewModel postVm)
        {
            if (ModelState.IsValid)
            {
                var postDto = _postViewModelMapper.Map(postVm);
                await _postManager.EditPostAsync(postDto);

                return RedirectToAction(nameof(Index));
            }
            return View(postVm);
        }

        //GET - DELETE
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postDto = await _postManager.GetSinglePostAsync(id);
            var postViewModel = _postViewModelMapper.Map(postDto);
            if (postViewModel == null)
            {
                return NotFound();
            }
            return View(postViewModel);
        }

        //POST - DELETE
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            await _postManager.DeletePostAsync(new PostDto { Id = (int)id });
            return RedirectToAction(nameof(Index));
        }

        //GET - Details
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var postDto = await _postManager.GetSinglePostAsync(id);
            var postViewModel = _postViewModelMapper.Map(postDto);
            if (postViewModel == null)
            {
                return NotFound();
            }
            return View(postViewModel);
        }

    }
}
