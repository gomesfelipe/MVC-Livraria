using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_LIVRARIA.Models;
namespace MVC_LIVRARIA.Controllers
{
    public class LivroController : Controller
    {
        LivroDAO livroDAO = new LivroDAO();
        // GET: Livro
        public ActionResult Index()
        {
            List<Livro> livrosList = new List<Livro>();
            livrosList = livroDAO.GetAllLivros().ToList();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind] Livro objLivro)
        {
            if (ModelState.IsValid)
            {
                livroDAO.AddLivro(objLivro);
                return RedirectToAction("Index");
            }

            return View(objLivro);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Livro livro = livroDAO.GetLivroByID(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, [Bind] Livro objLivro)
        {
            if (id == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                livroDAO.UpdateLivro(objLivro);
                return RedirectToAction("Index");
            }
            return View(livroDAO);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Livro livro = livroDAO.GetLivroByID(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Livro livro = livroDAO.GetLivroByID(id);
            if (livro == null)
            {
                return NotFound();
            }
            return View(livro);
        }

        [HttpPost,ActionName("Delete"),ValidateAntiForgeryToken]
        public ActionResult DeleteLivro(int? id)
        {
            livroDAO.DeleteLivro(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult _Fav(int ID)
        {
            List<string> errors = new List<string>(); // You might want to return an error if something wrong happened

            //Do DB Processing   

            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult _UnFav(int ID)
        {
            List<string> errors = new List<string>(); // You might want to return an error if something wrong happened

            //Do DB Processing   

            return Json(errors, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Random() {
            var livro = new Livro() { Titulo = "1984", Autor= "George orwell", Genero= CategoriaLivros.Romance };
            
            return View(livro);
        }
    }
}