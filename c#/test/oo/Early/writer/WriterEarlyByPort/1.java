package oootest;

import com.sun.star.beans.PropertyValue;
import com.sun.star.beans.XPropertySet;
import com.sun.star.bridge.XUnoUrlResolver;
import com.sun.star.connection.NoConnectException;
import com.sun.star.frame.XComponentLoader;
import com.sun.star.frame.XStorable;
import com.sun.star.lang.XMultiComponentFactory;
import com.sun.star.uno.UnoRuntime;
import com.sun.star.uno.XComponentContext;

public class InterprocessConnectionOdtToPdfQuickAndDirty {
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        String loadUrl="file:///C:/dev/netbeans/OOoTest/mydoc.odt";
        String storeUrl="file:///C:/dev/netbeans/OOoTest/mydocIC.pdf";

        try {
            // Start OOo
            Runtime.getRuntime().exec("C:\\Program Files\\OpenOffice.org 2.3\\program\\soffice.exe -accept=socket,host=localhost,port=8100;urp");
            Thread.sleep(10000); // Waits 10 seconds, because Runtime.getRuntime().exec("...") does not wait until OOo is really running in Listening Mode
           
            // Connect to OOo and us it
            XComponentContext xLocalContext = com.sun.star.comp.helper.Bootstrap.createInitialComponentContext(null);

            XMultiComponentFactory xLocalServiceManager = xLocalContext.getServiceManager();

            Object urlResolver  = xLocalServiceManager.createInstanceWithContext("com.sun.star.bridge.UnoUrlResolver",xLocalContext);
            XUnoUrlResolver xUnoUrlResolver = (XUnoUrlResolver) UnoRuntime.queryInterface(XUnoUrlResolver.class,urlResolver);

            Object initialObject = xUnoUrlResolver.resolve("uno:socket,host=localhost,port=8100;urp;StarOffice.ServiceManager");

            XPropertySet xPropertySet = (XPropertySet) UnoRuntime.queryInterface(XPropertySet.class,initialObject);
            XComponentContext remoteContext = (XComponentContext) UnoRuntime.queryInterface(XComponentContext.class, xPropertySet.getPropertyValue("DefaultContext"));

            XMultiComponentFactory remoteServiceManager = remoteContext.getServiceManager();
            Object desktop = remoteServiceManager.createInstanceWithContext("com.sun.star.frame.Desktop", remoteContext);
            XComponentLoader xcomponentloader = (XComponentLoader) UnoRuntime.queryInterface(XComponentLoader.class,desktop);

            Object objectDocumentToStore = xcomponentloader.loadComponentFromURL(loadUrl, "_blank", 0, new PropertyValue[0]);

            PropertyValue[] conversionProperties = new PropertyValue[1];
            conversionProperties[0] = new PropertyValue();
            conversionProperties[0].Name = "FilterName";
            conversionProperties[0].Value = "writer_pdf_Export";

            XStorable xstorable = (XStorable) UnoRuntime.queryInterface(XStorable.class,objectDocumentToStore);
            xstorable.storeToURL(storeUrl,conversionProperties);
        }
        catch (NoConnectException e) {
            String message = "OOo is not responding";
            e.printStackTrace();
        }
        catch (Exception e) {
            e.printStackTrace();
        }
        finally {
            System.exit(0);
        }
    }   
}