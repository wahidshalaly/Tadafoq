using System;

namespace CashFlowEngine
{
	public class CheckingAccount : Account, IAccount
	{
		public CheckingAccount(string name, string description)
			: base(name, description, 0)
		{
		}
	}
}
