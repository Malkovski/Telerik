namespace OrderedMultiDictionaryTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class FastRangeSearchDataStructure
    {
        public readonly Article article;
        public readonly OrderedMultiDictionary<decimal, Article> data; 

       public FastRangeSearchDataStructure()
       {
           this.article = new Article();
           this.data = new OrderedMultiDictionary<decimal, Article>(false);
       }

        public void Add(decimal key, Article value)
        {
            this.data.Add(key, value);
        }

        public void Update(Article element)
        {

        }

        public void Delete(Article element)
        {

        }

        public IEnumerable<KeyValuePair<decimal, ICollection<Article>>> FindRange(decimal from, decimal to)
        {
           return this.data.FindAll(x => (x.Key >= from && x.Key <= to));
        }
    }
}
