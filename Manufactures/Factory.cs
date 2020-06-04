using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manufactures
{
    public class Factory : Manufacture
    {
        int affiliatesCounter;

        public override string Type => "Завод";
        int AffiliatesCounter
        {
            get { return affiliatesCounter; }
            set
            {
                affiliatesCounter = value >= 0 ? value : 0;
            }
        }

        public Factory(string name, string city, int year, int staffCount, int affiliatesCounter) : base(name, city, year, staffCount)
        {
            AffiliatesCounter = affiliatesCounter;
        }

        public Factory() : base()
        {
            AffiliatesCounter = randomizer.Next(50);
        }

        public Manufacture GetBase()
        {
            return new Manufacture(Name, City, Year, StaffCount);
        }

        public override void Show()
        {
            Console.WriteLine(this);
        }

        public override bool Equals(object obj)
        {
            bool value = base.Equals(obj);
            if (value)
            {
                if (obj is Factory newObj)
                {
                    return AffiliatesCounter.Equals(newObj.AffiliatesCounter);
                }
            }
            return value;
        }

        public override int GetHashCode()
        {
            return (base.GetHashCode() + AffiliatesCounter * 100000000) % int.MaxValue;
        }

        //public override int CompareTo(object obj)
        //{
        //    int value = base.CompareTo(obj);
        //    if (obj is Factory newObj)
        //    {
        //        if (value == 0)
        //        {
        //            return AffiliatesCounter.CompareTo(newObj.AffiliatesCounter);
        //        }
        //        return value;
        //    }
        //    return 1;
        //}

        public new Factory ShallowCopy()
        {
            return (Factory)MemberwiseClone();
        }

        public override object Clone()
        {
            return new Factory(Name, City, Year, StaffCount, AffiliatesCounter);
        }

        public override string ToString()
        {
            return base.ToString() + ", филиалов в других городах: " + AffiliatesCounter;
        }
    }
}
