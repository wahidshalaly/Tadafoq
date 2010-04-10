namespace CashFlowEngine
{
	public class SavingAccount : Account, IAccount
	{
		public SavingAccount(string name, string description, decimal openingBalance)
			: base(name, description, openingBalance)
		{
		}
	}
}
