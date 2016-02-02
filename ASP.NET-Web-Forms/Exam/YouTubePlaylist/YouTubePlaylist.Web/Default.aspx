<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="YouTubePlaylist.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" ID="SearchPanel" Visible='<%# User.Identity.IsAuthenticated %>'>
        <asp:TextBox runat="server" ID="PlaylistSearch" Text="" />
        <asp:LinkButton Text="FILTER BY TITLE" runat="server" ID="Search" OnClick="Search_Click"  CssClass="btn btn-warning"/>
    </asp:Panel>

    <asp:ListView runat="server" ID="lvPlaylistsHome" ItemType="YouTubePlaylist.Web.Models.Playlist"
        SelectMethod="lvPlaylistsHome_GetData">
        <LayoutTemplate>
            <div class="jumbotron text-center">
            <h2>Welcome!</h2>

            </div>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
                <div class="col-md-2">
                    <asp:HyperLink NavigateUrl='<%#: string.Format("~/Details/PlaylistDetails.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkPlaylistName"
                        Text='<%#: Item.Title %>' />
                </div>
                <div class="col-md-2">
                    <p>rating: <%#: Item.Ratings.Count %></p>
                </div>
                <div class="col-md-2">
                    <strong><%#: Item.Creator.FirstName + " "+ Item.Creator.LastName %></strong>
                </div>
                <div class="col-md-4">
                    <i>created on: <%#: Item.CreationDate %></i>
                </div>
                <div class="col-md-2">
                    <asp:HyperLink NavigateUrl='<%#: string.Format("~/CategoryMembers.aspx?category={0}", Item.CategoryId) %>' runat="server"
                        ID="ListCategoryMembers" Text="View category" />
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
