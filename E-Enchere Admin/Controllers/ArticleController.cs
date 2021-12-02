using E_Enchere_Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Enchere_Admin.Controllers
{
    public class ArticleController : Controller
    {
        private readonly EEnchereContext _db;

        public ArticleController(EEnchereContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Article> Objectlist = _db.Articles;
            return View(Objectlist);
        }

        public IActionResult Create()
        {
            return View();
        }

        //Post-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Article obj)
        {
            _db.Articles.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            };
            var obj = _db.Articles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //Post Delete 
        [HttpPost]
        public IActionResult DeleteArticle(int? id)
        {
            var obj = _db.Articles.Find(id);
            if (obj == null)
            {
                return NotFound();
            };
            _db.Articles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            };
            var obj = _db.Articles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        // Post Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Article obj)
        {
            if (ModelState.IsValid)
            {
                _db.Articles.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(obj);
        }




    }
}
