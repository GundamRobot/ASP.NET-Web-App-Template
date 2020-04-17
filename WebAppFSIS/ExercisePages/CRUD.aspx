<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="WebAppFSIS.ExercisePages.CRUD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>CRUD</h1>
    </div>
    <div class="container">
        <div class="row">
            <%--<asp:DropDownList ID="DropDownList1" runat="server" CssClass="custom-select" DataSourceID="PlayerListODS" DataTextField="FullName" DataValueField="PlayerID" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Select a player...</asp:ListItem>
            </asp:DropDownList>--%>
            <asp:DropDownList ID="PlayerList" runat="server" CssClass="custom-select"></asp:DropDownList>
            <asp:Button runat="server" ID="ButtonAdd" CssClass="btn btn-success ml-2" Text="Add Player" CausesValidation="false" OnClick="Add_Click"/>
            <asp:Button runat="server" ID="ButtonFetch" CssClass="btn btn-secondary ml-2" Text="Edit Player" CausesValidation="false" OnClick="Edit_Click"/>
        </div>

        <div class="row">
            <asp:Label ID="Message" runat="server" CssClass="alert alert-danger mt-3"></asp:Label>
        </div>
    </div>
    <%--<asp:ObjectDataSource runat="server" ID="PlayerListODS" SelectMethod="Player_List" TypeName="FSISSystem.BLL.PlayerController"></asp:ObjectDataSource>--%>
</asp:Content>