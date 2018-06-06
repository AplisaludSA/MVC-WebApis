using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Model;
using Newtonsoft.Json.Linq;
using Logic;
using System.Web.Http.Results;

namespace Fidel.Controllers
{
    public class GrupoFamiliarController : ApiController
    {

        public IEnumerable<GRUPO_FAMILIAR> GetGRUPO_FAMILIAR()
        {
            return GrupoFamiliarLogic.GetAll(x => x.Activo == true);
        }

        public IEnumerable<GRUPO_FAMILIAR> GetGRUPO_FAMILIAR(long id)
        {
            return GrupoFamiliarLogic.GetAll(x => x.Activo == true && x.ID_PERSONA == id);
        }


        [ResponseType(typeof(List<GRUPO_FAMILIAR>))]
        public IHttpActionResult PostGRUPO_FAMILIAR(List<GRUPO_FAMILIAR> GrupoFamiliar)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            return (GrupoFamiliarLogic.Save(GrupoFamiliar)) ? StatusCode(HttpStatusCode.OK) : StatusCode(HttpStatusCode.NotFound);
        }


        [ResponseType(typeof(List<long>))]
        [HttpDelete]
        public IHttpActionResult DeleteGRUPO_FAMILIAR(List<long> IdsGrupoFamiliar)
        {
            return (IdsGrupoFamiliar.Count() > 0) ?
                (GrupoFamiliarLogic.Delete(IdsGrupoFamiliar))
                    ? StatusCode(HttpStatusCode.OK)
                    : StatusCode(HttpStatusCode.InternalServerError)
                : StatusCode(HttpStatusCode.LengthRequired);
        }
    }    
}