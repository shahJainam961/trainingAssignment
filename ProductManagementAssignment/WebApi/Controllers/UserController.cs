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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserController : ApiController
    {
        private dataEntities db = new dataEntities();

        // GET: api/User
        public IQueryable<user_tbl> Getuser_tbl()
        {
            return db.user_tbl;
        }

        // GET: api/User/5
        [ResponseType(typeof(user_tbl))]
        public IHttpActionResult Getuser_tbl(int id)
        {
            user_tbl user_tbl = db.user_tbl.Find(id);
            if (user_tbl == null)
            {
                return NotFound();
            }

            return Ok(user_tbl);
        }

        // PUT: api/User/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putuser_tbl(int id, user_tbl user_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != user_tbl.Id)
            {
                return BadRequest();
            }

            db.Entry(user_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!user_tblExists(id))
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

        // POST: api/User
        [ResponseType(typeof(user_tbl))]
        public IHttpActionResult Postuser_tbl(user_tbl user_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.user_tbl.Add(user_tbl);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = user_tbl.Id }, user_tbl);
        }

        // DELETE: api/User/5
        [ResponseType(typeof(user_tbl))]
        public IHttpActionResult Deleteuser_tbl(int id)
        {
            user_tbl user_tbl = db.user_tbl.Find(id);
            if (user_tbl == null)
            {
                return NotFound();
            }

            db.user_tbl.Remove(user_tbl);
            db.SaveChanges();

            return Ok(user_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool user_tblExists(int id)
        {
            return db.user_tbl.Count(e => e.Id == id) > 0;
        }
    }
}