using Avro;
using Avro.Specific;
using System;

namespace test
{
    public class TKafkaSC : ISpecificRecord
    {
        public int AId { get; set; }
        public int? ASeqNum { get; set; }
        public SystemControlCode? ASystemControlCode { get; set; }
        public int? ATimestamp { get; set; }
        public DateTime? AFptsDateTime { get; set; }
        public DateTime? ACreatedDateTime { get; set; }
        public int? ASeqNum1 { get; set; }
        public int? ASeqNum2 { get; set; }
        public int? ASeqNum3 { get; set; }
        public int? ASeqNum4 { get; set; }
        public int? ASeqNum5 { get; set; }
        public int? ASeqNum6 { get; set; }
        public int? ASeqNum7 { get; set; }
        public int? ASeqNum8 { get; set; }
        public int? ASeqNum9 { get; set; }
        public int? ASeqNum10 { get; set; }
        public int? ASeqNum11 { get; set; }
        public int? ASeqNum12 { get; set; }
        public int? ASeqNum13 { get; set; }


        public static Schema _SCHEMA = Schema.Parse(@"{
                            ""type"":""record"",
                            ""name"":""TKafkaSC"",""namespace"":""test"",
                            ""fields"":[
                            {""name"":""ASEQNUM"",""type"":[""int"",""null""]},
                            {""name"":""ASYSTEMCONTROLCODE"",""type"":[{
                            ""type"":""enum"",
                            ""name"":""SystemControlCode"",
                            ""namespace"":""test"",
                            ""symbols"":[""F"",""G"",""I"",""J"",""K"",""O"",""P""]},
                            ""null""]},
                            {""name"":""ATIMESTAMP"",""type"":[""int"",""null""]},
                            {""name"":""AFPTSDATETIME"",""type"":[""string"",""null""]},
                            {""name"":""ACREATEDDATETIME"",""type"":[""string"",""null""]},
                            {""name"":""ASEQNUM1"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM2"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM3"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM4"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM5"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM6"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM7"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM8"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM9"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM10"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM11"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM12"",""type"":[""int"",""null""]},
                            {""name"":""ASEQNUM13"",""type"":[""int"",""null""]}]}");
        public Schema Schema => _SCHEMA;

        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return ASeqNum;
                case 1: return ASystemControlCode;
                case 2: return ATimestamp;
                case 3: return AFptsDateTime?.ToString("yyyyMMdd HH:mm:ss.FFF"); //yyyy-MM-dd HH:mm:ss.FFF
                case 4: return ACreatedDateTime?.ToString("yyyyMMdd HH:mm:ss.FFF");
                case 5: return ASeqNum1;
                case 6: return ASeqNum2;
                case 7: return ASeqNum3;
                case 8: return ASeqNum4;
                case 9: return ASeqNum5;
                case 10: return ASeqNum6;
                case 11: return ASeqNum7;
                case 12: return ASeqNum8;
                case 13: return ASeqNum9;
                case 14: return ASeqNum10;
                case 15: return ASeqNum11;
                case 16: return ASeqNum12;
                case 17: return ASeqNum13;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            }
        }

        public void Put(int fieldPos, object fieldValue)
        {
            throw new NotImplementedException();
        }

        public enum SystemControlCode
        {
            F,
            G,
            I,
            J,
            K,
            O,
            P
        }
    }
}
