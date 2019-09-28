
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/TS_MasterPage.Master" CodeBehind="SignUpPage.aspx.cs" Inherits="TS_Connect.SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Styles/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <script src="js/JavaScript.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
    <script>
        function SignUpUserAlert() {
            Swal.fire({
                position: 'center',
                type: 'success',
                title: 'Registered Successfully!',
                showConfirmButton: false,
                timer: 5000
            }).then((result) => {
                if (result.value) {
                    window.location.replace("SignInPage.aspx");
                }
            })
        }

        function SignUpAdminAlert() {
            Swal.fire({
                type: 'success',
                title: 'Registered Successfully!',
                text: 'Wait For Approval',
                showConfirmButton: true,
                timer: 5000
            }).then((result) => {
                if (result.value) {
                    window.location.replace("SignInPage.aspx");
                }
            })
        }
    </script>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <form class="formSignInSignUp" runat="server">
       <div class="UserData">
           <span>
        <span class="head-style">REGISTRATION&nbsp;&nbsp;</span>
       <asp:Label runat="server" ID="lblRole" Text="SignUp as User/Admin ?" Font-Bold="true"></asp:Label>      
    <asp:DropDownList ID="RoleList" ClientIDMode="Static" runat="server"  Class="pad rounded-pill shadow-sm  bg-black" AutoPostBack="True" OnSelectedIndexChanged="RoleList_SelectedIndexChanged">
         <asp:ListItem Value="Customer">User</asp:ListItem>
        <asp:ListItem Value="Admin">Admin</asp:ListItem>
    </asp:DropDownList>
               </span>
       </div>
<%if (RoleList.SelectedValue != "Select")
    { 
        %>  
    <div class="formSignInSingnUp" id="UserPage">
        <div class="row">
       <div class="col-lg-7"> 
           <asp:Label ID="lblStatus" runat="server" ForeColor="#ff0000" ></asp:Label>
         <div class="UserData">
            <span><i class="fa fa-user" ></i></span>
        <asp:TextBox ID="txtBoxFirstName" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="First Name" ClientIDMode="Static"  Width="300px" onchange="FunFirstNameVal()"></asp:TextBox>
              <asp:TextBox ID="txtBoxLastName" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Last Name" ClientIDMode="Static"   Width="300px" onchange="FunLastNameVal()" ></asp:TextBox>  
        </div>
         <div class="UserData">
            <span><i class="fa fa-user" ></i></span>
        <asp:TextBox ID="txtBoxUserid" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="User Id" ClientIDMode="Static" Width="300px" onchange="FunAdminIdVal()"></asp:TextBox>
        </div>
        
            <div class="UserData">
                <span><i class="fa fa-lock" ></i></span>
        <asp:TextBox ID="txtBoxPassword" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Enter Password" TextMode="Password" ClientIDMode="Static"  Width="300px" onchange=" FunPasswordVal()" ></asp:TextBox>
    </div>

            <div class="UserData">
                 <span><i class="fa fa-envelope" ></i></span>
        <asp:TextBox ID="txtBoxEmail" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Email" ClientIDMode="Static" Width="300px" onchange="FunEmailVal()" ></asp:TextBox>
           </div>
                  <div class="UserData">
               <span><i class="fa fa-phone" ></i></span>
        <asp:TextBox ID="txtBoxContact" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Contact Number" ClientIDMode="Static" Width="300px" onchange="FunContactNoVal()" ></asp:TextBox>

    </div>

            <div class="UserData">
                <span><i class="fa fa-calendar" ></i></span>
        <asp:TextBox ID="txtBoxDOB" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Date of Birth (YYYY/MM/DD)" ClientIDMode="Static"  Width="300px" TextMode="Date" onchange="FunDOBVal()" ></asp:TextBox>
    </div>

            <div class="UserData">
                <span><i class="fa fa-calendar" ></i></span>
        <asp:TextBox ID="txtBoxAge" runat="server" Class="pad rounded-pill shadow-sm  bg-black" Placeholder="Age" ClientIDMode="Static"  Width="300px" onchange="FunAgeVal()" ></asp:TextBox>
    </div>
            <div class="UserData">
               <span><i class="fa fa-venus-mars" > </i></span>
       <asp:RadioButton runat="server" ID="radioBtnMale" Text="Male" ClientIDMode="Static" GroupName="Gender" Checked="true" />
                <asp:RadioButton runat="server" ID="radioBtnFemale" ClientIDMode="Static" GroupName="Gender" Text="Female"/>
       
    </div>
           <%if (RoleList.SelectedValue == "Customer")
               {
                   
     %>
           
           <div class="UserData">
               <span><asp:Label runat="server">Select Category: </asp:Label></span>
               <asp:DropDownList ID="DropDownCategory" Class=" rounded-pill" runat="server">
                   <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                   <asp:ListItem Value="Student">Student</asp:ListItem>
               </asp:DropDownList>
           </div>
           <%}%>
        <div class="UserData">
           <asp:Label runat="server">Select one Security Question: </asp:Label>
            <asp:DropDownList ID="DropDownListQuestion" Class="rounded-pill" runat="server">
                <asp:ListItem Value="1">What is your pet name?</asp:ListItem>
                <asp:ListItem Value="2">Who was your favorite Teacher?</asp:ListItem>
                <asp:ListItem Value="3">What was the name of first school you attended?</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList><asp:TextBox ID="txtBoxAns" runat="server" Class="pad rounded-pill shadow-sm  bg-black " PlaceHolder="Enter your Answer" ClientIDMode="Static" Width="230px" onchange="FunAnswerVal()" ></asp:TextBox> 
        </div>
           <div class="UserData" > 
                <span class="buttons container"><asp:Button ID="testBtn" Text="Register" runat="server" class="btn btn-primary btn-lg rounded-pill" OnClick="testBtn_Click" OnClientClick="return FunAdminSignUp()" />
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/SignInPage.aspx">Already have an account?Sign In</asp:HyperLink></span> 
        </div>
          <%-- <div class="UserData">
           <asp:HyperLink ID="signInLink" runat="server" NavigateUrl="~/SignInPage.aspx">Already have an account?Sign In</asp:HyperLink>
               </div>--%>
   </div>
        <div class=" col-lg-5">    
            <asp:Image ID="ProfileImage" Class="border border-dark rounded-circle" runat="server" ImageUrl="~/Images/Fotolia_188161178_XS-6.jpg" ClientIDMode="Static" Height="250px" Width="250px" />
            <br />
            <asp:Label runat="server">Choose your Image:</asp:Label>
        <asp:FileUpload ID="ImageUpload" runat="server" ClientIDMode="Static" onchange="ImagePreview(this)" />
            <br />
            <br />  
        <%--<asp:Button ID="ImageButton" runat="server" Text="Upload" class="btn btn-primary btn-lg rounded-pill " style="margin-left:40px" OnClick="ImageButton_Click" />--%>
        <asp:Label ID="lblUploaded" runat="server"></asp:Label>
        
        </div>
            </div>
        </div>
         <%} %>


         </form>
    </asp:Content>
