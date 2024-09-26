<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="Addressbook.StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>State Page</h2>
    <div class="container">
        <div class="col-5 pt-5">
            <div class="form-group">
                <label for="ddlCountryID">Select Country: </label>
                <asp:DropDownList runat="server" ID="ddlCountryID" CssClass="form-control">
                    <asp:ListItem Text="Select Country" Value="" />
                    <asp:ListItem Text="USA" Value="1" />
                    <asp:ListItem Text="Canada" Value="2" />
                    <asp:ListItem Text="UK" Value="3" />
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ID="rfvCountryID" ControlToValidate="ddlCountryID" InitialValue="" ErrorMessage="Select a Country" ForeColor="Red" />
            </div>
            <div class="form-group">
                <label for="txtID">Enter State ID: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtStateID" placeholder="Enter State ID" EnableViewState="False"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvStateID" ControlToValidate="txtStateID" ErrorMessage="Enter State Id" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtName">Enter State Name: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtStateName" placeholder="Enter State Name" EnableViewState="False"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvStateName" ControlToValidate="txtStateName" ErrorMessage="Enter State Name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtCode">Enter State Code: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtStateCode" placeholder="Enter State Code"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvStateCode" ControlToValidate="txtStateCode" ErrorMessage="Enter State Code" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnAdd" Text="AddState" OnClick="btnAdd_Click" CssClass="btn btn-success" />
                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" />
                <asp:HyperLink runat="server" ID="hlCancle" NavigateUrl="~/State.aspx" Text="Cancle" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
