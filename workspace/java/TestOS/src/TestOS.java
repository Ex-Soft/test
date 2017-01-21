public class TestOS {
	public static void main(String[] args) {
		System.out.print("os.name: ");
		System.out.println(System.getProperty("os.name"));
		
		System.out.print("java.library.path: ");
		System.out.println(System.getProperty("java.library.path"));
		
		System.out.println("System.getProperties()");
		System.getProperties().list(System.out);
	}
}
