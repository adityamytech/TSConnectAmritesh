/*===================================================*/
//TS_Connect Final
var UserNameVal = function () {
    var validateUserName = document.getElementById("txtBoxUser").value;
    if (validateUserName.length < 1) {
        document.getElementById("txtBoxUser").focus();
        document.getElementById("txtBoxUser").style.borderColor = "red";
        document.getElementById("txtBoxUser").style.borderStyle = "solid";
        document.getElementById("txtBoxUser").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxUser").style.borderStyle = "hidden";
        return true;
    }
}
    /*=====================*/
var PasswordVal = function () {
    var validatePassword = document.getElementById("txtBoxPassword").value;
    if (validatePassword.length < 1) {
        document.getElementById("txtBoxPassword").style.borderColor = "red";
        document.getElementById("txtBoxPassword").style.borderStyle = "solid";
        document.getElementById("txtBoxPassword").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxPassword").style.borderStyle = "hidden";
        return true;
    }
}
function LoginValidation() {
    var statusUserName = UserNameVal();
    var statusPassword = PasswordVal();
    if (statusUserName==true && statusPassword==false) {
        document.getElementById("txtBoxPassword").focus();
    }
    if (statusUserName==true && statusPassword==true) {
        return true;
    }
    else {
        return false;
    }
}
/*======================================================*/
var FunFirstNameVal = function () {
    var validateAdminFirstName = document.getElementById("txtBoxFirstName").value;
    var admin_regex = /^[A-Za-z]{1,15}$/;            /*Custom regular expression for admin name validation*/
    if (validateAdminFirstName.length < 1) {            /*First Name not null*/
        document.getElementById("txtBoxFirstName").style.borderColor = "red";
        document.getElementById("txtBoxFirstName").style.borderStyle = "solid";
        document.getElementById("txtBoxFirstName").style.borderWidth = "thin";
        return false;
    }
    else if (!(admin_regex.test(validateAdminFirstName))) {  /*First Name only contain letters*/
        document.getElementById("txtBoxFirstName").style.borderColor = "red";
        document.getElementById("txtBoxFirstName").style.borderStyle = "solid";
        document.getElementById("txtBoxFirstName").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxFirstName").style.borderStyle = "hidden";
        return true;
    }
}
/*==========================================================================================*/
var FunLastNameVal = function () {
    var validateAdminLastName = document.getElementById("txtBoxLastName").value;
    var admin_regex = /^[A-Za-z]{1,15}$/;
    if (validateAdminLastName.length < 1) {                 /*Last Name not null*/
        document.getElementById("txtBoxLastName").style.borderColor = "red";
        document.getElementById("txtBoxLastName").style.borderStyle = "solid";
        document.getElementById("txtBoxLastName").style.borderWidth = "thin";
        return false;
    }
    else if (!(admin_regex.test(validateAdminLastName))) { /*Last Name contains only letters*/
        document.getElementById("txtBoxLastName").style.borderColor = "red";
        document.getElementById("txtBoxLastName").style.borderStyle = "solid";
        document.getElementById("txtBoxLastName").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxLastName").style.borderStyle = "hidden";
        return true;
    }
}
/*===========================================================================================*/
var FunAdminIdVal = function () {
    var validateAdminId = document.getElementById("txtBoxUserid").value;
    var adminId_regex = /^^(?=.*[0-9])[a-zA-Z0-9]{3,15}$/;
    if (validateAdminId.length < 1) {                               /*Admin Id not empty*/
      //  document.getElementById("txtBoxUserid").focus();
       // alert("error");
        document.getElementById("txtBoxUserid").style.borderColor = "red";
        document.getElementById("txtBoxUserid").style.borderStyle = "solid";
        document.getElementById("txtBoxUserid").style.borderWidth = "thin";
        return false;
    }
    else if (!adminId_regex.test(validateAdminId)) {        /*AdminId should have one number and one letter atleast*/
        document.getElementById("txtBoxUserid").style.borderColor = "red";
        document.getElementById("txtBoxUserid").style.borderStyle = "solid";
        document.getElementById("txtBoxUserid").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxUserid").style.borderStyle = "hidden";
        return true;
    }
}

