using E_Enchere_Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Enchere_Admin.Controllers
{
    public class RoomController : Controller
    {
        private readonly EEnchereContext _db;
        public RoomController(EEnchereContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Room> objList = _db.Rooms;


            return View(objList);
        }
        // get create
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _db.Articles.Select(i => new SelectListItem
            {
                Text = i.Nom,
                Value = i.IdArticle.ToString(),
            });

            ViewBag.TypeDropDown = TypeDropDown;
            return View();
        }
        // post create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Room obj)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        //get delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Rooms.Find(Id);
            if (obj == null) { return NotFound(); }
            return View(obj);



        }
        //post delete
        [HttpPost]
        public IActionResult DeleteRoom(int? IdRoom)
        {
            var obj = _db.Rooms.Find(IdRoom);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Rooms.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        //get update
        public IActionResult Update(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var obj = _db.Rooms.Find(Id);
            if (obj == null) { return NotFound(); }
            //Article article = _db.Articles.Find(obj.IdArticle);
            return View(obj);



        }
        // post update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Room obj)
        {
            if (ModelState.IsValid)
            {
                _db.Rooms.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        public ActionResult Details(int id)
        {
            var room = _db.Rooms.Find(id);
            if (room == null)
            {
                return NotFound();
            }
            Article article = _db.Articles.Find(room.IdArticle);

            return View(room);
        }
    }
}
