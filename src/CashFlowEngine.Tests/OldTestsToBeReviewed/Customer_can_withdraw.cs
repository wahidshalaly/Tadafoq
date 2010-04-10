using System;
using NUnit.Framework;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine.Tests
{
	[TestFixture]
	public class Customer_can_withdraw
	{
		string name = "Account #1";
		string description = "This is my first intoAccount.";
		decimal openingBalance = 3000m;

		[Test]
		public void Can_withdraw_cash_from_saving_account_with_enough_balance()
		{
			var amount = 1000m;
			var account = new SavingAccount(name, description, openingBalance);
			account.Withdraw(amount);
			Assert.AreEqual(openingBalance - amount, account.CurrentBalance);
		}

		[Test]
		public void Can_withdraw_cash_from_checking_account_with_enough_balance()
		{
			var amount = 1000m;
			var account = new CheckingAccount(name, description);
			account.Deposit(openingBalance);
			account.Withdraw(amount);
			Assert.AreEqual(openingBalance - amount, account.CurrentBalance);
		}

		[Test]
		public void Cannot_withdraw_cash_from_saving_account_without_enough_balance()
		{
			var amount = 3001m;
			var account = new SavingAccount(name, description, openingBalance);
			var exception = Assert.Throws<PreconditionException>(() => account.Withdraw(amount));
			Assert.AreEqual(SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance, exception.Message);
		}

		[Test]
		public void Cannot_withdraw_cash_from_checking_account_without_enough_balance()
		{
			var amount = 1m;
			var account = new CheckingAccount(name, description);
			var exception = Assert.Throws<PreconditionException>(() => account.Withdraw(amount));
			Assert.AreEqual(SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance, exception.Message);
		}
	}
}
