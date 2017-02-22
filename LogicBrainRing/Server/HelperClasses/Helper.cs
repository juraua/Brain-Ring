using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LogicBrainRing.Server.HelperClasses
{


    class GenericList<T> : List<T>
    {
         GenericList(IEnumerable<T> collection)
            : base(collection)
        {
        }

        /*Перемешивание списка*/

         void Shuffle()
        {
            var r = new Random();
            var q = this
                .Select(i => new {i, ndx = r.Next()})
                .OrderBy(e => e.ndx)
                .Select(e => e.i);
            var sortedItems = q.ToArray();
            this.Clear();
            this.AddRange(sortedItems);
        }

         static GenericList<T> Shuffle(IEnumerable<T> collection)
        {
            var list = new GenericList<T>(collection);
            list.Shuffle();
            return list;
        }
    }

    public static class Helper
    {
        public static string GetEnumDisplay(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            //Створити окремий клас DisplayAttribute?
            DisplayAttribute[] attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Name;
            else
                return value.ToString();
        }

        //public static T GetEnumValuesByDisplayName<T>(this string enumItem)
        //{
        //    var result = Enum.GetValues(typeof(T)).Cast<T>().ToList();
        //    foreach (var item in result)
        //    {
        //        if (item.GetEnumDisplay() == enumItem)
        //        {
        //            return item;
        //            break;
        //        }
        //    }
        //    return null;
        //}
    }

}
