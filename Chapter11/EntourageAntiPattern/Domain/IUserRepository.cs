using System;

namespace Domain
{
    public interface IUserRepository
    {
        User GetByID(Guid userID);
    }
}
