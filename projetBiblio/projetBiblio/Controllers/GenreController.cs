using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using projetBiblio.Models;

namespace projetBiblio.Controllers
{
    public class GenreController : Controller
    {   //Chaine de connection
        BiblioEntities db = new BiblioEntities();
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutGenre()
        {
            try
            {
                ViewBag.listeGenre = db.GENRE.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult AjoutGenre(GENRE genre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    genre.DATE_SAISIE = DateTime.Now;
                    db.GENRE.Add(genre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerGenre(int id)
        {
            try
            {
                GENRE genre = db.GENRE.Find(id);
                if (genre != null)
                {
                    db.GENRE.Remove(genre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        //Fonction de modification

        public ActionResult ModifierGenre(int id)
        {
            try
            {
                ViewBag.listeGenre = db.GENRE.ToList();
                GENRE genre = db.GENRE.Find(id);
                if (genre != null)
                {
                    return View("AjoutGenre", genre);
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierGenre(GENRE genre)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(genre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutGenre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}