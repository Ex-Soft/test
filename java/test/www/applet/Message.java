import java.applet.Applet;
import java.awt.*;

public class Message extends Applet
{
    private int fontSize;
    private String message;
    
    public void init()
    {
	setBackground(Color.blue);
	setForeground(Color.white);
	fontSize=getSize().height-10;
	setFont(new Font("SansSerif",Font.BOLD,fontSize));
	message=getParameter("MESSAGE");
    }
    
    public void paint(Graphics g)
    {
	if(message!=null)
	    g.drawString(message,5,fontSize+5);
    }
}
