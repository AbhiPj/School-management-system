<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Department.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Department" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<div>
    <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>
    <asp:TextBox ID="txtDepartmentName" runat="server" ></asp:TextBox>
</div>

<div>
<asp:GridView ID="departmentGridView" runat="server" DataKeyNames="DEPARTMENT_ID,DEPARTMENT_NAME"  OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." >
    <Columns>
        <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
        <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
    </Columns>
</asp:GridView>
<asp:Button ID="btnSubmit" OnClick="btnSubmit_Click" runat="server" Text="Button" />
</div>
</asp:Content>