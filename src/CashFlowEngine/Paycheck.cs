using System;

namespace CashFlowEngine
{
	public class Paycheck
	{
		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string Payer { get; protected set; }
		public DateTime IssueDate { get; protected set; }
		public decimal Amount { get; protected set; }
		public bool IsCollected { get; protected set; }
		public string Remarks { get; set; }
	}
}
