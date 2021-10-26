using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using TestTypeFromStringConfiguration;

namespace ProducerResolverBlueprint
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProtonProducer(this IServiceCollection serviceCollection, IEnumerable<ProtonProducerConfig> producerConfigurations)
        {
            serviceCollection.Add(new ServiceDescriptor(typeof(IProtonProducer<>), typeof(ProtonProducer<>), ServiceLifetime.Transient));

            serviceCollection.AddSingleton<ConditionalServiceResolver<ProducerResolutionContext, IBusinessEvent, IProtonProducer>>();

            serviceCollection.AddSingleton<Func<IBusinessEvent, ProducerResolutionContext, bool>>(
                _ => (businessEvent, context) =>
                    businessEvent?.Topic == context.Topic &&
                    businessEvent?.Value?.GetType() == context.SpecificRecordType);


            foreach (var producerConfig in producerConfigurations)
            {
                foreach (var kafkaType in producerConfig.KafkaTypes)
                {
                    serviceCollection.Add(ServiceDescriptor.Transient(sp =>
                    {
                        var producer = (IProtonProducer)sp.GetService(typeof(IProtonProducer<>).MakeGenericType(kafkaType));

                        producer.Configure(producerConfig);

                        return new ServiceResolutionContext<ProducerResolutionContext, IProtonProducer>(
                            new ProducerResolutionContext
                            {
                                Topic = producerConfig.Topic,
                                SpecificRecordType = kafkaType
                            },
                            producer);
                    }));
                }
            }
        }
    }
}
