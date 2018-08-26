public class Base
{
    public static int
        staticInt1,
        staticInt2 = 2,
        staticInt3 = 3;

    private String
        str1,
        str2 = "str2",
        str3 = "str3";

    protected String
        str4,
        str5 = "str5",
        str6 = "str6";

    private double
        double1,
        double2 = 2,
        double3 = 3;

    private boolean
        boolean1,
        boolean2 = true,
        boolean3 = true;

    static
    {
        staticInt3 = 33;
    }

    {
        str3 = "str3str3";
        str6 = "str6str6";
        double3 = 33;
        boolean3 = false;
    }

    {
        str3 = "str3str3str3";
        str6 = "str6str6str6";
        double3 = 333;
        boolean3 = true;
    }

    public Base(String s1, double d1, boolean b1)
    {
        this(s1, "ctor.str2", "ctor.str3", "ctor.str4", "ctor.str5", "ctor.str6", d1, 2222, 3333, b1, false, false);
    }

    public Base(String s1, String s2, String s3, String s4, String s5, String s6, double d1, double d2, double d3, boolean b1, boolean b2, boolean b3)
    {
        System.out.printf("b4 str1:\"%s\", str2:\"%s\", str3:\"%s\", str4:\"%s\", str5:\"%s\", str6:\"%s\", d1:%f, d2:%f, d3:%f, b1:%b, b2:%b, b3:%b\n", str1, str2, str3, str4, str5, str6, double1, double2, double3, boolean1, boolean2, boolean3);

        str1 = s1;
        str2 = s2;
        str3 = s3;
        str4 = s4;
        str5 = s5;
        str6 = s6;
        double1 = d1;
        double2 = d2;
        double3 = d3;
        boolean1 = b1;
        boolean2 = b2;
        boolean3 = b3;

        System.out.printf("after str1:\"%s\", str2:\"%s\", str3:\"%s\", str4:\"%s\", str5:\"%s\", str6:\"%s\", d1:%f, d2:%f, d3:%f, b1:%b, b2:%b, b3:%b\n", str1, str2, str3, str4, str5, str6, double1, double2, double3, boolean1, boolean2, boolean3);
    }

    public String getStr1()
    {
        return str1;
    }

    public String getStr2()
    {
        return str2;
    }

    public String getStr3()
    {
        return str3;
    }

    public double getDouble1()
    {
        return double1;
    }

    public double getDouble2()
    {
        return double2;
    }

    public double getDouble3()
    {
        return double3;
    }

    public boolean getBoolean1()
    {
        return boolean1;
    }

    public boolean getBoolean2()
    {
        return boolean2;
    }

    public boolean getBoolean3()
    {
        return boolean3;
    }
}
