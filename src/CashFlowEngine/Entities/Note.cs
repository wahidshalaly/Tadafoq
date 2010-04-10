using System;

namespace CashFlowEngine
{
	public class Note : INote
	{
		#region INote Members

		public decimal Amount { get; protected set; }
		public decimal Balance { get; protected set; }
		public DateTime IssueDate { get; protected set; }
		public DateTime DueDate { get; protected set; }
		public NoteState State { get; protected set; }

		#endregion

		public Note(decimal amount) :
			this(amount, DateTime.Now, DateTime.Now)
		{
		}

		public Note(decimal amount, DateTime issueDate) :
			this(amount, issueDate, DateTime.Now)
		{
		}

		public Note(decimal amount, DateTime issueDate, DateTime dueDate)
		{
			Amount = amount;
			IssueDate = issueDate;
			DueDate = dueDate;
		}
	}
}
