<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="NewsSystem.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewCategories" ItemType="NewsSystem.Models.Category" SelectMethod="ListViewCategories_GetData" DataKeyNames="Id"
         UpdateMethod="ListViewCategories_UpdateItem"
         InsertMethod="ListViewCategories_InsertItem" InsertItemPosition="LastItem"
         DeleteMethod="ListViewCategories_DeleteItem">

        <LayoutTemplate>
            <div class="container body-content">
                <asp:LinkButton Text="Category name" runat="server" ID="LinkButtonCategoryName" CssClass="btn btn-default" CommandName="Sort" CommandArgument="Name"/>
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"/>
            </div>

            <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewCategories" PageSize="5">
                <Fields>
                    <asp:NumericPagerField ButtonType="Link" RenderNonBreakingSpacesBetweenControls="true" NextPageText="Next" PreviousPageText="Previous" ButtonCount="2" />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:Label Text="<%#: Item.Name %>" runat="server" ID="LabelCategoryName"/>
                </div>
                <asp:Panel runat="server" ID="CategoryEditSection"  Visible='<%# User.Identity.IsAuthenticated %>'>
                    <asp:LinkButton Text="Edit" runat="server" ID="LinkButtonCategorysEdit" CommandName="Edit" CssClass="btn btn-info" />
                    <asp:LinkButton Text="Delete" runat="server" ID="LinkButtonCategorysDelete" CommandName="Delete" CssClass="btn btn-danger"/>
                </asp:Panel>
            </div>   
        </ItemTemplate>

        <EditItemTemplate>
            <div class="row">
                <div class="col-md-3">
                    <asp:TextBox Text="<%#: BindItem.Name %>" runat="server" ID="TextBoxInsertCategoryName" CssClass="input-sm"/>
                    <asp:RequiredFieldValidator ErrorMessage="Required field!" ControlToValidate="TextBoxInsertCategoryName" runat="server"
                         ID="TextBoxInsertCategoryNameValid" ForeColor="red"/>
                </div>
                <asp:LinkButton Text="Save" runat="server" ID="LinkButtonCategorysUpdate" CommandName="Update" CssClass="btn btn-info"/>
                <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonCategorysCancelInsert" CommandName="Cancel" CssClass="btn btn-danger"/>
            </div> 
        </EditItemTemplate>

        <InsertItemTemplate>
            <asp:Panel runat="server" ID="CategoryInsertSection" Visible='<%# User.Identity.IsAuthenticated %>'>
                <div class="row">
                    <div class="col-md-3">
                        <asp:TextBox Text="<%#: BindItem.Name %>" runat="server" ID="TextBoxInsertCategoryName1" CssClass="input-sm"/>
                        <asp:CustomValidator ErrorMessage="Required field!" ID="TextBoxInsertCategoryName1Validator" ControlToValidate="TextBoxInsertCategoryName1"
                             runat="server" OnServerValidate="Unnamed_ServerValidate" ValidateEmptyText="false" ForeColor="red"/>  
                        <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "TextBoxInsertCategoryName1" ID="MaxLengthValidator"
                             ValidationExpression = "^[\s\S]{0,25}$" runat="server" ForeColor="Red" ErrorMessage="Maximum 25 characters allowed."/>
                    
                    
                    </div>
                    <asp:LinkButton Text="Save" runat="server" ID="LinkButtonCategorysInsert" CommandName="Insert" CssClass="btn btn-info"/>
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonCategorysCancelInsert" CommandName="Cancel" CssClass="btn btn-danger"/>
                </div>
            </asp:Panel> 
        </InsertItemTemplate>
    </asp:ListView>
</asp:Content>
