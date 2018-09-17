using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;

using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;
namespace WebAPI
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class MenuHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string cs = ConfigurationManager.ConnectionStrings["db_emp"].ConnectionString;
            List<Menu> listMenu = new List<Menu>();
            using(OleDbConnection connection = new OleDbConnection(cs))
            {
                OleDbCommand cmd = new OleDbCommand("SELECT * FROM TBL_Menu", connection);
                cmd.CommandType = CommandType.Text;
                connection.Open();
                OleDbDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Menu menu = new Menu();
                    menu.Id = Convert.ToInt32(rdr["Id"]);
                    menu.MenuText = rdr["Menu_Text"].ToString();
                    menu.ParentId = rdr["Parent_Id"] != DBNull.Value
                        ? Convert.ToInt32(rdr["Parent_Id"]) : (int?)null;
                    menu.Active = Convert.ToBoolean(rdr["Active"]);
                    listMenu.Add(menu);
                }

                List <Menu> menuTree = GetMenuTree(listMenu, null);

                string response = (JsonConvert.SerializeObject(menuTree));

                context.Response.Write(response);
            }
        }

        public List<Menu> GetMenuTree(List<Menu> list, int? parent)
        {
            return list.Where(x => x.ParentId == parent).Select(x => new Menu
            {
                Id = x.Id,
                MenuText = x.MenuText,
                ParentId = x.ParentId,
                Active = x.Active,
                List = GetMenuTree(list, x.Id)
            }).ToList();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}