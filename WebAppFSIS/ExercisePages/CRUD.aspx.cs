using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppFSIS.ExercisePages
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.Text = "";
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            try
            {
                string playerid = PlayerList.SelectedValue;
                Response.Redirect("CRUDPage.aspx?playerid=" + playerid);
            }
            catch (Exception ex)
            {
                Message.Text = ex.Message;
            }
        }
    }
}