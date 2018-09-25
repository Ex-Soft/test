import java.util.*;

public class TestReflection {
    public static void main(String[] args)
    {
        Class testClass = TestClass.class;
        String className = testClass.getName();
        System.out.println(className);
        TestClass tc1 = (TestClass)Class.forName(className);

        Date dt1 = new Date();
        Class dateClass = dt1.getClass();
        System.out.println(className = dateClass.getName());
        Date dt2 = (Date)Class.forName(className);

        Class doubleArrayClass = Double[].class;
        System.out.println(className = doubleArrayClass.getName());
    }
}
