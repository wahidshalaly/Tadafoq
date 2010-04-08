using System;

namespace CashFlowEngine
{
	public class Paycheck : Note, IReceivable
	{
		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string Remarks { get; set; }

		#region IReceivable Members

		public string Payor { get; protected set; }
		public DateTime CollectionDate { get; protected set; }
		public bool IsCollected { get; protected set; }

		#endregion
	}
}
