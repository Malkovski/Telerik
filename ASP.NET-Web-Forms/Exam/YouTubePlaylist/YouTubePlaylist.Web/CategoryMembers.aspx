<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CategoryMembers.aspx.cs" Inherits="YouTubePlaylist.Web.CategoryMembers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView runat="server" ID="FormViewCategorymenbers" ItemType="YouTubePlaylist.Web.Models.Category" DataKeyNames="Id"
        SelectMethod="FormViewCategorymenbers_GetItem">
        <ItemTemplate>
            <div class="jumbotron text-center">
                        <h3><%#: Item.Name %></h3>
                    </div>
            <asp:ListView runat="server" ID="ListViewByCategory" ItemType="YouTubePlaylist.Web.Models.Playlist"
                DataSource="<%# Item.Playlists.OrderByDescending(x => x.Id) %>">

                <LayoutTemplate>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                </LayoutTemplate>

                <ItemTemplate>

                    <div class="row">
                        <div class="col-md-4">
                            <asp:HyperLink NavigateUrl='<%#: string.Format("~/Details/PlaylistDetails.aspx?id={0}", Item.Id) %>' runat="server" ID="HyperLinkPlaylistName"
                                Text='<%#: Item.Title %>' />
                        </div>
                        <div class="col-md-2">
                            <p>rating: <%#: Item.Ratings.Count %></p>
                        </div>
                        <div class="col-md-3">
                            <strong><%#: Item.Creator.FirstName + " " + Item.Creator.LastName %></strong>
                        </div>
                        <div class="col-md-3">
                            <i>created on: <%#: Item.CreationDate %></i>
                        </div>
                    </div>

                </ItemTemplate>

                <EmptyDataTemplate>
                    No videos.
                </EmptyDataTemplate>

            </asp:ListView>

        </ItemTemplate>
    </asp:FormView>
</asp:Content>
