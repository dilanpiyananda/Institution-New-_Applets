using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Trendil.Models;

namespace Trendil.DataAccess
{
    public interface IDataAccessLayer
    {
        ContactUsVM SaveContactUs(ContactUsVM contact);
        DonationVM SaveDonation(DonationVM donation);

        User GetUser(LoginVM login);
        List<DonationVM> GetDonations();
        List<ContactUsVM> GetContacts();

    }
}