<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ShowResources.aspx.cs" Inherits="TS_Connect.ShowResources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Styles/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:LinkButton runat="server" ID="archiveLink" OnClick="archiveLink_Click"><i class="fa fa-archive" aria-hidden="true"></i></asp:LinkButton>
    </div>
     <%if (Request.QueryString["value"] == "Document")
         { %>
    <asp:GridView runat="server" ID="grdDocument" OnSelectedIndexChanging="grdDocument_SelectedIndexChanging" OnRowDeleting="grdDocument_RowDeleting" AutoGenerateColumns="false" AllowSorting="true" OnSorting="grdDocument_Sorting" OnRowCreated="grdDocument_RowCreated">
        <Columns>
            <asp:TemplateField  HeaderText="Document Id ↨" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="Doc_id">
                <ItemTemplate>
               
                     <asp:label runat="server" id="lblId" Text='<%# Eval("Doc_id") %>'> </asp:label>
                </ItemTemplate>            
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Title ↨" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="Doc_Title">
                <ItemTemplate>
                    <asp:label runat="server" id="lblTitle" Text='<%# Eval("Doc_Title") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Author ↨" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="Doc_Author">
                <ItemTemplate>
                    <asp:label runat="server" id="lblAuthor" Text='<%# Eval("Doc_Author") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subject ↨" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="Doc_Subject">
                <ItemTemplate>
                    <asp:label runat="server" id="lblSubject" Text='<%# Eval("Doc_Subject") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Year ↨" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="Doc_Year">
                <ItemTemplate>
                    <asp:label runat="server" id="lblYear" Text='<%# Eval("Doc_Year") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

          <asp:CommandField ButtonType="Link"  SelectText="View Details" ShowDeleteButton="true" DeleteText="Archive" ShowSelectButton="true" HeaderText="Action" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
             </asp:CommandField>
          </Columns>
    </asp:GridView>
    <%}
        else if (Request.QueryString["value"] == "Archive")
        { %>
    <asp:GridView runat="server" ID="gridArchiveDoc" AutoGenerateColumns="false" OnRowDeleting="gridArchiveDoc_RowDeleting" OnSelectedIndexChanging="gridArchiveDoc_SelectedIndexChanging">
         <Columns>
            <asp:TemplateField  HeaderText="Document Id" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >
                <ItemTemplate>
               
                     <asp:label runat="server" id="lblIdArch" Text='<%# Eval("Doc_id") %>'> </asp:label>
                </ItemTemplate>            
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Title" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblTitle" Text='<%# Eval("Doc_Title") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Author" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblAuthor" Text='<%# Eval("Doc_Author") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblSubject" Text='<%# Eval("Doc_Subject") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Year" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblYear" Text='<%# Eval("Doc_Year") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

          <asp:CommandField ButtonType="Link"  SelectText="View Details" ShowDeleteButton="true" DeleteText="Undo" ShowSelectButton="true" HeaderText="Action" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >
             </asp:CommandField>
          </Columns>
    </asp:GridView>
    <%} %>
     <% if (Request.QueryString["value"] == "Teacher" || Request.QueryString["value"] == "Student")
         {%>
    <asp:GridView runat="server" ID="grdTS" OnSelectedIndexChanging="grdTS_SelectedIndexChanging" AutoGenerateColumns="false" AllowSorting="true" OnSorting="grdTS_Sorting" OnRowCreated="grdTS_RowCreated">
         <Columns>
            <asp:TemplateField HeaderText="UserId" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="us_userId">
                <ItemTemplate>
                    <asp:label runat="server" id="lblUserId" Text='<%# Eval("us_userId") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
                  <asp:TemplateField HeaderText="Role" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="role_type">
                <ItemTemplate>
                    <asp:label runat="server" id="lblRole" Text='<%# Eval("role_type") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="FirstName" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="us_firstName">
                <ItemTemplate>
                    <asp:label runat="server" id="lblFName" Text='<%# Eval("us_firstName") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="LastName" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" SortExpression="us_lastName">
                <ItemTemplate>
                    <asp:label runat="server" id="lblLName" Text='<%# Eval("us_lastName") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
              <asp:CommandField ButtonType="Link"  SelectText="View Details" ShowSelectButton="true" HeaderText="Action" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >
             </asp:CommandField>
        </Columns>
        
    </asp:GridView>
    <%} %>
</asp:Content>
