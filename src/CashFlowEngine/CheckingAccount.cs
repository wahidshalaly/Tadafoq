using System;

namespace CashFlowEngine
{
	public class CheckingAccount : Account
	{
		public CheckingAccount(string name, string description)
			: base (name, description, 0)
		{
		}
	}
}
