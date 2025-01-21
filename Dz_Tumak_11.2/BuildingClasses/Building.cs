using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dz_Tumak_11._2.BuildingClasses
{
    [DeveloperOrganizationInfo("Боб", "Бумстрой")]
    [DeveloperOrganizationInfo("Степан", "Бумстрой")]
    public class Building
    {
        private string id;
        private float height { get; set; }
        private int floors { get; set; }
        private int apartmentAmount { get; set; }
        private int entranceAmount { get; set; }
        private static int unique = 0;

        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                unique += 1;
                id = $"{unique:D4}";
            }
        }

        internal Building() { }

        internal Building(float height, int floors, int apartmentAmount, int entranceAmount)
        {
            Id = "";
            this.height = height;
            this.floors = floors;
            this.apartmentAmount = apartmentAmount;
            this.entranceAmount = entranceAmount;
        }

        public void Print()
        {
            Console.WriteLine($"\nУникальный номер здания: {id}\nВысота: {height}\nЭтажность: {floors}\nКоличество квартир: {apartmentAmount}\nКоличество подъездов: {entranceAmount}");
        }

        public void FloorHeight()
        {
            try
            {
                Console.WriteLine($"Высота этажа: {height / floors}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nОшибка: Деление на ноль");
            }
        }

        public void FloorApartments()
        {
            try
            {
                Console.WriteLine($"Количество квартир на этаже: {apartmentAmount / floors}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nОшибка: Деление на ноль");
            }
        }

        public void EntranceApartments()
        {
            try
            {
                Console.WriteLine($"Количество квартир в подъезде: {apartmentAmount / entranceAmount}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("\nОшибка: Деление на ноль");
            }
        }
    }
}
