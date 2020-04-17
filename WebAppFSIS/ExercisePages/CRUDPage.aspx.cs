using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.BLL;
using FSISSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace WebAppFSIS.ExercisePages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string playerid = "";
        static string add = "";

        List<string> errorMessageList = new List<string>();
        private static List<Player> playerList = new List<Player>();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Message.Visible = false;

            Message.DataSource = null;
            Message.DataBind();

            if (!Page.IsPostBack)
            {
                playerid = Request.QueryString["playerid"];
                add = Request.QueryString["add"];
                BindGuardianList();
                BindTeamList();

                if (string.IsNullOrEmpty(playerid))
                {
                    Response.Redirect("CRUD.aspx");
                }
                else if (add == "yes")
                {
                    //PlayerIDLabel.Visible = false;
                    //ID.Visible = false;
                    UpdateButton.Visible = false;
                    DeleteButton.Visible = false;
                }
                else
                {
                    AddButton.Visible = false;

                    PlayerController playerController = new PlayerController();
                    Player playerInfo = null;
                    playerInfo = playerController.Player_Find(int.Parse(playerid));

                    if (playerInfo == null)
                    {
                        errorMessageList.Add("Record is no longer on file.");
                        LoadMessageDisplay(errorMessageList, "alert alert-info");
                        Clear_Fields(sender, e);
                    }
                    else
                    {
                        PlayerIDInput.Text = playerInfo.PlayerID.ToString();

                        if (playerInfo.GuardianID.HasValue)
                        {
                            GuardianList.SelectedValue = playerInfo.GuardianID.ToString();
                        }
                        else
                        {
                            GuardianList.SelectedIndex = 0;
                        }

                        if (playerInfo.TeamID.HasValue)
                        {
                            TeamList.SelectedValue = playerInfo.TeamID.ToString();
                        }
                        else
                        {
                            TeamList.SelectedIndex = 0;
                        }

                        FirstName.Text = playerInfo.FirstName;
                        LastName.Text = playerInfo.LastName;
                        Age.Text = playerInfo.Age.ToString();
                        Gender.Text = playerInfo.Gender;
                        AHCN.Text = playerInfo.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text = playerInfo.MedicalAlertDetails;
                    }
                }
            }
        }

        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }

        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }

        protected void Validation(object sender, EventArgs e)
        {
            // Guardian list dropdown
            if (GuardianList.SelectedIndex == 0)
            {
                errorMessageList.Add("Please select a guardian");
            }
            // Team list dropdown
            if (TeamList.SelectedIndex == 0)
            {
                errorMessageList.Add("Please select a team");
            }
            // First name textbox
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errorMessageList.Add("Please input a first name");
            }
            // Last name textbox
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errorMessageList.Add("Please input a last name");
            }
            // Age text box (between 6 to 14)
            if (string.IsNullOrEmpty(Age.Text))
            {
                errorMessageList.Add("Please input an age between 6 to 14 years old");
            }
            else
            {
                int ageRange = 0;

                if (int.TryParse(Age.Text, out ageRange))
                {
                    if (ageRange < 6 || ageRange > 14)
                    {
                        errorMessageList.Add("Age value must be between 6 to 14 years old");
                    }
                }
                else
                {
                    errorMessageList.Add("Age value must be a real whole number");
                }

            }
            // Gender textbox (Maybe consider using radio buttons)
            if (string.IsNullOrEmpty(Gender.Text))
            {
                errorMessageList.Add("Please input a gender");
            }
            // Alberta health care number
            if (string.IsNullOrEmpty(AHCN.Text))
            {
                errorMessageList.Add("Please input a 10 digit alberta healthcare number");
            }
            else
            {
                if (AHCN.Text.Length < 10 || AHCN.Text.Length > 10)
                {
                    errorMessageList.Add("Alberta healthcare number must be 10 digits");
                }
            }
        }

        protected void Clear_Fields(object sender, EventArgs e)
        {
            GuardianList.ClearSelection();
            TeamList.ClearSelection();
            FirstName.Text = "";
            LastName.Text = "";
            Age.Text = "";
            Gender.Text = "";
            AHCN.Text = "";
            MedicalAlertDetails.Text = "";
        }

        protected void BindGuardianList()
        {
            try
            {
                GuardianController guardianController = new GuardianController();
                List<Guardian> guardianInfo = null;
                guardianInfo = guardianController.Guardian_List();
                guardianInfo.Sort((x, y) => x.FullName.CompareTo(y.FullName));
                GuardianList.DataSource = guardianInfo;
                GuardianList.DataTextField = nameof(Guardian.FullName);
                GuardianList.DataValueField = nameof(Guardian.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "Select a guardian...");
            }
            catch (Exception ex)
            {
                //Message.Visible = true;
                errorMessageList.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errorMessageList, "alert alert-danger");
            }
        }

        protected void BindTeamList()
        {
            try
            {
                TeamController teamController = new TeamController();
                List<Team> teamInfo = null;
                teamInfo = teamController.Team_List();
                teamInfo.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = teamInfo;
                TeamList.DataTextField = nameof(Team.TeamName);
                TeamList.DataValueField = nameof(Team.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "Select a team...");
            }
            catch (Exception ex)
            {
                //Message.Visible = true;
                errorMessageList.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errorMessageList, "alert alert-danger");
            }
        }

        protected void Back_click(object sender, EventArgs e)
        {
            Response.Redirect("CRUD.aspx");
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            Validation(sender, e);

            if (errorMessageList.Count > 0)
            {
                LoadMessageDisplay(errorMessageList, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController playerController = new PlayerController();
                    Player player = new Player();

                    player.GuardianID = int.Parse(GuardianList.SelectedValue);
                    player.TeamID = int.Parse(TeamList.SelectedValue);
                    player.FirstName = FirstName.Text;
                    player.LastName = LastName.Text;
                    player.Age = int.Parse(Age.Text);
                    player.Gender = Gender.Text;
                    player.AlbertaHealthCareNumber = AHCN.Text;

                    if (string.IsNullOrEmpty(MedicalAlertDetails.Text))
                    {
                        player.MedicalAlertDetails = null;
                    }
                    else
                    {
                        player.MedicalAlertDetails = MedicalAlertDetails.Text;
                    }

                    int newID = playerController.Player_Add(player);
                    PlayerIDInput.Text = newID.ToString();

                    errorMessageList.Add("Player has been added!");
                    LoadMessageDisplay(errorMessageList, "alert alert-success");
                }
                catch (Exception ex)
                {
                    errorMessageList.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errorMessageList, "alert alert-danger");
                }
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (string.IsNullOrEmpty(PlayerIDInput.Text))
            {
                errorMessageList.Add("Search for a player to update");
            }
            else if (!int.TryParse(PlayerIDInput.Text, out id))
            {
                errorMessageList.Add("Invalid Player ID");
            }

            Validation(sender, e);

            if (errorMessageList.Count > 0)
            {
                LoadMessageDisplay(errorMessageList, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController playerController = new PlayerController();
                    Player player = new Player();

                    player.PlayerID = int.Parse(PlayerIDInput.Text);
                    player.GuardianID = int.Parse(GuardianList.SelectedValue);
                    player.TeamID = int.Parse(TeamList.SelectedValue);
                    player.FirstName = FirstName.Text;
                    player.LastName = LastName.Text;
                    player.Age = int.Parse(Age.Text);
                    player.Gender = Gender.Text;
                    player.AlbertaHealthCareNumber = AHCN.Text;

                    if (string.IsNullOrEmpty(MedicalAlertDetails.Text))
                    {
                        player.MedicalAlertDetails = null;
                    }
                    else
                    {
                        player.MedicalAlertDetails = MedicalAlertDetails.Text;
                    }

                    int rowsAffected = playerController.Player_Update(player);

                    if (rowsAffected > 0)
                    {
                        errorMessageList.Add("Player has been updated!");
                        LoadMessageDisplay(errorMessageList, "alert alert-success");
                    }
                    else
                    {
                        errorMessageList.Add("Player was not found");
                        LoadMessageDisplay(errorMessageList, "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    errorMessageList.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errorMessageList, "alert alert-danger");
                }
            }
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = 0;

            if (string.IsNullOrEmpty(PlayerIDInput.Text))
            {
                errorMessageList.Add("Select player data to delete");
            }
            else if (!int.TryParse(PlayerIDInput.Text, out id))
            {
                errorMessageList.Add("Invalid Player ID");
            }

            if (errorMessageList.Count > 0)
            {
                LoadMessageDisplay(errorMessageList, "alert alert-info");
            }
            else
            {
                try
                {
                    PlayerController playerController = new PlayerController();
                    int rowsAffected = playerController.Delete(id);

                    if (rowsAffected > 0)
                    {
                        errorMessageList.Add("Player info has been deleted!");
                        LoadMessageDisplay(errorMessageList, "alert alert-success");
                        Clear_Fields(sender, e);
                    }
                    else
                    {
                        errorMessageList.Add("Player was not found");
                        LoadMessageDisplay(errorMessageList, "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    errorMessageList.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errorMessageList, "alert alert-danger");
                }
            }

        }
    }
}