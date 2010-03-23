using System;
using System.Collections.Generic;
using WSKnowledge.WSHelpers;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine
{
	public class Customer
	{
		protected List<Account> _accounts;

		public string FullName { get; protected set; }

		public IList<Account> Accounts
		{
			get { return _accounts.AsReadOnly(); }
		}

		public Customer(string fullName)
		{
			Check.Require(fullName.IsNotEmpty(), "Full name is required.");

			FullName = fullName;
			_accounts = new List<Account>();
		}

		public void AddAccount(Account account)
		{
			Check.Require(account != null, "Account is required, null is not acceptable value.");
			
			_accounts.Add(account);
		}
	}
}
