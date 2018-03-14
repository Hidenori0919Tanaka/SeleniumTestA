using SampleWebAPI.Entity.RDB;
using SampleWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace SampleWebAPI.Controllers
{
    public class FasController : ApiController
    {
        // GET: api/Fas
        public IQueryable<Fa> Get()
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Fas;
            }
        }

        // GET: api/Fas/5
        [ResponseType(typeof(Fa))]
        public IHttpActionResult Get(int id)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Fa fa = context.Fas.Find(id);
                if (fa == null)
                {
                    return NotFound();
                }
                return Ok(fa);
            }
        }

        // POST: api/Fas
        public IHttpActionResult Post(int id, Fa fa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fa.FaId)
            {
                return BadRequest();
            }

            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Entry(fa).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FaExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return StatusCode(HttpStatusCode.NoContent);
            }
        }

        // POST: api/Secs
        [ResponseType(typeof(Fa))]
        public IHttpActionResult PostSec(Fa fa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Fas.Add(fa);
                context.SaveChanges();
            }
           

            return CreatedAtRoute("DefaultApi", new { id = fa.FaId }, fa);
        }


        private bool FaExists(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Secs.Count(e => e.SecId == id) > 0;
            }
        }

        // PUT: api/Fas/5
        public void Put(int id, [FromBody]string value)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {

            }
        }

        // DELETE: api/Fas/5
        public IHttpActionResult Delete(int id)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Fa fa = context.Fas.Find(id);
                if (fa == null)
                {
                    return NotFound();
                }

                context.Fas.Remove(fa);
                context.SaveChanges();

                return Ok(fa);
            }
        }

        protected override void Dispose(bool disposing)
        {
            using (var context = new ApplicationDbContext())
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
                
            base.Dispose(disposing);
        }
    }
}
