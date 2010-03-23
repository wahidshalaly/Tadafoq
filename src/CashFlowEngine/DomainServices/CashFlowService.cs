using System;

namespace CashFlowEngine
{
	public class CashFlowService : CashFlowEngine.ICashFlowService
	{
		public long OpenSavingAccount(long customerId, string name, string description, decimal openingBalance)
		{
			throw new NotImplementedException();
		}

		public long OpenCheckingAccount(long customerId, string name, string description)
		{
			throw new NotImplementedException();
		}

		public decimal GetCurrentBalance(long accountId)
		{
			throw new NotImplementedException();
		}
	}
}
