using System;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using TestTypeFromStringConfiguration;

namespace ProducerResolverBlueprint
{
    internal class Program
    {
        static void Main()
        {
            var serviceCollection = new ServiceCollection();

            var openDataTopicProducerConfiguration = new ProtonProducerConfig
            {
                ProducerName = "CareAdjustmentsService",
                DlqUrl = "Some Url",
                Topic = "OpenDataTopicName",
                KafkaTypes = new[] {typeof(SpecificRecord1), typeof(SpecificRecord2)}
            };

            var tokenizedTopicProducerConfiguration = new ProtonProducerConfig
            {
                ProducerName = "CareAdjustmentsService",
                DlqUrl = "Some Url",
                Topic = "TokenizedTopicName",
                KafkaTypes = new[] { typeof(SpecificRecord1), typeof(SpecificRecord2) }
            };

            var producerConfigurations = new[]
            {
                openDataTopicProducerConfiguration,
                tokenizedTopicProducerConfiguration
            };

            serviceCollection.AddProtonProducer(producerConfigurations);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var conditionalServiceResolver = serviceProvider.GetRequiredService<ConditionalServiceResolver<ProducerResolutionContext, IBusinessEvent, IProtonProducer>> ();

            var openDataTopicTopicSpecificRecord1BusinessEvent = new BusinessEvent
            {
                Topic = openDataTopicProducerConfiguration.Topic,
                Value = new SpecificRecord1()
            };

            var tokenizedTopicSpecificRecord1BusinessEvent = new BusinessEvent
            {
                Topic = tokenizedTopicProducerConfiguration.Topic,
                Value = new SpecificRecord1()
            };

            var openDataTopicSpecificRecord2BusinessEvent = new BusinessEvent
            {
                Topic = openDataTopicProducerConfiguration.Topic,
                Value = new SpecificRecord2()
            };

            var tokenizedTopicSpecificRecord2BusinessEvent = new BusinessEvent
            {
                Topic = tokenizedTopicProducerConfiguration.Topic,
                Value = new SpecificRecord2()
            };

            var businessEvents = new[]
            {
                tokenizedTopicSpecificRecord1BusinessEvent,
                openDataTopicTopicSpecificRecord1BusinessEvent,
                tokenizedTopicSpecificRecord2BusinessEvent,
                openDataTopicSpecificRecord2BusinessEvent
            };

            foreach (var businessEvent in businessEvents)
            {
                var producer = conditionalServiceResolver.Resolve(businessEvent).SingleOrDefault();
                if (producer == null) throw new Exception("Producer not resolved.");
                producer.Produce(businessEvent.Value);
            }

            var allServices = conditionalServiceResolver.List().ToArray();
        }
    }
}
