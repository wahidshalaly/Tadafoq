using System;
using System.Collections.Generic;

namespace CashFlowEngine.DomainServices
{
	public class SerialGenerator : ISerialGenerator
	{
		#region ISerialGenerator Members

		public bool IsTagRegistered(string tag)
		{
			throw new NotImplementedException();
		}

		public void RegisterTag(string tag)
		{
			throw new NotImplementedException();
		}

		public void RegisterTag(string tag, string format)
		{
			throw new NotImplementedException();
		}

		public string GetFormat(string tag)
		{
			throw new NotImplementedException();
		}

		public string GetNext(string tag)
		{
			throw new NotImplementedException();
		}

		public string GetNext(string tag, params string[] factors)
		{
			throw new NotImplementedException();
		}

		public List<string> GetAllTags(string tag)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
