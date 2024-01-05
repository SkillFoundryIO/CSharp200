using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingMethods
{
    public class Account
    {
        private string? _name;
        private decimal _balance;

        public string GetBalance()
        {
            return $"{_balance:c}";
        }

        public void SetName(string name)
        {
            _name = name;
        }

        public string GetName()
        {
            return _name;
        }

        public void AddInterest()
        {
            _balance *= .02M;
        }

        public void Deposit(decimal amount)
        {
            if(amount > 0)
            {
                _balance += amount;
            }
        }

        public bool Withdraw(decimal amount, bool allowOverdraft=false)
        {
            if(_balance - amount > 0)
            {
                _balance -= amount;
                return true;
            }
            else if (allowOverdraft)
            {
                _balance -= amount;
                return true;
            }
            else
            {
                return false;
            }        
        }
    }
}
