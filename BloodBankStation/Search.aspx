<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="BloodBankStation.Search" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blood Bank Station</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            max-width: 600px;
            margin: 20px auto;
            padding: 15px;
            background-color: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
        }

        .header {
            margin-bottom: 30px;
        }

        /* Style for the search box */
        .form-group {
            margin-bottom: 20px;
            text-align: center; /* Center align search box */
        }

        .input-container {
            text-align: center; /* Center-align the content */
            width: 100%; /* Take full width to center in the parent */
            margin-top: 20px; /* Adjust as needed for spacing */
            padding: 10px 0; /* Padding for aesthetic spacing */
        }

        .form-control {
            width: 30%; /* Adjust as needed */
            padding: 10px 15px;
            margin-top: 5px; /* Space between elements */
            font-size: 16px;
            display: inline-block; /* Align as inline elements for centering */
            border-radius: 20px; /* Rounded sides */
            transition: border-color 0.2s;
        }

        .btn-search {
            width: 10%; /* Adjust as needed */
            padding: 10px 15px;
            margin-top: 5px; /* Space between elements */
            font-size: 16px;
            display: inline-block; /* Align as inline elements for centering */
            border-radius: 20px; /* Rounded sides */
            transition: border-color 0.2s;
        }

        .form-control {
            border: 1px solid #d1d1d1; /* Light grey border */
        }

            .form-control:focus {
                border-color: #4a90e2; /* Blue border on focus */
                outline: none;
            }

        .btn-search {
            background-color: #0073b1; /* Example button color */
            color: white; /* Text color */
            border: none; /* No border */
            cursor: pointer;
        }

            .btn-search:hover {
                background-color: #005682; /* Darker shade for hover */
            }

        #lblSearch {
            display: block; /* Making the label a block element */
            margin-bottom: 5px; /* Space between label and input box */
            font-size: 14px; /* Font size for the label */
            color: #333; /* Dark color for label text */
        }

        /* Grid View Styles */
        .table-striped {
            margin-top: 20px;
            border-collapse: collapse;
            width: 100%; /* Full-width grid */
            margin-left: auto;
            margin-right: auto;
        }

            .table-striped tr:nth-child(odd) {
                background-color: #f2f2f2;
            }

            .table-striped th, .table-striped td {
                padding: 10px;
                border: 1px solid #ddd;
                text-align: left;
            }

        /* Top right buttons style */
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

        @media (max-width: 600px) {
            .container {
                width: 90%;
            }

            .form-control, .btn-primary {
                width: 100%;
                display: block; /* Stack elements vertically on small screens */
            }

            .top-right-buttons {
                position: relative; /* Adjust for small screens */
                text-align: center;
            }
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="top-right-buttons">
            <asp:Button ID="btnAddLocation" runat="server" Text="Add Location" CssClass="button add-location-button" OnClick="btnProfile_Click" />
            <asp:Button ID="btnLogout" runat="server" Text="Logout" CssClass="button logout-button" OnClick="btnLogout_Click" />
        </div>
        <div>
            <h2>
                <center>Search for Nearby Blood Banks</center>
            </h2>
            <div class="input-container">
                <asp:Label ID="lblSearch" runat="server" Text="Enter your location:"></asp:Label>
                <asp:TextBox ID="txtLocation" runat="server" Placeholder="Enter the City" CssClass="form-control" ></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn-search" OnClick="btnSearch_Click" />
            </div>

            <br />
            <br />
            <asp:GridView ID="gvBloodBanks" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:BoundField DataField="City" HeaderText="City" />
                    <asp:BoundField DataField="Address" HeaderText="Address" />
                    <asp:BoundField DataField="Phone" HeaderText="Contact" />


                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDetails" runat="server" Text="Details"
                                CommandName="Details" CommandArgument='<%# Container.DataItemIndex %>'
                                CssClass="btn btn-info" OnClick="btnDetails_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
            </asp:GridView>

        </div>
    </form>
</body>
</html>
