// soffice -norestore -nologo -nodefault -accept=socket,host=localhost,port=8100;urp;

using System;
using System.Collections;
using System.IO;
using System.Net.Sockets;

using unoidl.com.sun.star.lang;
using unoidl.com.sun.star.text;
using unoidl.com.sun.star.uno;
using unoidl.com.sun.star.bridge;
using unoidl.com.sun.star.frame;

namespace WriterEarlyByPort
{
	/*	
	public class Connection : IDisposable
	{
		#region Properties

		private Guid _id;
		/// <summary>
		/// The id of the connection. A registry of the connections is kept
		/// by the connection manager. This is a key that can be
		/// used to access them.
		/// </summary>
		public Guid ID
		{
			get { return _id; }
		}

		private int _connectionNumber;
		/// <summary>
		/// This is the number of the connection.
		/// If five connections have been made before this one,
		/// it will be number 6.
		/// </summary>
		public int ConnectionNumber
		{
			get { return _connectionNumber; }
		}


		private XMultiServiceFactory _serviceManager;
		/// <summary>
		/// This is the remote service manager for the connection.
		/// </summary>
		public XMultiServiceFactory ServiceManager
		{
			get { return _serviceManager; }
		}

		private XDesktop _desktop;
		/// <summary>
		/// This is the remote "Desktop". This desktop object
		/// hosts the frames in openoffice.
		/// </summary>
		public XDesktop Desktop
		{
			get { return _desktop; }
		}

		private bool _connected = false;
		/// <summary>
		/// This property tells us if the connection is still active.
		/// </summary>
		public bool Connected
		{
			get { return _connected; }
		}

		private TerminateListener _terminateListener = new TerminateListener();
		/// <summary>
		/// Listens for the remote OpenOffice desktop to be terminated.
		/// </summary>
		public TerminateListener TerminateListener
		{
			get { return _terminateListener; }
		}

		#endregion Properties

		#region Constructor

		/// <summary>
		/// This constructor is called by the connections manager.
		/// </summary>
		/// <param name="remoteContext">A remote context object, this should be connected to the UNO Server</param>
		public Connection(XComponentContext remoteContext)
		{
			// Initialize properties.
			_connectionNumber = ConnectionManager.NumberOfConnections;
			_id = Guid.NewGuid();

			// We then pull down the service manager. As i understand it,
			// this object is similar to our remoting agent, allowing us to create
			// remote instances of objects exposed by the UNO server.
			XMultiServiceFactory remoteFactory = remoteContext.getServiceManager() as XMultiServiceFactory;

			// Get the OpenOffice desktop object.
			XDesktop remoteDesktop = remoteFactory.createInstance("com.sun.star.frame.Desktop") as XDesktop;

			// Register the local terminate listener with the remote desktop.
			_terminateListener.OnTerminate += new EMIS.OpenOffice.TerminateListener.Terminate(_terminateListener_OnTerminate);
			remoteDesktop.addTerminateListener(this._terminateListener);

			// Publicly expose the remoteFactory & the remoteDesktop objects.
			_serviceManager = remoteFactory;
			_desktop = remoteDesktop;
			_connected = true;
		}

		#endregion Constructor

		#region IDisposable Members

		public void Dispose()
		{
			// Tell the remote object we don't need to know about it anymore.
			if (_connected)
				try
				{
					_desktop.removeTerminateListener(_terminateListener);
				}
				catch (System.Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
		}

		#endregion

		#region Internal Methods

		private void _terminateListener_OnTerminate()
		{
			_connected = false;
		}

		#endregion Internal Methods
	}

	public class ConnectionManager
	{
		#region Configuration Items

		// TODO: All of these Configuration Items should either be loaded from
		// a configuration file or specified by the developer.      
		private static string _startFilename = @"C:\Program Files\OpenOffice.org 3\program\soffice.exe";
		private static string _startArgs = @"-accept=socket,host=localhost,port=8100;urp; -nodefault -norestore -nologo";

		private static string _iniFile = @"C:\Program Files\OpenOffice.org 3\program\uno.ini";
		/// <summary>
		/// A path string, pointing to the uno.ini file that comes with openoffice.
		/// </summary>
		public static string INIFile
		{
			get { return _iniFile; }
		}

		private static Hashtable _bootstrapParamaters;
		/// <summary>
		/// An enumerator containing the SYSBINDIR for open office. (openoffice folder+\program\).
		/// This is the parameters that need passing to the Bootstrap.
		/// </summary>
		public static IDictionaryEnumerator BootstrapParamaters
		{
			get
			{
				if (_bootstrapParamaters == null)
				{
					_bootstrapParamaters = new Hashtable();
					_bootstrapParamaters.Add("SYSBINDIR", @"C:\Program Files\OpenOffice.org 2.0\program\");
				}
				return _bootstrapParamaters.GetEnumerator();
			}
		}

		private static string _cxString = @"uno:socket,host=localhost,port=2002;urp;StarOffice.ComponentContext";
		/// <summary>
		/// This is the connection string that will be used to connect to the UNO server,
		/// in this case, OpenOffice.org 2.0.
		/// </summary>
		public static string CxString
		{
			get { return _cxString; }
		}

		#endregion Configuration Items

		#region Properties

		private static int _numberOfConnections = 0;
		/// <summary>
		/// The number of connection attempts made.
		/// </summary>
		public static int NumberOfConnections
		{
			get { return _numberOfConnections; }
		}

		private static Hashtable _connections = new Hashtable();
		/// <summary>
		/// A registery of all the connections made.
		/// </summary>
		public static Hashtable Connections
		{
			get { return _connections; }
		}

		#endregion Properties

		#region Private Variables.

		private static bool _started = false;

		#endregion Private Variables.

		/// <summary>
		/// Creates an Connection.
		/// </summary>
		/// <returns>An Connection object.</returns>
		public static Connection CreateConnection()
		{
			lock (_connections)
			{
				// Tell open office to listen for our connection.
				StartOpenOfficeListener();

				// First we create a local context for the client,
				// we need to load the uno.ini file that comes with open office.
				// We also need to tell the bootstrap where the SYSBINDIR is.
				XComponentContext localContext = Bootstrap.defaultBootstrap_InitialComponentContext(INIFile, BootstrapParamaters);

				// We create a UrlResolver for our clients local context.
				// This will be used to connect to the UNO server (in this case openoffice 2.0)
				// and create a remote context. (Which i guess is similar to our remoting agent).
				XUnoUrlResolver urlResolver = localContext.getServiceManager().createInstanceWithContext("com.sun.star.bridge.UnoUrlResolver", localContext) as XUnoUrlResolver;

				// We create a remote context, this allows us to get the service manager.
				XComponentContext remoteContext = Connect(urlResolver);

				// Increment the number of connections.
				_numberOfConnections++;

				Connection connection = new Connection(remoteContext);
				Connections.Add(connection.ID, connection);
				return connection;
			}
		}

		/// <summary>
		/// This method just runs soffice.exe. This is a bit of a hack.
		/// Hopefully this won't be needed in the long term.
		/// </summary>
		private static void StartOpenOfficeListener()
		{
			if (_started)
				return;
			Process.Start(_startFilename, _startArgs);
		}

		/// <summary>
		/// This keeps trying to connect until the UNO Server is ready.
		/// It will time out after 60 seconds.
		/// </summary>
		/// <param name="urlResolver"></param>
		private static XComponentContext Connect(XUnoUrlResolver urlResolver)
		{
			int connectionAttempts = 0;
			while (true)
			{
				connectionAttempts++;
				try
				{
					return urlResolver.resolve(CxString) as XComponentContext;
				}
				catch (System.Exception ex)
				{
					if (connectionAttempts > 120)
						throw ex;
					else
						System.Threading.Thread.Sleep(500);
				}
			}
		}
	}
	*/

