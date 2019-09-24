using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ToDoApp.DataAccess;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class NotesController : Controller
    {
        // GET: Notes
        public ActionResult Index()
        {
            NotesRepository repository = new NotesRepository();
            List<Note> model = repository.GetAll();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Note model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            NotesRepository repository = new NotesRepository();
            repository.Insert(model);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            NotesRepository repository = new NotesRepository();
            Note model = repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Note model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            NotesRepository repository = new NotesRepository();
            repository.Update(model);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            NotesRepository repository = new NotesRepository();
            Note model = repository.GetById(id);

            if (model == null)
            {
                return HttpNotFound(); // or redirect to list: return RedirectToAction("Index");
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(Note model)
        {
            NotesRepository repository = new NotesRepository();
            model = repository.GetById(model.Id);

            if (model == null)
            {
                return HttpNotFound();
            }

            repository.Delete(model);
            return RedirectToAction("Index");
        }
    }
}