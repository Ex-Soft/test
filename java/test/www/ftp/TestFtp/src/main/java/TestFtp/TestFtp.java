package TestFtp;

import java.io.IOException;

import org.apache.commons.net.ftp.FTPClient;
import org.apache.commons.net.ftp.FTPFile;

public class TestFtp {
    public static void main(String[] args) {
        String server = "speedtest.tele2.net";
        String user = "anonymous";
        String pass = "password";

        FTPClient ftpClient = new FTPClient();

        try {
            ftpClient.connect(server);
            ftpClient.login(user, pass);

            // use local passive mode to pass firewall
            ftpClient.enterLocalPassiveMode();

            // get details of a file or directory
            String remoteFilePath = "1000GB.zip";

            FTPFile ftpFile = ftpClient.mlistFile(remoteFilePath);
            if (ftpFile != null) {
                String name = ftpFile.getName();
                long size = ftpFile.getSize();
                String timestamp = ftpFile.getTimestamp().getTime().toString();
                String type = ftpFile.isDirectory() ? "Directory" : "File";

                System.out.println("Name: " + name);
                System.out.println("Size: " + size);
                System.out.println("Type: " + type);
                System.out.println("Timestamp: " + timestamp);
            } else {
                System.out.println("The specified file/directory may not exist!");
            }

            FTPFile[] ftpFiles = ftpClient.listFiles();

            if (ftpFiles != null) {
                for (int i = 0; i < ftpFiles.length; ++i) {
                    ftpFile = ftpFiles[i];

                    String name = ftpFile.getName();
                    long size = ftpFile.getSize();
                    String timestamp = ftpFile.getTimestamp().getTime().toString();
                    String type = ftpFile.isDirectory() ? "Directory" : "File";

                    System.out.println("Name: " + name);
                    System.out.println("Size: " + size);
                    System.out.println("Type: " + type);
                    System.out.println("Timestamp: " + timestamp);
                }
            }
            ftpClient.logout();
            ftpClient.disconnect();

        } catch (IOException ex) {
            ex.printStackTrace();
        } finally {
            if (ftpClient.isConnected()) {
                try {
                    ftpClient.disconnect();
                } catch (IOException ex) {
                    ex.printStackTrace();
                }
            }
        }
    }
}
