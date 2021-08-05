using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using projetBiblio.Models;

namespace projetBiblio.Controllers
{
    public class EditeurController : Controller
    {   //Chaine de connection
        BiblioEntities db = new BiblioEntities();
        // GET: Categorie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AjoutEditeur()
        {
            try
            {
                ViewBag.listeEditeur = db.EDITEUR.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }
        [HttpPost]
        public ActionResult AjoutEditeur(EDITEUR editeur)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    editeur.DATE_SAISIE = DateTime.Now;
                    db.EDITEUR.Add(editeur);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutEditeur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

        }

        //Fonction de suppression
        public ActionResult SupprimerEditeur(int id)
        {
            try
            {
                EDITEUR editeur = db.EDITEUR.Find(id); 
                if (editeur != null)
                {
                    db.EDITEUR.Remove(editeur); 
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutEditeur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }

        }

        //Fonction de modification 

        public ActionResult ModifierEditeur(int id)
        {
            try
            {
                ViewBag.listeEditeur= db.EDITEUR.ToList();
                EDITEUR editeur = db.EDITEUR.Find(id);
                if (editeur != null)
                {
                    return View("AjoutEditeur", editeur);
                }
                return RedirectToAction("AjoutEditeur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult ModifierEditeur(EDITEUR editeur)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(editeur).State = EntityState.Modified; 
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutEditeur");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}