using System;

namespace CashFlowEngine.DomainServices
{
	public interface IAccountService
	{
		long OpenCheckingAccount(long customerId, string name, string description);

		decimal GetCurrentBalance(long accountId);

		void DepositCash(decimal amount, long intoAccountId);

		void WithdrawCash(decimal amount, long fromAccountId);

		void DepositPaycheck(Paycheck paycheck, long intoAccountId);

		void PayBill(Bill bill, decimal amount, long fromAccountId);
	}
}
