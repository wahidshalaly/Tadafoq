using System;

namespace CashFlowEngine
{
	public class TransactionLog
	{
		public Guid Id { get; protected set; }

		public IAccount Account { get; protected set; }

		public decimal Amount { get; protected set; }

		public INote RelatedNote { get; protected set; }

		public TransactionType Type { get; protected set; }

		public DateTime ProcessDate { get; protected set; }
	}
}
