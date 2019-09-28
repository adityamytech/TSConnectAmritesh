<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AddResources.aspx.cs" Inherits="TS_Connect.AddResources" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <link href="Styles/style.css" rel="stylesheet" />
    <script src="../js/JavaScript.js"></script>
    <link href="Content/bootstrap.css" rel="stylesheet" />
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script>
        function ResourceAdded() {
            Swal.fire({
                type: 'success',
                title: 'Resource Added Successfully!',
                showConfirmButton: true,
                timer: 5000
            })
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class=" formAdd">
         <div class="ResourceData">
         <asp:Label runat="server" Width="44px"><i class="fa fa-id-card"> : </i></asp:Label>
    <asp:TextBox ID="RCodeTextBox" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="376px" Placeholder="Resource Id" ClientIDMode="Static" onchange="FunResourceIdVal()"></asp:TextBox>
    </div>
         <div class="ResourceData">
        <asp:Label runat="server" Width="44px"> <i class="fa fa-pencil-square"> : </i></asp:Label>
    <asp:TextBox ID="RDesTextBox" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="376px" Placeholder="Resource Description"  ClientIDMode="Static" onchange="FunRDesVal()" ></asp:TextBox><br />
        </div>
         <div class="ResourceData">
             <table>
           <tr><td><asp:Label ID="SkillLabel" runat="server" Width="100px" Text="Add Skill? "></asp:Label></td>
           <td><asp:RadioButtonList runat="server" ID="AddSkill" AutoPostBack="true" Class="pad" Width="150px" RepeatDirection="Horizontal" RepeatLayout="Flow" ClientIDMode="Static" Height="22px"  >
           <asp:ListItem Value="Yes" >Yes&nbsp;&nbsp;</asp:ListItem>
           <asp:ListItem Value="No" Selected="True">No&nbsp;&nbsp;&nbsp;</asp:ListItem>
       </asp:RadioButtonList></td>        
   <td><asp:Label runat="server"><i class="fa fa-file"></i></asp:Label></td>
               <td><asp:FileUpload runat="server" ID="DocUpload" /></td>
               </tr>
                 </table>
    </div >
          <%if (AddSkill.SelectedValue == "Yes")
              { %>
        <div class="ResourceData">
             <asp:Label runat="server" ID="SkillName"   Text="Skill Name : " Width="150px"></asp:Label>
        <asp:DropDownList runat="server"  Class="pad rounded-pill shadow-sm  bg-black" Width="300px"  ID="DropDownSkills">
        </asp:DropDownList>
            </div>
         <div class="ResourceData">
             <asp:Label runat="server" ID="CompetencyLevel"  Text="Competency Level : " Width="150px"></asp:Label>
    <asp:DropDownList runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="300px" ID="DropDownCompetency">
        <asp:ListItem>Beginner</asp:ListItem>
        <asp:ListItem>Intermediate</asp:ListItem>
        <asp:ListItem>Advanced</asp:ListItem>
    </asp:DropDownList>
            </div>
        
        <div class="ResourceData">
             <asp:Label runat="server" ID="IntendedAudience" Text="Intended Audience : " Width="150px"></asp:Label>
        <asp:DropDownList runat="server" Class="pad rounded-pill shadow-sm  bg-black" Width="300px" ID="DropDownIntendedAud">
            <asp:ListItem>Teacher</asp:ListItem>
            <asp:ListItem>Student</asp:ListItem>
            <asp:ListItem>Both</asp:ListItem>
        </asp:DropDownList>
            </div>
        <%} %>
        <div class="ResourceData">
            <asp:Button runat="server" ID="btnSubmit" Class="btn btn-primary btn-lg rounded-pill" Text="Submit" OnClientClick="return FunAddResources()"  OnClick="btnSubmit_Click" />
            <asp:Label ID="lblFail" runat="server" ForeColor="#cc3300"></asp:Label>
        </div>
        </div>
</asp:Content>
