﻿using System;

namespace CashFlowEngine
{
	interface IAccount
	{
		string Name { get; }
		decimal CurrentBalance { get; }
		decimal OpeningBalance { get; }
		void Deposit(decimal amount);
		void Withdraw(decimal amount);
	}
}
