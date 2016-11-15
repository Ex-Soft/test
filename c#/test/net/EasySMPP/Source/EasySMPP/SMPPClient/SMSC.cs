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
 * File Name: SMSC.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace EasySMPP
{

    public class SMSC
    {
        private string description;
        private string host;
        private int port;
        private string systemId;
        private string password;
        private string systemType;
        private int sequenceNumber;
        private byte addrTon = 0;
        private byte addrNpi = 0;
        private string addressRange = "";

        public SMSC()
        {
        }

        public SMSC(string description, string host, int port, string systemId, string password, string systemType, int sequenceNumber)
        {
            this.description = description;
            this.host = host;
            this.port = port;

            if (systemId.Length > 15)
                this.systemId = systemId.Substring(0, 15);
            else
                this.systemId = systemId;

            if (password.Length > 8)
                this.password = password.Substring(0, 8);
            else
                this.password = password;

            if (systemType.Length > 12)
                this.systemType = systemType.Substring(0, 8);
            else
                this.systemType = systemType;

            this.sequenceNumber = sequenceNumber;
        }

        public SMSC(string description, string host, int port, string systemId, string password, string systemType, byte addrTon, byte addrNpi, string addressRange, int sequenceNumber) : this(description ,host, port, systemId, password, systemType, sequenceNumber)
        {
            this.addrTon = addrTon;
            this.addrNpi = addrNpi;
            this.addressRange = addressRange;
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }//Description

        public string Host
        {
            get
            {
                return host;
            }
            set
            {
                host = value;
            }
        }//Host

        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }//Port

        public string SystemId
        {
            get
            {
                return systemId;
            }
            set
            {
                systemId = value;
            }
        }//SystemId

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }//Password

        public string SystemType
        {
            get
            {
                return systemType;
            }
            set
            {
                systemType = value;
            }
        }//SystemType

        public byte AddrTon
        {
            get
            {
                return addrTon;
            }
            set
            {
                addrTon = value;
            }
        }//AddrTon

        public byte AddrNpi
        {
            get
            {
                return addrNpi;
            }
            set
            {
                addrNpi = value;
            }
        }//AddrNpi

        public string AddressRange
        {
            get
            {
                return addressRange;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                    addressRange = "";
                else
                {
                    if (value.Length > 40)
                        addressRange = value.Substring(40);
                    else
                        addressRange = value;
                }
            }
        }//AddressRange

        public int SequenceNumber
        {
            get
            {
                lock (this)
                {
                    if (sequenceNumber == Int32.MaxValue)
                        sequenceNumber = 0;
                    else
                        sequenceNumber++;
                    return sequenceNumber;
                }
            }
        }//SequenceNumber

        public int LastSequenceNumber
        {
            get
            {
                lock (this)
                {
                    return sequenceNumber;
                }
            }
        }//LastSequenceNumber


    }

    public class SMSCArray
    {
        private ArrayList SMSCAr = new ArrayList();
        private int curSMSC = 0;

        public void AddSMSC(SMSC pSMSC)
        {
            lock (this)
            {
                SMSCAr.Add(pSMSC);
            }
        }//AddSMSC

        public void Clear()
        {
            lock (this)
            {
                SMSCAr.Clear();
                curSMSC = 0;
            }
        }//Clear

        public void NextSMSC()
        {
            lock (this)
            {
                curSMSC++;
                if ((curSMSC + 1) > SMSCAr.Count)
                    curSMSC = 0;
            }
        }//AddSMSC


        public SMSC currentSMSC
        {
            get
            {
                SMSC mSMSC = null;
                try
                {
                    lock (this)
                    {

                        if (SMSCAr.Count == 0)
                            return null;
                        if (curSMSC > (SMSCAr.Count - 1))
                        {
                            curSMSC = 0;
                        }
                        mSMSC = (SMSC)SMSCAr[curSMSC];
                    }
                }
                catch (Exception ex)
                {
                }
                return mSMSC;
            }
        }//currentSMSC

        public bool HasItems
        {
            get
            {
                lock (this)
                {
                    if (SMSCAr.Count > 0)
                        return true;
                    else
                        return false;
                }
            }
        }//HasItems
    }//SMSCArray

}
