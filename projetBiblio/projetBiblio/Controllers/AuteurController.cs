using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using projetBiblio.Models;

namespace projetBiblio.Controllers
{
    public class AuteurController : Controller
    {   //Chaine de connection
        BiblioEntities db = new BiblioEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutAuteur()
        {
            try
            {
                ViewBag.listeAuteur = db.AUTEUR.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult AjoutAuteur(AUTEUR auteur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    auteur.DATE_SAISIE = DateTime.Now;
                    db.AUTEUR.Add(auteur);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerAuteur(int id)
        {
            try
            {
                AUTEUR auteur = db.AUTEUR.Find(id); 
                if (auteur != null)
                {
                    db.AUTEUR.Remove(auteur); 
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        //Fonction de modification

        public ActionResult ModifierAuteur(int id)
        {
            try
            {
                ViewBag.listeAuteur= db.AUTEUR.ToList();
                AUTEUR auteur = db.AUTEUR.Find(id);
                if (auteur != null)
                {
                    return View("AjoutAuteur", auteur);
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult ModifierAuteur(AUTEUR auteur)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(auteur).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutAuteur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}