/*======================================================================*/
var FunPasswordVal = function () {
    var validatePassword = document.getElementById("txtBoxPassword").value;
    var password_regex = /^^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{7,15}$/;
    if (validatePassword.length < 1) {                                /*Password not empty*/
        document.getElementById("txtBoxPassword").style.borderColor = "red";
        document.getElementById("txtBoxPassword").style.borderStyle = "solid";
        document.getElementById("txtBoxPassword").style.borderWidth = "thin";
        return false;
    }
    else if (!(password_regex.test(validatePassword))) {  /*password should contain 7 to 15 characters which contain at least one numeric digit and a special character*/
        document.getElementById("txtBoxPassword").style.borderColor = "red";
        document.getElementById("txtBoxPassword").style.borderStyle = "solid";
        document.getElementById("txtBoxPassword").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxPassword").style.borderStyle = "hidden";
        return true;
    }
}
/*===========================================================================================*/
var FunContactNoVal = function () {
    var validateContactNo = document.getElementById("txtBoxContact").value;
    var contactNo_regex = /^[6789]{1}[0-9]{9}$/;
    if (validateContactNo.length < 1) {                 /*Contact number not null*/
        document.getElementById("txtBoxContact").style.borderColor = "red";
        document.getElementById("txtBoxContact").style.borderStyle = "solid";
        document.getElementById("txtBoxContact").style.borderWidth = "thin";
        return false;
    }
    else if (!contactNo_regex.test(validateContactNo)) {
        document.getElementById("txtBoxContact").style.borderColor = "red";
        document.getElementById("txtBoxContact").style.borderStyle = "solid";
        document.getElementById("txtBoxContact").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxContact").style.borderStyle = "hidden";
        return true;
    }

}
/*===========================================================================================*/
var FunAgeVal = function () {
    var validateAge = document.getElementById("txtBoxAge").value;
    if (validateAge.length < 1) {                             /*Age not null*/
        document.getElementById("txtBoxAge").style.borderColor = "red";
        document.getElementById("txtBoxAge").style.borderStyle = "solid";
        document.getElementById("txtBoxAge").style.borderWidth = "thin";
        return false;
    }
    else if (validateAge > 99) {                     /*Age should be less than 99*/
        document.getElementById("txtBoxAge").style.borderColor = "red";
        document.getElementById("txtBoxAge").style.borderStyle = "solid";
        document.getElementById("txtBoxAge").style.borderWidth = "thin";
        return false;
    }
    else if (isNaN(validateAge)) {                          /*Age should be a number*/
        document.getElementById("txtBoxAge").style.borderColor = "red";
        document.getElementById("txtBoxAge").style.borderStyle = "solid";
        document.getElementById("txtBoxAge").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxAge").style.borderStyle = "hidden";
        return true;
    }
}
/*==============================================================================================*/
//var FunValGender = function () {
//    var validateMale = document.getElementById("radioBtnMale").checked;
//    var validateFemale = document.getElementById("radioBtnFemale").checked;
//    if (validateMale == false && validateFemale == false) {
//        document.getElementById("radioBtnMale").focus();
//        alert("Select gender");
//        return false;
//    }
//    else {
//        return true;
//    }
//}
/*===============================================================================================*/
var FunAnswerVal = function () {
    var validateAnswer = document.getElementById("txtBoxAns").value;
    if (validateAnswer.length < 1) {
        document.getElementById("txtBoxAns").style.borderColor = "red";
        document.getElementById("txtBoxAns").style.borderStyle = "solid";
        document.getElementById("txtBoxAns").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxAns").style.borderStyle = "hidden";
        return true;
    }
}
/*===============================================================================================*/
var FunEmailVal = function () {
    var emailRegex = /\S+@\S+\.\S+/;
    var validateEmail = document.getElementById("txtBoxEmail").value;
    if (validateEmail.length < 1) {
        document.getElementById("txtBoxEmail").style.borderColor = "red";
        document.getElementById("txtBoxEmail").style.borderStyle = "solid";
        document.getElementById("txtBoxEmail").style.borderWidth = "thin";
        return false;
    }
    else if (!emailRegex.test(validateEmail)) {
        document.getElementById("txtBoxEmail").style.borderColor = "red";
        document.getElementById("txtBoxEmail").style.borderStyle = "solid";
        document.getElementById("txtBoxEmail").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxEmail").style.borderStyle = "hidden";
        return true;
    }
}
/*================================================================================================*/
var FunDOBVal = function () {
    var validateDOB = document.getElementById("txtBoxDOB").value;
    if (validateDOB.length <1) {
        document.getElementById("txtBoxDOB").style.borderColor = "red";
        document.getElementById("txtBoxDOB").style.borderStyle = "solid";
        document.getElementById("txtBoxDOB").style.borderWidth = "thin";
        return false;
    }
    else {
        document.getElementById("txtBoxDOB").style.borderStyle = "hidden";
        return true;
    }
}
/*================================================================================================*/
/* Admin sign up validation*/
//function check() {
//    alert("check function");
//    return true;
//}
function FunAdminSignUp() {
  var a=  FunFirstNameVal();
  var b=  FunLastNameVal();
   var c= FunAdminIdVal();
   var d= FunPasswordVal();
   var e= FunEmailVal();
   var f= FunContactNoVal();
   var g= FunDOBVal();
   var h= FunAgeVal();
  // var i= FunValGender();
   var j = FunAnswerVal();
   if (a == true && b == true && c == true && d == true && e == true && f == true && g == true && h == true && j == true) {
      // alert("true");
       return true;
   }
   else {
      // alert("false");
       return false;
   }
}
/*==================================================================================================================================*/
/*registration sweet alert*/
//function SignUpUserAlert() {
//    Swal.fire({
//        position: 'top-end',
//        type: 'success',
//        title: 'Registered Successfully!',
//        showConfirmButton: false,
//        timer: 1500
//    }).then((result) => {
//        if (result.value) {
//            window.location.replace("https://www.google.com");
//        }
//    })
//}
//==================================================================================
//function SignUpAdminAlert() {
//    Swal.fire({
//        type: 'success',
//        title: 'Registered Successfully!',
//        text: 'Wait For Approval',
//        showConfirmButton: true,
//        timer: 5000
//    }).then((result) => {
//        if (result.value) {
//            window.location.replace("https://www.google.com");
//        }
//    })
//}
/*===================================================================================*/

