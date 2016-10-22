using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class ToDoTaskController : Controller
    {

        static List<ToDoTask> tasks = new List<ToDoTask>();

        
        public ActionResult Index()
        {
            return View(tasks);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ToDoTask t)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", t);
            }
            if (tasks.Count != 0) t.Id = tasks.First().Id++;
            tasks.Add(t);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            ToDoTask t = new ToDoTask();
            foreach (ToDoTask ts in tasks)
            {
                if (ts.Id == id)
                {
                    t.Name = ts.Name;
                    t.Text = ts.Text;
                    t.Id = ts.Id;
                }
            }
            return View(t);
        }


        [HttpPost]
        public ActionResult Edit(ToDoTask t)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", t);
            }

            foreach (ToDoTask ts in tasks)
            {
                if (ts.Id == t.Id)
                {
                    ts.Name = t.Name;
                    ts.Text = t.Text;
                    ts.Id = t.Id;
                }
            }
            return RedirectToAction("Index");
        }


        public ActionResult Delete(int id)
        {
            ToDoTask t = new ToDoTask();
            foreach (ToDoTask ts in tasks)
            {
                if (ts.Id == id)
                {
                    t.Name = ts.Name;
                    t.Text = ts.Text;
                    t.Id = ts.Id;
                }
            }
            return View(t);
        }


        [HttpPost]
        public ActionResult Delete(ToDoTask t)
        {
            tasks.Remove(tasks.Find(m => m.Id == t.Id));
            return RedirectToAction("Index");
        }
    }
}
