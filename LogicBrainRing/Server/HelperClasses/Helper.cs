using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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


}
