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
    public delegate void SubmitSmRespEventHandler(SubmitSmRespEventArgs e);

    public delegate void DeliverSmEventHandler(DeliverSmEventArgs e);

    public delegate void LogEventHandler(LogEventArgs e);

    /// <summary>
    /// Summary description for LogEventArgs.
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        private readonly string message;

        public LogEventArgs(string message)
        {
            this.message = message + "";
        }//LogEventArgs

        public string Message
        {
            get { return message; }
        }//Message
    }//LogEventArgs


    /// <summary>
    /// Summary description for SubmitSmRespEventArgs.
    /// </summary>
    public class SubmitSmRespEventArgs : EventArgs
    {
        private readonly int sequence;
        private readonly int status;
        private readonly string messageID;

        public SubmitSmRespEventArgs(int sequence, int status, string messageID)
        {
            this.sequence = sequence;
            this.status = status;
            this.messageID = messageID;
        }//SubmitSmRespEventArgs

        public int Sequence
        {
            get { return sequence; }
        }//Sequence

        public int Status
        {
            get { return status; }
        }//Status

        public string MessageID
        {
            get { return messageID; }
        }//MessageID

    }//SubmitSmRespEventArgs


    /// <summary>
    /// Summary description for DeliverSmEventArgs.
    /// </summary>
    public class DeliverSmEventArgs : EventArgs
    {
        private readonly int sequence_number;

        private readonly string to;
        private readonly string from;
        private readonly string textString;

        private readonly string hexString = "";
        private readonly byte dataCoding = 0;
        private readonly byte esmClass = 0;

        private readonly bool isDeliveryReceipt = false;
        private readonly byte messageState = 0;
        private readonly string receiptedMessageID = "";



        public DeliverSmEventArgs(int sequence_number, string to, string from, string textString, string hexString, byte dataCoding, byte esmClass, bool isDeliveryReceipt, byte messageState, string receiptedMessageID)
        {
            this.sequence_number = sequence_number;
            this.to = to;
            this.from = from;
            this.textString = textString;

            this.hexString = hexString;
            this.dataCoding = dataCoding;
            this.esmClass = esmClass;

            this.isDeliveryReceipt = isDeliveryReceipt;
            this.messageState = messageState;
            this.receiptedMessageID = receiptedMessageID;

        }//DeliverSmEventArgs

        public DeliverSmEventArgs(int sequence_number, string to, string from, string textString, string hexString, byte dataCoding, byte esmClass)
        {
            this.sequence_number = sequence_number;
            this.to = to;
            this.from = from;
            this.textString = textString;

            this.hexString = hexString;
            this.dataCoding = dataCoding;
            this.esmClass = esmClass;
        }//DeliverSmEventArgs

        public DeliverSmEventArgs(int sequence_number, string to, string from, string textString)
        {
            this.sequence_number = sequence_number;
            this.to = to;
            this.from = from;
            this.textString = textString;
        }//DeliverSmEventArgs

        public int SequenceNumber
        {
            get { return sequence_number; }
        }//SequenceNumber

        public string To
        {
            get { return to; }
        }//To

        public string From
        {
            get { return from; }
        }//From

        public string TextString
        {
            get { return textString; }
        }//TextString

        public string HexString
        {
            get { return hexString; }
        }//HexString

        public byte DataCoding
        {
            get { return dataCoding; }
        }//DataCoding

        public byte EsmClass
        {
            get { return esmClass; }
        }//EsmClass

        public bool IsDeliveryReceipt
        {
            get { return isDeliveryReceipt; }
        }//IsDeliveryReceipt

        public byte MessageState
        {
            get { return messageState; }
        }//MessageState

        public string ReceiptedMessageID
        {
            get { return receiptedMessageID; }
        }//ReceiptedMessageID

    }//DeliverSmEventArgs


}