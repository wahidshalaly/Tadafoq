using System;

namespace CashFlowEngine
{
	public interface IReceivable : INote
	{
		string Payor { get; }
		DateTime CollectionDate { get; }
		bool IsCollected { get; }

		#region INote Members
	
		decimal Amount { get; }
		DateTime IssueDate { get; }
		DateTime DueDate { get; }

		#endregion
	}
}
