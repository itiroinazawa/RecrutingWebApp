using System.Collections.Generic;

namespace RecrutingWebApp.Parser.Base
{
    public abstract class BaseParser<T, T2>
    {
        public List<T2> ParseList(List<T> list)
        {
            List<T2> newList = new List<T2>();

            if (list != null)
            {
                foreach (var item in list)
                {
                    newList.Add(ParseItem(item));
                }
            }

            return newList;
        }

        public abstract T2 ParseItem(T item);
    }
}
