using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufactures
{
    public class Manufacture : IExecutable
    {
        protected static Random randomizer = new Random();
        static readonly string[] NAMES = { "Toyota", "Samsung", "Apple", "HP", "Microsoft", "Panasonic", "Sony", "ArtSpace", "ErichKrause", "Kohinoor", "ASUS", "Простоквашино", "Добрый", "Xiaomi", "Philips", "Gucci", "Armani", "Louis Vouitton", "Supreme"};
        static readonly string[] CITIES = { "Пермь", "Москва", "Лондон", "Чернушка", "Сан-Франциско", "Санкт-Петербург", "Берлин", "Дрезден", "Вена", "Лион", "Милан", "Афины"};
        

        int year;
        int staffCount;

        public virtual string Type { get; } = "Производство";
        public string Name { get; }
        public string City { get; }

        public int Year { 
            get { return year; } 
            set { year = value >= 1900 && value <= DateTime.Now.Year ? value : DateTime.Now.Year; } 
        }

        public int StaffCount
        {
            get { return staffCount; }
            set { staffCount = value > 0 ? value : 1; }
        }

        public Manufacture(string name, string city, int year, int staffCount)
        {
            Name = name;
            City = city;
            Year = year;
            StaffCount = staffCount;
        }

        public Manufacture()
        {
            Name = NAMES[randomizer.Next(NAMES.Length)];
            City = CITIES[randomizer.Next(CITIES.Length)];
            Year = randomizer.Next(1900, DateTime.Now.Year);
            StaffCount = randomizer.Next(1001);
        }

        public virtual void Show()
        {
            Console.WriteLine(this);
        }

        public virtual object Clone()
        {
            return new Manufacture(Name, City, Year, StaffCount);
        }

        public Manufacture ShallowCopy()
        {
            return (Manufacture)MemberwiseClone();
        }

        public virtual int CompareTo(object obj)
        {
            if (!(obj is Manufacture newObj))
                return 1;

            if (this is WorkShop && !(newObj is WorkShop))
                return 1;
            if (!(this is WorkShop) && newObj is WorkShop)
                return -1;

            if (this is ShopFloor && !(newObj is ShopFloor))
                return 1;
            if (!(this is ShopFloor) && newObj is ShopFloor)
                return -1;

            if (this is Factory && !(newObj is Factory))
                return 1;
            if (!(this is Factory) && newObj is Factory)
                return -1;

            if (Equals(newObj)) return 0;

            int value = Name.CompareTo(newObj.Name);
            if (value != 0) return value;

            value = City.CompareTo(newObj.City);
            if (value != 0) return value;

            value = Year.CompareTo(newObj.Year);
            if (value != 0) return value;

            value = StaffCount.CompareTo(newObj.StaffCount);
            if (value != 0) return value;

            return value;
        }

        public override string ToString()
        {
            return $" {Type} \"{Name}\", {City}, {Year}-{DateTime.Now.Year}гг., количество сотрудников: {StaffCount}";
        }

        public override bool Equals(object obj)
        {
            Manufacture newObj = obj as Manufacture;
            if (newObj != null)
            {
                if (GetHashCode() == newObj.GetHashCode())
                    return newObj.Name.Equals(Name) && newObj.Year.Equals(Year) && newObj.StaffCount.Equals(StaffCount) && newObj.City.Equals(City);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return (Year + Name.Length * 1000 + StaffCount * 100000 + City.Length * 10000000) % int.MaxValue;
        }

    }
}
