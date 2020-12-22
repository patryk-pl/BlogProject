using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogProject
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminPanelController : Controller
    {
        private readonly IPostManager _postManager;
        private readonly PostViewModelMapper _postViewModelMapper;

        public AdminPanelController(IPostManager postManager, PostViewModelMapper postViewModelMapper)
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
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] p1 = null;
                    using (var fs1 = files[0].OpenReadStream())
                    {
                        using (var ms1 = new MemoryStream())
                        {
                            fs1.CopyTo(ms1);
                            p1 = ms1.ToArray();
                        }
                    }
                    postVm.Image = p1;
                }

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
            if (!ModelState.IsValid)
            {
                return View(postVm);
            }

            var files = HttpContext.Request.Form.Files;
            if(files.Count > 0)
            {
                byte[] p1 = null;
                using (var fs1 = files[0].OpenReadStream())
                {
                    using (var ms1 = new MemoryStream())
                    {
                        fs1.CopyTo(ms1);
                        p1 = ms1.ToArray();
                    }
                }
                postVm.Image = p1;
            }

            var postDto = _postViewModelMapper.Map(postVm);
            await _postManager.EditPostAsync(postDto);

            return RedirectToAction(nameof(Index));
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
