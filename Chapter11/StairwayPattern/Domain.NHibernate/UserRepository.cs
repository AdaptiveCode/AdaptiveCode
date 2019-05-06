using NHibernate;
using System;

namespace Domain.NHibernate
{
    public class UserRepository : IUserRepository
    {
        private readonly ISession session;

        public UserRepository(ISession session)
        {
            this.session = session;
        }

        public User GetByID(Guid userID)
        {
            return this.session.Get<User>(userID);
        }
    }
}
