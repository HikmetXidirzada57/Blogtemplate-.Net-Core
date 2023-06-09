﻿using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var category = _context.Categories.ToList();
            return View(category);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var findCategory = _context.Categories.FirstOrDefault(x => x.Name == category.Name);
            if (findCategory != null)
            {
                ViewBag.CategoryExist = "This category is exist.";
                return View();
            }
            _context.Categories.Add(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var findCategory = _context.Categories.FirstOrDefault(x => x.Name == category.Name);
            if (findCategory != null)
            {
                ViewBag.CategoryExist = "This category is exist.";
                return View(findCategory);
            }
            _context.Categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int id)
        {
            var category = _context.Categories.FirstOrDefault(x=>x.Id == id);
            return View(category);
        }


        [HttpPost]
        public IActionResult Delete(Category category)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
