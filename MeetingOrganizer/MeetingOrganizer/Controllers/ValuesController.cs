using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MeetingOrganizer.Models;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MeetingOrganizer.Controllers
{
    public class ValuesController : ApiController
    {
        private ToplantiContext db = new ToplantiContext();

        // GET api/values
        public IQueryable<Toplanti> GetToplantilar()
        {
            return db.Toplantis;
        }

        // GET api/values/5
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult GetToplanti(int id)
        {
            Toplanti toplanti = db.Toplantis.Find(id);
            if (toplanti == null)
            {
                return NotFound();
            }

            return Ok(toplanti);
        }



        // POST: api/values 
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult PostToplanti(Toplanti toplanti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toplantis.Add(toplanti);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toplanti.Id }, toplanti);
        }


        // PUT api/values/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToplanti(int id, Toplanti toplanti)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toplanti.Id)
            {
                return BadRequest();
            }

            db.Entry(toplanti).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToplantiExists(id))
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


    

        // DELETE api/values/5 
        [ResponseType(typeof(Toplanti))]
        public IHttpActionResult DeleteToplanti(int id)
        {
            Toplanti toplanti = db.Toplantis.Find(id);
            if (toplanti == null)
            {
                return NotFound();
            }

            db.Toplantis.Remove(toplanti);
            db.SaveChanges();

            return Ok(toplanti);
        }

        private bool ToplantiExists(int id)
        {
            return db.Toplantis.Count(e => e.Id == id) > 0;
        }
    }
}
