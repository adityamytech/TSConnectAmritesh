<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ProfileUser.aspx.cs" Inherits="TS_Connect.ProfileUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <link href="Styles/style.css" rel="stylesheet" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
  <script>
  $( function() {
      $("#txtBoxDOB").txtBoxDOB();
  });
  function UpdateProfileAlert() {
      Swal.fire({
          type: 'success',
          title: 'Updated Successfully!',
          showConfirmButton: false,
          timer: 2000
      }).then((result) => {
          if (result.value) {
              window.location.href="HomePageUser.aspx";
          }
      })
  }
  </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
   <asp:HiddenField runat="server" ID="hiddenStatus"/>
         <div class="formEditProfile profile-font" id="UserPage">
     <div class="row">
        
          <div class="col-lg-6">
             
            
              <br />
             <div class="UserData">
                 <span>  <span><i class="fa fa-user" ></i></span>
            <asp:TextBox runat="server" ID="txtBoxFirstName" Class="pad rounded-pill shadow-sm  bg-black"  Placeholder="First Name" Width="300px" AutoPostBack="True" ClientIDMode="Static" ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                 <span><i class="fa fa-user" ></i></span>
           <asp:TextBox runat="server" ID="txtBoxLastName" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Last Name" Width="300px" AutoPostBack="True"  ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>

                 </span>
           
            </div>
              <br />
             <div class="UserData">
                  <span><i class="fa fa-calendar" ></i></span>
                 <asp:TextBox runat="server" ID="txtBoxAge" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Age" Width="300px" AutoPostBack="True"   ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
            </div>
              <br />
              <div class="UserData">
               <span><i class="fa fa-venus-mars" > </i></span>
                    <asp:RadioButton runat="server" ID="radioMale" Text="Male" Enabled="false" GroupName="Gender"/>
                <asp:RadioButton runat="server" ID="radioFemale"  Enabled="false" GroupName="Gender" Text="Female"/>
       
                </div>
              <br />
            <div class="UserData">
                 <span><i class="fa fa-phone" ></i></span>
                 <asp:TextBox runat="server" ID="txtBoxContact" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Contact" Width="300px" AutoPostBack="True"  ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
            </div>
              <br />
            <div class="UserData">
                 <span><i class="fa fa-envelope" ></i></span>
                <asp:TextBox runat="server" ID="txtBoxEmailId" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="EmailID" Width="300px" AutoPostBack="True"   ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
            </div>
              <br />
            <div class="UserData">
                <span><i class="fa fa-calendar" ></i></span>
                <asp:TextBox runat="server" ID="txtBoxDOB"  Class="pad rounded-pill shadow-sm  bg-black" Placeholder="DOB" Width="300px" AutoPostBack="True"  ReadOnly="true" BackColor="#CCCCCC"></asp:TextBox>
                </div>
              <br />
              <div class="UserData">
               <asp:Label ID="lblSpecialization" runat="server" Text="Specialization:" Font-Bold="true"></asp:Label>
            <asp:TextBox runat="server" ID="txtSpecialization" Class="pad rounded-pill shadow-sm  bg-black" Width="300px"  BorderStyle="Solid" ReadOnly="true" BorderWidth="1px" BackColor="#CCCCCC"></asp:TextBox>

           </div>
            <div class="UserData">
                <br />
           <span>     <%--<asp:Button ID="btnEdit" runat="server" Text="Button" OnClick="btnEdit_Click"/>--%>
               <%if (hiddenStatus.Value=="Edit")
                   {%>
               <asp:Button ID="btnEdit" runat="server" class="btn btn-primary btn-lg rounded-pill" Text="Edit Profile" OnClick="btnEdit_Click" OnClientClick ="Return ChangeColor();"/>
               <% }
                   else if (hiddenStatus.Value=="Update")
                   {%>                 
                <asp:Button ID="btnUpdate" runat="server" class="btn btn-primary btn-lg rounded-pill" Text="Update" OnClick="btnUpdate_Click"/>
           <% } %>
                 </span></div>
              <asp:Label ID="lblStatus" runat="server" ForeColor="#66ff66"></asp:Label>
       </div>
        <div class="col-lg-6">
           <span>
                  <asp:Image class="rounded-circle profile-style" ImageAlign="Left" ID ="profileImage" runat="server"/> 
             </span>
            <br />
            <br />
             <asp:FileUpload runat="server" ID="ImageUpload" />
        </div>
        </div>
</div>
</asp:Content>
