<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Attendance.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Attendance" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>
    <asp:DropDownList ID="studentDropdown" runat="server" DataSourceID="StudentDatasource" DataTextField="STUDENT_NAME" DataValueField="STUDENT_ID">
    </asp:DropDownList>
    <asp:DropDownList ID="moduleDropdown" runat="server" DataSourceID="ModuleDataSource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
    </asp:DropDownList>
    <asp:TextBox placeholder="attendance" ID="txtattendance" runat="server" ></asp:TextBox>
    <asp:SqlDataSource ID="ModuleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>

        <asp:SqlDataSource ID="StudentDatasource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;STUDENT_ID&quot;, &quot;STUDENT_NAME&quot; FROM &quot;STUDENT&quot;"></asp:SqlDataSource>
</div>

<div>
<asp:GridView ID="attendanceGridview" runat="server" DataKeyNames="TEACHER_ID,TEACHER_NAME,EMAIL"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." >
    <Columns>
        <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
    </Columns>
</asp:GridView>
<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />
</div>
</asp:Content>
