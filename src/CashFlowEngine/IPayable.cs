using System;

namespace CashFlowEngine
{
	public interface IPayable : INote
	{
		string Beneficiary { get; }
		DateTime PayDate { get; }
		bool IsPaid { get; }

		#region INote Members

		decimal Amount { get; }
		DateTime IssueDate { get; }
		DateTime DueDate { get; }

		#endregion
	}
}
