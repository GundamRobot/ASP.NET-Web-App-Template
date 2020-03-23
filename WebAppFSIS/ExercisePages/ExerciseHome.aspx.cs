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
    public partial class ExerciseHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            TeamNameMessage.Text = "";
        }

        protected void FetchTeamList_Click(object sender, EventArgs e)
        {
            if(TeamList.SelectedIndex == 0)
            {
                Message.Text = "Select a category from the dropdown list.";
            }
        }

        protected void FetchTeamName_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TeamNameInput.Text))
            {
                TeamNameMessage.Text = "Enter a Team ID";
            }
            else
            {
                int teamid = 0;

                if(int.TryParse(TeamNameInput.Text, out teamid))
                {
                    if (teamid > 0)
                    {
                        TeamController teamController = new TeamController();

                        Team teamName = null;
                        teamName = teamController.Teams_FindByID(teamid);

                        if (teamName == null)
                        {
                            TeamNameMessage.Text = "Team ID is not found.";                            
                        }
                        else
                        {
                            TeamNameMessage.Text = teamName.TeamName;
                        }
                    }
                }
                else
                {
                    TeamNameMessage.Text = "Team ID must be a number.";
                }
            }
        }
    }
}