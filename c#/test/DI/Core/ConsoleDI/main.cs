using System;
using System.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();

            services.AddTransient<IParam1, Param1>();
            services.AddTransient<IParam2, Param2>();
            services.AddTransient<IParam3, Param3>();

            services.AddTransient<ICaller, Caller>();
            services.AddTransient<ICallerWithParams, CallerWithParams>();

            services.AddTransient(typeof(GenericClass<>), typeof(GenericClass<>));

            services.AddFactory<IRandomNumberGenerator, RandomNumberGenerator>();
            services.AddTransient<IController, Controller>();

            services.AddTransient(typeof(IBusinessEvent<>), typeof(BusinessEvent<>));
            services.AddTransient(typeof(IProducer<>), typeof(Producer<>));
            services.AddTransient<Func<IProducer<ConcreteRecord1>>>(s => () => s.GetRequiredService<IProducer<ConcreteRecord1>>());
            services.AddTransient<Func<IProducer<ConcreteRecord2>>>(s => () => s.GetRequiredService<IProducer<ConcreteRecord2>>());
            services.AddTransient(typeof(ProducerWrapper<>), typeof(ProducerWrapper<>));

            //services.Configure<Params>(@params =>
            //{
            //    @params.Param1 = new Param1();
            //    @params.Param2 = new Param2();
            //    @params.Param3 = new Param3();
            //});

            services.Configure<Params>((@params, provider) =>
            {
                @params.Param1 = provider.GetService<IParam1>();
                @params.Param2 = provider.GetService<IParam2>();
                @params.Param3 = provider.GetService<IParam3>();
            });

            var serviceProvider = services.BuildServiceProvider();

            var caller = serviceProvider.GetService<ICaller>();
            Debug.WriteLine(caller?.GetParams());

            var callerWithParams = serviceProvider.GetService<ICallerWithParams>();
            Debug.WriteLine(callerWithParams?.Params);

            var genericClassInt = serviceProvider.GetService<GenericClass<int>>();
            Debug.WriteLine(genericClassInt);

            var genericClassLong = serviceProvider.GetService<GenericClass<long>>();
            Debug.WriteLine(genericClassLong);

            var controller = serviceProvider.GetService<IController>();
            Debug.WriteLine(controller?.Get());

            var businessEvent1 = serviceProvider.GetService<IBusinessEvent<ConcreteRecord1>>();
            Debug.WriteLine(businessEvent1);

            var businessEvent2 = serviceProvider.GetService<IBusinessEvent<ConcreteRecord2>>();
            Debug.WriteLine(businessEvent2);

            var producer1 = serviceProvider.GetService<IProducer<ConcreteRecord1>>();
            Debug.WriteLine(producer1);

            var producer2 = serviceProvider.GetService<IProducer<ConcreteRecord2>>();
            Debug.WriteLine(producer2);

            var producerWrapper1 = serviceProvider.GetService<ProducerWrapper<ConcreteRecord1>>();
            Debug.WriteLine(producerWrapper1?.Produce(new BusinessEvent<ConcreteRecord1>()));

            var producerWrapper2 = serviceProvider.GetService<ProducerWrapper<ConcreteRecord2>>();
            Debug.WriteLine(producerWrapper2?.Produce(new BusinessEvent<ConcreteRecord2>()));
        }
    }
}
