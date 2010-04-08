using System;

namespace CashFlowEngine
{
	public enum TransactionType { Deposit, Withdraw }

	public interface ITransaction
	{
		IAccount Account { get; }
		decimal Amount { get; }
		TransactionType Type { get; }
		INote RelatedNote { get; }
	}
}
