using Domain;
using System;

namespace Services.Implementations
{
    public class SecurityService : ISecurityService
    {
        private readonly IUserRepository userRepository;

        public SecurityService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }


        public void ChangeUsersPassword(Guid userID, string newPassword)
        {
            var user = this.userRepository.GetByID(userID);
            user.Password = newPassword;
        }
    }
}
