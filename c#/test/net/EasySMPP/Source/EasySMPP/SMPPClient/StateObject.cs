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
 * File Name: StateObject.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;
using System.Net.Sockets;

namespace EasySMPP
{
    class StateObject
    {
        public Socket workSocket = null;								// Client socket.
        public const int BufferSize = KernelParameters.MaxBufferSize;      // Size of receive buffer.
        public int Position = 0;										// Size of receive buffer.
        public byte[] buffer = new byte[BufferSize];					// receive buffer.
    }
}
