using System;
using System.Collections.Generic;

namespace CashFlowEngine
{
	public interface IReceivable : INote
	{
		string Payor { get; }

		IList<Collection> Collections { get; }
	}
}
