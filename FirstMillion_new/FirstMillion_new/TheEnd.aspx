<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TheEnd.aspx.cs" Inherits="FirstMillion_new.TheEnd" %>
<%@ Register src="Scores.ascx" tagname="Scores" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    <asp:Button ID="BtnRestart" runat="server" CssClass="Restart" OnClick="BtnRestart_Click"/>

    <uc1:Scores ID="Scores" runat="server" />

</asp:Content>
