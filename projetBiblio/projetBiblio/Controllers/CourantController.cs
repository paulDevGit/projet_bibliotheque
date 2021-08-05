using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using projetBiblio.Models;
using System.IO;

namespace projetBiblio.Controllers
{
    public class CourantController : Controller
    {
        BiblioEntities db = new BiblioEntities();
        public ActionResult Index()
        {
            ViewBag.listeCourant = db.COURANT.ToList();
            ViewBag.listeGenre = db.GENRE.ToList();

            return View();
        }

        public ActionResult AjoutCourant()
        {
            try
            {
                ViewBag.listeCourant = db.COURANT.ToList();
                ViewBag.listeGenre = db.GENRE.ToList();
                return View();
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        [HttpPost]
        public ActionResult AjoutCourant(COURANT courant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    courant.DATE_SAISIE = DateTime.Now;
                    db.COURANT.Add(courant);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCourant");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

        public ActionResult SupprimerCourant(int id)
        {
            try
            {
                COURANT courant = db.COURANT.Find(id);
                if (courant != null)
                {
                    db.COURANT.Remove(courant);
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCourant");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }


        //Fonction de modification

        public ActionResult ModifierCourant(int id)
        {
            try
            {
                ViewBag.listeCourant = db.COURANT.ToList();
                COURANT courant = db.COURANT.Find(id);
                if (courant != null)
                {
                    return View("AjoutCourant", courant);
                }
                return RedirectToAction("AjoutCourant");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }


        [HttpPost]
        public ActionResult ModifierCourant(COURANT courant)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Entry(courant).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("AjoutCourant");
            }
            catch (Exception e)
            {
                return HttpNotFound();
            }
        }

    }
}
