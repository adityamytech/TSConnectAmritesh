<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddSkills.aspx.cs" Inherits="TS_Connect.AddSkills" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="../Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
      <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script>
        function Skilladded() {
            Swal.fire({
                type: 'success',
                title:'Updated',
                Text: 'Resource updated Successfully!',
                showConfirmButton: true,
                timer: 5000
            })
        }
        function SkillMapped() {
            Swal.fire({
                type: 'success',
                title: 'Updated',
                Text: 'Resource updated Successfully!',
                showConfirmButton: true,
                timer: 5000
            }).then((result) => {
                if (result.value) {
                    window.location.replace("ResourceList.aspx");
                }
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
       <div class="ResourceData">
         <asp:Label runat="server" Width="44px"><i class="fa fa-id-card"> : </i></asp:Label>
   <asp:TextBox ID="RCodeTextBox" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="376px" Placeholder="Resource Id" ClientIDMode="Static"></asp:TextBox>
<asp:LinkButton ID="searchButton" runat="server" OnClick="searchButton_Click"><i class="fa fa-search"></i></asp:LinkButton>
            <asp:Label ID="lblStatus" runat="server" ForeColor="#cc3300"></asp:Label>
       <asp:HiddenField ID="HiddenField1" runat="server" Value="" />
           </div>
        <%if (HiddenField1.Value !="")
                {
                 %>
    <table>
        <tr class="ResourceData">
            <td><asp:Label runat="server">Resource Description :</asp:Label></td>
            <td><asp:Label runat="server" ID="lblResourceDesc"></asp:Label></td>
        </tr>
        <tr class="ResourceData">
            <td><asp:Label runat="server" ID="Label1" Text="Existing Skills"></asp:Label></td>
            <td>
                <asp:GridView runat="server" ID="gridViewSkills" GridLines="None" AutoGenerateColumns="False" Width="175px">
                    <Columns>
                               <asp:TemplateField ShowHeader="False">
                                      <ItemTemplate>
                                           <asp:Label ID="lblSkills" runat="server" Text='<%# Eval("skRes_skillname") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                          </Columns>

                </asp:GridView>
            </td>
        </tr>
        <tr class="ResourceData">
            <td><asp:Label runat="server">Add New Skill : </asp:Label></td>
            <td><asp:DropDownList runat="server" ID="dropDownSkills" AutoPostBack="true">
                </asp:DropDownList></td>
        </tr>
        <%if (dropDownSkills.SelectedItem.Value=="Others")
            { %>
      <tr class="ResourceData">
          <td><asp:Label runat="server">New Skill Name : </asp:Label></td>
          <td><asp:TextBox runat="server" ID="txtBoxSkill" Class="pad rounded-pill shadow-sm  bg-black"></asp:TextBox></td>
      </tr>
        <%} %>
         <tr class="ResourceData">
              <td>
                  <asp:Label runat="server">Competency Level:</asp:Label>
              </td><td>
                   <asp:DropDownList runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="300px" ID="dropDownBoxComp">
                 </asp:DropDownList>
              </td>
        </tr>
          <tr class="ResourceData">
            <td> <asp:Label runat="server">Intended Audience:</asp:Label> </td>
              <td>
        <asp:DropDownList runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="300px" ID="DropDownIntendedAud">
        </asp:DropDownList></td>
              </tr>
          <tr class="ResourceData">
            <td><asp:Button runat="server" ID="btnSubmit" Class="btn btn-primary btn-lg rounded-pill" Text="Update" OnClick="btnSubmit_Click" /></td>
        </tr>
        </table>
   
    <%}
        HiddenField1.Value = "";
         %>
</asp:Content>
