using Avro;
using Avro.Specific;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFU
{
    public class TFU_POSITIONBALANCE : TFU_DATETIME, ISpecificRecord
    {
        public string AClientCode { get; set; }
        public string AStockCode { get; set; }
        public int AOpenBalance { get; set; }
        public int APendingSell { get; set; }
        public int APendingBuy { get; set; }
        public int AHNXConfirmBuy { get; set; }
        public int AHNXConfirmSell { get; set; }
        public int ATradedInDay { get; set; }
        public int AAvailQty { get; set; }
        public int ATradedLong { get; set; }
        public int ATradedShort { get; set; }
        public int? AVMOpenDay { get; set; }
        public int? AVMInTraDay { get; set; }

        public static Schema _SCHEMA = Avro.Schema.Parse(File.ReadAllText(@"C:/Workspace/Schemas/tfu_positionbalance.json"));

        public Schema Schema => _SCHEMA;

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.AClientCode;
                case 1: return this.AStockCode;
                case 2: return this.AOpenBalance;
                case 3: return this.APendingSell;
                case 4: return this.APendingBuy;
                case 5: return this.AHNXConfirmBuy;
                case 6: return this.AHNXConfirmSell;
                case 7: return this.ATradedInDay;
                case 8: return this.AAvailQty;
                case 9: return this.ATradedLong;
                case 10: return this.ATradedShort;
                case 11: return this.AVMOpenDay;
                case 12: return this.AVMInTraDay;
                case 13: return this.ADateTime.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }

        public void Put(int fieldPos, object fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}
