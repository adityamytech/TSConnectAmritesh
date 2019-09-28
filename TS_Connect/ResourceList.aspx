<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ResourceList.aspx.cs" Inherits="TS_Connect.ResourceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label runat="server" ID="lblStatus"></asp:Label>
    <asp:GridView ID="grdResourceList" CssClass="ResourceList" runat="server" AutoGenerateColumns="False" ShowHeader="true" OnRowDeleting="grdResourceList_RowDeleting" OnSelectedIndexChanging="grdResourceList_SelectedIndexChanging" BorderStyle="None" GridLines="Horizontal" HorizontalAlign="Center" BackColor="#CCCCCC" >
        <Columns>
             <asp:TemplateField HeaderText="Resource Code" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                       <%-- <asp:LinkButton ID="lblResCode1" runat="server" Text='<%# Bind("res_code") %>' OnClick="lblResCode_Click"></asp:LinkButton>--%>
                        <asp:Label runat="server" ID="lblResCode" Text='<%# Bind("res_code") %>'></asp:Label>
                    </ItemTemplate>

<HeaderStyle CssClass="thead-dark col-lg-1"></HeaderStyle>

<ItemStyle CssClass="col-lg-1"></ItemStyle>
                </asp:TemplateField>

             <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="col-lg-3" ItemStyle-CssClass="col-lg-3">
                    <ItemTemplate>
                        <asp:Label ID="lblDesc" runat="server" Text='<%# Eval("res_description") %>'></asp:Label>
                    </ItemTemplate>

<HeaderStyle CssClass="thead-dark col-lg-3"></HeaderStyle>

<ItemStyle CssClass="col-lg-3"></ItemStyle>
                </asp:TemplateField>

              <asp:TemplateField HeaderText="Skills" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                    <ItemTemplate>
                        <asp:Label ID="lblSkills" runat="server" Text='<%# Eval("skRes_skillname") %>'></asp:Label>
                    </ItemTemplate>

<HeaderStyle CssClass="thead-dark col-lg-1"></HeaderStyle>

<ItemStyle CssClass="col-lg-1"></ItemStyle>
                </asp:TemplateField>

            <asp:TemplateField HeaderText="Competency" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                    <ItemTemplate>
                        <asp:Label ID="lblCompetency" runat="server" Text='<%# Eval("skRes_compLevel") %>'></asp:Label>
                    </ItemTemplate>

<HeaderStyle CssClass="thead-dark col-lg-1"></HeaderStyle>

<ItemStyle CssClass="col-lg-1"></ItemStyle>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Intended Audience" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                        <asp:Label ID="lblAudience" runat="server" Text='<%# Eval("skRes_audience") %>'></asp:Label>
                    </ItemTemplate>

<HeaderStyle CssClass="thead-dark col-lg-2"></HeaderStyle>

<ItemStyle CssClass="col-lg-2"></ItemStyle>
                </asp:TemplateField>

<%--            <asp:TemplateField HeaderText="Document" HeaderStyle-CssClass="col-lg-4" ItemStyle-CssClass="col-lg-4">
                    <ItemTemplate>
                      <asp:LinkButton ID="lblDoc" runat="server" Text='<%# Bind("res_document") %>' OnClick="lblDoc_Click">HyperLink</asp:LinkButton>
                    </ItemTemplate>

<HeaderStyle CssClass="col-lg-4"></HeaderStyle>

<ItemStyle CssClass="col-lg-4"></ItemStyle>--%>
             <%--   </asp:TemplateField>--%>

            <asp:CommandField ButtonType="Link"  SelectText="Update" ShowSelectButton="true" ShowDeleteButton="true"  DeleteText="Delete" HeaderText="Delete" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >

             </asp:CommandField>
            </Columns>  
        <EditRowStyle BackColor="#FFCC99" />
        <HeaderStyle BackColor="Black" ForeColor="White" />
    </asp:GridView>
</asp:Content>
