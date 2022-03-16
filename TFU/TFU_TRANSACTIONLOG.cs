using Avro;
using Avro.Specific;
using System;
using System.IO;

namespace TFU
{
    public class TFU_TRANSACTIONLOG : ISpecificRecord
    {
        
        public int ATranId { get; set; }
        
        public int AOrderId { get; set; }
        
        public string AClientCode { get; set; }
        
        public string AStockCode { get; set; }
        
        public string AExchange { get; set; }
        
        public string ABuySell { get; set; }
        
        public string AOrderType { get; set; }
        
        public int AQuantity { get; set; }
        
        public double APrice { get; set; }
        
        public string APriceType { get; set; }
        
        public string ATradingAccount { get; set; }
        
        public string APlacedBy { get; set; }
        
        public string AProductType { get; set; }
        
        public string AMarketSegment { get; set; }
        
        public int AModifyFlag { get; set; }
        
        public int ACancelFlag { get; set; }
        
        public DateTime? ALastTradedTime { get; set; }
        
        public int AOrigOrderId { get; set; }
        
        public string ASource { get; set; }
        
        public DateTime ADateTime { get; set; }
        
        public double ALatestPrice { get; set; }
        
        public int AQuantityMax { get; set; }
        
        public int? ACallMargin_Order { get; set; }
        
        public int? AIsExpired { get; set; }
        
        public string? ALastestStatus { get; set; }
        
        public int? ARemainQty { get; set; }
        
        public string? AConditionType { get; set; }
        
        public int? AMaxAid { get; set; }

        public static Schema _SCHEMA = Avro.Schema.Parse(File.ReadAllText(@"C:/Workspace/Schemas/tfu_transactionlog.json"));

        public virtual Schema Schema
        {
            get
            {
                return _SCHEMA;
            }
        }


        public object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this.ATranId;
                case 1: return this.AOrderId;
                case 2: return this.AClientCode;
                case 3: return this.AStockCode;
                case 4: return this.AExchange;
                case 5: return this.ABuySell;
                case 6: return this.AOrderType;
                case 7: return this.AQuantity;
                case 8: return this.APrice;
                case 9: return this.APriceType;
                case 10: return this.ATradingAccount;
                case 11: return this.APlacedBy;
                case 12: return this.AProductType;
                case 13: return this.AMarketSegment;
                case 14: return this.AModifyFlag;
                case 15: return this.ACancelFlag;
                case 16: return this.ALastTradedTime?.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                case 17: return this.AOrigOrderId;
                case 18: return this.ASource;
                case 19: return this.ADateTime.ToString("dd-MMM-yy hh.mm.ss.FFFFFFF tt");
                case 20: return this.ALatestPrice;
                case 21: return this.AQuantityMax;
                case 22: return this.ACallMargin_Order;
                case 23: return this.AIsExpired;
                case 24: return this.ALastestStatus;
                case 25: return this.ARemainQty;
                case 26: return this.AConditionType;
                case 27: return this.AMaxAid;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }

        public void Put(int fieldPos, object fieldValue)
        {
            /*switch (fieldPos)
            {
                case 0: this.ATranId = (int)fieldValue; break;
                case 1: this.AOrderId = (int)fieldValue; break;
                case 2: this.AClientCode = (String)fieldValue; break;
                case 3: this.AStockCode = (String)fieldValue; break;
                case 4: this.AExchange = (String)fieldValue; break;
                case 5: this.ABuySell = (char)fieldValue; break;
                case 6: this.AOrderType = (String)fieldValue; break;
                case 7: this.AQuantity = (int)fieldValue; break;
                case 8: this.APrice = (int)fieldValue; break;
                case 9: this.APriceType = (String)fieldValue; break;
                case 10: this.ATradingAccount = (String)fieldValue; break;
                case 11: this.APlacedBy = (String)fieldValue; break;
                case 12: this.AProductType = (String)fieldValue; break;
                case 13: this.AMarketSegment = (String)fieldValue; break;
                case 14: this.AModifyFlag = (int)fieldValue; break;
                case 15: this.ACancelFlag = (int)fieldValue; break;
                case 16: this.ALastTradedTime = (DateTime)fieldValue; break;
                case 17: this.AOrigOrderId = (int)fieldValue; break;
                case 18: this.ASource = (string)fieldValue; break;
                case 19: this.ADateTime = (DateTime)fieldValue; break;
                case 20: this.ALatestPrice = (double)fieldValue; break;
                case 21: this.AQuantityMax = (int)fieldValue; break;
                case 22: this.ACallMargin_Order = (int)fieldValue; break;
                case 23: this.AIsExpired = (int)fieldValue; break;
                case 24: this.ALastestStatus = (string)fieldValue; break;
                case 25: this.ARemainQty = (int)fieldValue; break;
                case 26: this.AConditionType = (String)fieldValue; break;
                case 27: this.AMaxAid = (int)fieldValue; break;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
            };
            Console.WriteLine(fieldValue);*/
        }
    }

    public enum BuyOrSell
    {
        Buy = 'B',
        Sell = 'S'
    }

    public enum AcceptAction
    {
        Accepted = 0,
        Denied = 1
    }
}
