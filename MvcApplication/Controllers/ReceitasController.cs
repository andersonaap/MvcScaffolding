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
    public class ReceitasController : Controller
    {
        private MvcApplicationContext context = new MvcApplicationContext();

        //
        // GET: /Receitas/

        public ViewResult Index()
        {
            return View(context.Receitas.Include(receita => receita.Categoria).ToList());
        }

        //
        // GET: /Receitas/Details/5

        public ViewResult Details(int id)
        {
            Receita receita = context.Receitas.Single(x => x.ReceitaId == id);
            return View(receita);
        }

        //
        // GET: /Receitas/Create

        public ActionResult Create()
        {
            ViewBag.PossibleCategorias = context.Categorias;
            return View();
        } 

        //
        // POST: /Receitas/Create

        [HttpPost]
        public ActionResult Create(Receita receita)
        {
            if (ModelState.IsValid)
            {
                context.Receitas.Add(receita);
                context.SaveChanges();
                return RedirectToAction("Index");  
            }

            ViewBag.PossibleCategorias = context.Categorias;
            return View(receita);
        }
        
        //
        // GET: /Receitas/Edit/5
 
        public ActionResult Edit(int id)
        {
            Receita receita = context.Receitas.Single(x => x.ReceitaId == id);
            ViewBag.PossibleCategorias = context.Categorias;
            return View(receita);
        }

        //
        // POST: /Receitas/Edit/5

        [HttpPost]
        public ActionResult Edit(Receita receita)
        {
            if (ModelState.IsValid)
            {
                context.Entry(receita).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PossibleCategorias = context.Categorias;
            return View(receita);
        }

        //
        // GET: /Receitas/Delete/5
 
        public ActionResult Delete(int id)
        {
            Receita receita = context.Receitas.Single(x => x.ReceitaId == id);
            return View(receita);
        }

        //
        // POST: /Receitas/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = context.Receitas.Single(x => x.ReceitaId == id);
            context.Receitas.Remove(receita);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}