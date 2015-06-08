<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Countries.aspx.cs" Inherits="_01_03.CountryInfoSystem.Contries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Continents</h1>
    <asp:EntityDataSource ID="ContinentsEntitySource" runat="server"
        ConnectionString="name=CountriesInfoEntities" DefaultContainerName="CountriesInfoEntities"
        EntitySetName="Continents"
        EnableFlattening="False" EnableDelete="True" EnableInsert="True" EnableUpdate="True">
    </asp:EntityDataSource>
    <asp:ListBox ID="ContinentsListBox" runat="server"
        DataSourceID="ContinentsEntitySource"
        DataTextField="Name" DataValueField="Id"
        Rows="6" AutoPostBack="true"></asp:ListBox>

    <asp:ListView ID="ContinentsListView" runat="server"
        DataSourceID="ContinentsEntitySource" DataKeyNames="Id" ItemType="_01_03.CountryInfoSystem.Continent"
        InsertItemPosition="LastItem"
        OnItemInserted="ContinentsListView_ItemInserted">
        <LayoutTemplate>
            <table>
                <tr runat="server" style="">
                    <th runat="server"></th>
                    <th runat="server">Id</th>
                    <th runat="server">Name</th>
                </tr>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
        </ItemTemplate>

        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <h1>Countries</h1>
    <asp:EntityDataSource ID="CountriesDataSource" runat="server"
        EnableInsert="True" EnableUpdate="True" EnableDelete="True"
        ConnectionString="name=CountriesInfoEntities" DefaultContainerName="CountriesInfoEntities"
        EntitySetName="Countries" Include="Continent" Where="it.ContinentId=@ContId"
        EnableFlattening="False">
        <WhereParameters>
            <asp:ControlParameter Name="ContId" Type="Int32" ControlID="ContinentsListBox" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:GridView ID="CountriesGrid" runat="server"
        DataSourceID="CountriesDataSource" DataKeyNames="Id" AutoGenerateColumns="False"
        AllowPaging="True" AllowSorting="True" PageSize="5"
        ItemType="_01_03.CountryInfoSystem.Country" ShowFooter="True" OnRowCommand="CountriesGrid_RowCommand">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:BoundField DataField="Language" HeaderText="Language" SortExpression="Language" />
            <asp:BoundField DataField="Population" HeaderText="Population" SortExpression="Population" />
            <asp:BoundField DataField="ContinentId" HeaderText="ContinentId" SortExpression="ContinentId" />
            <asp:ImageField DataImageUrlField="Id" DataImageUrlFormatString="~/ImageHttpHandler.ashx?id={0}" HeaderText="Flag" NullDisplayText="No flag">
                <ControlStyle Height="50px" Width="100px" />
            </asp:ImageField>
        </Columns>
    </asp:GridView>
    <asp:ListView ID="ListView1" runat="server"
        DataSourceID="CountriesDataSource" DataKeyNames="Id" ItemType="_01_03.CountryInfoSystem.Continent"
        InsertItemPosition="LastItem"
        OnItemInserted="ContinentsListView_ItemInserted">
        <LayoutTemplate>
            <table>
                <tr runat="server" style="">
                    <th runat="server"></th>
                    <th runat="server">Id</th>
                    <th runat="server">Name</th>
                    <th runat="server">Language</th>
                    <th runat="server">Population</th>
                    <th runat="server">ContinentId</th>
                    <th runat="server">Flag</th>
                </tr>
                <tr id="itemPlaceholder" runat="server"></tr>
            </table>
        </LayoutTemplate>
        <ItemTemplate>
        </ItemTemplate>

        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="LanguageTextBox" runat="server" Text='<%# Bind("Language") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                </td>
                <td>
                    <asp:TextBox ID="ContinentTextBox" runat="server" Text='<%# Bind("ContinentId") %>' />
                </td>
                <td>
                    <asp:FileUpload runat="server" ID="Upload" ClientIDMode="AutoID" AllowMultiple="false" />
                </td>
            </tr>
        </InsertItemTemplate>
    </asp:ListView>

    <h1>Towns</h1>
    <asp:EntityDataSource ID="TownsDataSource" runat="server"
        EnableInsert="True" EnableUpdate="True" EnableDelete="True"
        ConnectionString="name=CountriesInfoEntities" DefaultContainerName="CountriesInfoEntities"
        EntitySetName="Towns" Where="it.CountryId=@CountId" Include="Country" EnableFlattening="False">
        <WhereParameters>
            <asp:ControlParameter Name="CountId" Type="Int32" ControlID="CountriesGrid" />
        </WhereParameters>
    </asp:EntityDataSource>
    <asp:ListView ID="TownsListView" runat="server"
        DataSourceID="TownsDataSource" DataKeyNames="Id" ItemType="_01_03.CountryInfoSystem.Town"
        InsertItemPosition="LastItem"
        OnItemInserted="TownsListView_ItemInserted">
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="0" style="">
                            <tr runat="server" style="">
                                <th runat="server"></th>
                                <th runat="server">Id</th>
                                <th runat="server">Name</th>
                                <th runat="server">Population</th>
                                <th runat="server">CountryId</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <ItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                </td>
                <td>
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                </td>
                <td>
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>
                    <asp:TextBox ID="IdTextBox" runat="server" Text='<%# Bind("Id") %>' />
                </td>
                <td>
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                </td>
                <td>
                    <asp:TextBox ID="PopulationTextBox" runat="server" Text='<%# Bind("Population") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CountryIdTextBox" runat="server" Text='<%# Bind("CountryId") %>' />
                </td>
            </tr>
        </InsertItemTemplate>
        <SelectedItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                </td>
                <td>
                    <asp:Label ID="PopulationLabel" runat="server" Text='<%# Eval("Population") %>' />
                </td>
                <td>
                    <asp:Label ID="CountryIdLabel" runat="server" Text='<%# Eval("CountryId") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>
