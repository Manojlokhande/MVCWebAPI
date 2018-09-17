using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    [Authorize]
    public class EmployeesController : ApiController
    {
        public IEnumerable<TBL_EMPLOYEE> Get()
        {
            using (DBRepository dbrepository = new DBRepository())
            {
                return dbrepository.TBL_EMPLOYEE.ToList();
            }
        }
    }
}
