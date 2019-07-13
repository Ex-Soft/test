public class Main {
    public static void main(String[] args) {
        int
                a = 10,
                b = 0,
                c;

        try {
            try {
                c = a / b;
            } finally {
                throw new IllegalArgumentException();
            }
        } catch(Exception eException) {
            System.out.println(eException.getClass().getName());
        }
    }
}
