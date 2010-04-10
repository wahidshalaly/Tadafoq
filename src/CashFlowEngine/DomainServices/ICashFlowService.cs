using System;

namespace CashFlowEngine
{
	public interface ICashFlowService
	{
		long ForcastBalanceAt(DateTime date, long forAccountId);
	}
}
