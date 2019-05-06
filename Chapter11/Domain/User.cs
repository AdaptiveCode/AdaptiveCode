using System;

namespace Domain
{
    public class User
    {
        public Guid ID { get; }

        public string Password { get; set; }

        //
        // Actual domain entity behavior...
        //
    }
}