function ImagePreview(input) {

    var FileUploadPath = document.getElementById("ImageUpload").value;
    ////To check if user upload any file
    if (FileUploadPath == '') {
        alert("Please upload an image");
        return false;
    } else {
        var Extension = FileUploadPath.substring(
            FileUploadPath.lastIndexOf('.') + 1).toLowerCase();
        //    //The file uploaded is an image
        if (Extension == "gif" || Extension == "png" || Extension == "bmp"
            || Extension == "jpeg" || Extension == "jpg") {
            if (input.files && input.files[0]) {
                var reader1 = new FileReader();
                reader1.onload = function (input) {
                    var abc = input.target.result;
                    document.getElementById("ProfileImage").src = abc;
                }
                reader1.readAsDataURL(input.files[0]);
            }
        }
        else {
            alert("Valid image type required");
        }
    }
}

//Add Resources Validation

var FunResourceIdVal = function () {
  
     var validateResourceId = document.getElementById("RCodeTextBox").value;
     if (validateResourceId.length < 1) {
       document.getElementById("RCodeTextBox").focus();
       document.getElementById("RCodeTextBox").style.borderColor = "red";
       document.getElementById("RCodeTextBox").style.borderStyle = "solid";
       document.getElementById("RCodeTextBox").style.borderWidth = "thin";     
        return false;
    }
    else {
        document.getElementById("RCodeTextBox").style.borderStyle = "hidden";
        return true;
    }
}
/*=======================================================================*/
var FunRDesVal = function () {
    var validateRDes = document.getElementById("RDesTextBox").value;
    if (validateRDes.length < 1) {     
        document.getElementById("RDesTextBox").style.borderColor = "red";
        document.getElementById("RDesTextBox").style.borderStyle = "solid";
        document.getElementById("RDesTextBox").style.borderWidth = "thin";
       
        return false;
    }
    else {
        document.getElementById("RDesTextBox").style.borderStyle = "hidden";
        return true;
    }
}
/*============================================================================*/
//var FunRadioSkillVal = function () {
//   // var check = $('#RadioButtonList').find(":checked").val();
//    var validateRadioSkill = document.getElementById("AddSkill");
//   // alert(validateRadioSkill);
//    if (validateRadioSkill==null) {
//        alert("Please Select Yes or No");
//        return false;
//    }
//    else {
//        return true;
//    }
//}
/*========================================================================*/
function FunAddResources() {
    var statusRId = FunResourceIdVal();
    var statusRDes = FunRDesVal();
  //  var statusRSkill = FunRadioSkillVal();

    if (statusRId == true && statusRDes == false) {
        document.getElementById("RDesTextBox").focus();
    }    
    if (statusRId == true && statusRDes == true) {
        return true;
    }
    else {
        return false;
    }
}
/*=========================================================================*/
/*===========================================================================================================================================================================================*/
//UserResource Submit
var ResCodeValidation = function () {
    alert("inside res code");
    var _resCodeVal = document.getElementById("txtBoxResCode").value;
    
    if (_resCodeVal.length < 1) {
        document.getElementById("txtBoxResCode").style.borderColor = "red";
        document.getElementById("txtBoxResCode").style.borderStyle = "solid";
        document.getElementById("txtBoxResCode").style.borderWidth = "thin";

        return false;
    }
    else {
        document.getElementById("txtBoxResCode").style.borderStyle = "hidden";
        return true;
    }
}
/*===================================================*/
var DescriptionValidation = function () {
    var _desVal = document.getElementById("txtBoxDesc").value;
    if (_desVal.length < 1) {
         alert("inside des");
         document.getElementById("txtBoxDesc").style.borderColor = "red";
         document.getElementById("txtBoxDesc").style.borderStyle = "solid";
         document.getElementById("txtBoxDesc").style.borderWidth = "thin";

        return false;
    }
    else {
        document.getElementById("txtBoxDesc").style.borderStyle = "hidden";
        return true;
    }
}
/*===============================================================*/
var TitleValidation = function () {
    var _titleVal = document.getElementById("txtBoxTitle").value;

    if (_titleVal.length < 1) {
         alert("inside title code");
        document.getElementById("txtBoxTitle").style.borderColor = "red";
        document.getElementById("txtBoxTitle").style.borderStyle = "solid";
        document.getElementById("txtBoxTitle").style.borderWidth = "thin";

        return false;
    }
    else {
        document.getElementById("txtBoxTitle").style.borderStyle = "hidden";
        return true;
    }
}

