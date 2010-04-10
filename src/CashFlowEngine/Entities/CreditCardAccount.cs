namespace CashFlowEngine
{
	// I added this to see the benefit of inheriting from Account.
	// But this type must be delayed for complication at the moment.
	// It should have a due date for its balance.
	// Since that its balance is a debt the customer owe to bank.
	public class CreditCardAccount : Account, IAccount
	{
		public CreditCardAccount(string name, string description, decimal openingBalance)
			: base(name, description, openingBalance)
		{
		}
	}
}
