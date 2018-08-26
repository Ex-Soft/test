public class TestInitialization
{
    public static void main(String[] args)
    {
        Base
            b1 = new Base("1", "2", "3", "4", "5", "6",1.1, 2.2, 3.3, true, false, true),
            b2 = new Base("1", 1, true);

        Derived
            d1 = new Derived();
    }
}
