using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication.Models;

namespace MvcApplication.Controllers
{   
    public class CategoriasController : Controller
    {
        private MvcApplicationContext context = new MvcApplicationContext();

        //
        // GET: /Categorias/

        public ViewResult Index()
        {
            return View(context.Categorias.Include(categoria => categoria.Receitas).ToList());
        }

        //
        // GET: /Categorias/Details/5

        public ViewResult Details(int id)
        {
            Categoria categoria = context.Categorias.Single(x => x.CategoriaId == id);
            return View(categoria);
        }

        //
        // GET: /Categorias/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Categorias/Create

        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(categoria);
        }
        
        //
        // GET: /Categorias/Edit/5
 
        public ActionResult Edit(int id)
        {
            Categoria categoria = context.Categorias.Single(x => x.CategoriaId == id);
            return View(categoria);
        }

        //
        // POST: /Categorias/Edit/5

        [HttpPost]
        public ActionResult Edit(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        //
        // GET: /Categorias/Delete/5
 
        public ActionResult Delete(int id)
        {
            Categoria categoria = context.Categorias.Single(x => x.CategoriaId == id);
            return View(categoria);
        }

        //
        // POST: /Categorias/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = context.Categorias.Single(x => x.CategoriaId == id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}