<%@ Page Title="Blood Bank Station" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BloodBankStation._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <section class="row" aria-labelledby="bloodBankTitle">
            <h1 id="bloodBankTitle">Blood Bank Station</h1>
            <p class="lead">Your reliable partner in saving lives through blood donation and management.</p>
            <p><a href="http://www.bloodbankstation.com" class="btn btn-primary btn-md">Learn more &raquo;</a></p>
        </section>

        <div class="row">
            <section class="col-md-4" aria-labelledby="donationTitle">
                <h2 id="donationTitle">Become a Donor</h2>
                <p>
                    Join our community of heroes! Learn how easy it is to donate blood and how your donation can save up to three lives.
                </p>
                <p>
                    <a class="btn btn-default" href="http://www.bloodbankstation.com/donate">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="servicesTitle">
                <h2 id="servicesTitle">Our Services</h2>
                <p>
                    Discover the range of services we offer, from blood collection to processing and distribution.
                </p>
                <p>
                    <a class="btn btn-default" href="http://www.bloodbankstation.com/services">Learn more &raquo;</a>
                </p>
            </section>
            <section class="col-md-4" aria-labelledby="educationTitle">
                <h2 id="educationTitle">Educational Resources</h2>
                <p>
                    Learn about the importance of blood donation and how it helps in the medical community.
                </p>
                <p>
                    <a class="btn btn-default" href="http://www.bloodbankstation.com/education">Learn more &raquo;</a>
                </p>
            </section>
        </div>
    </main>

</asp:Content>
