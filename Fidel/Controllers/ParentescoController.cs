using System.Net;
using System.Web.Mvc;
using Model;
using Logic;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace Fidel
{
    public class ParentescoController : Controller
    {
        public ActionResult Index()
        {
            return View(ParentescoLogic.GetAll( x => x.Activo == true));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PARENTESCO Parentesco)
        {
            if (ModelState.IsValid)
            {
                ParentescoLogic.Create(Parentesco);
                return RedirectToAction("Index");
            }

            return View(Parentesco);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PARENTESCO Parentesco = ParentescoLogic.FindParentesco(id);
            if (Parentesco == null)
                return HttpNotFound();
            return View(Parentesco);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PERSONA Parentesco)
        {
            if (ModelState.IsValid)
            {
                PersonaLogic.EditPersona(Parentesco);
                return RedirectToAction("Index");
            }
            return View(Parentesco);
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            PARENTESCO Parentesco = ParentescoLogic.FindParentesco(id);
            if (Parentesco == null)
                return HttpNotFound();

            return View(Parentesco);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(long id)
        {
            ParentescoLogic.DeleteParentesco(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> GetListParentesco() {
            try
            {

                System.Collections.Generic.IEnumerable<PARENTESCO> Parentesco = await Task.Run(() => ParentescoLogic.GetAll(x => x.Activo != null));
                if (Parentesco.Count() > 0)
                {
                    var data = Parentesco.ToList().Select(x => new { id = x.ID_PARENTESCO, nombre = x.NOMBRE }).ToList();
                    return Json(new { success = true, data = data });
                }
                else return Json(new { success = false });
            }
            catch(Exception ex)
            {
                throw;
            }

        } 
    }
}
