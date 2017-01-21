public class HelloJNI {
	   static {
		   try
		   {
			   System.loadLibrary("hello");
		   }
		   catch (UnsatisfiedLinkError e)
		   {
			   System.err.println("Native code library failed to load.\n" + e);
			   System.exit(1);
		   }
	   }
	 
	   private native void sayHello();
	 
	   public static void main(String[] args) {
		   new HelloJNI().sayHello();
	   }
}