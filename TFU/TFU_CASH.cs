using Avro;
using Avro.Specific;
using System;
using System.IO;

namespace TFU
{
    public class TFU_CASH : TFU_DATETIME, ISpecificRecord
    {
        public string AClientCode { get; set; }
        public long? ADFPTS { get; set; }
        public long? ADVSD { get; set; }
        public long? ADFPTSHold { get; set; }
        public long? ADVSDHold { get; set; }
        public int? AUnpaidVM { get; set; }
        public int? AOthersCash { get; set; }
        public int? ACS_DFPTS_Hold { get; set; }
        public int? ADFPTS_CS_Hold { get; set; }
        public int? ADebit { get; set; }
        public int? AUncollectedInt { get; set; }
        public DateTime? AModifiedDTE { get; set; }
        public string? AModifiedBY { get; set; }
        public int? AFeePosition { get; set; }
        public int? AFeeManageDVSD { get; set; }
        public int? ADVSDRequire { get; set; }

        public static Schema _SCHEMA = Avro.Schema.Parse(File.ReadAllText(@"C:/Workspace/Schemas/tfu_cash.json"));

        public Schema Schema => _SCHEMA;

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return AClientCode;
                case 1: return ADFPTS;
                case 2: return ADVSD;
                case 3: return ADFPTSHold;
                case 4: return ADVSDHold;
                case 5: return AUnpaidVM;
                case 6: return AOthersCash;
                case 7: return ACS_DFPTS_Hold;
                case 8: return ADFPTS_CS_Hold;
                case 9: return ADebit;
                case 10: return AUncollectedInt;
                case 11: return AModifiedDTE?.ToString("dd-MMM-yy");
                case 12: return AModifiedBY;
                case 13: return AFeePosition;
                case 14: return AFeeManageDVSD;
                case 15: return ADVSDRequire;
                case 16: return ADateTime.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            }
        }

        public void Put(int fieldPos, object fieldValue)
        {
            throw new NotImplementedException();
        }
    }
}
