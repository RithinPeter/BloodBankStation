<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddLocation.aspx.cs" Inherits="BloodBankStation.AddLocation" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add New Location</title>
    <style type="text/css">
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            position: relative;
        }
        .form-container {
            max-width: 700px;
            margin: 40px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
            background-color: #fff;
        }
        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 30px;
        }
        label {
            display: block;
            margin-bottom: 10px;
            color: #555;
            font-weight: bold;
        }
        input[type="text"] {
            width: calc(100% - 16px);
            padding: 10px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }
        .submit-button {
            width: 100%;
            background-color: #007bff;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s;
        }
        .submit-button:hover {
            background-color: #0056b3;
        }
         .go-back-button {
            position: absolute;
            top: 20px;
            right: 20px;
            background-color: #808080;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 14px;
            transition: background-color 0.3s;
            text-decoration: none; /* Remove underline from link */
        }
        .go-back-button:hover {
            background-color: #696969;
        }
    </style>
</head>
<body>
    <a href="Search.aspx" class="go-back-button">Go Back</a>

    <form id="form1" runat="server">
        <div class="form-container">
            <h2>Add New Blood Bank Location</h2>

            <label for="city">City:</label>
            <asp:TextBox ID="city" runat="server" /><br />

            <label for="address">Address:</label>
            <asp:TextBox ID="address" runat="server" /><br />

            <label for="phone">Phone Number:</label>
            <asp:TextBox ID="phone" runat="server" /><br />

            <label for="monday">Monday:</label>
            <asp:TextBox ID="monday" runat="server" /><br />

            <label for="tuesday">Tuesday:</label>
            <asp:TextBox ID="tuesday" runat="server" /><br />

            <label for="wednesday">Wednesday:</label>
            <asp:TextBox ID="wednesday" runat="server" /><br />

            <label for="thursday">Thursday:</label>
            <asp:TextBox ID="thursday" runat="server" /><br />

            <label for="friday">Friday:</label>
            <asp:TextBox ID="friday" runat="server" /><br />

            <label for="saturday">Saturday:</label>
            <asp:TextBox ID="saturday" runat="server" /><br />

            <label for="sunday">Sunday:</label>
            <asp:TextBox ID="sunday" runat="server" /><br />

            <asp:Button ID="submit" runat="server" Text="Submit" CssClass="submit-button" OnClick="Submit_Click" />
        </div>
    </form>
</body>
</html>
