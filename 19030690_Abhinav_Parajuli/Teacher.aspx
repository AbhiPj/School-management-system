<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Teacher.aspx.cs" Inherits="_19030690_Abhinav_Parajuli.Teacher" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-holder">
        <asp:TextBox ID="txtID" runat="server" visible="false"></asp:TextBox>
        <asp:TextBox ID="txtTeacherName" placeholder="Teacher Name" runat="server" ></asp:TextBox>
        <asp:DropDownList ID="addressDropdown" runat="server" DataSourceID="AddressDataSource" DataTextField="ADDRESS" DataValueField="ADDRESS_ID">
        </asp:DropDownList>
        <asp:SqlDataSource ID="AddressDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;ADDRESS_ID&quot;, &quot;ADDRESS&quot; FROM &quot;ADDRESS&quot;"></asp:SqlDataSource>
        <asp:DropDownList ID="moduleDropdown" runat="server" DataSourceID="ModuleDataSource" DataTextField="MODULE_NAME" DataValueField="MODULE_CODE">
        </asp:DropDownList>
        <asp:SqlDataSource ID="ModuleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot; FROM &quot;MODULE&quot;"></asp:SqlDataSource>
        <asp:TextBox ID="txtEmail" placeholder="Email" runat="server" ></asp:TextBox>
    </div>

    <div class="content-holder">
        <asp:GridView ID="teacherGridView" runat="server" DataKeyNames="TEACHER_ID,TEACHER_NAME,EMAIL" OnSelectedIndexChanging="OnSelectedIndexChanging" OnRowDataBound="OnRowDataBound" OnRowEditing="OnRowEditing" OnRowCancelingEdit ="OnRowCancelingEdit"  OnRowDeleting="OnRowDeleting" EmptyDataText="No records has been added." BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" Width="100%" >
            <AlternatingRowStyle BackColor="#F7F7F7" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Delete" Text="Delete" />
                <asp:ButtonField ButtonType="Button" CommandName="Edit" Text="Edit" />
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="View" />
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
    </div>

    <style>
                .content-holder{
            background-color:white;
            border-radius:10px;
            height:auto;
            margin-top:20px;
        }
    </style>
</asp:Content>
