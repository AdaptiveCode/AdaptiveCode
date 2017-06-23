﻿using System;

using Domain;
using Services;
using RepositoryInterfaces;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;

namespace ServiceTests
{
    [TestClass]
    public class AccountServiceTests
    {
        [TestMethod]
        public void AddingTransactionToAccountDelegatesToAccountInstance()
        {
            // Arrange
            var account = new Mock<Account>();
            account.Setup(a => a.AddTransaction(200m)).Verifiable();
            var mockRepository = new Mock<IAccountRepository>();
            mockRepository.Setup(r => r.GetByName("Trading Account")).Returns(account.Object);
            var sut = new AccountService(mockRepository.Object);

            // Act
            sut.AddTransactionToAccount("Trading Account", 200m);

            // Assert
            account.Verify();
        }
    }
}
