using System;
using NUnit.Framework;

namespace CashFlowEngine.Tests.UnitTests
{
	[TestFixture]
	public class AccountTests
	{
		[Test]
		public void Cannot_create_account_with_noargs_ctor()
		{
			Assert.Throws<MissingMethodException>(() => Activator.CreateInstance<Account>());
		}

		[Test]
		public void Can_create_account_with_name_description_and_opening_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;

			var account = new Account(name, description, openingBalance);

			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
			Assert.AreNotEqual(Guid.Empty, account.Id);
		}

		[Test]
		public void Can_deposit_positive_amounts()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 1000m;

			// Given account
			var account = new Account(name, description, openingBalance);

			// When depositing positive amounts
			account.Deposit(amount);

			// Then
			// 1. Current balance should increase by deposited amount
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			// 2. Opening balance should stay the same
			Assert.AreEqual(openingBalance + amount, account.CurrentBalance);
		}

		[Test]
		public void When_depositing_non_positive_amounts_Throws_exception()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = -1000m;

			// Given account
			var account = new Account(name, description, openingBalance);

			// When depositing a non-positive accounts
			var exception = Assert.Throws<ArgumentException>(() => account.Deposit(amount));

			// 1. Throws an exception with an error message `DepositedAmountMustBeGreaterThanZero`
			Assert.AreEqual(exception.Message, SystemMessages.Errors.DepositedAmountMustBeGreaterThanZero);
			// 2. Balances shouldn't be modified
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		[Test]
		public void Given_positive_balance_greater_than_zero_Then_can_withdraw_amount_less_than_or_equal_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 1000m;

			// Given account with balance greater than Zero
			var account = new Account(name, description, openingBalance);

			// When withdraw amount less than balance and greater than Zero
			account.Deposit(amount);

			// Then 
			// 1. balance should decrease by withdrawn amount
			Assert.AreEqual(openingBalance - amount, account.CurrentBalance);
			// 2. opening balance should stay the same
			Assert.AreEqual(openingBalance, account.OpeningBalance);
		}

		[Test]
		public void Given_positive_balance_When_withdraw_amount_greater_than_balance_Throws_exception()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 3000m;

			// Given account with balance greater than Zero
			var account = new Account(name, description, openingBalance);

			// When withdraw amount greater than balance
			var exception = Assert.Throws<ArgumentException>(() => account.Deposit(amount));
			// Throws an exception with an error message `WithdrawnAmountMustBeLessThanOrEqualBalance`
			Assert.AreEqual(exception.Message, SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance);
		}
	}
}
