using System;
using System.Security.Principal;
using Dz_Tumak_11._1.BankClasses;
using Dz_Tumak_11._1.BuildingClasses;
namespace Tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Upr_13_1_2();
            Dz_13_1_2();
        }
        static void Upr_13_1_2()
        {
            Console.WriteLine(@"Упражнение 13.1 Из класса банковский счет удалить методы, возвращающие значения
            полей номер счета и тип счета, заменить эти методы на свойства только для чтения.
            Добавить свойство для чтения и записи типа string для отображения поля держатель
            банковского счета. Изменить класс BankTransaction, созданный для хранений финансовых
            операций со счетом, - заменить методы доступа к данным на свойства для чтения.");
            Console.WriteLine(@"Упражнение 13.2 Добавить индексатор в класс банковский счет для получения доступа к
            любому объекту BankTransaction.");
            Bank_account account = new Bank_account(56789, AccountType.сберегательный);
            Bank_account account2 = new Bank_account(5678, AccountType.текущий);
            bool flag = true;
            decimal res;
            while (flag)
            {
                Console.WriteLine("\nВыберите операцию:\n1.Пополнить\n2.Снять\n3.Отобразить счёт\n4.Перевести деньги\n5.Записать данные об операциях в файл");
                switch (Console.ReadLine())
                {
                    case "1": account.Deposit(); account.Print(); break;
                    case "2": account.Withdraw(); account.Print(); break;
                    case "3": account.Print(); break;
                    case "4":
                        Console.WriteLine("Введите сумму, которую хотите перевести.\n");
                        while (!decimal.TryParse(Console.ReadLine(), out res))
                        {
                            Console.WriteLine("\nНеверный формат данных. Повторите попытку\n");
                        }
                        account.Transfer(account2, res);
                        break;
                    case "5": account.Dispose(); break;
                    default: flag = false; break;
                }
            }
        }
        static void Dz_13_1_2()
        {
            Console.WriteLine(@"Домашнее задание 13.1 В классе здания из домашнего задания 7.1 все методы для
            заполнения и получения значений полей заменить на свойства.Написать тестовый пример.");
            Console.WriteLine(@" Домашнее задание 13.2 Создать класс для нескольких зданий.Поле класса – массив на 10
            зданий.В классе создать индексатор, возвращающий здание по его номеру.");
            Building building = new (76, 9, 36, 1);
            Building building2 = new(32, 3, 14, 2);
            building.Print();
            building.FloorHeight();
            building.EntranceApartments();
            building.FloorApartments();
            Zastroika zastroika = new Zastroika();
            zastroika[5] = building;
            zastroika[3] = building2;
            zastroika[3].Print();
        }
    }
}