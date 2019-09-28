<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ShowResourceList.aspx.cs" Inherits="TS_Connect.ShowResourceList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="grdDocumentDisplay" AutoGenerateColumns="false" OnSelectedIndexChanging="grdDocumentDisplay_SelectedIndexChanging" ShowHeader="true">
         <Columns>

             <asp:TemplateField HeaderText="Description" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblDes" Text='<%# Eval("Doc_Description") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Uploaded By" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblUploadBy" Text='<%# Eval("Doc_UploadedBy") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

              <asp:TemplateField HeaderText="Uploaded On" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblUploadedOn" Text='<%# Eval("Doc_UploadedOn") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>

         
              <asp:TemplateField HeaderText="File" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>              
                <asp:Label runat="server" ID="lblFile" Text='<%# System.IO.Path.GetFileNameWithoutExtension(Eval("Doc_File").ToString().Substring(13,Eval("Doc_File").ToString().Length-13))  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

               <asp:TemplateField HeaderText="File" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>             
                <asp:Label runat="server" ID="lblFileDownload" Text='<%# Eval("Doc_File")  %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="CoverPage" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                        <asp:Image ID="Image1" runat="server" Width="150" Height="100" ImageUrl='<%#Eval("Doc_Cover_Page")%>'/>        
               </ItemTemplate>
            </asp:TemplateField>

             <asp:CommandField ButtonType="Button"  SelectText="Download" ShowSelectButton="true" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1" >
                 </asp:CommandField>
        </Columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grdStudent" AutoGenerateColumns="false" ShowHeader="true">
         <columns>
          <asp:TemplateField HeaderText="Specialization" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblUserId" Text='<%# Eval("Student_specialization") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Batch" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblSchedule" Text='<%# Eval("Student_Batch") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Number of Documents Uploaded" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblNoOFStudents" Text='<%# Eval("Student_noOfDocuments") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
         
          <asp:TemplateField HeaderText="Contact" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblContact" Text='<%# Eval("details_contact") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblEmail" Text='<%# Eval("details_emailId") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderText="Image" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                        <asp:Image ID="stdImage" runat="server" Width="150" Height="100" ImageUrl='<%#Eval("details_image")%>'/>
                </ItemTemplate>
            </asp:TemplateField>
    </columns>
    </asp:GridView>
    <asp:GridView runat="server" ID="grdTeacher" AutoGenerateColumns="false" OnSelectedIndexChanging="grdTeacher_SelectedIndexChanging" ShowHeader="true">
         <Columns>
             <asp:TemplateField HeaderText="Specialization" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblUserId" Text='<%# Eval("Teacher_specialization") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
         
         <asp:TemplateField HeaderText="Number of Students Enroll" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblNoOFStudents" Text='<%# Eval("Teacher_numberOfStudents") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Planned Leaves" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblLeaves" Text='<%# Eval("Teacher_plannedLeaves") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="Contact" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblContact" Text='<%# Eval("details_contact") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
          <asp:TemplateField HeaderText="EmailId" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                    <asp:label runat="server" id="lblEmail" Text='<%# Eval("details_emailId") %>'> </asp:label>
                </ItemTemplate>
            </asp:TemplateField>
         <asp:TemplateField HeaderText="Image" HeaderStyle-CssClass="col-lg-1" ItemStyle-CssClass="col-lg-1">
                <ItemTemplate>
                        <asp:Image ID="tchImage" runat="server" Width="150" Height="100" ImageUrl='<%#Eval("details_image")%>'/>
         </ItemTemplate>
            </asp:TemplateField>
            
             
        </Columns>
    </asp:GridView>

    <% if (Session["RoleId"].ToString() == "1")
        { %>
    <asp:Label ID="lblStatus" runat="server" ForeColor="#33cc33"></asp:Label>
    <asp:GridView ID="grdTeacherSchedule" runat="server" OnSelectedIndexChanging="grdTeacherSchedule_SelectedIndexChanging" AutoGenerateColumns="false">
        <Columns>
              <asp:TemplateField HeaderText="BatchId" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                  <asp:Label runat="server" ID="lblBatchId" Text='<%# Eval("Scdle_BatchId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSubject" Text='<%# Eval("Scdle_Subject") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Start From" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                     <asp:Label runat="server" ID="lblDateFrom" Text='<%#DateTime.Parse(Eval("Scdle_FromDate").ToString()).ToString("dd/MM/yyyy")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="End ON" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                     <asp:Label runat="server" ID="lblDateTo" Text='<%# DateTime.Parse(Eval("Scdle_ToDate").ToString()).ToString("dd/MM/yyyy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Batch Time" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                      <asp:Label runat="server" ID="lblBatchTime" Text='<%# Eval("Scdle_Time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

           <asp:CommandField ButtonType="Button"  SelectText="Enroll" ShowSelectButton="true" HeaderText="Action" HeaderStyle-CssClass="column-head" />
      
        </Columns>
    </asp:GridView>

    <%} %>

   <% else if (Session["RoleId"].ToString() == "0")
    { %>
    <asp:GridView ID="grdTSchedule" runat="server" AutoGenerateColumns="false" ShowHeader="true">
        <Columns>

                   <asp:TemplateField HeaderText="BatchId" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                  <asp:Label runat="server" ID="lblBatchId" Text='<%# Eval("Scdle_BatchId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSubject" Text='<%# Eval("Scdle_Subject") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Start From" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                     <asp:Label runat="server" ID="lblDateFrom" Text='<%#DateTime.Parse(Eval("Scdle_FromDate").ToString()).ToString("dd/MM/yyyy")%>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField> 

            <asp:TemplateField HeaderText="End ON" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                     <asp:Label runat="server" ID="lblDateTo" Text='<%# DateTime.Parse(Eval("Scdle_ToDate").ToString()).ToString("dd/MM/yyyy") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Batch Time" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                      <asp:Label runat="server" ID="lblBatchTime" Text='<%# Eval("Scdle_Time") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <%} %>
</asp:Content>