	class Program
	{
		static void Main(string[] args)
		{
			Socket
				s = new Socket(AddressFamily.InterNetwork, SocketType.Raw, ProtocolType.IP);

			string
				sUnoIni = "file:///c:/OpenOffice.org%203/URE/bin/uno.ini";

			XComponentContext
				//xLocalContext = uno.util.Bootstrap.defaultBootstrap_InitialComponentContext(sUnoIni, null);
				xLocalContext = uno.util.Bootstrap.defaultBootstrap_InitialComponentContext();

			XMultiComponentFactory
				xLocalServiceManager = xLocalContext.getServiceManager();
 
			XUnoUrlResolver
				xUrlResolver = (XUnoUrlResolver)xLocalServiceManager.createInstanceWithContext("com.sun.star.bridge.UnoUrlResolver", xLocalContext);

			XMultiServiceFactory
			   xRemoteServiceManager = (XMultiServiceFactory)xUrlResolver.resolve("uno:socket,host=localhost,port=8100;urp;StarOffice.ServiceManager");

			XDesktop
				Desktop = (XDesktop)xRemoteServiceManager.createInstance("com.sun.star.frame.Desktop");

			/*
			XDesktop
				remoteDesktop = (XDesktop)xRemoteServiceManager.createInstance("com.sun.star.frame.Desktop");

			XComponentLoader
				Desktop = (XComponentLoader)remoteDesktop; // (XComponentLoader)multiServiceFactory.createInstance("com.sun.star.frame.Desktop");

			XComponent
				Document = Desktop.loadComponentFromURL("private:factory/swriter", "_blank", 0, new unoidl.com.sun.star.beans.PropertyValue[0]);

			XText
				Text = ((XTextDocument)Document).getText();

			Text.setString("Hello I'm the first text!");

			XTextCursor
				Cursor = Text.createTextCursor();

			Text.insertString(Cursor, "Line# 1\n", false);
			Text.insertString(Cursor, "Line# 2", false);

			XTextTable
				Table;

			if ((Table = (XTextTable)multiServiceFactory.createInstance("com.sun.star.text.TextTable")) != null)
			{
				Table.initialize(2, 2);
				Text.insertTextContent(Text.getEnd(), Table, false);
			}


			unoidl.com.sun.star.beans.PropertyValue[]
				Params = new unoidl.com.sun.star.beans.PropertyValue[2];

			unoidl.com.sun.star.beans.PropertyValue
				Param = new unoidl.com.sun.star.beans.PropertyValue();

			Param.Name = "FilterName";
			Param.Value = new uno.Any("writer_pdf_Export");
			Params[0] = Param;

			Param = new unoidl.com.sun.star.beans.PropertyValue();
			Param.Name = "CompressionMode";
			Param.Value = new uno.Any("1");
			Params[1] = Param;

			string
				CurrentDirectory = System.IO.Directory.GetCurrentDirectory(),
				DocumentDestName;

			CurrentDirectory = CurrentDirectory.Substring(0, CurrentDirectory.LastIndexOf("bin", CurrentDirectory.Length - 1));

			if (File.Exists(DocumentDestName = (CurrentDirectory + "test_out.pdf")))
				File.Delete(DocumentDestName);

			DocumentDestName = DocumentDestName.Replace(Path.DirectorySeparatorChar, '/').Replace("#", "%23");

			((XStorable)Document).storeToURL("file:///" + DocumentDestName, Params);
			 */
		}
	}
}
