namespace OrderedMultiDictionaryTask
{
    using System;
    using System.Linq;

    public class Article
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public byte[] Barcode { get; set; }
    }
}
