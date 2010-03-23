using System;

namespace CashFlowEngine
{
	public class Bill
	{
		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string BeneficiaryName { get; protected set; }
		public DateTime IssueDate { get; protected set; }
		public DateTime DueDate { get; protected set; }
		public decimal Amount { get; protected set; }
		public bool IsPaid { get; protected set; }
		public string Remarks { get; set; }
	}
}
