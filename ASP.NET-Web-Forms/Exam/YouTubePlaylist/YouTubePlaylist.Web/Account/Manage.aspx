<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="YouTubePlaylist.Web.Account.Manage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="USerInfo" ItemType="YouTubePlaylist.Web.Models.User" SelectMethod="USerInfo_GetItem" DataKeyNames="Id" Width="100%">
        <ItemTemplate>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">First name</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBoxNewArticleBody" Text="<%#: Item.FirstName %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">Last name</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBox1" Text="<%#: Item.LastName %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">Username</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBox2" Text="<%#: Item.UserName %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">Email</label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="TextBox3" Text="<%#: Item.Email %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">Facebook link</label>
                <div class="col-md-10">
                    <asp:HyperLink runat="server" ID="TextBox4" Text="<%#: Item.Facebook %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class=" control-label">YouTube link</label>
                <div class="col-md-10">
                    <asp:HyperLink runat="server" ID="TextBox5" Text="<%#: Item.YouTube %>" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <label for="TextBoxNewArticleBody" class="control-label">Avater</label>
                <div class="col-md-10">
                    <asp:Image ImageUrl='<%# String.Format("http://{0}", Item.Image.ToString()) %>' runat="server" />

                </div>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>
