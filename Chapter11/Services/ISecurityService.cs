using System;

namespace Services
{
    public interface ISecurityService
    {
        void ChangeUsersPassword(Guid userID, string newPassword);
    }
}
