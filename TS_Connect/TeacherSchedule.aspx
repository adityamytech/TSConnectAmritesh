<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="TeacherSchedule.aspx.cs" Inherits="TS_Connect.TeacherSchedule" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="gridScheduleList" AutoGenerateColumns="False" CssClass="table table-borderless column-item" Width="1000px">
        <Columns>
            <asp:TemplateField HeaderText="Teacher Name" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTeacherName" Text='<%# Eval("us_firstName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="BatchId" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                  <asp:Label runat="server" ID="lblBatchId" Text='<%# Eval("Scdle_BatchId") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Subject" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblSubject" Text='<%# Eval("Scdle_Subject") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>      
    </asp:GridView>

    <asp:GridView ID="gridScheduleStudent" runat="server" AutoGenerateColumns="false">

        <Columns>

             <asp:TemplateField HeaderText="Teacher Name" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                    <asp:Label runat="server" ID="lblTeacherName" Text='<%# Eval("us_firstName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

                        <asp:TemplateField HeaderText="BatchId" HeaderStyle-CssClass="column-head">
                <ItemTemplate>
                  <asp:Label runat="server" ID="lblBatchId" Text='<%# Eval("El_batchId") %>'></asp:Label>
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
     <%if (Session["RoleId"].ToString() == "0")
         { %>
    <div class="scheduleBtn">
       
    <asp:Button runat="server" ID="btnAddSchedule" Text="Add Schedule" OnClick="btnAddSchedule_Click" CssClass="btn btn-primary btn-lg rounded-pill" />
        <asp:Label runat="server" ID="lblStatus" ForeColor="Red" Font-Size="Small"></asp:Label>
        </div>
    <%} %>
    <asp:HiddenField runat="server" ID="hiddenSchedule" />
    <%if (hiddenSchedule.Value=="Show")
        {%>
    <table class="table-style">
        <tr>
            <td><asp:Label runat="server">From : </asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxFrom" TextMode="Date"></asp:TextBox>    </td>
            <td><asp:Label runat="server">To :</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxTo" TextMode="Date"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" >BatchID</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxId"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Batch Time : </asp:Label></td>
            <td><asp:DropDownList runat="server" ID="dropDownTime" AutoPostBack="true">
                <asp:ListItem Value="10:00 AM-12:00 PM">10:00 AM-12:00 PM</asp:ListItem>
                <asp:ListItem Value="12:00 PM-2:00 PM">12:00 PM-2:00 PM</asp:ListItem>
                <asp:ListItem Value="3:00 PM-5:00 PM">3:00 PM-5:00 PM</asp:ListItem>
                <asp:ListItem Value="5:00 PM-7:00 PM">5:00 PM-7:00 PM</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label runat="server" >Subject :</asp:Label></td>
            <td><asp:TextBox runat="server" ID="txtBoxSubject"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Description : </asp:Label>
            </td>
            <td><asp:TextBox runat="server" ID="txtBoxDesc"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label runat="server">Notes :</asp:Label></td>
            <td><asp:FileUpload runat="server" ID="uploadNotes"/></td>
            <td><asp:Button runat="server" ID="btnAdd" Text="Add" OnClick="btnAdd_Click" CssClass="btn btn-primary btn-lg rounded-pill"/></td>
        </tr>
    </table>
      <%}
          hiddenSchedule.Value = ""; %>
</asp:Content>
