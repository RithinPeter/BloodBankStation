<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BloodBankStation.Search" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Find Nearby Blood Banks</title>
    <style type="text/css">
        .top-right-buttons {
            position: absolute;
            top: 20px;
            right: 20px;
        }
        .button {
            padding: 10px 20px;
            color: white;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            transition: background-color 0.3s ease;
            margin-left: 10px;
        }
        .add-location-button {
            background-color: #28a745;
        }
        .add-location-button:hover {
            background-color: #218838;
        }
        .logout-button {
            background-color: #007bff;
        }
        .logout-button:hover {
            background-color: #0056b3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-right-buttons">
            <asp:Button ID="btnAddLocation" runat="server" Text="Add Location" CssClass="button add-location-button" OnClick="btnAddLocation_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="button logout-button" OnClick="btnLogout_Click" />
        </div>
        <div>
            <h2>Search for Nearby Blood Banks</h2>
            <asp:Label ID="lblSearch" runat="server" Text="Enter your location:"></asp:Label>
            <asp:TextBox ID="txtLocation" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary" />
            <br /><br />
            <asp:GridView ID="gvBloodBanks" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Name" HeaderText="Blood Bank Name" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Distance" HeaderText="Distance" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
