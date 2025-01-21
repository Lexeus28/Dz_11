#define DEBUG_ACCOUNT
using System;
using Dz_Tumak_11._2.BankClasses;
using Dz_Tumak_11._2.BuildingClasses;
using Dz_Tumak_11._2.NumsClasses;
namespace Tumakov
{
    class Program
    {
        static void Main(string[] args)
        {
            Upr_14_1();
            Upr_14_2();
            Dz_14_1();
        }
        static void Upr_14_1()
        {
            Console.WriteLine(@"Упражнение 14.1 Использование предопределенного условного атрибута для условного
            выполнения кода (указывает компиляторам, что при отсутствии символа условной
            компиляции, вызов метода или атрибут следует игнорировать). В классе банковский счет
            добавить метод DumpToScreen, который отображает детали банковского счета. Для
            выполнения этого метода использовать условный атрибут, зависящий от символа условной
            компиляции DEBUG_ACCOUNT. Протестировать метод DumpToScreen.");
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
                    case "3": account.DumpToScreen(); break;
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
        static void Upr_14_2()
        {
            Console.WriteLine(@"Упражнение 14.2 Создать пользовательский атрибут DeveloperInfoAttribute. Этот атрибут
            позволяет хранить в метаданных класса имя разработчика и, дополнительно, дату
            разработки класса. Атрибут должен позволять многократное использование. Использовать
            этот атрибут для записи имени разработчика класса рациональные числа (упражнение 12.2).");
            Rational a = new Rational(14, 23);
            Rational b = new Rational(24, 45);

            Console.WriteLine($"a: {a}");
            Console.WriteLine($"b: {b}");
            Console.WriteLine($"a+b: {a+b}");
            Console.WriteLine($"a-b: {a-b}");
            Console.WriteLine($"a*b: {a*b}");
            Console.WriteLine($"a/b: {a/b}");
            Console.WriteLine($"float a: {(float)a}");
            Console.WriteLine($"int b: {(int)b}");

            Attribute [] attributes = Attribute.GetCustomAttributes(typeof(Rational), typeof(DeveloperInfoAttribute));
            foreach (DeveloperInfoAttribute attribute in attributes)
            {
                Console.WriteLine($"Разработчик: {attribute.developerName}, Дата: {attribute.date}");
            }
        }
        static void Dz_14_1()
        {
            Console.WriteLine(@"Домашнее задание 14.1 Создать пользовательский атрибут для класса из домашнего
            задания 13.1. Атрибут позволяет хранить в метаданных класса имя разработчика и название
            организации. Протестировать.");
            Building building = new(76, 9, 36, 1);
            building.Print();
            building.FloorHeight();
            building.EntranceApartments();
            building.FloorApartments();
            Attribute[] attributes = Attribute.GetCustomAttributes(typeof(Building), typeof(DeveloperOrganizationInfoAttribute));
            foreach (DeveloperOrganizationInfoAttribute attribute in attributes)
            {
                Console.WriteLine($"Разработчик: {attribute.developerName}, Организация: {attribute.organization}");
            }
        }
    }
}