using Avro;
using Avro.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductLibrary
{
    public class ProductUpdate : ISpecificRecord
    {
        public string ID { get; set; }
        public int QUANTITY { get; set; }
        public DateTime CREATED_AT { get; set; } = DateTime.Now;

        public static Schema _SCHEMA = Schema.Parse(@"{
                                        ""type"":""record"",
                                        ""name"":""ProductUpdate"",
                                        ""namespace"":""Confluent.Kafka.ProductUpdate.AvroSpecific"",
                                        ""fields"":[
	                                        {""name"":""ID"", ""type"":""string""},
	                                        {""name"":""QUANTITY"",""type"":""int""},
	                                        {""name"":""CREATED_AT"",""type"":""string""}
                                        ]}");
        public Schema Schema => _SCHEMA;

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.ID;
                case 1: return this.QUANTITY;
                case 2: return this.CREATED_AT.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }

        public void Put(int fieldPos, object fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}
