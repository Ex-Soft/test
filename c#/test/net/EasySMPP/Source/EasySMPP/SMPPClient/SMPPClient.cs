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
 * File Name: SMPPClient.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using EasySMPP;

namespace EasySMPP
{
        /// <summary>
        /// Summary description for SMPPClient.
        /// </summary>
        public class SMPPClient
        {
            
            #region Private variables
            private Socket clientSocket;

            private int connectionState;
            
            private DateTime enquireLinkSendTime;
            private DateTime enquireLinkResponseTime;
            private DateTime lastSeenConnected;
            private DateTime lastPacketSentTime;

            private Timer enquireLinkTimer;
            private int undeliveredMessages = 0;

            private SMSCArray smscArray = new SMSCArray();

            private byte[] mbResponse = new byte[KernelParameters.MaxBufferSize];
            private int mPos = 0;
            private int mLen = 0;
            
            private bool mustBeConnected;

            private int logLevel = 0;
            private byte askDeliveryReceipt = KernelParameters.AskDeliveryReceipt;
            private bool splitLongText = KernelParameters.SplitLongText;
            private int nationalNumberLength = KernelParameters.NationalNumberLength;
            private bool useEnquireLink = KernelParameters.UseEnquireLink;
            private int enquireLinkTimeout = KernelParameters.EnquireLinkTimeout;
            private int reconnectTimeout = KernelParameters.ReconnectTimeout;

            private SortedList sarMessages = SortedList.Synchronized(new SortedList());
            #endregion Private variables

            #region Public Functions

            public SMPPClient()
            {
                connectionState= ConnectionStates.SMPP_SOCKET_DISCONNECTED;

                enquireLinkSendTime = DateTime.Now;
                enquireLinkResponseTime = enquireLinkSendTime.AddSeconds(1);
                lastSeenConnected = DateTime.Now;
                lastPacketSentTime = DateTime.MaxValue;

                mustBeConnected = false;

                TimerCallback timerDelegate = new TimerCallback(checkSystemIntegrity);
                enquireLinkTimer = new Timer(timerDelegate, null, enquireLinkTimeout, enquireLinkTimeout);

            }//SMPPClient

            public void Connect()
            {
                try
                {
                    mustBeConnected = true;
                    connectToSMSC();
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "connectToSMSC | " + ex.ToString());
                }
            }//connectToSMSC

