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
 * File Name: Constants.cs
 * 
 * File Authors:
 * 		Balan Name, http://balan.name
 */
namespace EasySMPP
{
    public class LogLevels
    {
        public const int LogPdu = 1;
        public const int LogSteps = 2;
        public const int LogWarnings = 4;
        public const int LogErrors = 8;
        public const int LogExceptions = 16;
        public const int LogDebug = 32;
    }//LogLevels

    public class ConnectionStates
    {
        public const int SMPP_SOCKET_CONNECT_SENT = 1;
        public const int SMPP_SOCKET_CONNECTED = 2;
        public const int SMPP_BIND_SENT = 3;
        public const int SMPP_BINDED = 4;
        public const int SMPP_UNBIND_SENT = 5;
        public const int SMPP_UNBINDED = 6;
        public const int SMPP_SOCKET_DISCONNECTED = 7;
    }//ConnectionStates

    public class StatusCodes
    {
        public const int ESME_ROK = 0x00000000; // No Error
        public const int ESME_RINVMSGLEN = 0x00000001; // Message Length is invalid
        public const int ESME_RINVCMDLEN = 0x00000002; // Command Length is invalid
        public const int ESME_RINVCMDID = 0x00000003; // Invalid Command ID
        public const int ESME_RINVBNDSTS = 0x00000004; // Incorrect BIND Status for given command
        public const int ESME_RALYBND = 0x00000005; // ESME Already in Bound State
        public const int ESME_RINVPRTFLG = 0x00000006; // Invalid Priority Flag
        public const int ESME_RINVREGDLVFLG = 0x00000007; // Invalid Registered Delivery Flag
        public const int ESME_RSYSERR = 0x00000008; // System Error
        public const int ESME_RINVSRCADR = 0x0000000A; // Invalid Source Address
        public const int ESME_RINVDSTADR = 0x0000000B; // Invalid Dest Addr
        public const int ESME_RINVMSGID = 0x0000000C; // Message ID is invalid
        public const int ESME_RBINDFAIL = 0x0000000D; // bind Failed
        public const int ESME_RINVPASWD = 0x0000000E; // Invalid Password
        public const int ESME_RINVSYSID = 0x0000000F; // Invalid System ID
        public const int ESME_RCANCELFAIL = 0x00000011; // Cancel SM Failed
        public const int ESME_RREPLACEFAIL = 0x00000013; // Replace SM Failed
        public const int ESME_RMSGQFUL = 0x00000014; // Message Queue Full
        public const int ESME_RINVSERTYP = 0x00000015; // Invalid Service Type
        public const int ESME_RINVNUMDESTS = 0x00000033; // Invalid number of destinations
        public const int ESME_RINVDLNAME = 0x00000034; // Invalid Distribution List name
        public const int ESME_RINVDESTFLAG = 0x00000040; // Destination flag is invalid(submit_multi)
        public const int ESME_RINVSUBREP = 0x00000042; // Invalid `submit with replace? request(i.e. submit_sm with replace_if_present_flag set)
        public const int ESME_RINVESMCLASS = 0x00000043; // Invalid esm_class field data
        public const int ESME_RCNTSUBDL = 0x00000044; // Cannot Submit to Distribution List
        public const int ESME_RSUBMITFAIL = 0x00000045; // submit_sm or submit_multi failed
        public const int ESME_RINVSRCTON = 0x00000048; // Invalid Source address TON
        public const int ESME_RINVSRCNPI = 0x00000049; // Invalid Source address NPI
        public const int ESME_RINVDSTTON = 0x00000050; // Invalid Destination address TON
        public const int ESME_RINVDSTNPI = 0x00000051; // Invalid Destination address NPI
        public const int ESME_RINVSYSTYP = 0x00000053; // Invalid system_type field
        public const int ESME_RINVREPFLAG = 0x00000054; // Invalid replace_if_present flag
        public const int ESME_RINVNUMMSGS = 0x00000055; // Invalid number of messages
        public const int ESME_RTHROTTLED = 0x00000058; // Throttling error (ESME has exceeded allowed message limits)
        public const int ESME_RINVSCHED = 0x00000061; // Invalid Scheduled Delivery Time
        public const int ESME_RINVEXPIRY = 0x00000062; // Invalid message validity period (Expiry time)
        public const int ESME_RINVDFTMSGID = 0x00000063; // Predefined Message Invalid or Not Found
        public const int ESME_RX_T_APPN = 0x00000064; // ESME Receiver Temporary App Error Code
        public const int ESME_RX_P_APPN = 0x00000065; // ESME Receiver Permanent App Error Code
        public const int ESME_RX_R_APPN = 0x00000066; // ESME Receiver Reject Message Error Code
        public const int ESME_RQUERYFAIL = 0x00000067; // query_sm request failed
        public const int ESME_RINVOPTPARSTREAM = 0x000000C0; // Error in the optional part of the PDU Body.
        public const int ESME_ROPTPARNOTALLWD = 0x000000C1; // Optional Parameter not allowed
        public const int ESME_RINVPARLEN = 0x000000C2; // Invalid Parameter Length.
        public const int ESME_RMISSINGOPTPARAM = 0x000000C3; // Expected Optional Parameter missing
        public const int ESME_RINVOPTPARAMVAL = 0x000000C4; // Invalid Optional Parameter Value
        public const int ESME_RDELIVERYFAILURE = 0x000000FE; // Delivery Failure (used for data_sm_resp)
        public const int ESME_RUNKNOWNERR = 0x000000FF; // Unknown Error
    }//StatusCodes

    public class PriorityFlags
    {
        public const byte Bulk = 0;
        public const byte Normal = 1;
        public const byte Urgent = 2;
        public const byte VeryUrgent = 3;
    }//PriorityFlags

    public class DeliveryReceipts
    {
        public const byte NoReceipt = 0;
        public const byte OnSuccessOrFailure = 1;
        public const byte OnFailure = 2;
    }//DeliveryReceipt

    public class ReplaceIfPresentFlags
    {
        public const byte DoNotReplace = 0;
        public const byte Replace = 1;
    }//ReplaceIfPresentFlag

    public class AddressTons
    {
        public const byte Unknown = 0;
        public const byte International = 1;
        public const byte National = 2;
        public const byte NetworkSpecific = 3;
        public const byte SubscriberNumber = 4;
        public const byte Alphanumeric = 5;
        public const byte Abbreviated = 6;
    }//AddressTon

    public class AddressNpis
    {
        public const byte Unknown = 0;
        public const byte ISDN = 1;
    }//AddressTon


}