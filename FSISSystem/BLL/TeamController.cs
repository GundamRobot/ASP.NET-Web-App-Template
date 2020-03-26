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
    public class TeamController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Team> Team_List()
        {
            using (var context = new FSISContext())
            {
                return context.Teams.ToList();
            }
        }

        public Team Teams_FindByID(int teamid)
        {
            using (var context = new FSISContext())
            {
                return context.Teams.Find(teamid);
            }
        }

        public List<Team> TeamsList_FindByID(int teamid)
        {
            using (var context = new FSISContext())
            {
                IEnumerable<Team> results = context.Database.SqlQuery<Team>("Products_GetByTeam @TeamID", new SqlParameter("TeamID", teamid));

                return results.ToList();
            }
        }


    }
}
