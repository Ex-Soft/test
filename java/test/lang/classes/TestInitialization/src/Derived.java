public class Derived extends Base
{
    {
        str4 = "derived.str4str4str4";
        str5 = "derived.str5str5str5";
        str6 = "derived.str6str6str6";
    }

    public Derived()
    {
        this("derived.str1", 9, true);
    }

    public Derived(String s1, double d1, boolean b1)
    {
        this(s1, "derived.str2", "derived.str3", "derived.str4", "derived.str5", "derived.str6", d1, 8, 7, b1, false, false);
    }

    public Derived(String s1, String s2, String s3, String s4, String s5, String s6, double d1, double d2, double d3, boolean b1, boolean b2, boolean b3)
    {
        super(s1, s2, s3, s4, s5, s6, d1, d2, d3, b1, b2, b3);

        System.out.printf("after str1:\"%s\", str2:\"%s\", str3:\"%s\", str4:\"%s\", str5:\"%s\", str6:\"%s\", d1:%f, d2:%f, d3:%f, b1:%b, b2:%b, b3:%b\n", getStr1(), getStr2(), getStr3(), str4, str5, str6, getDouble1(), getDouble2(), getDouble3(), getBoolean1(), getBoolean2(), getBoolean3());
    }
}
