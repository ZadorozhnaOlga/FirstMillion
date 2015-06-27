<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Game.aspx.cs" Inherits="FirstMillion_new.Game" %>

<%@ Register Src="~/Scores.ascx" TagPrefix="uc" TagName="Scores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

     <asp:Button ID="BtnQuestion" disabled="disabled" runat="server" CssClass="Question" />

    <table class="tableAnswers" runat="server">
            <tr>
                <td class="tableAnswer">
                    <asp:Button ID="BtnA" runat="server" CssClass="tableAnswerA" OnClick="BtnA_Click" />
                </td>
                <td class="tableAnswer">
                    <asp:Button ID="BtnB" runat="server" CssClass="tableAnswerB" OnClick="BtnB_Click" />
                </td>
                
            </tr>
            <tr>
                <td class="tableAnswer">
                    <asp:Button ID="BtnC" runat="server" CssClass="tableAnswerC" OnClick="BtnC_Click" />
                </td>
                <td class="tableAnswer">
                    <asp:Button ID="BtnD" runat="server" CssClass="tableAnswerD" OnClick="BtnD_Click" />
                    
                </td>
            </tr>
        </table>

    <table id="TblTooltips" class="tableTooltips" runat="server" >
        <tr>
            <td class="Tooltips">
                <asp:Button ID="Btn5050" runat="server" CssClass="Btn5050" OnClick="Btn5050_Click" />
                <asp:Button ID="BtnCall" runat="server" CssClass="BtnCall" OnClick="BtnCall_Click" />
                <asp:Button ID="BtnAsk" runat="server" CssClass="BtnAsk" OnClick="BtnAsk_Click" />
                <br />
                <asp:TextBox ID="TxtMymail" runat="server" CssClass="Text" TextMode="Email" placeholder ="Введіть вашу адресу"></asp:TextBox>
                <asp:TextBox ID="TxtPass" runat="server" CssClass="Text" TextMode="Password" placeholder="Введіть ваш пароль"></asp:TextBox>
                <br />
                <asp:TextBox ID="TxtMail" runat="server" CssClass="Mail" TextMode="Email" placeholder ="Введіть адресу друга"></asp:TextBox>
                <asp:Button ID="BtnSend" runat="server" Text="Відправити" OnClick ="BtnSend_Click" OnClientClick ="SendMail()"  CssClass="Send" />
                
                
            </td>
        </tr>
    </table>
    
    <uc:Scores ID="ActiveScores" runat="server" />
        
</asp:Content>
