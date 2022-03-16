using Avro;
using Avro.Specific;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace TFU
{
    public class TFU_CLIENT_POSITIONLIMIT : TFU_DATETIME, ISpecificRecord
    {
        public string AClientCode { get; set; }
        public string AStockCode { get; set; }
        public string ABasicCode { get; set; }
        public int APositionLimit { get; set; }
        public int? ALimit { get; set; }
        public int? ABasicType { get; set; }

        public static Schema _SCHEMA = Avro.Schema.Parse(File.ReadAllText(@"C:/Workspace/Schemas/tfu_client_positionlimit.json"));

        public virtual Schema Schema
        {
            get
            {
                return _SCHEMA;
            }
        }
        public enum BasicType
        {
            Index = 1,
            Bond = 2
        }

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.AClientCode;
                case 1: return this.AStockCode;
                case 2: return this.ABasicCode;
                case 3: return this.APositionLimit;
                case 4: return this.ALimit;
                case 5: return this.ABasicType;
                case 6: return this.ADateTime.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }
            
        public void Put(int fieldPos, object fieldValue)
        {
        }
    }
}
