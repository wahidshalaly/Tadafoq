using System;

namespace CashFlowEngine
{
	public class Collection
	{
		public Guid Id { get; protected set; }
		public decimal Amount { get; protected set; }
		public DateTime Date { get; protected set; }

		public Collection(decimal amount, DateTime date)
		{
		}
	}
}
