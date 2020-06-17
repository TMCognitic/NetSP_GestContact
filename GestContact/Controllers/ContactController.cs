using GestContact.Infrastructure;
using GestContact.Models.Client.Data;
using GestContact.Models.Client.Services;
using GestContact.Models.Forms;
using GestContact.Models.Mappers;
using GestContact.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestContact.Controllers
{
    [AuthRequired]
    public class ContactController : Controller
    {
        IContactService<Contact> _service;

        public ContactController()
        {
            _service = new ContactService();
        }

        // GET: Contact
        public ActionResult Index()
        {
            return View(_service.Get(SessionManager.User.Id).Select(c => c.ToDisplay()));
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            Contact contact = _service.Get(SessionManager.User.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToDetails());
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(CreateContactForm contactForm)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _service.Insert(new Contact(contactForm.Nom, contactForm.Prenom, contactForm.Email, contactForm.Tel, SessionManager.User.Id));
                    return RedirectToAction("Index");
                }                
            }
            catch
            {
                ViewBag.Error = "Une erreur est survenue durant l'insertion, merci de contacter l'admin du site";
            }

            return View(contactForm);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            Contact contact = _service.Get(SessionManager.User.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToEditForm());
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, EditContactForm contactForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Update(id, new Contact(contactForm.Nom, contactForm.Prenom, contactForm.Email, contactForm.Tel, SessionManager.User.Id));
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Error = "Une erreur est survenue durant la mise à jour, merci de contacter l'admin du site";
            }

            return View(contactForm);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            Contact contact = _service.Get(SessionManager.User.Id, id);

            if (contact is null)
                return RedirectToAction("Index");

            return View(contact.ToDetails());
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DetailsContact contactForm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.Delete(SessionManager.User.Id, id);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Error = "Une erreur est survenue durant la suppression, merci de contacter l'admin du site";
            }

            return View(contactForm);
        }
    }
}
