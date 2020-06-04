using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufactures
{
    public class ShopFloor : Manufacture
    {
        static readonly string[] PRODUCTS = { "Электроника", "Одежда", "Молочные продукты", "Смартфоны", "Автомобили", "Обувь", "Канцелярия", "Соки", "Программное обеспечение", "Ноутбуки", "Телевизоры"};
        public string Product { get; }

        public override string Type => "Цех";

        public ShopFloor(string name, string city, int year, int staffCount, string product) : base(name, city, year, staffCount)
        {
            Product = product;
        }

        public ShopFloor() : base()
        {
            Product = PRODUCTS[randomizer.Next(PRODUCTS.Length)];
        }

        public virtual Manufacture GetBase()
        {
            return new Manufacture(Name, City, Year, StaffCount);
        }

        public override void Show()
        {
            Console.WriteLine(this);
        }

        //public override int CompareTo(object obj)
        //{
        //    int value = base.CompareTo(obj);
        //    ShopFloor newObj = obj as ShopFloor;

        //    if (newObj != null)
        //    {
        //        if (value != 0)
        //        {
        //            return Product.CompareTo(newObj.Product);
        //        }
        //        return value;
        //    }
        //    return 1;
        //}

        public override bool Equals(object obj)
        {
            bool value = base.Equals(obj);
            ShopFloor newObj = obj as ShopFloor;
            if (newObj != null)
            {
                if (value && newObj.GetHashCode() == GetHashCode())
                    return Product.Equals(newObj.Product);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() + Product.Length + 100000000) % int.MaxValue;
        }

        public new ShopFloor ShallowCopy()
        {
            return (ShopFloor)MemberwiseClone();
        }

        public override object Clone()
        {
            return new ShopFloor(Name, City, Year, StaffCount, Product);
        }

        public override string ToString()
        {
            return base.ToString() + ", производимая продукция: " + Product;
        }
    }
}
