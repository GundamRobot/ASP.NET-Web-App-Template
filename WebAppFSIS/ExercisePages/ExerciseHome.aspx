<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ExerciseHome.aspx.cs" Inherits="WebAppFSIS.ExercisePages.ExerciseHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Exercise 5</h1>
    </div>

    <div class="row">
        <p>This is where a dataset retrieved from the database will be output in a grid view.</p>
    </div>

    <div class="row">
        <asp:TextBox ID="TeamNameInput" runat="server" class="form-control" placeholder="Team ID"></asp:TextBox>
        <asp:LinkButton runat="server" CssClass="btn btn-primary ml-2" OnClick="FetchTeamName_Click">Find Team Name</asp:LinkButton>
    </div>
    <div class="row">
        <asp:Label ID="TeamNameMessage" runat="server" CssClass="alert alert-secondary mt-2"></asp:Label>
    </div>

    <hr />

    <div class="row">
        <asp:DropDownList ID="TeamList" runat="server" CssClass="custom-select" DataSourceID="TeamListODS" DataTextField="TeamName" DataValueField="TeamID" AppendDataBoundItems="true">
            <asp:ListItem Value="0">Select a team...</asp:ListItem>
        </asp:DropDownList>
        <asp:LinkButton runat="server" CssClass="btn btn-primary ml-2">Fetch Team List</asp:LinkButton>
    </div>

    <div class="row">
        <asp:Label ID="Message" runat="server" ></asp:Label>
    </div>

    <asp:ObjectDataSource ID="TeamListODS" runat="server" SelectMethod="Team_List" TypeName="FSISSystem.BLL.TeamController"></asp:ObjectDataSource>
</asp:Content>
