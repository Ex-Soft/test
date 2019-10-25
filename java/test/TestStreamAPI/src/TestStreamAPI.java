import java.util.ArrayList;
import java.util.stream.Collectors;

public class TestStreamAPI {
    public static void main(String[] args) {
        ArrayList<Rectangle> listOfRectangle1 = new ArrayList<Rectangle>() {
            {
                add(new Rectangle(1, 2));
                add(new Rectangle(3, 4));
                add(new Rectangle(5, 6));
                add(new Rectangle(7, 2));
                add(new Rectangle(8, 2));
                add(new Rectangle(1, 2));
            }
        },
                listOfRectangle2,
                listOfRectangle3,
                listOfRectangle4;

        listOfRectangle2 = listOfRectangle1.stream().filter(item -> item.getWidth() == 2).distinct().collect(Collectors.toCollection(ArrayList::new));
        //listOfRectangle3 = listOfRectangle1.stream().filter(item -> item.getWidth() == 2).map(WrapperRectangle::new).distinct().map(WrapperRectangle::unwrap).collect(Collectors.toCollection(ArrayList::new));
        //listOfRectangle4 = listOfRectangle1.stream().map(WrapperRectangle::new).map(WrapperRectangle::unwrap).collect(Collectors.toCollection(ArrayList::new));
    }
}
