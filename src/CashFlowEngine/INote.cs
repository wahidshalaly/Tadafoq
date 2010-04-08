using System;
using System.Collections.Generic;
using System.Text;

namespace CashFlowEngine
{
	public interface INote
	{
		decimal Amount { get; }

		DateTime IssueDate { get; }

		DateTime DueDate { get; }
	}
}
