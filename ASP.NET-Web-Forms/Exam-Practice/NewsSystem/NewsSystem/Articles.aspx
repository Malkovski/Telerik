<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Articles.aspx.cs" Inherits="NewsSystem.Articles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <asp:ListView runat="server" ID="ListViewArticles" ItemType="NewsSystem.Models.Article" DataKeyNames="Id"
            SelectMethod="ListViewArticles_GetData"
            UpdateMethod="ListViewArticles_UpdateItem"
            InsertMethod="ListViewArticles_InsertItem" InsertItemPosition="LastItem"
            DeleteMethod="ListViewArticles_DeleteItem">

            <LayoutTemplate>
                <asp:Panel runat="server" ID="PanelSortOptions" CssClass="container">
                    <asp:LinkButton Text="Sort by Title" runat="server" ID="LinkButtonTitleSort" CssClass="col-md-2 btn btn-default" CommandName="Sort" CommandArgument="Title" />
                    <asp:LinkButton Text="Sort by Date" runat="server" ID="LinkButtonDateSort" CssClass="col-md-2 btn btn-default" CommandName="Sort" CommandArgument="DateCreated" />
                    <asp:LinkButton Text="Sort by Category" runat="server" ID="LinkButtonCaterory" CssClass="col-md-2 btn btn-default" OnClick="LinkButtonCaterory_Click1" CommandName="Sort" />
                    <asp:LinkButton Text="Sort by Likes" runat="server" ID="LinkButtonLikes" CssClass="col-md-2 btn btn-default" CommandName="Sort" CommandArgument="Likes" />
                </asp:Panel>

                <asp:Panel runat="server" ID="PanelPlaceHolder" CssClass="conteiner">
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                </asp:Panel>

            </LayoutTemplate>

            <ItemTemplate>
                <div class="row">
                    <h3><%#: Item.Title %>
                        <asp:Label runat="server" ID="ArticleEditSection" Visible='<%# User.Identity.IsAuthenticated %>'>
                            <asp:LinkButton Text="Edit" runat="server" ID="LinkButtonArticleEdit" CommandName="Edit" CssClass="btn btn-info" />
                            <asp:LinkButton Text="Delete" runat="server" ID="LinkButtonArticleDelete" CommandName="Delete" CssClass="btn btn-danger" />
                        </asp:Label>
                    </h3>
                    <p>Category: <%#: Item.Category.Name %></p>
                    <asp:Label ID="LabelArticleContent" runat="server"
                        Text='<%# Item.Content.Length > 30 ? Item.Content.ToString().Substring(0, 300) + "..." : Item.Content %>' />
                    <p>Likes count: <%#: Item.Likes %></p>
                    <div>
                        <i>by <%#: Item.Author.UserName %></i>
                        <i>created on: <%#: Item.DateCreated %></i>
                    </div>
                </div>
            </ItemTemplate>

            <EditItemTemplate>
                <div class="row">
                    <h3>
                        <asp:TextBox runat="server" ID="TextBoxTitleEdit" Text="<%#: BindItem.Title %>" />
                        <asp:Label runat="server" ID="ArticleEditSection" Visible='<%# User.Identity.IsAuthenticated %>'>
                            <asp:LinkButton Text="Save" runat="server" ID="LinkButtonArticleEdit" CommandName="Update" CssClass="btn btn-info" />
                            <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonArticleDelete" CommandName="Cancel" CssClass="btn btn-danger" />
                        </asp:Label>
                    </h3>

                    <p>Category: <%#: Item.Category.Name %></p>
                    <p>
                        <asp:TextBox ID="TextBoxContentEdit" runat="server" Text='<%# BindItem.Content %>' CssClass="input-lg" />
                    </p>
                    <p>Likes count: <%#: Item.Likes %></p>
                    <div>
                        <i>by <%#: Item.Author.UserName %></i>
                        <i>created on: <%#: Item.DateCreated %></i>
                    </div>
            </EditItemTemplate>

            <InsertItemTemplate>
            </InsertItemTemplate>

        </asp:ListView>
    </div>
    <asp:Panel runat="server" ID="PanelButtonCreateArticle" Visible='<%# User.Identity.IsAuthenticated %>'>
        <asp:LinkButton runat="server" Text="Insert new Article" ID="LinkToCreateArticle" OnClick="LinkToCreateArticle_Click"
            CssClass="btn btn-info pull-right" Visible='<%# User.Identity.IsAuthenticated %>' />

        <asp:UpdatePanel runat="server" UpdateMode="Conditional" Visible='<%# User.Identity.IsAuthenticated %>'>
            <ContentTemplate>
                <asp:Panel runat="server" ID="CreateArticle" CssClass="hidden">
                    <asp:FormView runat="server" ID="FormViewInsertArticle" DefaultMode="Insert" ItemType="NewsSystem.Models.Article" Width="40%"
                        InsertMethod="FormViewInsertArticle_InsertItem">

                        <InsertItemTemplate>
                            <form class="form-horizontal">
                                <fieldset>
                                    <asp:ValidationSummary runat="server" ForeColor="Red" DisplayMode="SingleParagraph" ShowSummary="true" ShowValidationErrors="true"/>
                                    <div class="form-group">
                                        <label for="TextBoxNewArticleTitle" class="col-md-2 control-label">Title</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="TextBoxNewArticleTitle" Text="<%#: BindItem.Title %>" CssClass="form-control" Width="100%" />
                                            <asp:CustomValidator runat="server" ErrorMessage="Required field!" ID="TextBoxInsertArticleTitleValidator"
                                                ControlToValidate="TextBoxNewArticleTitle"
                                                OnServerValidate="TextBoxInsertArticleTitleValidator_ServerValidate"
                                                ValidateEmptyText="false" ForeColor="red" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="DropDownListCategoriesCreate" class="col-md-2 control-label">Category</label>
                                        <div class="col-md-10">
                                            <asp:DropDownList runat="server" ID="DropDownListCategoriesCreate" ItemType="NewsSystem.Models.Category" CssClass="form-control"
                                                SelectMethod="DropDownListCategoriesCreate_GetData" DataValueField="Id" DataTextField="Name"
                                                SelectedValue="<%#: BindItem.CategoryId %>">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label for="TextBoxNewArticleBody" class="col-md-2 control-label">Body</label>
                                        <div class="col-md-10">
                                            <asp:TextBox runat="server" ID="TextBoxNewArticleBody" Text="<%#: BindItem.Content %>" TextMode="MultiLine" CssClass="form-control" />
                                            <asp:CustomValidator ErrorMessage="Required field!" ID="TextBoxNewArticleBodyValidator"
                                                ControlToValidate="TextBoxNewArticleBody"
                                                runat="server" OnServerValidate="TextBoxNewArticleBodyValidator_ServerValidate"
                                                ValidateEmptyText="false" ForeColor="red" />
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TextBoxNewArticleBody" ID="NewArtiMaxLengthValidator"
                                                ValidationExpression="^[\s\S]{3,500}$" runat="server" ForeColor="Red" ErrorMessage="Minimum 3/maximum 500 characters allowed." />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-md-10 col-md-offset-2">
                                            <div class="col-md-2">
                                                <asp:LinkButton Text="Insert" runat="server" ID="LinkButtonArticlesInsert" CommandName="Insert" CssClass="btn btn-md btn-success" />
                                            </div>
                                            <div class="col-md-2">
                                                <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonArticlesInsertCancel" CommandName="Cancel" CssClass="btn btn-md btn-danger" />
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </form>
                            </div>
                        </InsertItemTemplate>
                    </asp:FormView>
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="LinkToCreateArticle" EventName="Click" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:DataPager runat="server" ID="DataPagerArticles" PagedControlID="ListViewArticles" PageSize="5">
        <Fields>
            <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="true" NextPageText="Next" PreviousPageText="Previous" ButtonCount="2" />
        </Fields>
    </asp:DataPager>
</asp:Content>
