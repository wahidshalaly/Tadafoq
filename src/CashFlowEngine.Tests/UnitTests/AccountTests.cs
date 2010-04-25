using System;
using NUnit.Framework;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine.Tests.UnitTests
{
	[TestFixture]
	public class AccountTests
	{
		private decimal _openingBalance = 2000m;
		private decimal _positiveAmount = 500m;
		private decimal _negativeAmount = -300m;
		private Account _account;

		private void Given_account_with_positive_balance()
		{
			string name = "Account Name";
			string description = "Account Description";

			_account = new Account(name, description, _openingBalance);
		}

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

		private void When_depositing_positive_amount()
		{
			_account.Deposit(_positiveAmount);
		}

		private void When_depositing_negative_amount()
		{
			_account.Deposit(_negativeAmount);
		}

		private void When_depositing_zero()
		{
			_account.Deposit(0m);
		}

		[Test]
		public void Can_deposit_positive_amounts()
		{
			Given_account_with_positive_balance();

			When_depositing_positive_amount();

			// Then
			// 1. Current balance should increase by deposited amount
			Assert.AreEqual(_openingBalance, _account.OpeningBalance);
			// 2. Opening balance should stay the same
			Assert.AreEqual(_openingBalance + _positiveAmount, _account.CurrentBalance);
		}

		[Test]
		public void Cannot_deposit_negative_amounts()
		{
			Given_account_with_positive_balance();

			var exception = Assert.Throws<PreconditionException>(() => When_depositing_negative_amount());

			// 1. Throws an exception
			Assert.AreEqual(exception.Message, SystemMessages.Errors.DepositedAmountMustBeGreaterThanZero);
			// 2. Balances shouldn't be modified
			Assert.AreEqual(_openingBalance, _account.OpeningBalance);
			Assert.AreEqual(_openingBalance, _account.CurrentBalance);
		}

		[Test]
		public void Cannot_deposit_Zero()
		{
			Given_account_with_positive_balance();

			var exception = Assert.Throws<PreconditionException>(() => When_depositing_zero());

			// 1. Throws an exception
			Assert.AreEqual(exception.Message, SystemMessages.Errors.DepositedAmountMustBeGreaterThanZero);
			// 2. Balances shouldn't be modified
			Assert.AreEqual(_openingBalance, _account.OpeningBalance);
			Assert.AreEqual(_openingBalance, _account.CurrentBalance);
		}

		#endregion

		#region Withdraw() method test cases

		private void When_withdrawing_positive_amount_less_than_balance()
		{
			_account.Withdraw(_positiveAmount);
		}

		private void When_withdrawing_positive_amount_equals_balance()
		{
			_account.Withdraw(_openingBalance);
		}

		private void When_withdrawing_positive_amount_greater_than_balance()
		{
			_account.Withdraw(_openingBalance + _positiveAmount);
		}

		private void When_withdrawing_negative_amount()
		{
			_account.Withdraw(_negativeAmount);
		}

		private void When_withdrawing_zero_amount()
		{
			_account.Withdraw(0m);
		}

		[Test]
		public void Can_withdraw_amount_less_than_balance()
		{
			Given_account_with_positive_balance();

			When_withdrawing_positive_amount_less_than_balance();

			// Then 
			// 1. balance should decrease by withdrawn amount
			Assert.AreEqual(_openingBalance - _positiveAmount, _account.CurrentBalance);
			// 2. opening balance should stay the same
			Assert.AreEqual(_openingBalance, _account.OpeningBalance);
		}

		[Test]
		public void Can_withdraw_amount_equals_balance()
		{
			Given_account_with_positive_balance();

			When_withdrawing_positive_amount_equals_balance();

			// Then 
			// 1. balance should by Zero
			Assert.AreEqual(0m, _account.CurrentBalance);
			// 2. opening balance should stay the same
			Assert.AreEqual(_openingBalance, _account.OpeningBalance);
		}

		[Test]
		public void Cannot_withdraw_amount_greater_than_balance()
		{
			Given_account_with_positive_balance();

			var exception = Assert.Throws<PreconditionException>(
				() => When_withdrawing_positive_amount_greater_than_balance());

			Assert.AreEqual(exception.Message, 
				SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance);
		}

		[Test]
		public void Cannot_withdraw_zero_amount()
		{
			Given_account_with_positive_balance();

			var exception = Assert.Throws<PreconditionException>(
				() => When_withdrawing_zero_amount());

			Assert.AreEqual(exception.Message,
				SystemMessages.Errors.WithdrawnAmountMustBeGreaterThanZero);
		}

		[Test]
		public void Cannot_withdraw_negative_amount()
		{
			Given_account_with_positive_balance();

			var exception = Assert.Throws<PreconditionException>(
				() => When_withdrawing_negative_amount());

			Assert.AreEqual(exception.Message,
				SystemMessages.Errors.WithdrawnAmountMustBeGreaterThanZero);
		}

		#endregion
	}
}
