using System;
using System.Collections.Generic;

namespace CashFlowEngine.DomainServices
{
	/// <summary>
	///  This is a service that generate serials based on tags & formats.
	///  Tags are to create different domains for serials, like: Checks, Accounts, Bills..etc.
	///  Formats to give custom formats for each different domain, like: %branch%-month-day-xxx
	///  For the above sample format there should be 
	/// </summary>
	public interface ISerialGenerator
	{
		bool IsTagRegistered(string tag);

		void RegisterTag(string tag);

		void RegisterTag(string tag, string format);

		string GetFormat(string tag);

		string GetNext(string tag);

		string GetNext(string tag, params string[] factors);

		List<string> GetAllTags(string tag);
	}
}
