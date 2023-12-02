<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Details.aspx.cs" Inherits="BloodBankStation.Details" Async="true" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Blood Bank Details</title>
    <style>
        /* Style for the container */
        .container {
            max-width: 600px;
            margin: 20px auto;
            padding: 15px;
            background-color: #ffffff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: left;
        }

        /* Style for the headings */
        h2, h3 {
            color: #333;
        }

        /* Style for the address, phone, and timing sections */
        .section {
            margin-bottom: 20px;
        }

        .section-label {
            font-weight: bold;
        }

        .section-value {
            margin-top: 5px;
        }
        .go-back-button {
    display: block;
    position: absolute;
    top: 20px;
    right: 20px;
    padding: 10px 15px;
    background-color: #007bff;
    color: white;
    text-decoration: none;
    border-radius: 4px;
    font-size: 14px;
}

.go-back-button:hover {
    background-color: #0056b3;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <a href="Search.aspx" class="go-back-button">Go Back</a>       
        <div class="container">
            <h2>Blood Bank Details</h2>
            
            <div class="section">
                <span class="section-label">City:</span>
                <span class="section-value" id="lblCity" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Address:</span>
                <span class="section-value" id="lblAddress" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Contact Number:</span>
                <span class="section-value" id="lblContact" runat="server"></span>
            </div>

            <h3>Opening Hours:</h3>

            <div class="section">
                <span class="section-label">Sunday:</span>
                <span class="section-value" id="lblSunday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Monday:</span>
                <span class="section-value" id="lblMonday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Tuesday:</span>
                <span class="section-value" id="lblTuesday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Wednesday:</span>
                <span class="section-value" id="lblWednesday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Thursday:</span>
                <span class="section-value" id="lblThursday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Friday:</span>
                <span class="section-value" id="lblFriday" runat="server"></span>
            </div>

            <div class="section">
                <span class="section-label">Saturday:</span>
                <span class="section-value" id="lblSaturday" runat="server"></span>
            </div>
        </div>
    </form>
</body>
</html>