/*===================================================*/

var AuthorValidation = function () {
    var _authorVal = document.getElementById("txtBoxAuthor").value;
    if (_authorVal.length < 1) {
         alert("inside author");
        document.getElementById("txtBoxAuthor").style.borderColor = "red";
        document.getElementById("txtBoxAuthor").style.borderStyle = "solid";
        document.getElementById("txtBoxAuthor").style.borderWidth = "thin";

        return false;
    }
    else {
        document.getElementById("txtBoxAuthor").style.borderStyle = "hidden";
        return true;
    }
}


/*===================================================*/

var SubjectValidation = function () {

    var _subjectVal = document.getElementById("txtBoxSubject").value;
     alert("************");
    if (_subjectVal.length < 1) {
         alert("inside subject");
        document.getElementById("txtBoxSubject").style.borderColor = "red";
        document.getElementById("txtBoxSubject").style.borderStyle = "solid";
        document.getElementById("txtBoxSubject").style.borderWidth = "thin";

        return false;
    }
    else {
         alert("inside subject else");
        document.getElementById("txtBoxSubject").style.borderStyle = "hidden";
        return true;
    }
}

/*===================================================*/

var YearValidation = function () {
    var _yearVal = document.getElementById("txtBoxYear").value;
    if (isNaN(_yearVal) || _yearVal.length < 1) {
          alert("inside year");
        document.getElementById("txtBoxYear").style.borderColor = "red";
        document.getElementById("txtBoxYear").style.borderStyle = "solid";
        document.getElementById("txtBoxYear").style.borderWidth = "thin";
        return false;
    }
    else if (_yearVal > 2019 || _yearVal < 2000) {
        document.getElementById("txtBoxYear").style.borderColor = "red";
        document.getElementById("txtBoxYear").style.borderStyle = "solid";
        document.getElementById("txtBoxYear").style.borderWidth = "thin";
        return false;
    }
    else {
          alert(_yearVal);
        document.getElementById("txtBoxYear").style.borderStyle = "hidden";
        return true;
    }
}
/*=============================================================================*/

/*=========================================================*/
function SubmitResourceVal() {
     alert("inside main function");
    var statusResCode = ResCodeValidation();
    var statusDes = DescriptionValidation();
    var statusTitle = TitleValidation();
    var statusAuthor = AuthorValidation();
    var statusSubject = SubjectValidation();
    var statusYear = YearValidation();
    if (statusResCode == true && statusTitle == true && statusAuthor == true && statusSubject == true && statusYear == true && statusDes == true) {
        return true;
    }
    else {
         alert("inside user else");
        return false;
    }
}

