import package1.*;
import package2.Class2;
import package2.package3.*;

public class TestPackages
{
	public static void main(String[] args)
	{
		Class1.printInfo();
		Class2.printInfo();
		Class3.printInfo();
		package4.Class1.printInfo();
	}
}

