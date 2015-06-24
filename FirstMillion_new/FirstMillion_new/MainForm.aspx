<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainForm.aspx.cs" Inherits="FirstMillion_new.MainForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" onload="window.history.forward()">
<head runat="server">
    <link rel="stylesheet" href="Css/styles.css"/>
    <script src="Jscripts/scripts.js"></script>
    <script src="Jscripts/jquery.min.js"></script>
    <title></title>
    
    
    
    </head>
<body>
    <form id="form1" runat="server">
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
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
        
    <table id="TblScores" class="tableScores" runat="server" >
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
        <tr>
            <td class="Million">1 000 000</td>
        </tr>
        <tr>
            <td class="tableCell">500 000</td>
        </tr>
        <tr>
            <td class="tableCell">250 000</td>
        </tr>
        <tr>
            <td class="tableCell">125 000</td>
        </tr>
        <tr>
            <td class="tableCell">64 000</td>
        </tr>
        <tr>
            <td class="tableCellUnFired">32 000</td>
        </tr>
        <tr>
            <td class="tableCell">16 000</td>
        </tr>
        <tr>
            <td class="tableCell">8 000</td>
        </tr>
        <tr>
            <td class="tableCell">4 000</td>
        </tr>
        <tr>
            <td class="tableCell">2 000</td>
        </tr>
        <tr>
            <td class="tableCellUnFired">1 000</td>
        </tr>
        <tr>
            <td class="tableCell">500</td>
        </tr>
        <tr>
            <td class="tableCell">300</td>
        </tr>
        <tr>
            <td class="tableCell">200</td>
        </tr>
        <tr>
            <td class="tableCell">100</td>
        </tr>
        <tr>
            <td class="tableCell"></td>
        </tr>
    </table>
               
        <asp:Button ID="BtnQuestion" runat="server" CssClass="Question" />
        
    </form>
    </body>
</html>
