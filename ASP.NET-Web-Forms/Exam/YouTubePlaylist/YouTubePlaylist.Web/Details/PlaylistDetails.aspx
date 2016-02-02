<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PlaylistDetails.aspx.cs" Inherits="YouTubePlaylist.Web.Details.PlaylistDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewPlaylistDetail" ItemType="YouTubePlaylist.Web.Models.Playlist" DataKeyNames="Id"
        SelectMethod="FormViewPlaylistDetail_GetItem"
        DeleteMethod="FormViewPlaylistDetail_DeleteItem"
        UpdateMethod="FormViewPlaylistDetail_UpdateItem">
        <ItemTemplate>

            <h2><%#: Item.Title %> <small>Category: <%#: Item.Category.Name %></small></h2>
            <p>
                <%#: Item.Description %>
            <p>
                <span>Author: <strong><%#: Item.Creator.UserName %></strong></span>
                <span class="pull-right"><%#: Item.CreationDate %></span>
            </p>
            <div class="container">
                <strong>Rate me:</strong>
                <asp:ImageButton ImageUrl="~/Content/star.png" runat="server" ID="star1" Width="50" />
                <asp:ImageButton ImageUrl="~/Content/star.png" runat="server" ID="star2" Width="50" />
                <asp:ImageButton ImageUrl="~/Content/star.png" runat="server" ID="star3" Width="50" />
                <asp:ImageButton ImageUrl="~/Content/star.png" runat="server" ID="star4" Width="50" />
                <asp:ImageButton ImageUrl="~/Content/star.png" runat="server" ID="star5" Width="50" />
            </div>

            <div class="row">
                <div class="col-md-3 pull-right">
                    <asp:LinkButton Text="Delete Playlist" runat="server" ID="DeletePlaylistButton" CommandName="Delete" CssClass="btn btn-lg btn-danger" />
                </div>
            </div>
            <asp:ListView runat="server" ID="RepeaterVideosHomePage" ItemType="YouTubePlaylist.Web.Models.Video"
                SelectMethod="RepeaterVideosHomePage_GetData" DataKeyNames="Id"
                DeleteMethod="RepeaterVideosHomePage_DeleteItem">

                <LayoutTemplate>
                    <h3>Videos:</h3>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                </LayoutTemplate>

                <ItemTemplate>
                    <li>
                        <asp:HyperLink ID="HyperLink3" runat="server" Target="HyperLink"
                            NavigateUrl='<%# String.Format("http://{0}", Item.Url.ToString()) %>'
                            Text='<%# Item.Url %>'></asp:HyperLink>
                        <asp:LinkButton Text="DEL" runat="server" ID="DeleteVideo" CommandName="Delete" CssClass="btn btn-sm btn-danger" />
                    </li>
                </ItemTemplate>

                <EmptyDataTemplate>
                    No videos.
                </EmptyDataTemplate>

            </asp:ListView>

        </ItemTemplate>
    </asp:FormView>
</asp:Content>
