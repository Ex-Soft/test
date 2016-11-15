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
 * File Name: Delegates.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;

namespace EasySMPP
{
    public delegate void NewSmsEventHandler(NewSmsEventArgs e);

    /// <summary>
    /// Summary description for NewSmsEventArgs.
    /// </summary>
    public class NewSmsEventArgs : EventArgs
    {
        private readonly string to;
        private readonly string from;
        private readonly string text;

        public NewSmsEventArgs(string from, string to, string text)
        {
            this.from = from;
            this.to = to;
            this.text = text;
        }//NewSmsEventArgs

        public string From
        {
            get { return from; }
        }//From

        public string To
        {
            get { return to; }
        }//To

        public string Text
        {
            get { return text; }
        }//TextString

    }//NewSmsEventArgs

}