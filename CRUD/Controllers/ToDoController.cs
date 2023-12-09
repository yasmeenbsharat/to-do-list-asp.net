using Microsoft.AspNetCore.Mvc;
using CRUD.Data;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ApplicationDbContext _context;
         public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.toDos.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
      public IActionResult Create(CRUD.Models.ToDo toDo)
        {
            if(ModelState.IsValid) {
                _context.toDos.Add(toDo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
            }

            return View();
        }
        public IActionResult Details(int? id)
        { if (id== null || _context.toDos==null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            } 
          var toDosRus = _context.toDos.FirstOrDefault(item=> item.Id==id);
             if (toDosRus== null)
            {
                return NotFound();
            }
            
            return View(toDosRus);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || _context.toDos == null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            }
            var toDosRus = _context.toDos.FirstOrDefault(item => item.Id == id);
            if (toDosRus == null)
            {
                return NotFound();
            }

            return View(toDosRus);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, CRUD.Models.ToDo toDo)
        {   if (id != toDo.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.toDos.Update(toDo);
                _context.SaveChanges();
                return RedirectToAction("Index");

            }

            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || _context.toDos == null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            }
            var toDosRus = _context.toDos.FirstOrDefault(item => item.Id == id);
            if (toDosRus == null)
            {
                return NotFound();
            }

            return View(toDosRus);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]       
        public IActionResult DeleteConfirmed(int? id)
        {
            if (id == null || _context.toDos == null)
            {
                return RedirectToAction("Index");
                //return NotFound();
            }
            var toDosRus = _context.toDos.FirstOrDefault(item => item.Id == id);
            if (toDosRus != null)
            {
                _context.toDos.Remove(toDosRus);
            }
                _context.SaveChanges();
                return RedirectToAction("Index");

            

        }

    }
}
