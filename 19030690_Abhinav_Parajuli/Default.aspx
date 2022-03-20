<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_19030690_Abhinav_Parajuli._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 
    <div style="width: 535px; padding:10px; background-color:white; border-radius:10px; box-shadow:1px 1px 3px ">
           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="MODULE_CODE" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="231px" >
               <Columns>
                   <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                   <asp:BoundField DataField="MODULE_CODE" HeaderText="MODULE_CODE" ReadOnly="True" SortExpression="MODULE_CODE" />
                   <asp:BoundField DataField="MODULE_NAME" HeaderText="MODULE_NAME" SortExpression="MODULE_NAME" />
                   <asp:BoundField DataField="CREDIT_HOUR" HeaderText="CREDIT_HOUR" SortExpression="CREDIT_HOUR" />
               </Columns>
            </asp:GridView>
           <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM MODULE WHERE MODULE_CODE = '?'" InsertCommand="INSERT INTO &quot;MODULE&quot; (&quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot;, &quot;CREDIT_HOUR&quot;) VALUES (?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT &quot;MODULE_CODE&quot;, &quot;MODULE_NAME&quot;, &quot;CREDIT_HOUR&quot; FROM &quot;MODULE&quot;" UpdateCommand="UPDATE &quot;MODULE&quot; SET &quot;MODULE_NAME&quot; = ?, &quot;CREDIT_HOUR&quot; = ? WHERE &quot;MODULE_CODE&quot; = ?">
               <DeleteParameters>
                   <asp:Parameter Name="MODULE_CODE" Type="String" />
               </DeleteParameters>
               <InsertParameters>
                   <asp:Parameter Name="MODULE_CODE" Type="String" />
                   <asp:Parameter Name="MODULE_NAME" Type="String" />
                   <asp:Parameter Name="CREDIT_HOUR" Type="Decimal" />
               </InsertParameters>
               <UpdateParameters>
                   <asp:Parameter Name="MODULE_NAME" Type="String" />
                   <asp:Parameter Name="CREDIT_HOUR" Type="Decimal" />
                   <asp:Parameter Name="MODULE_CODE" Type="String" />
               </UpdateParameters>
           </asp:SqlDataSource>
           <asp:FormView ID="FormView1" runat="server" DataKeyNames="MODULE_CODE" DataSourceID="SqlDataSource1">
               <EditItemTemplate>
                   MODULE_CODE:
                   <asp:Label ID="MODULE_CODELabel1" runat="server" Text='<%# Eval("MODULE_CODE") %>' />
                   <br />
                   MODULE_NAME:
                   <asp:TextBox ID="MODULE_NAMETextBox" runat="server" Text='<%# Bind("MODULE_NAME") %>' />
                   <br />
                   CREDIT_HOUR:
                   <asp:TextBox ID="CREDIT_HOURTextBox" runat="server" Text='<%# Bind("CREDIT_HOUR") %>' />
                   <br />
                   <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update" />
                   &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
               </EditItemTemplate>
               <InsertItemTemplate>
                   MODULE_CODE:
                   <asp:TextBox ID="MODULE_CODETextBox" runat="server" Text='<%# Bind("MODULE_CODE") %>' />
                   <br />
                   MODULE_NAME:
                   <asp:TextBox ID="MODULE_NAMETextBox" runat="server" Text='<%# Bind("MODULE_NAME") %>' />
                   <br />
                   CREDIT_HOUR:
                   <asp:TextBox ID="CREDIT_HOURTextBox" runat="server" Text='<%# Bind("CREDIT_HOUR") %>' />
                   <br />
                   <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insert" />
                   &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel" />
               </InsertItemTemplate>
               <ItemTemplate>
                   MODULE_CODE:
                   <asp:Label ID="MODULE_CODELabel" runat="server" Text='<%# Eval("MODULE_CODE") %>' />
                   <br />
                   MODULE_NAME:
                   <asp:Label ID="MODULE_NAMELabel" runat="server" Text='<%# Bind("MODULE_NAME") %>' />
                   <br />
                   CREDIT_HOUR:
                   <asp:Label ID="CREDIT_HOURLabel" runat="server" Text='<%# Bind("CREDIT_HOUR") %>' />
                   <br />
                   <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit" />
                   &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" />
                   &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="New" />
               </ItemTemplate>
           </asp:FormView>
    </div>
 
     

</asp:Content>
