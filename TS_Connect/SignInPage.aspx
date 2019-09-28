<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/TS_MasterPage.Master" CodeBehind="SignInPage.aspx.cs" Inherits="TS_Connect.SignInPage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>SIGN IN</title>

    <link href="Styles/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
    <link href="https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" rel="stylesheet"/>
    <script src="https://code.jquery.com/jquery-2.1.3.min.js"></script>

    <script src="js/JavaScript.js"></script>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@8"></script>
   <%-- <script>
        function SignIn() {
            swal.fire({
                title: 'Welcome!',
                text: 'Sunny',
                imageUrl: 'Images/Fotolia_188161178_XS-6.jpg',
                imageWidth: 250,
                imageHeight: 250,
                imageAlt: 'Custom image',
                animation: false,
              
            })
                //.then((result) => {
            //    //if (result.value) {
            //    //}
            //})
        }
    </script>--%>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form  class="formSignIn text-center " runat="server">

              
        <h2>SIGN IN</h2>

        <div class="SignInData" >
        <span><i class="fa fa-user" ></i></span>
        <asp:TextBox ID="txtBoxUser" runat="server" Class="pad rounded-pill shadow-sm  bg-black" placeholder="UserName" ClientIDMode="Static" width="300px" onchange="UserNameVal()"></asp:TextBox>
        </div>

        <div class="SignInData">
        <span ><i class="fa fa-lock" ></i></span>
        <asp:TextBox ID="txtBoxPassword" runat="server" Class="pad rounded-pill shadow-sm  bg-black" placeholder="Password" TextMode="Password" ClientIDMode="Static"  width="300px" onchange="PasswordVal()"></asp:TextBox>
        </div>
        <div>
           
        <asp:Label ID="lblStatus" runat="server" ForeColor="Red"></asp:Label>
                
            </div>
        <div class="SignInData">
            <asp:Button ID="btnSignIn" runat="server" Text="SIGN IN" class="btn btn-primary btn-lg rounded-pill" OnClick="btnSignIn_Click" OnClientClick="return LoginValidation()"/>
            <asp:Button ID="btnSignUp" runat="server" Text="SIGN UP" class="btn btn-secondary btn-lg rounded-pill " OnClick="btnSignUp_Click" />
            <br />
            <asp:HyperLink ID="PasswordHyperLink" runat="server" NavigateUrl="https://www.google.com">Forgot Password?</asp:HyperLink>
            <br />
        </div>
        
   
          </form>

    </asp:Content>


