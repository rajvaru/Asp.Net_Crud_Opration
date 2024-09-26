<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="Addressbook.CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>City Page</h2>
    <div class="container">
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <div class="col-5 pt-5">
            <div class="form-group">
                <div class="form-group">
                    <label for="txtName">Enter City Name: </label>
                    <asp:TextBox runat="server" class="form-control" ID="txtCityName" placeholder="Enter City Name" EnableViewCity="False"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvCityName" ControlToValidate="txtCityName" ErrorMessage="Enter City Name" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <label for="txtCode">Enter City ID: </label>
                    <asp:TextBox runat="server" class="form-control" ID="txtCityID" placeholder="Enter City ID"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="rfvCityID" ControlToValidate="txtCityID" ErrorMessage="Enter City ID" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                </div>
                
                <label for="ddlStateID">Select State: </label>
                <asp:DropDownList runat="server" ID="ddlStateID" CssClass="form-control">
                    <asp:ListItem Value="0">Select State</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtCode">Enter City Code: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtSTDCode" placeholder="Enter City Code"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvSTDCode" ControlToValidate="txtSTDCode" ErrorMessage="Enter City Code" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <label for="txtCode">Enter Pin Code: </label>
                <asp:TextBox runat="server" class="form-control" ID="txtPinCode" placeholder="Enter Pin Code"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ID="rfvPinCode" ControlToValidate="txtPinCode" ErrorMessage="Enter Pin Code" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div class="form-group">
                <asp:Button runat="server" ID="btnAdd" Text="AddCity" OnClick="btnAdd_Click" CssClass="btn btn-success" />
                <asp:Button runat="server" ID="btnSave" Text="Save" OnClick="btnSave_Click" CssClass="btn btn-success" />
                <asp:HyperLink runat="server" ID="hlCancle" NavigateUrl="~/City.aspx" Text="Cancle" CssClass="btn btn-danger" />
            </div>
        </div>
    </div>
</asp:Content>
