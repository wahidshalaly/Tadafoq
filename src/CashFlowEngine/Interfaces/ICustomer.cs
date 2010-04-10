using System;
using System.Collections.Generic;

namespace CashFlowEngine
{
	interface ICustomer
	{
		string FullName { get; }

		IList<IAccount> Accounts { get; }

		IList<IPayable> Payables { get; }

		IList<IReceivable> Receivables { get; }

		void AddAccount(IAccount account);

		void AddPayable(IPayable payable);

		void AddReceivable(IReceivable receivable);
	}
}
