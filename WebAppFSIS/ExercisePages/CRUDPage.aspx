<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUDPage.aspx.cs" Inherits="WebAppFSIS.ExercisePages.CRUDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Player Maintenance Page</h1>
    </div>
    <div class="container">
        <div class="row">
            <%--<asp:Label ID="Message" runat="server" CssClass="alert alert-danger mt-3"></asp:Label>--%>
            <asp:DataList ID="Message" runat="server">
                <ItemTemplate>
                    <%# Container.DataItem %>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" ID="PlayerIDLabel" CssClass="mr-2">ID</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="PlayerIDInput" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                <%--<asp:label runat="server" ID="ID" CssClass=""></asp:label>--%>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Guardian</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:DropDownList runat="server" ID="GuardianList" CssClass="custom-select"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Team</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:DropDownList runat="server" ID="TeamList" CssClass="custom-select"></asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">First Name</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="FirstName" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Last Name</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="LastName" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Age</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Age" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Gender</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="Gender" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-2">Alberta Health Care Number</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="AHCN" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-4">
                <asp:Label runat="server" CssClass="mr-3">Medical Alert Details</asp:Label>
            </div>
            <div class="col-md-8">
                <asp:TextBox runat="server" ID="MedicalAlertDetails" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <hr />
        <div class="row">
            <div class="col-md-4">
                <asp:Button runat="server" CssClass="btn btn-secondary" Text="Back" CausesValidation="false" OnClick="Back_click" />
            </div>
            <div class="col-md-8">
                <asp:Button runat="server" ID="AddButton" CssClass="btn btn-success" OnClick="Add_Click" Text="Add" />
                <asp:Button runat="server" ID="UpdateButton" CssClass="btn btn-success" OnClick="Update_Click" Text="Update" />
                <asp:Button runat="server" ID="DeleteButton" CssClass="btn btn-danger" OnClick="Delete_Click" OnClientClick="return DeletePopup();" Text="Delete" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function DeletePopup() {
            return confirm("Are you sure you wish to delete this player info?");
        }
    </script>
</asp:content>