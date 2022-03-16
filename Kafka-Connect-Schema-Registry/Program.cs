using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
using Confluent.SchemaRegistry;
using KafkaConfigs;
using System.Diagnostics;
using Confluent.SchemaRegistry.Serdes;
using System.Threading;
using TFU;
using SolTechnology.Avro;
using test;
using static test.TKafkaSC;
using ProductLibrary;
using static TFU.TFU_CLIENT_POSITIONLIMIT;

namespace Kafka_Connect_Schema_Registry
{
    class Program
    {
        /// <summary>
        /// cached schema when publish message to topic kafka
        /// </summary>
        public static CachedSchemaRegistryClient schemaRegistry = new CachedSchemaRegistryClient(Configs.registryConfig);

        /// <summary>
        /// set up producer builder with Avro Schema (sync serialize) 
        /// </summary>
        public static ProducerBuilder<Null, TFU_CLIENT_POSITIONLIMIT> builder = new ProducerBuilder<Null, TFU_CLIENT_POSITIONLIMIT>(Configs.producerConfig)
            .SetValueSerializer(new AvroSerializer<TFU_CLIENT_POSITIONLIMIT>(schemaRegistry).AsSyncOverAsync());

        public static IProducer<Null, TFU_CLIENT_POSITIONLIMIT> producer = builder.Build();

        static void Main(string[] args)
        {
            /*var tfu = new TFU_TRANSACTIONLOG
            {
                ATranId = i,
                AOrderId = i,
                AClientCode = "demo " + i,
                AStockCode = "demo " + i,
                AExchange = "demo " + i,
                ABuySell = "B",
                AOrderType = "demo " + i,
                AQuantity = i,
                APrice = i,
                APriceType = "demo " + i,
                ATradingAccount = "demo " + i,
                APlacedBy = "demo " + i,
                AProductType = "demo " + i,
                AMarketSegment = "demo " + i,
                ACancelFlag = (int)AcceptAction.Accepted,
                AModifyFlag = (int)AcceptAction.Denied,
                ALastTradedTime = DateTime.Now,
                AOrigOrderId = i,
                ASource = "demo " + i,
                ADateTime = DateTime.Now,
                ALatestPrice = i,
                AQuantityMax = i,
                ACallMargin_Order = null,
                AIsExpired = null,
                ALastestStatus = null,
                ARemainQty = null,
                AConditionType = null,
                AMaxAid = null
            };*/

            /*var tfu = new TFU_CLIENT_POSITIONLIMIT
            {
                AClientCode = "demo " + 0,
                AStockCode = "demo " + i,
                ABasicCode = "demo " + i,
                APositionLimit = 9999,
                ALimit = 9999,
                ABasicType = (int)BasicType.Index,
                ADateTime = DateTime.Now
            };*/

            /*var tfu = new TFU_CASH
            {
                AClientCode = "demo "+0,
                ADFPTS = i,
                ADVSD = i,
                ADFPTSHold = i,
                ADVSDHold = i,
                AUnpaidVM = i,
                AOthersCash = i,
                ACS_DFPTS_Hold = i,
                ADFPTS_CS_Hold = i,
                ADebit = i,
                AUncollectedInt = i,
                AModifiedDTE=DateTime.Now,
                AModifiedBY="DATTQ "+i,
                AFeePosition=i,
                AFeeManageDVSD=i,
                ADVSDRequire=i,
                ADateTime=DateTime.Now
            };*/

            /*var tfu = new Product
            {
                NAME = "demo " + i,
                PRICE = i,
                QUANTITY = i
            };*/

            /*var tfu = new TFU_POSITIONBALANCE
            {
                AClientCode = "demo " + i,
                AStockCode = "demo " + i,
                AOpenBalance = i,
                APendingSell = i,
                APendingBuy = i,
                AHNXConfirmBuy = i,
                AHNXConfirmSell = i,
                ATradedInDay = i,
                AAvailQty = i,
                ATradedLong = i,
                ATradedShort = i,
                AVMOpenDay = i,
                AVMInTraDay = i,
                ADateTime = DateTime.Now
            };*/
            /*var tfu = new TKafkaSC
            {
                AId = i,
                ASeqNum = i,
                ASystemControlCode = SystemControlCode.I,
                ATimestamp = i,
                AFptsDateTime = DateTime.Now,
                ACreatedDateTime = DateTime.Now
            };*/

            /*var tfu = new ProductUpdate
            {
                ID = "87cb6f24-b934-452e-8d3d-602831ff9199",
                QUANTITY = 0
            };*/

            /*var tfu = new TKafkaSC
            {
                ASeqNum = i,
                ASystemControlCode = SystemControlCode.I,
                ATimestamp = i,
                AFptsDateTime = DateTime.Now,
                ACreatedDateTime = DateTime.Now,
                ASeqNum1 = i,
                ASeqNum2 = i,
                ASeqNum3 = i,
                ASeqNum4 = i,
                ASeqNum5 = i,
                ASeqNum6 = i,
                ASeqNum7 = i,
                ASeqNum8 = i,
                ASeqNum9 = i,
                ASeqNum10 = i,
                ASeqNum11 = i,
                ASeqNum12 = i,
                ASeqNum13 = i
            };*/


            Publish("TFU_CLIENT_POSITIONLIMIT", 10);

            // genarate schema from class
            // string schema = AvroConvert.GenerateSchema(typeof(TFU_CLIENT_POSITIONLIMIT));
            // Console.WriteLine(schema.ToString());
        }


        /// <summary>
        /// publish message to topic kafka
        /// </summary>
        /// <param name="topic">topic name</param>
        /// <param name="size">max size of for loop</param>
        public static void Publish(string topic, int size)
        {
            var s = size-1;
            var autoReset = new AutoResetEvent(false);
            var deliveryHandler = new Action<DeliveryReport<Null, TFU_CLIENT_POSITIONLIMIT>>((report) =>
            {
                    if(--s == 0)
                    {
                        autoReset.Set();
                    }
            });

            // message mồi
            var bait = new TFU_CLIENT_POSITIONLIMIT
            {
                AClientCode = "demo " + 0,
                AStockCode = "demo " + 0,
                ABasicCode = "demo " + 0,
                APositionLimit = 0,
                ALimit = 0,
                ABasicType = (int)BasicType.Index,
                ADateTime = DateTime.Now
            };
            producer.ProduceAsync(topic, new Message<Null, TFU_CLIENT_POSITIONLIMIT>
            {
                Value = bait
            }).Wait();

            Stopwatch stopwatch = new();
            stopwatch.Start();
            for (var i = 1; i < size; i++)
            {
                var tfu = new TFU_CLIENT_POSITIONLIMIT
                {
                    AClientCode = "demo " + i,
                    AStockCode = "demo " + i,
                    ABasicCode = "demo " + i,
                    APositionLimit = i,
                    ALimit = i,
                    ABasicType = (int)BasicType.Index,
                    ADateTime = DateTime.Now
                };
                try
                {
                    producer.Produce(topic, new Message<Null, TFU_CLIENT_POSITIONLIMIT>
                    {
                        Value = tfu
                    }, deliveryHandler);
                }
                catch (Exception ex)
                {
                    producer.Poll(TimeSpan.FromSeconds(1));
                    i--;
                }
            }
            autoReset.WaitOne();
            stopwatch.Stop();

            Console.WriteLine($"Total miliseconds: {stopwatch.ElapsedMilliseconds}");
            producer.Flush();
        }
    }
}
