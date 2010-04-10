using System;

namespace CashFlowEngine
{
	public interface INote
	{
		decimal Amount { get; }

		decimal Balance { get; }

		DateTime IssueDate { get; }

		DateTime DueDate { get; }

		NoteState State { get; }
	}
}
