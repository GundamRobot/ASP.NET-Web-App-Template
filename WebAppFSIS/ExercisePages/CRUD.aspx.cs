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
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
            Message.Visible = false;

            if (!Page.IsPostBack)
            {
                BindPlayerList();
            }
        }

        protected void BindPlayerList()
        {
            try
            {
                // Here this will be similar to using the ObjectDataSource except now we're doing this more in the code behind instead of the web form
                // This is considered better for bigger projects
                PlayerController playerController = new PlayerController();
                List<Player> playerInfo = null;
                playerInfo = playerController.Player_List();
                playerInfo.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                PlayerList.DataSource = playerInfo;
                PlayerList.DataTextField = nameof(Player.FullName);
                PlayerList.DataValueField = nameof(Player.PlayerID);
                PlayerList.DataBind();
                PlayerList.Items.Insert(0, "Select a player...");
            }
            catch (Exception ex)
            {
                Message.Visible = true;
                Message.Text = ex.Message;
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex != 0)
            {
                Message.Visible = true;
                Message.Text = "Player has already been added";
            }
            else
            {
                try
                {
                    string playerid = PlayerList.SelectedValue;
                    Response.Redirect("CRUDPage.aspx?playerid=" + playerid + "&add=yes");
                }
                catch (Exception ex)
                {
                    Message.Visible = true;
                    Message.Text = ex.Message;
                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            if (PlayerList.SelectedIndex == 0)
            {
                Message.Visible = true;
                Message.Text = "Please select a player";
            }
            else
            {
                try
                {
                    string playerid = PlayerList.SelectedValue;
                    Response.Redirect("CRUDPage.aspx?playerid=" + playerid + "&add=no");
                }
                catch (Exception ex)
                {
                    Message.Visible = true;
                    Message.Text = ex.Message;
                }
            }
        }
    }
}