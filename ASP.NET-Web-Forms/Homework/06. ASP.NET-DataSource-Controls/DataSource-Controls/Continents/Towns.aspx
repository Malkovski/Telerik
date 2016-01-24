<%@ Page Title="Towns" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Towns.aspx.cs" Inherits="Continents.Towns" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListView runat="server" ID="ListViewTowns" ItemType="Continents.Models.Town" DataKeyNames="Id"
         SelectMethod="ListViewTowns_GetData"
         UpdateMethod="ListViewTowns_UpdateItem" 
         DeleteMethod="ListViewTowns_DeleteItem">

        <LayoutTemplate>
            <table>
                <thead class="myitem">
                    <th>
                        <asp:LinkButton Text="Name" runat="server" ID="LinkButtonSortTownName" CommandName="Sort" CommandArgument="Name"/>
                    </th>
                    <th>
                        <asp:LinkButton Text="Population" runat="server" ID="LinkButtonSortPopulationName" CommandName="Sort" CommandArgument="Population"/>
                    </th>
                    <th>
                        <asp:Label Text="Method" runat="server" ID="LabelMethod"/>
                    </th>
                </thead>
                <tbody>
                    <asp:PlaceHolder runat="server" ID="itemPlaceHolder"/>
                </tbody>
            </table>

            <asp:DataPager runat="server" ID="DataPagerTowns" PagedControlID="ListViewTowns" PageSize="10">
                <Fields>
                    <asp:NumericPagerField />
                </Fields>
            </asp:DataPager>
        </LayoutTemplate>

        <ItemTemplate>
            <tr class="myitem">
                <td>
                    <asp:HyperLink NavigateUrl='<%# string.Format("~/TownDetails.aspx?id={0}",Item.Id) %>' runat="server" ID="TownDetailLink" Text="<%#: Item.Name %>" />

                </td>
                <td><%#: Item.Population %></td>
                <td>
                    <asp:LinkButton Text="Edit" runat="server" ID="LinkButtonTownsEdit" CommandName="Edit"/>
                    <asp:LinkButton Text="Delete" runat="server" ID="LinkButtonTownDelete" CommandName="Delete"/>
                </td>
            </tr>
        </ItemTemplate> 
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxNameEdit" Text="<%#: BindItem.Name %>"/>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="TextBoxPopulationEdit" Text="<%#: BindItem.Population %>"/>
                </td>
                <td>
                    <asp:LinkButton Text="Save" runat="server" ID="LinkButtonTownsEdit" CommandName="Update"/>
                    <asp:LinkButton Text="Cancel" runat="server" ID="LinkButtonTownDelete" CommandName="Cancel"/>
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
