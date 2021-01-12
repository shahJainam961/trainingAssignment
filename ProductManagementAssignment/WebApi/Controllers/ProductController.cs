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
    
    public class ProductController : ApiController
    {
        private dataEntities db = new dataEntities();

        // GET: api/Product
        public IQueryable<product_tbl> Getproduct_tbl()
        {
            return db.product_tbl;
        }

        // GET: api/Product/5
        [ResponseType(typeof(product_tbl))]
        public IHttpActionResult Getproduct_tbl(int id)
        {
            product_tbl product_tbl = db.product_tbl.Find(id);
            if (product_tbl == null)
            {
                return NotFound();
            }

            return Ok(product_tbl);
        }

        // PUT: api/Product/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putproduct_tbl(int id, product_tbl product_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product_tbl.Id)
            {
                return BadRequest();
            }

            db.Entry(product_tbl).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!product_tblExists(id))
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

        // POST: api/Product
        [ResponseType(typeof(product_tbl))]
        public IHttpActionResult Postproduct_tbl(product_tbl product_tbl)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.product_tbl.Add(product_tbl);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (product_tblExists(product_tbl.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = product_tbl.Id }, product_tbl);
        }

        // DELETE: api/Product/5
        [ResponseType(typeof(product_tbl))]
        public IHttpActionResult Deleteproduct_tbl(int id)
        {
            product_tbl product_tbl = db.product_tbl.Find(id);
            if (product_tbl == null)
            {
                return NotFound();
            }

            db.product_tbl.Remove(product_tbl);
            db.SaveChanges();

            return Ok(product_tbl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool product_tblExists(int id)
        {
            return db.product_tbl.Count(e => e.Id == id) > 0;
        }
    }
}