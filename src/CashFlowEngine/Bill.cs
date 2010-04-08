using System;

namespace CashFlowEngine
{
	public class Bill : Note, IPayable
	{
		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string Remarks { get; set; }

		#region IPayable Members

		public string Beneficiary { get; protected set; }
		public DateTime PayDate { get; protected set; }
		public bool IsPaid { get; protected set; }

		#endregion
	}
}
