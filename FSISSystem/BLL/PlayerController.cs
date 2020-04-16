using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using FSISSystem.DAL;
using FSISSystem.ENTITIES;
using System.ComponentModel;

namespace FSISSystem.BLL
{
    [DataObject]
    public class PlayerController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Player> Players_FindByTeam(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Player> results = context.Database.SqlQuery<Player>("Player_GetByTeam @TeamID", new SqlParameter("TeamID", teamid));
                return results.ToList();
            }
        }
    }
}
