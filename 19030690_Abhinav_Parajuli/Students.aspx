<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Students.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Students" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox ID="txtname" placeholder="Student Name" runat="server" ></asp:TextBox>
    <asp:TextBox ID="txtaddress" placeholder="Address" runat="server" ></asp:TextBox>
    <asp:TextBox ID="txtattendance" placeholder="Attendance" runat="server" ></asp:TextBox>
</div>

<div>
    <asp:GridView ID="studentGridView" runat="server" DataKeyNames="STUDENT_ID,STUDENT_NAME,STUDENT_ADDRESS,ATTENDANCE"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" >
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
            <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />
    </asp:GridView>
    <asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />

</asp:Content>
