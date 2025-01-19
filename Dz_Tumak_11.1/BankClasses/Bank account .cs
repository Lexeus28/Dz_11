using System;
using System.Collections;
using System.Collections.Generic;
using Tumakov;

namespace Tumakov
{
    public class Bank_account
    {
        private string number;
        private decimal balance;
        private AccountType type;
        private static List<string> numbers = new List<string>();
        private static List<BankTransaction> bankTransactions = new List<BankTransaction>();
        private string holder;

        public string Number
        {
            get { return number; }
        }

        public AccountType Type
        {
            get { return type; }
        }

        public string Holder
        {
            get { return holder; }
            set { holder = value; }
        }

        public BankTransaction this[int index]
        {
            get { return bankTransactions[index]; }
        }

        internal Bank_account()
        {
            number = UniqueNum();
            balance = 0;
            type = AccountType.текущий;
        }

        internal Bank_account(decimal balance)
        {
            this.balance = balance;
            number = UniqueNum();
        }

        internal Bank_account(AccountType type)
        {
            this.type = type;
            number = UniqueNum();
        }

        internal Bank_account(decimal balance, AccountType type)
        {
            number = UniqueNum();
            this.balance = balance;
            this.type = type;
        }

        public string UniqueNum()
        {
            string newNumber;
            do
            {
                Random rand = new Random();
                int[] rand_numbers = new int[20];
                for (int i = 0; i < rand_numbers.Length; i++)
                {
                    rand_numbers[i] = rand.Next(0, 9);
                }
                newNumber = string.Join("", rand_numbers);
            }
            while (numbers.Contains(newNumber));
            numbers.Add(newNumber);
            return newNumber;
        }

        public void Print()
        {
            Console.WriteLine($"\nНомер счёта: {number}\nБаланс: {balance}\nТип банковского счёта: {type}");
        }

        static bool IsAllDigit(string n)
        {
            foreach (char c in n)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        public void Deposit()
        {
            Console.WriteLine("\nВведите сумму для пополнения:");
            decimal bal;
            while (!decimal.TryParse(Console.ReadLine(), out bal))
            {
                Console.WriteLine("\nНеверный формат данных. Повторите попытку.");
            }
            BankTransaction a = new BankTransaction(bal);
            bankTransactions.Add(a);
            balance += bal;
        }

        public void Withdraw()
        {
            Console.WriteLine("\nВведите сумму для снятия:");
            decimal bal;
            while (!decimal.TryParse(Console.ReadLine(), out bal) || bal > balance)
            {
                Console.WriteLine("\nНеверный формат данных или недостаточно средств. Повторите попытку.");
            }
            BankTransaction a = new BankTransaction(bal);
            bankTransactions.Add(a);
            balance -= bal;
        }

        public void Transfer(Bank_account targetAccount, decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("\nСумма перевода должна быть больше нуля.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("\nНедостаточно средств для перевода.");
                return;
            }
            BankTransaction a = new BankTransaction(amount);
            bankTransactions.Add(a);
            balance -= amount;
            targetAccount.balance += amount;
            Console.WriteLine($"\nПеревод успешно выполнен.\nС вашего счёта снято: {amount}\nТекущий баланс: {balance}");
            Console.WriteLine($"На счёт {targetAccount.number} зачислено: {amount}\nТекущий баланс получателя: {targetAccount.balance}");
        }
        public void Dispose()
        {
            string filePath = "transactions.txt";
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                foreach (var transaction in bankTransactions)
                {
                    writer.WriteLine($"Дата: {transaction.date}, Сумма: {transaction.sum}");
                }
                bankTransactions.Clear();
            }
            Console.WriteLine($"Транзакции записаны в файл {filePath}.");
            GC.SuppressFinalize(this);
        }
    }
}