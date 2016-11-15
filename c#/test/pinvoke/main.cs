#define GET_PRIVATE_PROFILE_SECTION_NAMES
#define GET_PRIVATE_PROFILE_SECTION_NAMES_A
#define GET_PRIVATE_PROFILE_SECTION
//#define GET_PRIVATE_PROFILE_SECTION_ALT
#define GET_PRIVATE_PROFILE_STRING
//#define GET_PRIVATE_PROFILE_STRING_ALT

using System;
using System.Runtime.InteropServices;

namespace pinvoke
{
	class pinvoke
	{
		#if GET_PRIVATE_PROFILE_SECTION_NAMES
			[DllImport("kernel32.dll")]
			static extern uint
				GetPrivateProfileSectionNames(
				IntPtr lpszReturnBuffer,
				uint nSize,
				string lpFileName);
		#endif

		#if GET_PRIVATE_PROFILE_SECTION_NAMES_A
			[DllImport("kernel32.dll",CharSet=CharSet.Ansi)]
			static extern uint 
				GetPrivateProfileSectionNamesA(
				byte[] lpszReturnBuffer,
				int nSize,
				String lpFileName);
		#endif

		#if GET_PRIVATE_PROFILE_SECTION
			[DllImport("kernel32.dll")]
			static extern uint GetPrivateProfileSection(
				string lpAppName,
				IntPtr lpReturnedString,
				uint nSize,
				string lpFileName);
		#endif

		#if GET_PRIVATE_PROFILE_SECTION_ALT
			[DllImport("kernel32.dll",CharSet=CharSet.Auto)]
			static extern uint GetPrivateProfileSection(
				string lpAppName,
				IntPtr lpReturnedString,
				uint nSize,
				string lpFileName);
		#endif

		#if GET_PRIVATE_PROFILE_STRING
			[DllImport("kernel32.dll")]
			static extern uint GetPrivateProfileString(
				string lpAppName,
				string lpKeyName,
				string lpDefault,
				System.Text.StringBuilder lpReturnedString,
				uint nSize,
				string lpFileName);
		#endif

		#if GET_PRIVATE_PROFILE_STRING_ALT
			[DllImport("kernel32.dll")]
			static extern uint GetPrivateProfileString(
				string lpAppName,
				string lpKeyName,
				string lpDefault,
				[In, Out] char[] lpReturnedString,
				uint nSize,
				string lpFileName);
		#endif

		[STAThread]
		static void Main(string[] args)
		{
			string
				tmpString=string.Empty;

			string[]
				tmpStrings=null;

			System.Text.StringBuilder
				tmpStringBuilder=null;

			#if GET_PRIVATE_PROFILE_SECTION_NAMES || GET_PRIVATE_PROFILE_SECTION_NAMES_A || GET_PRIVATE_PROFILE_SECTION || GET_PRIVATE_PROFILE_SECTION_ALT || GET_PRIVATE_PROFILE_STRING || GET_PRIVATE_PROFILE_STRING_ALT
				string
					IniPath="E:\\Soft.src\\ASP.NET\\Bill\\import\\Payments\\ini\\PIB_Central.ini";
			#endif

			#if GET_PRIVATE_PROFILE_SECTION_NAMES
				IntPtr
					ptr=Marshal.StringToHGlobalAnsi(new string('\x0',1024));

				int
					len=(int)GetPrivateProfileSectionNames(ptr,1024,IniPath);

				tmpString=Marshal.PtrToStringAnsi(ptr,len);
				Marshal.FreeHGlobal(ptr);
				tmpStrings=tmpString.Split(new Char[]{'\x0'});
			#endif

			#if GET_PRIVATE_PROFILE_SECTION_NAMES_A
				byte[]
					bytes=new byte[1024];

				GetPrivateProfileSectionNamesA(bytes,bytes.Length,IniPath);
				tmpString=System.Text.Encoding.Default.GetString(bytes);
				tmpStrings=tmpString.Split(new Char[]{'\x0'});
			#endif

			#if GET_PRIVATE_PROFILE_SECTION || GET_PRIVATE_PROFILE_SECTION_ALT
				GetPrivateProfileSection("main",IniPath,out tmpStrings);
			#endif

			#if GET_PRIVATE_PROFILE_STRING
				tmpStringBuilder=new System.Text.StringBuilder(500);
				GetPrivateProfileString("main","CodePage","866",tmpStringBuilder,(uint)tmpStringBuilder.Capacity,IniPath);
				tmpString=tmpStringBuilder.ToString();
			#endif

			#if GET_PRIVATE_PROFILE_STRING_ALT
				char[]
					tmpChar=new char[1024];

				GetPrivateProfileString("main","CodePage","866",tmpChar,1024,IniPath);
				tmpString=new string(tmpChar);
			#endif
		}

		#if GET_PRIVATE_PROFILE_SECTION || GET_PRIVATE_PROFILE_SECTION_ALT
			public static bool GetPrivateProfileSection(string SectionName, string IniFileName, out string[] section)
			{
				section=null;

				if(!System.IO.File.Exists(IniFileName))
					return false;

				uint
					MAX_BUFFER=32767;

				IntPtr
					pReturnedString=Marshal.AllocCoTaskMem((int)MAX_BUFFER);

				uint
					bytesReturned=GetPrivateProfileSection(SectionName,pReturnedString,MAX_BUFFER,IniFileName);

				if((bytesReturned==MAX_BUFFER-2) || (bytesReturned==0)) 
					return false;

				System.Text.StringBuilder
					returnedString=new System.Text.StringBuilder((int)bytesReturned);

				//bytesReturned -1 to remove trailing \0
				for(int i=0; i<bytesReturned-1; i++)
					returnedString.Append((char)Marshal.ReadByte(new IntPtr((uint)pReturnedString+(uint)i)));

				Marshal.FreeCoTaskMem(pReturnedString);

				section=returnedString.ToString().Split('\0');

				return true;
			}
		#endif
	}
}