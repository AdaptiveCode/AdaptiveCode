﻿using NullObjectPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheInterface
{
    class Program
    {
        static IUserRepository userRepository = new UserRepository();

        static void Main(string[] args)
        {
            var user = userRepository.GetByID(Guid.NewGuid());
            // Without the Null Object pattern, this line would throw an exception
            user.IncrementSessionTicket();

            Console.WriteLine("The user's name is {0}", user.Name);

            Console.ReadKey();
        }
    }
}
