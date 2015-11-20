using Sonartez.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonartez.Hepldesk.Bussiness
{
    class BBLUser
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Sonartez.App.Properties.Settings.SonartezClientConnectionString"].ConnectionString;
       
        public IEnumerable<TblUser> GetUser()
        {
            List<TblUser> u = new List<TblUser>();
            var conn = new System.Data.SqlServerCe.SqlCeConnection(connectionString);
            using (Sonartez_server db = new Sonartez_server(conn))
            {
                var q =
                from a in db.TblUser
                select a;
                u = q.ToList();
            }
            return u;
        }
    }
}
