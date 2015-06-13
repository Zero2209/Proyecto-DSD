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
    public class OpinionController : ApiController
    {

        VamosPalHuariqueEntities db = new VamosPalHuariqueEntities();

        [HttpGet]
        public IEnumerable<Opinion> Get()
        {
            return db.Opinions.AsEnumerable();
        }

        public Opinion Get(int id)
        {
            Opinion o = db.Opinions.Find(id);
            if (o == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return o;
        }

        public HttpResponseMessage Post(Opinion o)
        {
            if (ModelState.IsValid)
            {
                db.Opinions.Add(o);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, o);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(int id, Opinion o)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != o.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(o).State = EntityState.Modified;
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
            Opinion o = db.Opinions.Find(id);
            if (o == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Opinions.Remove(o);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, o);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
