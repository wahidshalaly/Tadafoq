using System;
using System.Collections.Generic;
using WSKnowledge.WSHelpers;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine
{
	public class Customer : ICustomer
	{
		protected List<IAccount> _accounts;
		protected List<IPayable> _payables;
		protected List<IReceivable> _receivables;

		public Customer(string fullName)
		{
			Check.Require(fullName.IsNotEmpty(), "Full name is required.");

			FullName = fullName;
			_accounts = new List<IAccount>();
		}

		#region ICustomer Members

		public string FullName { get; protected set; }

		public IList<IAccount> Accounts { get { return _accounts.AsReadOnly(); } }

		public IList<IPayable> Payables { get { return _payables.AsReadOnly(); } }

		public IList<IReceivable> Receivables { get { return _receivables.AsReadOnly(); } }

		public void AddAccount(IAccount account)
		{
			Check.Require(account != null, "Account is required, null is not acceptable value.");

			_accounts.Add(account);
		}

		public void AddPayable(IPayable payable)
		{
			throw new NotImplementedException();
		}

		public void AddReceivable(IReceivable receivable)
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
