using HuariqueRest;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HuariqueRest.Controllers
{
    public class UsuarioController : ApiController
    {
        VamosPalHuariqueEntities db = new VamosPalHuariqueEntities();

        [HttpGet]
        public IEnumerable<Usuario> Get()
        {
            return db.Usuarios.AsEnumerable();
        }

        public Usuario Get(int id)
        {
            Usuario u = db.Usuarios.Find(id);
            if (u == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return u;
        }

        public HttpResponseMessage Post(Usuario u)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(u);
                db.SaveChanges();
                //HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, u);
                //response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = u.Id }));
                //return response;
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, u);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(int id, Usuario u)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != u.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(u).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public HttpResponseMessage Delete(int id)
        {
            Usuario u = db.Usuarios.Find(id);
            if (u == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Usuarios.Remove(u);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, u);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
