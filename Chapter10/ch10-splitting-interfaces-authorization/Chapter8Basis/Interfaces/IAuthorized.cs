﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IAuthorized
    {
        void ChangePassword(string oldPassword, string newPassword);

        void AddToBasket(Guid itemID);

        void Checkout();

        void Logout();
    }
}
