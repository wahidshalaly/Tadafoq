using System;

namespace CashFlowEngine
{
	public class SavingAccount : Account
	{
		public SavingAccount(string name, string description, decimal openingBalance)
			: base (name, description, openingBalance)
		{
		}
	}
}
