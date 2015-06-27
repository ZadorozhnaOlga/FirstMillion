<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Start.aspx.cs" Inherits="FirstMillion_new.Start" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="server">

    
    <table id="TblEnterName" class="tableEnterName" runat="server" >
        <tr>
            <td>
                <asp:Label ID="LblName" runat="server" CssClass ="LblStart" Text="Введіть ім'я"></asp:Label>
               
            </td>
        </tr>
        <tr>
            <td>     
                <asp:TextBox ID="TxtName" runat="server" CssClass="TxtName"></asp:TextBox>     
                
                <asp:RequiredFieldValidator ID="rfvName" runat="server"
                                ErrorMessage="Введіть своє ім'я" ControlToValidate="TxtName"
                                ForeColor="Red" Display="Dynamic"/>
                
                <asp:RegularExpressionValidator ID="rfv1Name" runat="server"
                                    ErrorMessage="Некоректне введення" ControlToValidate="TxtName"
                                    ValidationExpression="^[а-яА-Яa-zA-Z]{3,12}$"
                                    ForeColor="Red" Display="Dynamic"/> 
            </td>
        </tr>
        <tr>
            <td>           
                <asp:Button ID="BtnStart" runat="server" CssClass ="BtnStart" OnClick="BtnStart_Click" Text="Розпочати гру" />
            </td>
        </tr>
    </table>
    
    

</asp:Content>
