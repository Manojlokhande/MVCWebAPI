using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Text;

namespace WebAPI.Controllers
{
    public class UserController : ApiController
    {
        private DBRepository db = new DBRepository();

        [HttpGet]
        public HttpResponseMessage Get()
        {
            var list = db.TBL_USER.Select(s => new { s.USER_ID, s.NAME});
            return ToJson(list);
        }

        [HttpPost]
        public HttpResponseMessage Post(int id, [FromBody]TBL_USER value)
        {
            if (id == 0)
                db.TBL_USER.Add(value);
            else
                db.Entry(value).State = EntityState.Modified;

            return ToJson(db.SaveChanges());
        }

        [HttpPost]
        [Route("api/User/Delete")]
        public HttpResponseMessage Delete(int id)
        {
            db.TBL_USER.Remove(db.TBL_USER.FirstOrDefault(x => x.USER_ID == id));
            return ToJson(db.SaveChanges());
        }

        public HttpResponseMessage ToJson(dynamic obj)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");

            return response;
        }
    }
}
