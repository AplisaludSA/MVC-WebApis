using System.Net;
using System.Web.Mvc;
using Model;
using Logic;
using System;

namespace Fidel
{
    public class PersonaController : Controller
    {
        public ActionResult Index()
        {
            return View(PersonaLogic.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [System.Web.Http.Description.ResponseType(typeof(PERSONA))]
        public JsonResult Create(PERSONA Persona)
        {
            //if (ModelState.IsValid)
            //{
            try
            {
                return ( PersonaLogic.Create(Persona) ) ? Json(new { success = true }) : Json(new { success = false });
            }
            catch(Exception)
            {
                return Json(new { success = false });
            }
            //}
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PERSONA Persona = PersonaLogic.FindPersona(id);
            if (Persona == null)
                return HttpNotFound();
            return View(Persona);
        }

        [HttpPost]
        public JsonResult Edit(PERSONA Persona)
        {
            try
            {
                return (PersonaLogic.EditPersona(Persona)) ? Json(new { success = true }) : Json(new { success = false });
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PERSONA Persona = PersonaLogic.FindPersona(id);
            if (Persona == null)
                return HttpNotFound();

            return View(Persona);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(long id)
        {
            PersonaLogic.DeletePersona(id);
            return RedirectToAction("Index");
        }
    }
}
