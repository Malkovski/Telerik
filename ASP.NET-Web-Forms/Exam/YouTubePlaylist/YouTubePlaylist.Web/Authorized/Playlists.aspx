<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Playlists.aspx.cs" Inherits="YouTubePlaylist.Web.Authorized.Playlists" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView runat="server" ID="ListViewPlaylists" ItemType="YouTubePlaylist.Web.Models.Playlist" DataKeyNames="Id"
            SelectMethod="ListViewPlaylists_GetData"
            UpdateMethod="ListViewPlaylists_UpdateItem"
            InsertMethod="ListViewPlaylists_InsertItem"
            DeleteMethod="ListViewPlaylists_DeleteItem">

            <LayoutTemplate>
                <asp:Panel runat="server" ID="PanelSortOptions" CssClass="container">
                    <asp:LinkButton Text="Sort by Title" runat="server" ID="LinkButton1" CssClass="col-md-2 btn btn-default"
                        CommandName="Sort" CommandArgument="Title" />
                    <asp:LinkButton Text="Sort by Date" runat="server" ID="LinkButtonTitleSort" CssClass="col-md-2 btn btn-default"
                        CommandName="Sort" CommandArgument="CreationDate" />
                    <asp:HyperLink NavigateUrl="?orderBy=Rating" Text="Sort by Rating" runat="server" ID="LinkButtonCaterory" CssClass="col-md-2 btn btn-default" />
                </asp:Panel>

                <asp:Button runat="server" Text="Insert new Playlist" ID="btnInsertNewPlaylist" OnClick="btnInsertNewPlaylist_Click"
                    CssClass="btn btn-info pull-right" />

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

            <EditItemTemplate>
            </EditItemTemplate>

            <InsertItemTemplate>
                <form class="form-horizontal">
                    <fieldset>
                        <div class="form-group">
                            <label for="TextBoxNewPlaylistTitle" class="col-md-2 control-label">Title</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxNewPlaylistTitle" Text="<%#: BindItem.Title %>"
                                    CssClass="form-control" Width="100%" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="DropDownListCategoriesCreate" class="col-md-2 control-label">Category</label>
                            <div class="col-md-10">
                                <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" ItemType="YouTubePlaylist.Web.Models.Category"
                                    CssClass="form-control"
                                    SelectMethod="DropDownListCategoriesCreate_GetData"
                                    DataValueField="Id" DataTextField="Name"
                                    SelectedValue="<%#: BindItem.CategoryId %>">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="TextBoxNewPlaylistBody" class="col-md-2 control-label">Body</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxNewPlaylistBody" Text="<%#: BindItem.Description %>" TextMode="MultiLine"
                                    CssClass="form-control" />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-10 col-md-offset-2">
                                <div class="col-md-2">
                                    <asp:LinkButton Text="Insert" runat="server" ID="LinkButtonPlaylistInsert"
                                        CommandName="Insert" CssClass="btn btn-md btn-success" />
                                </div>
                                <div class="col-md-2">
                                    <asp:Button Text="Cancel" runat="server" ID="LinkButtonArticlesInsertCancel"
                                        OnClick="LinkButtonArticlesInsertCancel_Click" CssClass="btn btn-md btn-danger" />
                                </div>
                            </div>
                        </div>
                    </fieldset>
                </form>
            </InsertItemTemplate>

        </asp:ListView>
    </div>
</asp:Content>