            public void Disconnect()
            {
                try
                {
                    mustBeConnected = false;
                    unBind();
                    disconnectSocket();
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "DisconnectFromSMSC | " + ex.ToString());
                }
            }//DisconnectFromSMSC

            public void ClearSMSC()
            {
                try
                {
                    smscArray.Clear();
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "AddSMSC | " + ex.ToString());
                }

            }//ClearSMSC

            public void AddSMSC(SMSC mSMSC)
            {
                try
                {
                    smscArray.AddSMSC(mSMSC);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "AddSMSC | " + ex.ToString());
                }

            }//AddSMSC

            #region Send Functions

            public void Send(byte[] data, int n)
            {
                try
                {
                    lastPacketSentTime = DateTime.Now;
                    logMessage(LogLevels.LogPdu, "Sending PDU : " + Tools.ConvertArrayToHexString(data, n));
                    clientSocket.BeginSend(data, 0, n, 0, new AsyncCallback(sendCallback), clientSocket);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "Send | " + ex.ToString());
                }
            }//Send

            public int SubmitSM(byte sourceAddressTon, byte sourceAddressNpi, string sourceAddress,
                                byte destinationAddressTon, byte destinationAddressNpi, string destinationAddress,
                                byte esmClass, byte protocolId, byte priorityFlag, 
                                DateTime sheduleDeliveryTime, DateTime validityPeriod, byte registeredDelivery, 
                                byte replaceIfPresentFlag, byte dataCoding, byte smDefaultMsgId, 
                                byte[] message)
            {
                try
                {
                    byte[] _destination_addr;
                    byte[] _source_addr;
                    byte[] _SUBMIT_SM_PDU;
                    byte[] _shedule_delivery_time;
                    byte[] _validity_period;
                    int _sequence_number;
                    int pos;
                    byte _sm_length;


                    _SUBMIT_SM_PDU = new byte[KernelParameters.MaxPduSize];

                    ////////////////////////////////////////////////////////////////////////////////////////////////
                    /// Start filling PDU						

                    Tools.CopyIntToArray(0x00000004, _SUBMIT_SM_PDU, 4);
                    _sequence_number = smscArray.currentSMSC.SequenceNumber;
                    Tools.CopyIntToArray(_sequence_number, _SUBMIT_SM_PDU, 12);
                    pos = 16;
                    _SUBMIT_SM_PDU[pos] = 0x00; //service_type
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = sourceAddressTon;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = sourceAddressNpi;
                    pos += 1;
                    _source_addr = Tools.ConvertStringToByteArray(Tools.GetString(sourceAddress, 20, ""));
                    Array.Copy(_source_addr, 0, _SUBMIT_SM_PDU, pos, _source_addr.Length);
                    pos += _source_addr.Length;
                    _SUBMIT_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = destinationAddressTon;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = destinationAddressNpi;
                    pos += 1;
                    _destination_addr = Tools.ConvertStringToByteArray(Tools.GetString(destinationAddress, 20, ""));
                    Array.Copy(_destination_addr, 0, _SUBMIT_SM_PDU, pos, _destination_addr.Length);
                    pos += _destination_addr.Length;
                    _SUBMIT_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = esmClass;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = protocolId;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = priorityFlag;
                    pos += 1;
                    _shedule_delivery_time = Tools.ConvertStringToByteArray(Tools.GetDateString(sheduleDeliveryTime));
                    Array.Copy(_shedule_delivery_time, 0, _SUBMIT_SM_PDU, pos, _shedule_delivery_time.Length);
                    pos += _shedule_delivery_time.Length;
                    _SUBMIT_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _validity_period = Tools.ConvertStringToByteArray(Tools.GetDateString(validityPeriod));
                    Array.Copy(_validity_period, 0, _SUBMIT_SM_PDU, pos, _validity_period.Length);
                    pos += _validity_period.Length;
                    _SUBMIT_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = registeredDelivery;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = replaceIfPresentFlag;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = dataCoding;
                    pos += 1;
                    _SUBMIT_SM_PDU[pos] = smDefaultMsgId;
                    pos += 1;

                    _sm_length = message.Length > 254 ? (byte)254 : (byte)message.Length;

                    _SUBMIT_SM_PDU[pos] = _sm_length;
                    pos += 1;
                    Array.Copy(message, 0, _SUBMIT_SM_PDU, pos, _sm_length);
                    pos += _sm_length;

                    Tools.CopyIntToArray(pos, _SUBMIT_SM_PDU, 0);

                    Send(_SUBMIT_SM_PDU, pos);
                    undeliveredMessages++;
                    return _sequence_number;
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "SubmitSM | " + ex.ToString());
                }
                return -1;

            }//SubmitSM

            public int DataSM(byte sourceAddressTon, byte sourceAddressNpi, string sourceAddress,
                                byte destinationAddressTon, byte destinationAddressNpi, string destinationAddress,
                                byte esmClass,
                                byte registeredDelivery,
                                byte dataCoding,
                                byte[] data)
            {
                try
                {
                    byte[] _destination_addr;
                    byte[] _source_addr;
                    byte[] _DATA_SM_PDU;
                    int _sequence_number;
                    int pos;
                    Int16 _sm_length;


                    _DATA_SM_PDU = new byte[KernelParameters.MaxPduSize];

                    ////////////////////////////////////////////////////////////////////////////////////////////////
                    /// Start filling PDU						

                    Tools.CopyIntToArray(0x00000103, _DATA_SM_PDU, 4);
                    _sequence_number = smscArray.currentSMSC.SequenceNumber;
                    Tools.CopyIntToArray(_sequence_number, _DATA_SM_PDU, 12);
                    pos = 16;
                    _DATA_SM_PDU[pos] = 0x00; //service_type
                    pos += 1;
                    _DATA_SM_PDU[pos] = sourceAddressTon;
                    pos += 1;
                    _DATA_SM_PDU[pos] = sourceAddressNpi;
                    pos += 1;
                    _source_addr = Tools.ConvertStringToByteArray(Tools.GetString(sourceAddress, 20, ""));
                    Array.Copy(_source_addr, 0, _DATA_SM_PDU, pos, _source_addr.Length);
                    pos += _source_addr.Length;
                    _DATA_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _DATA_SM_PDU[pos] = destinationAddressTon;
                    pos += 1;
                    _DATA_SM_PDU[pos] = destinationAddressNpi;
                    pos += 1;
                    _destination_addr = Tools.ConvertStringToByteArray(Tools.GetString(destinationAddress, 20, ""));
                    Array.Copy(_destination_addr, 0, _DATA_SM_PDU, pos, _destination_addr.Length);
                    pos += _destination_addr.Length;
                    _DATA_SM_PDU[pos] = 0x00;
                    pos += 1;
                    _DATA_SM_PDU[pos] = esmClass;
                    pos += 1;
                    _DATA_SM_PDU[pos] = registeredDelivery;
                    pos += 1;
                    _DATA_SM_PDU[pos] = dataCoding;
                    pos += 1;

                    _DATA_SM_PDU[pos] = 0x04;
                    pos += 1;
                    _DATA_SM_PDU[pos] = 0x24;
                    pos += 1;

                    _sm_length = data.Length > 32767 ? (Int16)32767 : (Int16)data.Length;

                    _DATA_SM_PDU[pos] = BitConverter.GetBytes(_sm_length)[1];
                    pos += 1;
                    _DATA_SM_PDU[pos] = BitConverter.GetBytes(_sm_length)[0];
                    pos += 1;
                    Array.Copy(data, 0, _DATA_SM_PDU, pos, _sm_length);
                    pos += _sm_length;

                    Tools.CopyIntToArray(pos, _DATA_SM_PDU, 0);

                    Send(_DATA_SM_PDU, pos);
                    undeliveredMessages++;
                    return _sequence_number;
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "DataSM | " + ex.ToString());
                }
                return -1;

            }//DataSM

            public int SendSms(String from, String to, String text)
            {
                return SendSms(from, to, splitLongText, text, askDeliveryReceipt);
            }//SendSms
            public int SendSms(String from, String to, String text, byte askDeliveryReceipt)
            {
                return SendSms(from, to, splitLongText, text, askDeliveryReceipt);
            }//SendSms
            public int SendSms(String from, String to, bool splitLongText, String text)
            {
                return SendSms(from, to, splitLongText, text, askDeliveryReceipt);
            }//SendSms
            public int SendSms(String from, String to, bool splitLongText, String text, byte askDeliveryReceipt)
            {
                return SendSms(from, to, splitLongText, text, askDeliveryReceipt, 0, Tools.GetDataCoding(text));
            }

            public int SendSms(String from, String to, bool splitLongText, String text, byte askDeliveryReceipt, byte esmClass, byte dataCoding)
            {
                int messageId = -1;
                byte sourceAddressTon;
                byte sourceAddressNpi;
                string sourceAddress;
                byte destinationAddressTon;
                byte destinationAddressNpi;
                string destinationAddress;
                byte registeredDelivery;
                byte maxLength;

                sourceAddress = Tools.GetString(from, 20, "");
                sourceAddressTon = getAddrTon(sourceAddress);
                sourceAddressNpi = getAddrNpi(sourceAddress);

                destinationAddress = Tools.GetString(to, 20, "");
                destinationAddressTon = getAddrTon(destinationAddress);
                destinationAddressNpi = getAddrNpi(destinationAddress);

                registeredDelivery = askDeliveryReceipt;

                if (dataCoding == 8)
                {
                    text = Tools.Endian2UTF(text);
                    maxLength = 70;
                }
                else
                    maxLength = 160;

                if ((text.Length <= maxLength) || (splitLongText))
                {
                    byte protocolId;
                    byte priorityFlag;
                    DateTime sheduleDeliveryTime;
                    DateTime validityPeriod;
                    byte replaceIfPresentFlag;
                    byte smDefaultMsgId;
                    byte[] message;
                    string smsText = text;

                    protocolId = 0;
                    priorityFlag = PriorityFlags.VeryUrgent;
                    sheduleDeliveryTime = DateTime.MinValue;
                    validityPeriod = DateTime.MinValue;
                    replaceIfPresentFlag = ReplaceIfPresentFlags.DoNotReplace;
                    smDefaultMsgId = 0;

                    while (smsText.Length > 0)
                    {
                        if (dataCoding == 8)
                            message = Encoding.UTF8.GetBytes(smsText.Substring(0, smsText.Length > maxLength ? maxLength : smsText.Length));
                        else
                            message = Encoding.ASCII.GetBytes(smsText.Substring(0, smsText.Length > maxLength ? maxLength : smsText.Length));

                        smsText = smsText.Remove(0, smsText.Length > maxLength ? maxLength : smsText.Length);
                        
                        messageId = SubmitSM(sourceAddressTon, sourceAddressNpi, sourceAddress, 
                                            destinationAddressTon, destinationAddressNpi, destinationAddress,
                                            esmClass, protocolId, priorityFlag,
                                            sheduleDeliveryTime, validityPeriod, registeredDelivery, replaceIfPresentFlag,
                                            dataCoding, smDefaultMsgId, message);
                    }
                }
                else
                {
                    byte[] data;

                    if (dataCoding == 8)
                        data = Encoding.UTF8.GetBytes(text);
                    else
                        data = Encoding.ASCII.GetBytes(text);
                    messageId = DataSM(sourceAddressTon, sourceAddressNpi, sourceAddress,
                                        destinationAddressTon, destinationAddressNpi, destinationAddress,
                                        esmClass, registeredDelivery, dataCoding, data);
                }
                return messageId;
            }//SendSms
            public int SendFlashSms(String from, String to, String text)
            {
                return SendFlashSms(from, to, text, askDeliveryReceipt);
            }//SendFlashSms
            public int SendFlashSms(String from, String to, String text, byte askDeliveryReceipt)
            {
                return SendSms(from, to, false, text.Substring(0, text.Length > 160 ? 160 : text.Length), askDeliveryReceipt, 0, 0x10);
            }//SendFlashSms
            public int SendMedia(String from, String to, byte[] media)
            {
                return SendMedia(from, to, media, askDeliveryReceipt);
            }//SendMedia
            public int SendMedia(String from, String to, byte[] media, byte askDeliveryReceipt)
            {
                return SendData(from, to, media, 0x40, 0xF5, askDeliveryReceipt);
            }//SendMedia
            public int SendData(String from, String to, byte[] data)
            {
                return SendData(from, to, data, askDeliveryReceipt);
            }//SendData
            public int SendData(String from, String to, byte[] data, byte askDeliveryReceipt)
            {
                return SendData(from, to, data, 0, 0, 0);
            }//SendData
            public int SendData(String from, String to, byte[] data, byte esmClass, byte dataCoding, byte askDeliveryReceipt)
            {
                int messageId;
                byte sourceAddressTon;
                byte sourceAddressNpi;
                string sourceAddress;
                byte destinationAddressTon;
                byte destinationAddressNpi;
                string destinationAddress;
                byte registeredDelivery;

                sourceAddress = Tools.GetString(from, 20, "");
                sourceAddressTon = getAddrTon(sourceAddress);
                sourceAddressNpi = getAddrNpi(sourceAddress);

                destinationAddress = Tools.GetString(from, 20, "");
                destinationAddressTon = getAddrTon(destinationAddress);
                destinationAddressNpi = getAddrNpi(destinationAddress);

                registeredDelivery = askDeliveryReceipt;

                messageId = DataSM(sourceAddressTon, sourceAddressNpi, sourceAddress,
                                    destinationAddressTon, destinationAddressNpi, destinationAddress,
                                    esmClass, registeredDelivery, dataCoding, data);

                return messageId;
            }//SendData
            #endregion New Send Functions

            #endregion Public Functions

            #region Properties
            public bool CanSend
            {
                get
                {
                    try
                    {
                        if ((connectionState== ConnectionStates.SMPP_BINDED) && (undeliveredMessages <= KernelParameters.MaxUndeliverableMessages))
                            return true;
                    }
                    catch (Exception ex)
                    {
                        logMessage(LogLevels.LogExceptions, "CanSend | " + ex.ToString());
                    }
                    return false;
                }
            }//CanSend

            public int LogLevel
            {
                get
                {
                    return logLevel;
                }
                set
                {
                    logLevel = value;
                }
            }//CanSend


            public byte AskDeliveryReceipt
            {
                get
                {
                    return askDeliveryReceipt;
                }
                set
                {
                    if ((value < 3) && (value >= 0))
                        askDeliveryReceipt = value;
                }
            }//AskDeliveryReceipt

            public bool SplitLongText
            {
                get
                {
                    return splitLongText;
                }
                set
                {
                    splitLongText = value;
                }
            }//SplitLongText
            public int NationalNumberLength
            {
                get
                {
                    return nationalNumberLength;
                }
                set
                {
                    if (value <= 12)
                        nationalNumberLength = value;
                }
            }//NationalNumberLength
            public bool UseEnquireLink
            {
                get
                {
                    return useEnquireLink;
                }
                set
                {
                    useEnquireLink = value;
                }
            }//UseEnquireLink
            public int EnquireLinkTimeout
            {
                get
                {
                    return enquireLinkTimeout;
                }
                set
                {
                    if (value > 1000)
                        enquireLinkTimeout = value;
                }
            }//EnquireLinkTimeout
            public int ReconnectTimeout
            {
                get
                {
                    return reconnectTimeout;
                }
                set
                {
                    if (value > 1000)
                        reconnectTimeout = value;
                }
            }//ReconnectTimeout

            #endregion Properties

            #region Events

            public event SubmitSmRespEventHandler OnSubmitSmResp;

            public event DeliverSmEventHandler OnDeliverSm;

            public event LogEventHandler OnLog;

            #endregion Events

            #region Private functions
            private void connectToSMSC()
            {
                try
                {
                    if (!smscArray.HasItems)
                    {
                        logMessage(LogLevels.LogErrors, "Connect | ERROR #1011 : No SMSC defined. Please ddd SMSC definition first.");
                        return;
                    }
                    initClientParameters();

                    IPAddress ipAddress = IPAddress.Parse(smscArray.currentSMSC.Host);
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, smscArray.currentSMSC.Port);
                    //  Create a TCP/IP  socket.
                    //Try to disconnect if connected
                    tryToDisconnect();
                    clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    logMessage(LogLevels.LogSteps, "Trying to connect to " + smscArray.currentSMSC.Description + "[" + smscArray.currentSMSC.Host + ":" + smscArray.currentSMSC.Port + "]");
                    clientSocket.BeginConnect(remoteEP, new AsyncCallback(connectCallback), clientSocket);
                    connectionState= ConnectionStates.SMPP_SOCKET_CONNECT_SENT;
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "connectToSMSC | " + ex.ToString());
                }

            }//connectToSMSC

            private void tryToDisconnect()
            {
                try
                {
                    if (clientSocket != null)
                    {
                        if (clientSocket.Connected)
                        {
                            clientSocket.Shutdown(SocketShutdown.Both);
                        }
                        clientSocket = null;
                    }
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "tryToDisconnect | " + ex.ToString());
                }
            }//tryToDisconnect

            private void disconnectSocket()
            {
                try
                {
                    logMessage(LogLevels.LogSteps, "Disconnected");
                    connectionState= ConnectionStates.SMPP_SOCKET_DISCONNECTED;
                    clientSocket.Shutdown(SocketShutdown.Both);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "disconnectSocket | " + ex.ToString());
                }
            }//disconnectSocket

            private void disconnect(Socket client)
            {
                try
                {
                    logMessage(LogLevels.LogSteps, "Disconnected");
                    connectionState= ConnectionStates.SMPP_SOCKET_DISCONNECTED;
                    client.Shutdown(SocketShutdown.Both);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "disconnect | " + ex.ToString());
                }
            }//Disconnect


            private void receive()
            {
                try
                {
                    // Create the state object.
                    StateObject state = new StateObject();
                    state.workSocket = clientSocket;

                    // Begin receiving the data from the remote device.
                    clientSocket.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                        new AsyncCallback(receiveCallback), state);

                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "receive | " + ex.ToString());
                }

            }//receive

            private void bind()
            {
                try
                {
                    byte[] Bind_PDU = new byte[1024];
                    int pos, i, n;

                    pos = 7;
                    Bind_PDU[pos] = 0x09;

                    pos = 12;
                    Tools.CopyIntToArray(smscArray.currentSMSC.SequenceNumber, Bind_PDU, pos);
                    pos = 15;

                    pos++;
                    n = smscArray.currentSMSC.SystemId.Length;
                    for (i = 0; i < n; i++, pos++)
                        Bind_PDU[pos] = (byte)smscArray.currentSMSC.SystemId[i];
                    Bind_PDU[pos] = 0;

                    pos++;
                    n = smscArray.currentSMSC.Password.Length;
                    for (i = 0; i < n; i++, pos++)
                        Bind_PDU[pos] = (byte)smscArray.currentSMSC.Password[i];
                    Bind_PDU[pos] = 0;

                    pos++;
                    n = smscArray.currentSMSC.SystemType.Length;
                    for (i = 0; i < n; i++, pos++)
                        Bind_PDU[pos] = (byte)smscArray.currentSMSC.SystemType[i];
                    Bind_PDU[pos] = 0;

                    Bind_PDU[++pos] = 0x34; //interface version
                    Bind_PDU[++pos] = (byte)smscArray.currentSMSC.AddrTon; //addr_ton
                    Bind_PDU[++pos] = (byte)smscArray.currentSMSC.AddrNpi; //addr_npi
                    
                    //address_range
                    pos++;
                    n = smscArray.currentSMSC.AddressRange.Length;
                    for (i = 0; i < n; i++, pos++)
                        Bind_PDU[pos] = (byte)smscArray.currentSMSC.AddressRange[i];
                    Bind_PDU[pos] = 0x00;

                    pos++;
                    Bind_PDU[3] = Convert.ToByte(pos & 0x00FF);
                    Bind_PDU[2] = Convert.ToByte((pos >> 8) & 0x00FF);

                    // Begin sending the data to the remote device.
                    logMessage(LogLevels.LogSteps, "BindSent");
                    Send(Bind_PDU, pos);
                    connectionState= ConnectionStates.SMPP_BIND_SENT;
                    receive();
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "bind | " + ex.ToString());
                }

            }//bind

            private void unBind()
            {
                if (connectionState== ConnectionStates.SMPP_BINDED)
                {
                    try
                    {
                        byte[] _PDU = new byte[16];

                        Tools.CopyIntToArray(16, _PDU, 0);

                        Tools.CopyIntToArray(0x00000006, _PDU, 4);

                        Tools.CopyIntToArray(smscArray.currentSMSC.SequenceNumber, _PDU, 12);

                        logMessage(LogLevels.LogSteps, "Unbind sent.");
                        connectionState= ConnectionStates.SMPP_UNBIND_SENT;

                        Send(_PDU, 16);
                    }
                    catch (Exception ex)
                    {
                        logMessage(LogLevels.LogExceptions, "unBind | " + ex.ToString());
                    }
                }

            }//unBind


            private void processSubmitSmResp(SubmitSmRespEventArgs e)
            {
                try
                {
                    undeliveredMessages--;

                    if (OnSubmitSmResp != null)
                    {
                        OnSubmitSmResp(e);
                    }
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "processSubmitSmResp | " + ex.ToString());
                }

            }//processSubmitSmResp

            private void processDeliverSm(DeliverSmEventArgs e)
            {
                try
                {
                    if (OnDeliverSm != null)
                    {
                        OnDeliverSm(e);
                    }
                    else
                        sendDeliverSmResp(e.SequenceNumber, StatusCodes.ESME_ROK);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "processDeliverSm | " + ex.ToString());
                }
            }//processDeliverSm

            private void processLog(LogEventArgs e)
            {
                try
                {
                    if (OnLog != null)
                    {
                        OnLog(e);
                    }
                }
                catch
                {
                }

            }//processLog

            private void logMessage(int logLevel, string pMessage)
            {
                try
                {
                    if ((this.LogLevel & logLevel) > 0)
                    {
                        LogEventArgs evArg = new LogEventArgs(pMessage);
                        processLog(evArg);
                    }
                }
                catch (Exception ex)
                {
                    // DO NOT USE LOG INSIDE LOG FUNCTION !!! logMessage(LogLevels.LogExceptions, "logMessage | " +ex.ToString());
                }
            }//logMessage

            private void connectCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.
                    Socket client = (Socket)ar.AsyncState;

                    // Complete the connection.
                    client.EndConnect(ar);
                    clientSocket = client;
                    clientSocket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.KeepAlive, 1);
                    connectionState= ConnectionStates.SMPP_SOCKET_CONNECTED;
                    logMessage(LogLevels.LogSteps, "Connected");
                    lastSeenConnected = DateTime.Now;
                    bind();
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "connectCallback | " + ex.ToString());
                    tryToReconnect();
                }
            }//connectCallback


            private void tryToReconnect()
            {
                try
                {
                    disconnectSocket();
                    Thread.Sleep(reconnectTimeout);
                    if (mustBeConnected)
                    {
                        smscArray.NextSMSC();
                        connectToSMSC();
                    }
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "tryToReconnect | " + ex.ToString());
                }

            }//tryToReconnect

            private void receiveCallback(IAsyncResult ar)
            {
                try
                {
                    int _command_length;
                    uint _command_id;
                    int _command_status;
                    int _sequence_number;
                    int _body_length;
                    byte[] _PDU_body = new byte[0];
                    byte[] _RESPONSE_PDU = new byte[KernelParameters.MaxPduSize];
                    int i, x;
                    bool _exit_flag;

                    // Retrieve the state object and the client socket 
                    // from the async state object.
                    StateObject state = (StateObject)ar.AsyncState;
                    Socket client = state.workSocket;
                    // Read data from the remote device.
                    int bytesRead = client.EndReceive(ar);
                    logMessage(LogLevels.LogSteps, "Received " + Tools.ConvertIntToHexString(bytesRead) + " bytes");
                    if (bytesRead > 0)
                    {
                        // There might be more data, so store the data received so far.
                        if ((LogLevel & LogLevels.LogPdu) > 0)
                            logMessage(LogLevels.LogPdu, "Received Binary Data " + Tools.ConvertArrayToHexString(state.buffer, bytesRead));
                        //////////////////////////////
                        /// Begin processing SMPP messages
                        /// 
                        mLen = mPos + bytesRead;
                        if (mLen > KernelParameters.MaxBufferSize)
                        {
                            mPos = 0;
                            mLen = 0;
                            mbResponse = new byte[KernelParameters.MaxBufferSize];
                        }
                        else
                        {
                            Array.Copy(state.buffer, 0, mbResponse, mPos, bytesRead);
                            mPos = mLen;
                            _exit_flag = false;
                            x = 0;
                            while (((mLen - x) >= 16) && (_exit_flag == false))
                            {
                                _command_length = mbResponse[x + 0];
                                for (i = x + 1; i < x + 4; i++)
                                {
                                    _command_length <<= 8;
                                    _command_length = _command_length | mbResponse[i];
                                }

                                _command_id = mbResponse[x + 4];
                                for (i = x + 5; i < x + 8; i++)
                                {
                                    _command_id <<= 8;
                                    _command_id = _command_id | mbResponse[i];
                                }

                                _command_status = mbResponse[x + 8];
                                for (i = x + 9; i < x + 12; i++)
                                {
                                    _command_status <<= 8;
                                    _command_status = _command_status | mbResponse[i];
                                }

                                _sequence_number = mbResponse[x + 12];
                                for (i = x + 13; i < x + 16; i++)
                                {
                                    _sequence_number <<= 8;
                                    _sequence_number = _sequence_number | mbResponse[i];
                                }
                                if ((_command_length <= (mLen - x)) && (_command_length >= 16))
                                {
                                    if (_command_length == 16)
                                        _body_length = 0;
                                    else
                                    {
                                        _body_length = _command_length - 16;
                                        _PDU_body = new byte[_body_length];
                                        Array.Copy(mbResponse, x + 16, _PDU_body, 0, _body_length);
                                    }
                                    //////////////////////////////////////////////////////////////////////////////////////////
                                    ///SMPP Command parsing

                                    switch (_command_id)
                                    {
                                        case 0x80000009:
                                            logMessage(LogLevels.LogSteps, "Bind_Transiver_Resp");

                                            if (connectionState== ConnectionStates.SMPP_BIND_SENT)
                                            {
                                                if (_command_status == 0)
                                                {
                                                    connectionState= ConnectionStates.SMPP_BINDED;
                                                    logMessage(LogLevels.LogSteps, "SMPP Binded");
                                                }
                                                else
                                                {
                                                    logMessage(LogLevels.LogSteps | LogLevels.LogErrors, "SMPP BIND ERROR : " + Tools.ConvertIntToHexString(_command_status));
                                                    disconnect(client);
                                                    tryToReconnect();
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "ERROR #3011 : Unexpected Bind_Transiver_Resp");
                                            }
                                            break;
                                        case 0x80000004:
                                            logMessage(LogLevels.LogSteps, "Submit_Sm_Resp");
                                            SubmitSmRespEventArgs evArg = new SubmitSmRespEventArgs(_sequence_number, _command_status, Tools.ConvertArrayToString(_PDU_body, _body_length - 1));
                                            processSubmitSmResp(evArg);
                                            break;
                                        case 0x80000103:
                                            logMessage(LogLevels.LogSteps, "Data_Sm_Resp");
                                            evArg = new SubmitSmRespEventArgs(_sequence_number, _command_status, Tools.ConvertArrayToString(_PDU_body, _body_length - 1));
                                            processSubmitSmResp(evArg);
                                            break;
                                        case 0x80000015:
                                            logMessage(LogLevels.LogSteps, "Enquire_Link_Resp");
                                            enquireLinkResponseTime = DateTime.Now;
                                            break;
                                        case 0x00000015:
                                            logMessage(LogLevels.LogSteps, "Enquire_Link");
                                            sendEnquireLinkResp(_sequence_number);
                                            break;
                                        case 0x80000006:
                                            logMessage(LogLevels.LogSteps, "Unbind_Resp");
                                            connectionState= ConnectionStates.SMPP_UNBINDED;
                                            disconnect(client);
                                            break;
                                        case 0x00000005:
                                            logMessage(LogLevels.LogSteps, "Deliver_Sm");
                                            decodeAndProcessDeliverSm(_sequence_number, _PDU_body, _body_length);
                                            break;
                                        case 0x00000103:
                                            logMessage(LogLevels.LogSteps, "Data_Sm");
                                            decodeAndProcessDataSm(_sequence_number, _PDU_body, _body_length);
                                            break;
                                        default:
                                            sendGenericNack(_sequence_number, StatusCodes.ESME_RINVCMDID);
                                            logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "Unknown SMPP PDU type" + Tools.ConvertUIntToHexString(_command_id));
                                            break;
                                    }
                                    ///////////////////////////////////////////////////////////////////////////////////////////
                                    ///END SMPP Command parsing
                                    ///////////////////////////////////////////////////////////////////////////////////////////

                                    if (_command_length == (mLen - x))
                                    {
                                        mLen = 0;
                                        mPos = 0;
                                        x = 0;
                                        _exit_flag = true;
                                    }
                                    else
                                    {
                                        x += _command_length;
                                    }
                                }
                                else
                                {
                                    sendGenericNack(_sequence_number, StatusCodes.ESME_RINVMSGLEN);
                                    mLen -= x;
                                    mPos = mLen;
                                    Array.Copy(mbResponse, x, mbResponse, 0, mLen);
                                    _exit_flag = true;
                                    logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "Invalid PDU Length");
                                }
                                if (x < mLen)
                                    logMessage(LogLevels.LogPdu, "NEXT PDU STEP IN POS " + Convert.ToString(x) + " FROM " + Convert.ToString(mLen));
                            }
                        }
                        //////////////////////////////
                        /// End processing SMPP messages
                        //  Get the rest of the data.
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(receiveCallback), state);
                    }
                    else
                    {
                        logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "Incoming network buffer from SMSC is empty.");
                        /*					if (client.Poll(0,SelectMode.SelectError)&&client.Poll(0,SelectMode.SelectRead)&&client.Poll(0,SelectMode.SelectWrite))
                                            {
                                                logMessage(LogLevels.LogSteps|LogLevels.LogExceptions, "Socket Error");
                                                unBind();
                                            }
                        */
                        tryToReconnect();
                    }
                }

                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "receiveCallback | " + ex.ToString());
                    unBind();
                }

            }//receiveCallback

            private void initClientParameters()
            {
                mbResponse = new byte[KernelParameters.MaxBufferSize];
                mPos = 0;
                mLen = 0;

                enquireLinkResponseTime = DateTime.Now;

                undeliveredMessages = 0;
            }//initClientParameters

            private void decodeAndProcessDeliverSm(int sequence_number, byte[] _body, int _length)
            {
                if (_length < 17)
                {
                    sendDeliverSmResp(sequence_number, StatusCodes.ESME_RINVCMDLEN);
                    return;
                }
                try
                {
                    bool isDeliveryReceipt = false;
                    bool isUdhiSet = false;
                    byte _source_addr_ton, _source_addr_npi, _dest_addr_ton, _dest_addr_npi;
                    byte _priority_flag, _data_coding, _esm_class;
                    byte[] _source_addr = new byte[21];
                    byte[] _dest_addr = new byte[21];
                    byte saLength, daLength;
                    byte[] _short_message = new byte[0];
                    int _sm_length;
                    int pos;

                    /////////////////////////////////////
                    /// Message Delivery Params
                    /// 
                    byte[] _receipted_message_id = new byte[254];
                    byte _receipted_message_id_len = 0;
                    byte _message_state = 0;
                    Int16 sar_msg_ref_num = 0;
                    byte sar_total_segments = 0;
                    byte sar_segment_seqnum = 0;

                    pos = 0;
                    while ((pos < 5) && (_body[pos] != 0x00))
                        pos++;
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x01");
                        return;
                    }
                    _source_addr_ton = _body[++pos];
                    _source_addr_npi = _body[++pos];
                    pos++;
                    saLength = 0;
                    while ((saLength < 20) && (_body[pos] != 0x00))
                    {
                        _source_addr[saLength] = _body[pos];
                        pos++;
                        saLength++;
                    }
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x02");
                        return;
                    }
                    _dest_addr_ton = _body[++pos];
                    _dest_addr_npi = _body[++pos];
                    pos++;
                    daLength = 0;
                    while ((daLength < 20) && (_body[pos] != 0x00))
                    {
                        _dest_addr[daLength] = _body[pos];
                        pos++;
                        daLength++;
                    }
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x03");
                        return;
                    }
                    _esm_class = _body[++pos];
                    switch (_esm_class)
                    {
                        case 0x00:
                            break;
                        case 0x04:
                            logMessage(LogLevels.LogSteps, "Delivery Receipt Received");
                            isDeliveryReceipt = true;
                            break;
                        case 0x40:
                            logMessage(LogLevels.LogSteps, "UDHI Indicator set");
                            isUdhiSet = true;
                            break;
                        default:
                            logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "Unknown esm_class for DELIVER_SM : " + Tools.GetHexFromByte(_esm_class));
                            break;
                    }
                    pos += 1;
                    _priority_flag = _body[++pos];
                    pos += 4;
                    _data_coding = _body[++pos];
                    pos += 1;
                    _sm_length = _body[++pos];
                    pos += 1;
                    if (_sm_length > 0)
                    {
                        _short_message = new byte[_sm_length];
                        Array.Copy(_body, pos, _short_message, 0, _sm_length);
                    }
                    if ((isDeliveryReceipt) || (isUdhiSet))
                    {
                        int _par_tag, _par_tag_length;
                        bool exit = false;
                        if (_sm_length > 0)
                        {
                            pos += _sm_length;
                        }
                        while ((pos < _length) && (exit == false))
                        {
                            if (Tools.Get2ByteIntFromArray(_body, pos, _length, out _par_tag) == false)
                            {
                                exit = true;
                                break;
                            }
                            pos += 2;
                            if (Tools.Get2ByteIntFromArray(_body, pos, _length, out _par_tag_length) == false)
                            {
                                exit = true;
                                break;
                            }
                            pos += 2;
                            switch (_par_tag)
                            {
                                case 0x020C:
                                    if (((pos + _par_tag_length - 1) <= _length) && (_par_tag_length == 2))
                                    {
                                        byte[] temp = new byte[_par_tag_length];
                                        Array.Copy(_body, pos, temp, 0, _par_tag_length);
                                        pos += _par_tag_length;
                                        sar_msg_ref_num = BitConverter.ToInt16(temp, 0);
                                        logMessage(LogLevels.LogSteps, "sar_msg_ref_num : " + sar_msg_ref_num);
                                    }
                                    else
                                        exit = true;

                                    break;
                                case 0x020E:
                                    if ((pos <= _length) && (_par_tag_length == 1))
                                    {
                                        sar_total_segments = _body[pos];
                                        logMessage(LogLevels.LogSteps, "sar_total_segments : " + Convert.ToString(sar_total_segments));
                                        pos++;
                                    }
                                    else
                                        exit = true;

                                    break;
                                case 0x020F:
                                    if ((pos <= _length) && (_par_tag_length == 1))
                                    {
                                        sar_segment_seqnum = _body[pos];
                                        logMessage(LogLevels.LogSteps, "sar_segment_seqnum : " + Convert.ToString(sar_segment_seqnum));
                                        pos++;
                                    }
                                    else
                                        exit = true;

                                    break;
                                case 0x0427:
                                    if ((pos <= _length) && (_par_tag_length == 1))
                                    {
                                        _message_state = _body[pos];
                                        logMessage(LogLevels.LogSteps, "Message state : " + Convert.ToString(_message_state));
                                        pos++;
                                    }
                                    else
                                        exit = true;

                                    break;
                                case 0x001E:
                                    if ((pos + _par_tag_length - 1) <= _length)
                                    {
                                        _receipted_message_id = new byte[_par_tag_length];
                                        Array.Copy(_body, pos, _receipted_message_id, 0, _par_tag_length);
                                        _receipted_message_id_len = Convert.ToByte(_par_tag_length);
                                        pos += _par_tag_length;
                                        logMessage(LogLevels.LogSteps, "Delivered message id : " + Tools.ConvertArrayToString(_receipted_message_id, _receipted_message_id_len - 1));
                                    }
                                    else
                                        exit = true;
                                    break;
                                default:
                                    if ((pos + _par_tag_length - 1) <= _length)
                                        pos += _par_tag_length;
                                    else
                                        exit = true;
                                    logMessage(LogLevels.LogDebug, "_par_tag : " + Convert.ToString(_par_tag));
                                    logMessage(LogLevels.LogDebug, "_par_tag_length : " + Convert.ToString(_par_tag_length));
                                    break;

                            }
                        }
                        logMessage(LogLevels.LogDebug, "Delivery Receipt Processing Exit value - " + Convert.ToString(exit));
                        if (exit)
                            isDeliveryReceipt = false;
                    }

                    if ((sar_msg_ref_num > 0) && ((sar_total_segments > 0) && ((sar_segment_seqnum > 0) && (isUdhiSet))))
                    {
                        lock (sarMessages.SyncRoot)
                        {
                            SortedList tArr = new SortedList();
                            if (sarMessages.ContainsKey(sar_msg_ref_num))
                            {
                                tArr = (SortedList)sarMessages[sar_msg_ref_num];
                                if (tArr.ContainsKey(sar_segment_seqnum))
                                    tArr[sar_segment_seqnum] = _short_message;
                                else
                                    tArr.Add(sar_segment_seqnum, _short_message);
                                bool isFull = true;
                                byte i;
                                for (i = 1; i <= sar_total_segments; i++)
                                {
                                    if (!tArr.ContainsKey(i))
                                    {
                                        isFull = false;
                                        break;
                                    }//if
                                }//for
                                if (!isFull)
                                {
                                    sarMessages[sar_msg_ref_num] = tArr;
                                    sendDeliverSmResp(sequence_number, StatusCodes.ESME_ROK);
                                    return;
                                }
                                else
                                {
                                    _sm_length = 0;
                                    for (i = 1; i <= sar_total_segments; i++)
                                    {
                                        _sm_length += ((byte[])tArr[i]).Length;
                                    }
                                    _short_message = new byte[_sm_length + 100];
                                    _sm_length = 0;
                                    for (i = 1; i <= sar_total_segments; i++)
                                    {
                                        Array.Copy(((byte[])tArr[i]), 0, _short_message, _sm_length, ((byte[])tArr[i]).Length);
                                        _sm_length += ((byte[])tArr[i]).Length;
                                    }
                                    sarMessages.Remove(sar_msg_ref_num);
                                }
                            }//if
                            else
                            {
                                tArr.Add(sar_segment_seqnum, _short_message);
                                sarMessages.Add(sar_msg_ref_num, tArr);
                                sendDeliverSmResp(sequence_number, StatusCodes.ESME_ROK);
                                return;
                            }
                        }//lock
                    }
                    string to;
                    string from;
                    string textString;

                    string hexString = "";

                    byte messageState = 0;
                    string receiptedMessageID = "";

                    to = Encoding.ASCII.GetString(_dest_addr, 0, daLength);
                    from = Encoding.ASCII.GetString(_source_addr, 0, saLength);
                    if (_data_coding == 8) //USC2
                        textString = Encoding.BigEndianUnicode.GetString(_short_message, 0, _sm_length);
                    else
                        textString = Encoding.UTF8.GetString(_short_message, 0, _sm_length);
                    hexString = Tools.ConvertArrayToHexString(_short_message, _sm_length);

                    if (isDeliveryReceipt)
                    {
                        isDeliveryReceipt = true;
                        messageState = _message_state;
                        receiptedMessageID = Encoding.ASCII.GetString(_receipted_message_id, 0, _receipted_message_id_len - 1); ;
                    }

                    DeliverSmEventArgs evArg = new DeliverSmEventArgs(sequence_number, to, from, textString, hexString, _data_coding, _esm_class, isDeliveryReceipt, messageState, receiptedMessageID);
                    processDeliverSm(evArg);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm | " + ex.ToString());
                    sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                }

            }//decodeAndProcessDeliverSm

            private void decodeAndProcessDataSm(int sequence_number, byte[] _body, int _length)
            {
                if (_length < 17)
                {
                    sendDeliverSmResp(sequence_number, StatusCodes.ESME_RINVCMDLEN);
                    return;
                }
                try
                {
                    bool isDeliveryReceipt = false;
                    byte _source_addr_ton, _source_addr_npi, _dest_addr_ton, _dest_addr_npi;
                    byte _priority_flag, _data_coding, _esm_class;
                    byte[] _source_addr = new byte[21];
                    byte[] _dest_addr = new byte[21];
                    byte saLength, daLength;
                    byte[] _short_message = new byte[254];
                    int pos;

                    /////////////////////////////////////
                    /// Message Delivery Params
                    /// 
                    byte[] _receipted_message_id = new byte[254];
                    byte _receipted_message_id_len = 0;
                    byte _message_state = 0;


                    pos = 0;
                    while ((pos < 5) && (_body[pos] != 0x00))
                        pos++;
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x04");
                        return;
                    }
                    _source_addr_ton = _body[++pos];
                    _source_addr_npi = _body[++pos];
                    pos++;
                    saLength = 0;
                    while ((saLength < 20) && (_body[pos] != 0x00))
                    {
                        _source_addr[saLength] = _body[pos];
                        pos++;
                        saLength++;
                    }
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x05");
                        return;
                    }
                    _dest_addr_ton = _body[++pos];
                    _dest_addr_npi = _body[++pos];
                    pos++;
                    daLength = 0;
                    while ((daLength < 20) && (_body[pos] != 0x00))
                    {
                        _dest_addr[daLength] = _body[pos];
                        pos++;
                        daLength++;
                    }
                    if (_body[pos] != 0x00)
                    {
                        sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                        logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm returned UNKNOWNERR on 0x06");
                        return;
                    }
                    _esm_class = _body[++pos];
                    switch (_esm_class)
                    {
                        case 0x00:
                            break;
                        case 0x04:
                            logMessage(LogLevels.LogSteps, "Delivery Receipt Received");
                            isDeliveryReceipt = true;
                            break;
                        default:
                            logMessage(LogLevels.LogSteps | LogLevels.LogWarnings, "Unknown esm_class for DATA_SM : " + Tools.GetHexFromByte(_esm_class));
                            break;
                    }
                    pos += 1;
                    _priority_flag = _body[++pos];
                    pos += 4;
                    _data_coding = _body[++pos];
                    pos += 1;
                    if (isDeliveryReceipt)
                    {
                        int _par_tag, _par_tag_length;
                        bool exit = false;
                        while ((pos < _length) && (exit == false))
                        {
                            if (Tools.Get2ByteIntFromArray(_body, pos, _length, out _par_tag) == false)
                            {
                                exit = true;
                                break;
                            }
                            pos += 2;
                            if (Tools.Get2ByteIntFromArray(_body, pos, _length, out _par_tag_length) == false)
                            {
                                exit = true;
                                break;
                            }
                            pos += 2;
                            switch (_par_tag)
                            {
                                case 0x0427:
                                    if ((pos <= _length) && (_par_tag_length == 1))
                                    {
                                        _message_state = _body[pos];
                                        logMessage(LogLevels.LogSteps, "Message state : " + Convert.ToString(_message_state));
                                        pos++;
                                    }
                                    else
                                        exit = true;

                                    break;
                                case 0x001E:
                                    if ((pos + _par_tag_length - 1) <= _length)
                                    {
                                        _receipted_message_id = new byte[_par_tag_length];
                                        Array.Copy(_body, pos, _receipted_message_id, 0, _par_tag_length);
                                        _receipted_message_id_len = Convert.ToByte(_par_tag_length);
                                        pos += _par_tag_length;
                                        logMessage(LogLevels.LogSteps, "Delivered message id : " + Tools.ConvertArrayToString(_receipted_message_id, _receipted_message_id_len - 1));
                                    }
                                    else
                                        exit = true;
                                    break;
                                default:
                                    if ((pos + _par_tag_length - 1) <= _length)
                                        pos += _par_tag_length;
                                    else
                                        exit = true;
                                    logMessage(LogLevels.LogDebug, "_par_tag : " + Convert.ToString(_par_tag));
                                    logMessage(LogLevels.LogDebug, "_par_tag_length : " + Convert.ToString(_par_tag_length));
                                    break;

                            }
                        }
                        logMessage(LogLevels.LogDebug, "Delivery Receipt Processing Exit value - " + Convert.ToString(exit));
                        if (exit)
                            isDeliveryReceipt = false;
                    }

                    string to;
                    string from;
                    string textString = "";

                    string hexString = "";

                    byte messageState = 0;
                    string receiptedMessageID = "";

                    to = Encoding.ASCII.GetString(_dest_addr, 0, daLength);
                    from = Encoding.ASCII.GetString(_source_addr, 0, saLength);

                    if (isDeliveryReceipt)
                    {
                        isDeliveryReceipt = true;
                        messageState = _message_state;
                        receiptedMessageID = Encoding.ASCII.GetString(_receipted_message_id, 0, _receipted_message_id_len - 1); ;
                    }

                    DeliverSmEventArgs evArg = new DeliverSmEventArgs(sequence_number, to, from, textString, hexString, _data_coding, _esm_class, isDeliveryReceipt, messageState, receiptedMessageID);
                    processDeliverSm(evArg);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "decodeAndProcessDeliverSm | " + ex.ToString());
                    sendDeliverSmResp(sequence_number, StatusCodes.ESME_RUNKNOWNERR);
                }

            }//decodeAndProcessDataSm

            private void checkSystemIntegrity(Object state)
            {
                try
                {
                    if (mustBeConnected)
                    {
                        if (connectionState== ConnectionStates.SMPP_BINDED)
                        {
                            if (enquireLinkSendTime <= enquireLinkResponseTime)
                            {
                                enquireLinkSendTime = DateTime.Now;
                                sendEnquireLink(smscArray.currentSMSC.SequenceNumber);
                                lastSeenConnected = DateTime.Now;
                            }
                            else
                            {
                                logMessage(LogLevels.LogSteps | LogLevels.LogErrors, "checkSystemIntegrity | ERROR #9001 - no response to Enquire Link");
                                tryToReconnect();
                            }
                        }
                        else
                        {
                            if (((TimeSpan)(DateTime.Now - lastSeenConnected)).TotalSeconds > KernelParameters.CanBeDisconnected)
                            {
                                logMessage(LogLevels.LogSteps | LogLevels.LogErrors, "checkSystemIntegrity | ERROR #9002 - diconnected more than " + Convert.ToString(KernelParameters.CanBeDisconnected) + " seconds");
                                lastSeenConnected = DateTime.Now.AddSeconds(KernelParameters.CanBeDisconnected);
                                tryToReconnect();
                            }
                        }
                    }
                    else
                    {
                        if (connectionState== ConnectionStates.SMPP_UNBIND_SENT)
                        {
                            if (((TimeSpan)(DateTime.Now - lastPacketSentTime)).TotalSeconds > KernelParameters.WaitPacketResponse)
                            {
                                disconnectSocket();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "checkSystemIntegrity | " + ex.ToString());
                }

            }//checkSystemIntegrity

            public void sendDeliverSmResp(int sequence_number, int command_status)
            {
                try
                {
                    byte[] _PDU = new byte[17];

                    Tools.CopyIntToArray(17, _PDU, 0);

                    Tools.CopyIntToArray(0x80000005, _PDU, 4);

                    Tools.CopyIntToArray(command_status, _PDU, 8);

                    Tools.CopyIntToArray(sequence_number, _PDU, 12);

                    _PDU[16] = 0;

                    Send(_PDU, 17);

                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "sendDeliverSmResp | " + ex.ToString());
                }
            }//sendDeliverSmResp

            private void sendGenericNack(int sequence_number, int command_status)
            {
                try
                {
                    byte[] _PDU = new byte[16];

                    Tools.CopyIntToArray(16, _PDU, 0);

                    Tools.CopyIntToArray(0x80000000, _PDU, 4);

                    Tools.CopyIntToArray(command_status, _PDU, 8);

                    Tools.CopyIntToArray(sequence_number, _PDU, 12);

                    Send(_PDU, 16);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "sendGenericNack | " + ex.ToString());
                }

            }//sendGenericNack

            private void sendEnquireLink(int sequence_number)
            {
                try
                {
                    byte[] _PDU = new byte[16];
                    Tools.CopyIntToArray(16, _PDU, 0);

                    Tools.CopyIntToArray(0x00000015, _PDU, 4);

                    Tools.CopyIntToArray(0x00000000, _PDU, 8);

                    Tools.CopyIntToArray(sequence_number, _PDU, 12);

                    Send(_PDU, 16);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "sendEnquireLink | " + ex.ToString());
                }
            }//sendEnquireLink

            private void sendEnquireLinkResp(int sequence_number)
            {
                try
                {
                    byte[] _PDU = new byte[16];
                    Tools.CopyIntToArray(16, _PDU, 0);

                    Tools.CopyIntToArray(0x80000015, _PDU, 4);

                    Tools.CopyIntToArray(0x00000000, _PDU, 8);

                    Tools.CopyIntToArray(sequence_number, _PDU, 12);

                    Send(_PDU, 16);
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "sendEnquireLink | " + ex.ToString());
                }
            }//sendEnquireLink

            private void sendCallback(IAsyncResult ar)
            {
                try
                {
                    // Retrieve the socket from the state object.
                    Socket client = (Socket)ar.AsyncState;

                    // Complete sending the data to the remote device.
                    int bytesSent = client.EndSend(ar);
                    logMessage(LogLevels.LogSteps | LogLevels.LogPdu, "Sent " + bytesSent.ToString() + " bytes");
                }
                catch (Exception ex)
                {
                    logMessage(LogLevels.LogExceptions, "Send | " + ex.ToString());
                }
            }//Send

            private byte getAddrTon(string address)
            {
                int i;
                for (i = 0; i < address.Length; i++)
                    if (!Char.IsDigit(address, i))
                    {
                        return AddressTons.Alphanumeric;
                    }
                if (address.Length == nationalNumberLength)
                    return AddressTons.National;
                if (address.Length > nationalNumberLength)
                    return AddressTons.International;
                return AddressTons.Unknown;
            }//getAddrTon
            private byte getAddrNpi(string address)
            {
                int i;
                for (i = 0; i < address.Length; i++)
                    if (!Char.IsDigit(address, i))
                    {
                        return AddressNpis.Unknown;
                    }
                return AddressNpis.ISDN;
            }//getAddrTon
            #endregion Private Functions

        }//SMPPClient

    
}
