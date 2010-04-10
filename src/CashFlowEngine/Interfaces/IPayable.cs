using System;
using System.Collections.Generic;

namespace CashFlowEngine
{
	public interface IPayable : INote
	{
		string Beneficiary { get; }

		IList<Payment> Payments { get; }
	}
}
