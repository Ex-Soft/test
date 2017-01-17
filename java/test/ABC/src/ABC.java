public class ABC {
	public static void main(String[] args)
    {
		System.out.println("Hello, world.");
		
		for(int i=0; i<args.length; ++i)
		    System.out.println("Arg["+i+"]=\""+args[i]+"\""); 
    }
}
