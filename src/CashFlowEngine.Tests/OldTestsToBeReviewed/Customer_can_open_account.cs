using CashFlowEngine;
using NUnit.Framework;

namespace CashFlowEngine.Tests
{
	[TestFixture]
	public class Customer_can_open_account
	{
		string name = "My Checking Account";
		string description = "This is my checking intoAccount.";
		decimal openingBalance = 3000m;

		[Test]
		public void Can_open_saving_account_with_cash_depositing()
		{
			var account = new SavingAccount(name, description, openingBalance);

			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}

		[Test]
		public void Can_open_checking_account_without_cash_depositing()
		{
			var account = new CheckingAccount(name, description);

			Assert.AreEqual(name, account.Name);
			Assert.AreEqual(description, account.Description);
			Assert.AreEqual(0, account.OpeningBalance);
			Assert.AreEqual(0, account.CurrentBalance);
		}

		[Test]
		public void Can_open_multiple_mixed_accounts()
		{
			string name1 = "intoAccount one", description1 = "This is the first intoAccount";
			string name2 = "intoAccount two", description2 = "This is the second intoAccount";
			decimal openingBalance1 = 1500m;
			var account1 = new SavingAccount(name1, description1, openingBalance1);
			var account2 = new CheckingAccount(name2, description2);
			var customer = new Customer("Customer Full Name");

			customer.AddAccount(account1);
			customer.AddAccount(account2);

			Assert.AreEqual(2, customer.Accounts.Count);
			Assert.IsTrue(customer.Accounts.Contains(account1));
			Assert.IsTrue(customer.Accounts.Contains(account2));
		}

		[Test]
		public void Can_check_account_opening_balance()
		{
			var account = new SavingAccount(name, description, openingBalance);

			Assert.AreEqual(openingBalance, account.OpeningBalance);
		}

		[Test]
		public void Can_check_account_current_balance()
		{
			var account = new SavingAccount(name, description, openingBalance);

			Assert.AreEqual(openingBalance, account.OpeningBalance);
			Assert.AreEqual(openingBalance, account.CurrentBalance);
		}
	}
}
