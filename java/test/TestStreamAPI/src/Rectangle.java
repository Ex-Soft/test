import java.util.Objects;

public class Rectangle {
    private double
        height,
        width;

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Rectangle rectangle = (Rectangle) o;
        return Double.compare(rectangle.height, height) == 0 &&
                Double.compare(rectangle.width, width) == 0;
    }

    @Override
    public int hashCode() {
        return Objects.hash(height, width);
    }

    public double getHeight() {
        return height;
    }

    public void setHeight(double height) {
        this.height = height;
    }

    public double getWidth() {
        return width;
    }

    public void setWidth(double width) {
        this.width = width;
    }

    public Rectangle(double height, double width) {
        this.height = height;
        this.width = width;
    }
}

/*
class WrapperRectangle {
    private Rectangle r;

    public WrapperRectangle(Rectangle r) {
        this.r = r;
    }

    public Rectangle unwrap() {
        return this.r;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        WrapperRectangle that = (WrapperRectangle) o;
        return Objects.equals(r.getHeight(), that.r.getHeight()) && Objects.equals(r.getWidth(), that.r.getWidth());
    }

    @Override
    public int hashCode() {
        return Objects.hash(r.getHeight(), r.getWidth());
    }
}
*/
