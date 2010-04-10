using System;
using NUnit.Framework;

namespace CashFlowEngine.Tests
{
	[TestFixture]
	public class Customer_can_deposit
	{
		string name = "Account #1";
		string description = "This is my first intoAccount.";
		decimal openingBalance = 3000m;

		[Test]
		public void Can_deposit_cash_in_saving_account()
		{
			var amount = 1000m;
			var account = new SavingAccount(name, description, openingBalance);

			account.Deposit(amount);

			Assert.AreEqual(openingBalance + amount, account.CurrentBalance);
		}

		[Test]
		public void Can_deposit_cash_in_checking_account()
		{
			var amount = 1000m;
			var account = new CheckingAccount(name, description);

			account.Deposit(amount);

			Assert.AreEqual(amount, account.CurrentBalance);
		}
	}
}
