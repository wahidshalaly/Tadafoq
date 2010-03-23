using System;

namespace CashFlowEngine
{
	public static class SystemMessages
	{
		public static class Errors
		{
			public const string OpeningBalanceMustBeGreaterThanZero
				= "Opening balance must be greater than Zero.";

			public const string InsufficientFunds
				= "Account does not have sufficient funds for this transaction.";

			public const string DepositedAmountMustBeGreaterThanZero
				= "Deposited amount must be greater than Zero.";

			public const string WithdrawnAmountMustBeGreaterThanZero
				= "Withdrawn amount must be greater than Zero.";

			public const string WithdrawnAmountMustBeLessThanOrEqualBalance
				= "Withdrawn amount must be less than or equal to current balance.";

			public static string ValueIsRequired(string paramterName)
			{
				return String.Format("{0} is required.", paramterName);
			}
		}
	}
}
