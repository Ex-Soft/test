import java.util.*;

public class TestParams {
    public static void main(String[] args)
    {
        Employee
            employee1 = new Employee("1st", 100, 2018, 8, 26),
            employee2 = new Employee("2nd", 200, 2008, 8, 26);

        Date d = employee1.getHireDay();
        double tenYearsInMilliSeconds = 10 * 365.25 * 24 * 60 * 60 * 1000;
        d.setTime(d.getTime() - (long)tenYearsInMilliSeconds);

        double percent = 10;
        TestClass.tripleValue(percent);

        TestClass.tripleSalary(employee1);
        TestClass.triplePublicInt1(employee1);

        TestClass.swap(employee1, employee2);
    }
}
