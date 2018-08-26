public class TestClass {
    public static void tripleValue(double x)
    {
        x = 3 * x;
    }

    public static void tripleSalary(Employee x)
    {
        x.raiseSalary(200);
    }

    public static void swap(Employee x, Employee y)
    {
        Employee temp = x;
        x = y;
        y = temp;
    }
}
