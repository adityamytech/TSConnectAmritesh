<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ListSkills.aspx.cs" Inherits="TS_Connect.ListSkills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
     <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="gridViewSkills" OnSelectedIndexChanging="gridViewSkills_SelectedIndexChanging" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Sr.No">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSkillId" Text='<%#Eval("sk_code") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Skill Name">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSkillName" Text='<%#Eval("sk_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Action" SelectText="MAP" ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <asp:HiddenField ID="gridDisplayhide" runat="server" Value="" />
    <%if (gridDisplayhide.Value != "")
        { %>
    <asp:GridView runat="server" ID="gridViewResource" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="Resource Code">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblresCode" Text='<%#Eval("skRes_resCode") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Resource Description">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblResDes" Text='<%#Eval("res_description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Competency Level">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblComplevel" Text='<%#Eval("skRes_compLevel") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Intended Audience">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblIntendedAud" Text='<%#Eval("skRes_audience") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField HeaderText="Action" SelectText="Show Details" ShowCancelButton="False" ShowHeader="True" ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <%} %>
    <%--<table>
        <tr>
            <td>
            <asp:Label ID="lblresourceCode" runat="server">Resource Code:</asp:Label></td>
           <td> <asp:Label ID="resourceCode" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td>
            <asp:Label runat="server" ID="lblResDesc">Resource Description : </asp:Label></td>
           <td> <asp:Label runat="server" ID="resDesc"></asp:Label></td>
        </tr>
        <tr>
            <td>
            <asp:Label runat="server" ID="lblIntendedAud">Intended Audience : </asp:Label></td>
           <td> <asp:Label runat="server" ID="intendedAud"></asp:Label></td>
        </tr>
        <tr>
            <td>
            <asp:Label runat="server" ID="lblCompLevel">Competency Level : </asp:Label></td>
           <td> <asp:Label runat="server" ID="compLevel"></asp:Label></td>
        </tr>
    </table>--%>
</asp:Content>
