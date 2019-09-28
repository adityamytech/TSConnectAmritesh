<%@ Page Title="" Language="C#" MasterPageFile="~/TS_MasterPage.Master" AutoEventWireup="true" CodeBehind="SuperUser.aspx.cs" Inherits="TS_Connect.SuperUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
      <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script>
        function Approved() {
            Swal.fire({
                type: 'success',
                title:'Approved',
                showConfirmButton: false,
                timer: 3000
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form runat="server">
         <div class="homepageSize navbar navbar-expand-lg navbar-light"> 
    <%--  <div class="log-out">
      <asp:LinkButton runat="server" ID="logoutbtn" OnClick="logoutbtn_Click"><i class="fas fa-power-off"></i></asp:LinkButton>
  </div>--%>
        <div class="log-out">
       <asp:LinkButton ID="LinkButton1" runat="server" OnClick="logoutbtn_Click" ForeColor="Black" Font-Size="X-Large"><i class="fa fa-power-off"></i></asp:LinkButton>
      </div> 
             <%--<div class="log-out">
      <asp:LinkButton runat="server" ID="logoutbtn" NavigateUrl="~/SignInPage.aspx" Font-Size="XX-Large" ForeColor="Black"><i class="fa fa-power-off"></i></asp:LinkButton>
             </div>--%>
             </div>
        <div class="updatestatus">
           <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </div>
        <asp:GridView ID="grdApprovalList" runat="server" CssClass="grdApprovalList" AutoGenerateColumns="False" HorizontalAlign="Center" GridLines="Horizontal"
            OnSelectedIndexChanging="grdApprovalList_SelectedIndexChanging" OnRowDeleting="grdApprovalList_RowDeleting" EditIndex="-1">
            <Columns>
                <asp:TemplateField HeaderText="UserId" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("us_userId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="First Name" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                        <asp:Label ID="lblFname" runat="server" Text='<%# Eval("us_firstName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Last Name" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                        <asp:Label ID="lblLname" runat="server" Text='<%# Eval("us_lastName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Number" HeaderStyle-CssClass="col-lg-2" ItemStyle-CssClass="col-lg-2">
                    <ItemTemplate>
                        <asp:Label ID="lblCnumber" runat="server" Text='<%# Eval("details_contact") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ButtonType="Button" SelectText="Approve" ShowSelectButton="true" ShowDeleteButton="true"  DeleteText="Reject" ItemStyle-CssClass="col-lg-3" />
            </Columns>
            <HeaderStyle BackColor="Black" ForeColor="White" />
        </asp:GridView>
         </form>
</asp:Content>
