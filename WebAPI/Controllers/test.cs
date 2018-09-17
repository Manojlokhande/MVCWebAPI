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
using WebAPI;

namespace WebAPI.Controllers
{
    public class test : ApiController
    {
        private DBRepository db = new DBRepository();

        // GET: api/test
        public IQueryable<TBL_USER> GetTBL_USER()
        {
            return db.TBL_USER;
        }

        // GET: api/test/5
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult GetTBL_USER(long id)
        {
            TBL_USER tBL_USER = db.TBL_USER.Find(id);
            if (tBL_USER == null)
            {
                return NotFound();
            }

            return Ok(tBL_USER);
        }

        // PUT: api/test/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTBL_USER(long id, TBL_USER tBL_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tBL_USER.USER_ID)
            {
                return BadRequest();
            }

            db.Entry(tBL_USER).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TBL_USERExists(id))
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

        // POST: api/test
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult PostTBL_USER(TBL_USER tBL_USER)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TBL_USER.Add(tBL_USER);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (TBL_USERExists(tBL_USER.USER_ID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tBL_USER.USER_ID }, tBL_USER);
        }

        // DELETE: api/test/5
        [ResponseType(typeof(TBL_USER))]
        public IHttpActionResult DeleteTBL_USER(long id)
        {
            TBL_USER tBL_USER = db.TBL_USER.Find(id);
            if (tBL_USER == null)
            {
                return NotFound();
            }

            db.TBL_USER.Remove(tBL_USER);
            db.SaveChanges();

            return Ok(tBL_USER);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TBL_USERExists(long id)
        {
            return db.TBL_USER.Count(e => e.USER_ID == id) > 0;
        }
    }
}