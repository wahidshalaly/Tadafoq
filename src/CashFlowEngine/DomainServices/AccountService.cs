using System;

namespace CashFlowEngine.DomainServices
{
	public class AccountService : IAccountService
	{
		public long OpenCheckingAccount(long customerId, string name, string description)
		{
			throw new NotImplementedException();
		}

		public decimal GetCurrentBalance(long accountId)
		{
			throw new NotImplementedException();
		}

		public void DepositCash(decimal amount, long accountId)
		{
			throw new NotImplementedException();
		}

		public void WithdrawCash(decimal amount, long accountId)
		{
			throw new NotImplementedException();
		}

		public void DepositPaycheck(Paycheck paycheck, long intoAccountId)
		{
			throw new NotImplementedException();
		}

		public void PayBill(Bill bill, decimal amount, long fromAccountId)
		{
			throw new NotImplementedException();
		}
	}
}
