using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using projetBiblio.Models;

namespace projetBiblio.Controllers
{
    public class LivreController : Controller
    {   //Chaine de connection
        BiblioEntities db = new BiblioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutLivre()
        {
            try
            {
                
                ViewBag.listeLivre = db.LIVRE.ToList();
                ViewBag.listeAuteur = db.AUTEUR.ToList();
                ViewBag.listeEditeur = db.EDITEUR.ToList();
                ViewBag.listeGenre = db.GENRE.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult AjoutLivre(LIVRE livre)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    livre.DATE_SAISIE = DateTime.Now;
                    db.LIVRE.Add(livre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerLivre(int id)
        {
            try
            {
                LIVRE livre = db.LIVRE.Find(id);
                if (livre != null)
                {
                    db.LIVRE.Remove(livre);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult ModifierLivre(int id)
        {
            try
            {
                ViewBag.listeLivre = db.LIVRE.ToList();
                LIVRE livre = db.LIVRE.Find(id);
                if (livre != null)
                {
                    return View("AjoutLivre", livre);
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult ModifierLivre(LIVRE livre)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(livre).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutLivre");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
    }
}