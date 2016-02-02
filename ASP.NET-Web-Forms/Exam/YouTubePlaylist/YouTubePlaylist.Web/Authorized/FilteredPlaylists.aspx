<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilteredPlaylists.aspx.cs" Inherits="YouTubePlaylist.Web.Authorized.FilteredPlaylists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView runat="server" ID="ListViewPlaylists" ItemType="YouTubePlaylist.Web.Models.Playlist"
             SelectMethod="ListViewPlaylists_GetData">

            <LayoutTemplate>
  
                <asp:Panel runat="server" ID="PanelPlaceHolder" CssClass="conteiner">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                </asp:Panel>

                <asp:DataPager runat="server" ID="DataPagerPlaylists" PagedControlID="ListViewPlaylists" PageSize="10">
                    <Fields>
                        <asp:NextPreviousPagerField ShowPreviousPageButton="true" ShowNextPageButton="false" ButtonType="Link" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowPreviousPageButton="false" ShowNextPageButton="true" ButtonType="Link" />
                    </Fields>
                </asp:DataPager>

            </LayoutTemplate>

            <ItemTemplate>
                <div class="row">
                    <h3>
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/Details/PlaylistDetails.aspx?id={0}", Item.Id) %>' runat="server"
                            Text="<%#: Item.Title %>" />
                    </h3>
                    <p>
                        Category: 
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/CategoryMembers.aspx?category={0}", Item.CategoryId) %>' runat="server"
                            Text="<%#: Item.Category.Name %>" />
                    </p>
                    <p>
                        Description:
                         <i>
                             <asp:Label ID="LabelArticleContent" runat="server"
                                 Text='<%# Item.Description %>' />
                         </i>
                    </p>
                    <p>Videos : <%#: Item.Videos.Count %></p>
                    <div>
                        <i>by <b><%#: Item.Creator.FirstName + " " + Item.Creator.LastName %></b></i>
                        <i>created on: <%#: Item.CreationDate %></i>
                    </div>
                    <div>
                        <asp:HyperLink NavigateUrl='<%#: string.Format("~/Authorized/AddVideo.aspx?id={0}", Item.Id) %>' runat="server" Text="Add video" CssClass="btn btn-sm btn-success" />
                    </div>
                </div>
            </ItemTemplate>
        </asp:ListView>
    </div>
</asp:Content>
