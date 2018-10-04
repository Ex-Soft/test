import java.util.*;

public class TestReflection {
    public static void main(String[] args)
    {
        try {
            Class _class = TestClass.class;
            String className = _class.getName();
            System.out.println(className);
            _class = Class.forName(className);
            TestClass testClass = (TestClass)Class.forName(className).newInstance();

            Date dt1 = new Date();
            _class = dt1.getClass();
            System.out.println(className = _class.getName());
            _class = Class.forName(className);
            dt1 = (Date)Class.forName(className).newInstance();

            Class doubleArrayClass = Double[].class;
            System.out.println(className = doubleArrayClass.getName());
        }
        catch (Exception e)
        {
            e.printStackTrace();
        }
    }
}
