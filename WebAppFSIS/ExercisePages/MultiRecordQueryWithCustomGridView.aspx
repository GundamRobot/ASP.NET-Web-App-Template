<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithCustomGridView.aspx.cs" Inherits="WebAppFSIS.ExercisePages.MultiRecordQueryWithCustomGridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1> Multi Record Query with Custom GridView</h1>
    </div>
    <div class="container">    
        <div class="row">
            <p>This is where a dataset retrieved from the database will be output in a grid view.</p>
        </div>
        <div class="row">
            <asp:DropDownList runat="server">
                <asp:ListItem Value="0">Select a team...</asp:ListItem>
            </asp:DropDownList>
            <asp:Button runat="server" Text="Fetch" />
        </div>

        <div class="row">
            <asp:Label runat="server">Team Name: </asp:Label>
            <asp:Label runat="server">Coach: </asp:Label>
            <asp:Label runat="server">Assistant Coach: </asp:Label>
            <asp:Label runat="server">Wins: </asp:Label>
            <asp:Label runat="server">Losses: </asp:Label>

        </div>

        <div class="row">
            <h2>

            </h2>
            <asp:GridView runat="server" CssClass="table table-striped" BorderStyle="None" AllowPaging="true" PageSize="5">
                <Columns>
                    <asp:TemplateField HeaderText="Player ID"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Player Name"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Age"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender"></asp:TemplateField>
                    <asp:TemplateField HeaderText="Medical Details"></asp:TemplateField>                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
