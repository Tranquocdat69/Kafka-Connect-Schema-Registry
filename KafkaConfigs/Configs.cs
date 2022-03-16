using Confluent.Kafka;
using Confluent.SchemaRegistry;
using ProductLibrary;
using System;
using System.Collections.Generic;
using System.Net;

namespace KafkaConfigs
{
    public class Configs
    {

        public static ProducerConfig producerConfig = new ProducerConfig
        {
            BootstrapServers = "localhost:9092",
            ClientId = Dns.GetHostName()
        };

        public static SchemaRegistryConfig registryConfig = new SchemaRegistryConfig()
        {
            Url = "http://localhost:8081"
        };

        /* public static ConsumerConfig consumerConfig = new ConsumerConfig
        {
            BootstrapServers = "10.26.7.58:9092,10.26.7.59:9092,10.26.7.60:9092",
            GroupId = "consume-message-oracle-source-product-v1",
            AutoOffsetReset = AutoOffsetReset.Earliest
        };*/
    }
}
