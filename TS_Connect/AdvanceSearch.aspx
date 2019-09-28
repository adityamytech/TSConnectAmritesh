<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="AdvanceSearch.aspx.cs" Inherits="TS_Connect.AdvanceSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr class="UserData">
            <td><asp:Label runat="server">Search By : </asp:Label></td>
            <td><asp:DropDownList runat="server" ID="dropDownKeyword" Class="pad rounded-pill shadow-sm  bg-black" AutoPostBack="true">
                <asp:ListItem Value="Title">Title</asp:ListItem>
                <asp:ListItem Value="Author">Author</asp:ListItem>
                <asp:ListItem Value="Subject">Subject</asp:ListItem>
                <asp:ListItem Value="Year">Year</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr class="UserData">
            <td><asp:Label runat="server">Search Keyword : </asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="txtBoxKeyword" Class="pad rounded-pill shadow-sm  bg-black"></asp:TextBox>
            </td>
        </tr>
        <tr class="UserData">
            <td>
                <asp:Button runat="server" ID="btnSubmitQ" Text="Submit Query" class="btn btn-primary btn-lg rounded-pill" OnClick="btnSubmitQ_Click" />
            </td>
            <td>
                <asp:Button runat="server" ID="btnReset" Text="Reset" class="btn btn-primary btn-lg rounded-pill" OnClick="btnReset_Click" />
            </td>
        </tr>
    </table>
    <asp:Label runat="server" ID="lblStatus"></asp:Label>
    <asp:GridView runat="server" ID="gridViewSearch" AutoGenerateColumns="False" CssClass="grdApprovalList" OnSelectedIndexChanging="gridViewSearch_SelectedIndexChanging">
        <Columns>
            <asp:TemplateField HeaderText="Title Name" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTitle" Text='<%# Eval("Doc_Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Document" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDoc" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Doc_File").ToString().Substring(13,Eval("Doc_File").ToString().Length-13)) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Document" HeaderStyle-CssClass="column-head" Visible="false">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblDocDocument" Text='<%# Eval("Doc_File") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
             <asp:CommandField ButtonType="Button"  SelectText="Download" ShowSelectButton="true" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >
                 </asp:CommandField>
        </Columns>
    </asp:GridView>
</asp:Content>
