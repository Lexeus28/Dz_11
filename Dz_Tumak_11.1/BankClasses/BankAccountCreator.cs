using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tumakov;

namespace Dz_Tumak_11._1.BankClasses
{
    public class BankAccountCreator
    {
        public readonly Hashtable accounts = new();
        public string CreateAccount()
        {
            Bank_account account = new Bank_account();
            accounts[account.UniqueNum()] = account;
            return account.UniqueNum();
        }

        public string CreateAccount(decimal balance)
        {
            Bank_account account = new Bank_account(balance);
            accounts[account.UniqueNum()] = account;
            return account.UniqueNum();
        }
        public string CreateAccount(AccountType type)
        {
            Bank_account account = new Bank_account(type);
            accounts[account.UniqueNum()] = account;
            return account.UniqueNum();
        }
        public string CreateAccount(decimal balance, AccountType type)
        {
            Bank_account account = new Bank_account(balance, type);
            accounts[account.UniqueNum()] = account;
            return account.UniqueNum();
        }
        public void CloseAccount(string accountNumber)
        {
            if (!accounts.ContainsKey(accountNumber))
            {
                throw new KeyNotFoundException("Account not found.");
            }
            accounts.Remove(accountNumber);
            Console.WriteLine($"Account {accountNumber} has been closed.");
        }
    }
}
