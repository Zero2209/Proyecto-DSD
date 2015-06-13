using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace HuariqueRest.Controllers
{
    public class HuariqueController : ApiController
    {
        VamosPalHuariqueEntities db = new VamosPalHuariqueEntities();

        [HttpGet]
        public IEnumerable<Huarique> Get()
        {
            return db.Huariques.AsEnumerable();
        }

        public Huarique Get(int id)
        {
            Huarique h = db.Huariques.Find(id);
            if (h == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return h;
        }

        public HttpResponseMessage Post(Huarique h)
        {
            if (ModelState.IsValid)
            {

                db.Huariques.Add(h);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, h);
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        public HttpResponseMessage Put(int id, Huarique h)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            if (id != h.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            db.Entry(h).State = EntityState.Modified;
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
            Huarique h = db.Huariques.Find(id);
            if (h == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Huariques.Remove(h);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK, h);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
