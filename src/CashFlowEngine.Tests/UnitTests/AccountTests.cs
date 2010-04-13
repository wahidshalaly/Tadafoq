using System;
using NUnit.Framework;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine.Tests.UnitTests
{
	[TestFixture]
	public class AccountTests
	{
		#region Constructor test cases

		[Test]
		public void Cannot_create_account_with_noargs_ctor()
		{
			Assert.Throws<MissingMethodException>(() => Activator.CreateInstance<Account>());
		}

		[Test]
		public void Can_create_account_with_valid_name_description_and_opening_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;

			var account = new Account(name, description, openingBalance);

			Assert.AreNotEqual(Guid.Empty, account.Id);
			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		[Test]
		public void Cannot_create_account_with_empty_name()
		{
			string name = string.Empty;
			string description = "Account Description";
			decimal openingBalance = 2500m;

			var exception = Assert.Throws<PreconditionException>(() => new Account(name, description, openingBalance));

			Assert.AreEqual(exception.Message, SystemMessages.Errors.ValueIsRequired("name"));
		}

		[Test]
		public void Cannot_create_account_with_null_name()
		{
			string name = null;
			string description = "Account Description";
			decimal openingBalance = 2500m;

			var exception = Assert.Throws<PreconditionException>(() => new Account(name, description, openingBalance));

			Assert.AreEqual(exception.Message, SystemMessages.Errors.ValueIsRequired("name"));
		}

		[Test]
		public void Cannot_create_account_with_negative_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = -2500m;

			var exception = Assert.Throws<PreconditionException>(() => new Account(name, description, openingBalance));

			Assert.AreEqual(exception.Message, SystemMessages.Errors.OpeningBalanceMustBeGreaterThanZero);
		}

		[Test]
		public void Can_create_account_with_empty_description()
		{
			string name = "Account Name";
			string description = String.Empty;
			decimal openingBalance = 2500m;

			var account = new Account(name, description, openingBalance);

			Assert.AreNotEqual(Guid.Empty, account.Id);
			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		[Test]
		public void Can_create_account_with_zero_opening_balance()
		{
			string name = "Account Name";
			string description = String.Empty;
			decimal openingBalance = 0m;

			var account = new Account(name, description, openingBalance);

			Assert.AreNotEqual(Guid.Empty, account.Id);
			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}
		#endregion

		#region Deposit() method test cases

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
		public void Cannot_deposit_negative_amounts()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = -1000m;

			// Given account
			var account = new Account(name, description, openingBalance);

			// When depositing a non-positive accounts
			var exception = Assert.Throws<PreconditionException>(() => account.Deposit(amount));

			// 1. Throws an exception with an error message `DepositedAmountMustBeGreaterThanZero`
			Assert.AreEqual(exception.Message, SystemMessages.Errors.DepositedAmountMustBeGreaterThanZero);
			// 2. Balances shouldn't be modified
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		[Test]
		public void Cannot_deposit_Zero_amount()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 0m;

			// Given account
			var account = new Account(name, description, openingBalance);

			// When depositing a non-positive accounts
			var exception = Assert.Throws<PreconditionException>(() => account.Deposit(amount));

			// 1. Throws an exception with an error message `DepositedAmountMustBeGreaterThanZero`
			Assert.AreEqual(exception.Message, SystemMessages.Errors.DepositedAmountMustBeGreaterThanZero);
			// 2. Balances shouldn't be modified
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		#endregion

		#region Withdraw() method test cases

		[Test]
		public void Can_withdraw_amount_less_than_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = openingBalance;

			// Given account with balance greater than Zero
			var account = new Account(name, description, openingBalance);

			// When withdraw amount less than balance and greater than Zero
			account.Withdraw(amount);

			// Then 
			// 1. balance should decrease by withdrawn amount
			Assert.AreEqual(openingBalance - amount, account.CurrentBalance);
			// 2. opening balance should stay the same
			Assert.AreEqual(openingBalance, account.OpeningBalance);
		}

		[Test]
		public void Can_withdraw_amount_equals_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 1000m;

			// Given account with balance greater than Zero
			var account = new Account(name, description, openingBalance);

			// When withdraw amount less than balance and greater than Zero
			account.Withdraw(amount);

			// Then 
			// 1. balance should decrease by withdrawn amount
			Assert.AreEqual(openingBalance - amount, account.CurrentBalance);
			// 2. opening balance should stay the same
			Assert.AreEqual(openingBalance, account.OpeningBalance);
		}

		[Test]
		public void Cannot_withdraw_amount_greater_than_balance()
		{
			string name = "Account Name";
			string description = "Account Description";
			decimal openingBalance = 2500m;
			decimal amount = 3000m;

			// Given account with balance greater than Zero
			var account = new Account(name, description, openingBalance);

			// When withdraw amount greater than balance
			var exception = Assert.Throws<PreconditionException>(() => account.Withdraw(amount));
			// Throws an exception with an error message `WithdrawnAmountMustBeLessThanOrEqualBalance`
			Assert.AreEqual(exception.Message, SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance);
		}

		#endregion
	}
}
