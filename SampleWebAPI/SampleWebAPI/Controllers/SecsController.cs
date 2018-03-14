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
using SampleWebAPI.Entity.RDB;
using SampleWebAPI.Models;

namespace SampleWebAPI.Controllers
{
    public class SecsController : ApiController
    {
        //private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Secs
        public IQueryable<Sec> GetSecs()
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                return context.Secs;
            }
        }

        // GET: api/Secs/5
        [ResponseType(typeof(Sec))]
        public IHttpActionResult GetSec(int id)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Sec sec = context.Secs.Find(id);
                if (sec == null)
                {
                    return NotFound();
                }
                return Ok(sec);
            }
        }

        // PUT: api/Secs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSec(int id, Sec sec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sec.SecId)
            {
                return BadRequest();
            }

            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Entry(sec).State = EntityState.Modified;

                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SecExists(id))
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
        [ResponseType(typeof(Sec))]
        public IHttpActionResult PostSec(Sec sec)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                context.Secs.Add(sec);
                context.SaveChanges();
            }
            

            return CreatedAtRoute("DefaultApi", new { id = sec.SecId }, sec);
        }

        // DELETE: api/Secs/5
        [ResponseType(typeof(Sec))]
        public IHttpActionResult DeleteSec(int id)
        {
            using (var context = new ApplicationDbContext())
            using (var transaction = context.Database.BeginTransaction())
            {
                Sec sec = context.Secs.Find(id);
                if (sec == null)
                {
                    return NotFound();
                }

                context.Secs.Remove(sec);
                context.SaveChanges();

                return Ok(sec);
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

        private bool SecExists(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                return context.Secs.Count(e => e.SecId == id) > 0;
            }
            
        }
    }
}