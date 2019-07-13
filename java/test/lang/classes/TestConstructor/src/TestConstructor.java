public class TestConstructor
{
    public static void main(String[] args)
    {
        Base
            b1 = new Base(),
            b2 = new Base(3, 4);

        b1.Base(1, 2);

        System.out.print(b1.int1);
        System.out.print(b1.int2);
        System.out.print(b2.int1);
        System.out.print(b2.int2);
    }
}
