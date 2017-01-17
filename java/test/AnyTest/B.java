public class B extends Main {
    String variable = null;
    //String variable;

    public B(){
        System.out.println("variable value = " + variable);
    }

    protected void printVariable(){
        variable = "variable is initialized in B Class";
    }
}