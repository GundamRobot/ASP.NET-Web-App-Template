<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MultiRecordQueryWithCustomGridView.aspx.cs" Inherits="WebAppFSIS.ExercisePages.MultiRecordQueryWithCustomGridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="page-header">
        <h1>Multi Record Query with Custom GridView</h1>
    </div>
    <div class="container">    
        <div class="row">
            <p>This is where a dataset retrieved from the database will be output in a grid view.</p>
        </div>
        <div class="row">
            <asp:DropDownList ID="TeamList" runat="server" CssClass="custom-select" DataSourceID="TeamListODS" DataTextField="TeamName" DataValueField="TeamID" AppendDataBoundItems="true">
                <asp:ListItem Value="0">Select a team...</asp:ListItem>
            </asp:DropDownList>
            <asp:LinkButton runat="server" CssClass="btn btn-primary ml-2" OnClick="FetchTeamList_Click">Fetch Team List</asp:LinkButton>
        </div>

        <div class="row">
            <asp:Label ID="Message" runat="server" CssClass="alert alert-danger mt-3"></asp:Label>
        </div>

        <hr />      

        <div class="row">
            <h2>Team Roster</h2>
        </div>
        <asp:Panel runat="server" ID="TeamInfo">
            <div>
                <b>Coach: </b>
                <asp:Label runat="server" ID="Coach"></asp:Label>
            </div>
            <div>
                <b>Assistant Coach:</b>
                <asp:Label runat="server" ID="AssistantCoach"></asp:Label>
            </div>
            <div>
                <b>Wins:</b>
                <asp:Label runat="server" ID="Wins"></asp:Label>
            </div>
            <div>
                <b>Losses:</b>
                <asp:Label runat="server" ID="Losses"></asp:Label>
            </div>
        </asp:Panel>

        <br />

        <div class="row table-responsive-lg">
            <asp:GridView runat="server" ID="PlayerList" AutoGenerateColumns="false" OnSelectedIndexChanged="PlayerList_SelectedIndexChanged" DataSourceID="PlayerListODS" AllowPaging="true" PageSize="5" CssClass="table table-striped table-hover" GridLines="None" BorderStyle="None">               
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="FirstName" Text='<%# Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Age">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Age" Text='<%# Eval("Age") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Gender">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="Gender" Text='<%# Eval("Gender") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Medical Alert Details">
                        <ItemTemplate>
                            <asp:Label runat="server" ID="MedicalAlertDetails" Text='<%# Eval("MedicalAlertDetails") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>

                <EmptyDataTemplate>
                    <div>
                        No data to display at this time
                    </div>
                </EmptyDataTemplate>

            </asp:GridView>
        </div>

        <%-- Object Data Sources: --%>
        <asp:ObjectDataSource runat="server" ID="TeamListODS" SelectMethod="Team_List" TypeName="FSISSystem.BLL.TeamController"></asp:ObjectDataSource>
        <asp:ObjectDataSource runat="server" ID="PlayerListODS" SelectMethod="Players_FindByTeam" TypeName="FSISSystem.BLL.PlayerController">
            <SelectParameters>
                <asp:ControlParameter ControlID="TeamList" PropertyName="SelectedValue" DefaultValue="0" Name="teamid" Type="Int32"/>
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
</asp:Content>
