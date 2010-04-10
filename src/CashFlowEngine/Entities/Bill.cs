using System;
using System.Collections.Generic;

namespace CashFlowEngine
{
	public class Bill : Note, IPayable
	{
		protected List<Payment> _payments;

		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string Remarks { get; set; }

		#region IPayable Members

		public string Beneficiary { get; protected set; }
		public IList<Payment> Payments { get { return _payments.AsReadOnly(); } }

		#endregion

		public Bill(string serial, string payor, decimal amount)
			: base(amount, DateTime.Now, DateTime.Now)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Beneficiary = payor;
		}

		public Bill(string serial, string payor, decimal amount, DateTime issueDate)
			: base(amount, issueDate, issueDate)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Beneficiary = payor;
		}

		public Bill(string serial, string payor, decimal amount, DateTime issueDate, DateTime dueDate)
			: base(amount, issueDate, dueDate)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Beneficiary = payor;
		}
	}
}
