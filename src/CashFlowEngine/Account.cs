﻿using System;
using WSKnowledge.WSHelpers;
using WSKnowledge.WSHelpers.DesignByContract;

namespace CashFlowEngine
{
	public abstract class Account
	{
		public Guid Id { get; protected set; }
		public string Name { get; protected set; }
		public string Description { get; set; }
		public decimal OpeningBalance { get; protected set; }
		public decimal CurrentBalance { get; protected set; }

		public Account(string name, string description, decimal openingBalance)
		{
			Check.Require(name.IsNotEmpty(), SystemMessages.Errors.ValueIsRequired("Name"));
			Check.Require(openingBalance >= 0, SystemMessages.Errors.OpeningBalanceMustBeGreaterThanZero);

			Name = name;
			Description = description;
			OpeningBalance = openingBalance;
			CurrentBalance = openingBalance;
		}

		public virtual void Deposit(decimal amount)
		{
			Check.Require(amount > 0, SystemMessages.Errors.WithdrawnAmountMustBeGreaterThanZero);
			CurrentBalance += amount ;
		}

		public virtual void Withdraw(decimal amount)
		{
			Check.Require(amount > 0, SystemMessages.Errors.WithdrawnAmountMustBeGreaterThanZero);
			Check.Require(amount <= CurrentBalance, SystemMessages.Errors.WithdrawnAmountMustBeLessThanOrEqualBalance);
			CurrentBalance -= amount;
		}
	}
}
