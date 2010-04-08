using System;

namespace CashFlowEngine
{
	public class Note : INote
	{
		#region INote Members

		public decimal Amount { get; protected set; }
		public DateTime IssueDate { get; protected set; }
		public DateTime DueDate { get; protected set; }

		#endregion
	}
}
