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

        public List<Player> Player_List()
        {
            using (var context = new FSISContext())
            {
                return context.Players.ToList();
            }
        }

        public Player Player_Find(int playerid)
        {
            using (var context = new FSISContext())
            {
                return context.Players.Find(playerid);
            }
        }

        public int Player_Add(Player player)
        {
            using (var context = new FSISContext())
            {
                context.Players.Add(player);
                context.SaveChanges();

                return player.PlayerID;
            }
        }

        public int Player_Update(Player player)
        {
            using (var context = new FSISContext())
            {
                context.Entry(player).State = System.Data.Entity.EntityState.Modified;
                
                return context.SaveChanges();
            }
        }

        public int Delete(int playerid)
        {
            using (var context = new FSISContext())
            {
                var existingPlayer = context.Players.Find(playerid);

                if (existingPlayer == null)
                {
                    throw new Exception("Player has been removed from the database");
                }
                context.Players.Remove(existingPlayer);
                
                return context.SaveChanges();
            }
        }
    }
}
