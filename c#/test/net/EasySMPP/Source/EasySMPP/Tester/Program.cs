/*
 * EasySMPP - SMPP protocol library for fast and easy
 * SMSC(Short Message Service Centre) client development
 * even for non-telecom guys.
 * 
 * Easy to use classes covers all needed functionality
 * for SMS applications developers and Content Providers.
 * 
 * Written for .NET 2.0 in C#
 * 
 * Copyright (C) 2006 Balan Andrei, http://balan.name
 * 
 * Licensed under the terms of the GNU Lesser General Public License:
 * 		http://www.opensource.org/licenses/lgpl-license.php
 * 
 * For further information visit:
 * 		http://easysmpp.sf.net/
 * 
 * 
 * "Support Open Source software. What about a donation today?"
 *
 * 
 * File Name: Program.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;
using System.Collections.Generic;
using System.Text;

using EasySMPP;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {

            SmsClient
				client = new SmsClient();

            client.Connect();
	
            do
            {
                Console.Write("From : ");
                string from = Console.ReadLine();
                Console.Write("To : ");
                string to = Console.ReadLine();
                Console.Write("Text : ");
                string text = Console.ReadLine();
                if (client.SendSms(from, to, text))
                    Console.WriteLine("Message sent");
                else
                    Console.WriteLine("Error");
            } while (Console.ReadLine() != "exit");
            client.Disconnect();
        }
    }
}
