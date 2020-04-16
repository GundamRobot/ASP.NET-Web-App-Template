using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.BLL;
using FSISSystem.ENTITIES;

namespace WebAppFSIS.ExercisePages
{
    public partial class MultiRecordQueryWithCustomGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            Message.Visible = false;
            TeamInfo.Visible = false;
        }

        protected void FetchTeamList_Click(object sender, EventArgs e)
        {
            int teamid = 0;

            if (int.TryParse(TeamList.SelectedValue, out teamid))
            {
                if (teamid > 0)
                {                    
                    TeamController teamController = new TeamController();
                    Team team = teamController.Teams_FindByID(teamid);

                    Coach.Text = team.Coach;
                    AssistantCoach.Text = team.AssistantCoach;
                    Wins.Text = team.Wins.ToString();
                    Losses.Text = team.Losses.ToString();
                }
            }

            if (TeamList.SelectedIndex == 0)
            {
                Message.Text = "Select a team to its list of players.";
                Message.Visible = true;
                TeamInfo.Visible = false;
            }
            else
            {
                Message.Text = "";
                Message.Visible = false;
                TeamInfo.Visible = true;
            }

        }

        protected void PlayerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow agvrow = PlayerList.Rows[PlayerList.SelectedIndex];
            string playerid = (agvrow.FindControl("PlayerID") as Label).Text;
            Response.Redirect("CRUD.aspx?pid=" + playerid);
        }

        protected void ViewEditPage(object sender, EventArgs e)
        {
            GridViewRow agvrow = PlayerList.Rows[PlayerList.SelectedIndex];
        }
    }
}