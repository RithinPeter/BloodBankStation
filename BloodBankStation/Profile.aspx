<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="BloodBankStation.Profile" Async="true"%>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Update Profile</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css">
    <style type="text/css">
        body {
            font-family: 'Segoe UI', Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            background-color: lightblue;
        }

        .form-container {
            max-width: 500px;
            margin: 30px auto;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 20px;
            /* Adjust the border-radius to make the edges more curved */
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.2);
            background-color: lightyellow;
        }

        h2 {
            text-align: center;
            margin-bottom: 30px;
        }

        label {
            display: block;
            margin-bottom: 10px;
            font-weight: bold;
        }

        input[type="text"],
        input[type="password"] {
             width: 100%;
             padding: 10px;
             margin-bottom: 20px;
             border: 1px solid #ccc;
             border-radius: 20px; /* Increased border-radius for curved sides */
             box-sizing: border-box;
       }
        .button-container {
            display: flex;
            justify-content: space-around; /* This will space the buttons evenly */
        }

        .submit-button {
            width: 50%;
            background-color: lightgreen;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 20px;
            cursor: pointer;
            font-size: 16px;
            transition: background-color 0.3s;
        }
        .submit1-button {
            width: 50%;
            background-color: orangered;
            color: white;
            padding: 12px 20px;
            border: none;
            border-radius: 20px;
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
            text-decoration: none;
        }

        .go-back-button:hover {
            background-color: #696969;
        }

        .textbox-row {
            /* Removed display: flex; and margin-bottom */
        }
    </style>
</head>
<body>
    <a href="Search.aspx" class="go-back-button"><i class="fas fa-arrow-left "></i> Back</a>

    <form id="form1" runat="server">
        <div class="form-container">
            <h2><i class="fas fa-user"></i> Update Profile</h2>

            <asp:HiddenField ID="userId" runat="server" />

            <div class="textbox-row">
                <label for="firstName"><i class="fas fa-user"></i>First Name:</label>
                <asp:TextBox ID="firstName" runat="server" />
            </div>

            <div class="textbox-row">
                <label for="lastName"><i class="fas fa-user"></i>Last Name:</label>
                <asp:TextBox ID="lastName" runat="server"/>
            </div>

            <div class="textbox-row">
                <label for="username"><i class="fas fa-envelope "></i>Email:</label>
                <asp:TextBox ID="username" runat="server" />
            </div>

            <div class="textbox-row">
                <label for="password"><i class="fas fa-key"></i>Password:</label>
                <asp:TextBox ID="password" runat="server" TextMode="Password" />
            </div>

            <div class="button-container">
            <asp:Button ID="submit" runat="server" Text="Update Profile" CssClass="submit-button" OnClick="UpdateProfile_Click" />
            <asp:Button ID="sumbit" runat="server" Text="Delete Profile" CssClass="submit1-button" OnClick="DeleteProfile_Click" />
        </div>
        </div>
    </form>
</body>
</html>
