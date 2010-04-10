using System;

namespace CashFlowEngine
{
	public class Payment
	{
		public Guid Id { get; protected set; }
		public decimal Amount { get; protected set; }
		public DateTime Date { get; protected set; }

		public Payment(decimal amount, DateTime date)
		{
		}
	}
}
