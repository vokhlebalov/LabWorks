using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Manufactures
{
    public class WorkShop : ShopFloor
    {
        int productsPerDay;
        int ProductsPerDay
        {
            get { return productsPerDay; }
            set
            {
                productsPerDay = value > 0 ? value : 1;
            }
        }

        public override string Type => "Мастерская";

        public WorkShop(string name, string city, int year, int staffCount, string product, int productsPerDay) : base(name, city, year, staffCount, product)
        {
            ProductsPerDay = productsPerDay;
        }

        public WorkShop() : base()
        {
            ProductsPerDay = randomizer.Next(200);
        }

        public override void Show()
        {
            Console.WriteLine(this);
        }

        //public override int CompareTo(object obj)
        //{
        //    int value = base.CompareTo(obj);
        //    WorkShop newObj = obj as WorkShop;
        //    if (newObj != null)
        //    {
        //        if (value == 0)
        //        {
        //            return ProductsPerDay.CompareTo(newObj.ProductsPerDay);
        //        }
        //        return value;
        //    }
        //    return 1;
        //}

        public override Manufacture GetBase()
        {
            return new ShopFloor(Name, City, Year, StaffCount, Product);
        }
        public override bool Equals(object obj)
        {
            bool value =  base.Equals(obj);
            WorkShop newObj = obj as WorkShop;
            if (newObj != null)
            {
                if (value)
                {
                    return ProductsPerDay.Equals(newObj.ProductsPerDay);
                }
            }
            return false;
        }

        public override object Clone()
        {
            return new WorkShop(Name, City, Year, StaffCount, Product, ProductsPerDay);
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() + productsPerDay * 1000000000) % int.MaxValue;
        }

        public override string ToString()
        {
            return base.ToString() + ", количество производимой продукции : " + ProductsPerDay;
        }
    }
}
