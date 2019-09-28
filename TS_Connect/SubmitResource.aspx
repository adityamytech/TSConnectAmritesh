<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="SubmitResource.aspx.cs" Inherits="TS_Connect.SubmitResource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
     <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <script src="../js/JavaScript.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="column-item">
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblResourceCode">Resource Code : </asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxResCode" class="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td>
                <asp:Label runat="server" ID="lblDescription">Description : </asp:Label>
            </td>
            <td><asp:TextBox runat="server" ID="txtBoxDesc" CssClass="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td>
                <asp:Label runat="server" ID="lblTitle">Title : </asp:Label>
            </td>
            <td><asp:TextBox runat="server" ID="txtBoxTitle" CssClass="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblAuthor">Author : </asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxAuthor" CssClass="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblSubject">Subject : </asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxSubject" CssClass="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblYear">Year : </asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxYear" CssClass="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblCoverPage">Upload Cover Page : </asp:Label></td>
            <td><asp:FileUpload runat="server" ID="uploadCoverPage" /></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server" ID="lblFile">Upload File : </asp:Label></td>
            <td><asp:FileUpload runat="server" ID="uploadFile" /></td>
        </tr>
        <tr class="UserData">
            <td><asp:Button runat="server" ID="btnSubmit" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td><asp:Label runat="server" ID="lblStatus"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
