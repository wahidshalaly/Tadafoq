using System;

namespace CashFlowEngine
{
	public interface ICashFlowService
	{
		long OpenCheckingAccount(long customerId, string name, string description);

		long OpenSavingAccount(long customerId, string name, string description, decimal openingBalance);

		decimal GetCurrentBalance(long accountId);
	}
}
