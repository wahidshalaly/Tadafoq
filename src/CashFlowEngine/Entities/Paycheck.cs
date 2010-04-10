using System;
using System.Collections.Generic;

namespace CashFlowEngine
{
	public class Paycheck : Note, IReceivable
	{
		protected List<Collection> _collections;

		public Guid Id { get; protected set; }
		public string Serial { get; protected set; }
		public string Remarks { get; set; }

		#region IReceivable Members

		public string Payor { get; protected set; }
		public IList<Collection> Collections { get { return _collections.AsReadOnly(); } }

		#endregion

		public Paycheck(string serial, string payor, decimal amount)
			: base(amount, DateTime.Now, DateTime.Now)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Payor = payor;
		}

		public Paycheck(string serial, string payor, decimal amount, DateTime issueDate)
			: base(amount, issueDate, issueDate)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Payor = payor;
		}

		public Paycheck(string serial, string payor, decimal amount, DateTime issueDate, DateTime dueDate)
			: base(amount, issueDate, dueDate)
		{
			Id = Guid.NewGuid();
			Serial = serial;
			Payor = payor;
		}
	}
}
