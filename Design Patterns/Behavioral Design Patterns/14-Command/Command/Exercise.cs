using System;
using static System.Console;

// Implement the Account.Process()  method to process different account commands. The rules are obvious:
// Success indicates whether the operation was successful
// You can only withdraw money if you have enough in your account

namespace Behavioral.Command.Exercise
{
    public class Exercise
    {
        static void Main(string[] args)
        {
            var account = new Account();
            account.Process(new Command { TheAction = Command.Action.Deposit, Amount = 100 });
            WriteLine(account.Balance);
        }
    }

    public class Command
    {
        public enum Action
        {
            Deposit,
            Withdraw
        }

        public Action TheAction;
        public int Amount;
        public bool Success;
    }

    public class Account
    {
        public int Balance { get; set; }

        public void Process(Command c)
        {
            switch (c.TheAction)
            {
                case Command.Action.Deposit:
                    Balance += c.Amount;
                    c.Success = true;
                    break;
                case Command.Action.Withdraw:
                    c.Success = Balance >= c.Amount;
                    if (c.Success) Balance -= c.Amount;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}