using System;

namespace AbstractFactoryGeneric
{
    public interface IAbstractFactory
    {
        T Create<T>();

        bool IsProduct<T>();
    }

    public interface IFactoryMethod<T>
    {
        T Create();
    }

    public abstract class AbstractFactory : IAbstractFactory
    {
        public T Create<T>()
        {
            IFactoryMethod<T> factoryMethod;

            if ((factoryMethod = this as IFactoryMethod<T>) != null)
            {
                return factoryMethod.Create();
            }

            return default(T);
        }

        public bool IsProduct<T>()
        {
            return this is IFactoryMethod<T>;
        }
    }

    public class ConcreteFactory1 : AbstractFactory, IFactoryMethod<ProductA>, IFactoryMethod<ProductB>
    {
        ProductA IFactoryMethod<ProductA>.Create()
        {
            return new ConcreteProductA1();
        }

        ProductB IFactoryMethod<ProductB>.Create()
        {
            return new ConcreteProductB1();
        }
    }

    abstract class ProductA
    {

    }

    abstract class ProductB
    {

    }

    class ConcreteProductA1 : ProductA
    {
        public ConcreteProductA1()
        {
            Console.WriteLine("ConcreteProductA1::ConcreteProductA1()");
        }
    }

    class ConcreteProductB1 : ProductB
    {
        public ConcreteProductB1()
        {
            Console.WriteLine("ConcreteProductB1::ConcreteProductB1()");
        }
    }

    class Program
    {
        static void Main()
        {
            IAbstractFactory
                factory = new ConcreteFactory1();

            ProductA
                productA;

            if (factory.IsProduct<ProductA>())
                productA = factory.Create<ProductA>();

            ProductB
                productB;

            if (factory.IsProduct<ProductB>())
                productB = factory.Create<ProductB>();
        }
    }
}
