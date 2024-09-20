<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="State.aspx.cs" Inherits="Addressbook.State" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>State</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>State Page</h2>
    <asp:GridView ID="GridViewState" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered" OnRowCommand="GridViewState_RowCommand">
        <Columns>
            <asp:BoundField DataField="StateID" HeaderText="StateID" />
            <asp:BoundField DataField="StateName" HeaderText="StateName" />
            <asp:BoundField DataField="StateCode" HeaderText="StateCode" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>

                    <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="DeleteRecord" CommandArgument='<%# Eval("StateID") %>' />
                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CssClass="btn btn-info" CommandName="EditRecord" CommandArgument='<%# Eval("StateID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>



