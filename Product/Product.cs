using Avro;
using Avro.Specific;
using System;
using System.IO;

namespace ProductLibrary
{
    public class Product : ISpecificRecord
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string NAME { get; set; }
        public float PRICE { get; set; }
        public int QUANTITY { get; set; }
        public DateTime CREATED_AT { get; set; } = DateTime.Now;

        public static Schema _SCHEMA = Avro.Schema.Parse(File.ReadAllText(@"C:/Workspace/Schemas/product.json"));
        public virtual Schema Schema
        {
            get
            {
                return Product._SCHEMA;
            }
        }

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.ID;
                case 1: return this.NAME;
                case 2: return this.PRICE;
                case 3: return this.QUANTITY;
                case 4: return this.CREATED_AT.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }

        public void Put(int fieldPos, object fieldValue)
        {
            switch (fieldPos)
            {
                case 0: this.ID = (String)fieldValue; break;
                case 1: this.NAME = (String)fieldValue; break;
                case 2: this.PRICE = (float)fieldValue; break;
                case 3: this.QUANTITY = (int)fieldValue; break;
                case 4: this.CREATED_AT = (DateTime)fieldValue; break;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
            };
        }
    }
    /*public class Product
    {
        public string ID { get; set; } = Guid.NewGuid().ToString();
        public string NAME { get; set; }
        public float PRICE { get; set; }
        public int QUANTITY { get; set; }
        public string CREATED_AT { get; set; } = DateTime.Now.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
    }  //"dd-MMM-yy hh.mm.ss.FFFFFFF tt"

    public class AllProducts
    {
        public static Dictionary<string, Product> dictionaryOfProducts = new Dictionary<string, Product>();
    }*/
}
