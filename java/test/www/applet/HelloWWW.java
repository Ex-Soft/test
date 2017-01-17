import java.applet.Applet;
import java.awt.*;

public class HelloWWW extends Applet
{
    private int fontSize=30;
    
    public void init()
    {
	setBackground(Color.blue);
	setForeground(Color.white);
	setFont(new Font("SansSerif",Font.BOLD,fontSize));
    }
    
    public void paint(Graphics g)
    {
	g.drawString("Hello, World Wide Web.",5,fontSize+5);
    }
}
