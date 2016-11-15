/* RoaminSMPP: SMPP communication library
 * Copyright (C) 2004, 2005 Christopher M. Bouzek
 *
 * This file is part of RoaminSMPP.
 *
 * RoaminSMPP is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, version 3 of the License.
 *
 * RoaminSMPP is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lessert General Public License for more details.
 *
 * You should have received a copy of the GNU Lesser General Public License
 * along with RoaminSMPP.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections;
using RoaminSMPP;
using RoaminSMPP.Packet;
using RoaminSMPP.Packet.Request;
using RoaminSMPP.Packet.Response;

namespace RoaminSMPP.Utility
{
	/// <summary>
	/// Takes incoming packets from an input stream and generates
	/// PDUs based on the command field.
	/// </summary>
	public class PduFactory
	{
		/// <summary>
		/// Constructor.
		/// </summary>
		public PduFactory()
		{
		}
		
		/// <summary>
		/// Factory method to generate the PDU.
		/// </summary>
		/// <param name="incomingPDUs">The SMSC response.</param>
		/// <returns>The PDU.</returns>
		public Queue GetPduQueue(byte[] incomingPDUs)
		{
			Queue packetQueue = new Queue();
			//get the first packet
			byte[] response = null;
			Pdu packet = null;
			int newLength = 0;
			//this needs to start at zero
			uint CommandLength = 0;
			
			//look for multiple PDUs in the response
			while(incomingPDUs.Length > 0)
			{
				//determine if we have another response PDU after this one
				newLength =(int)(incomingPDUs.Length - CommandLength);
				//could be empty data or it could be a PDU
				if(newLength > 0)
				{
					//get the next PDU
					response = Pdu.TrimResponsePdu(incomingPDUs);
					//there could be none...
					if(response.Length > 0)
					{
						//get the command length and command ID
						CommandLength = Pdu.DecodeCommandLength(response);
						//trim the packet down so we can look for more PDUs
						long length = incomingPDUs.Length - CommandLength;
						byte[] newRemainder = new byte[length];
						Array.Copy(incomingPDUs, CommandLength, newRemainder, 0, length);
						incomingPDUs = newRemainder;
						newRemainder = null;
						if(CommandLength > 0)
						{
							//process
							packet = GetPDU(response);
							if(packet != null)
								packetQueue.Enqueue(packet);
						}
					}
					else
					{
						//kill it off and return
						incomingPDUs = new Byte[0];
					}
				}
			}
			
			return packetQueue;
		}
		
		/// <summary>
		/// Gets a single PDU based on the response bytes.
		/// </summary>
		/// <param name="response">The SMSC response.</param>
		/// <returns>The PDU corresponding to the bytes.</returns>
		private Pdu GetPDU(byte[] response)
		{
			Pdu.CommandIdType commandID = Pdu.DecodeCommandId(response);
			Pdu packet;
			switch(commandID)
			{
				case Pdu.CommandIdType.alert_notification:
					packet = new SmppAlertNotification(response);
					break;
				case Pdu.CommandIdType.bind_receiver_resp:
				case Pdu.CommandIdType.bind_transceiver_resp:
				case Pdu.CommandIdType.bind_transmitter_resp:
					packet = new SmppBindResp(response);
					break;
				case Pdu.CommandIdType.cancel_sm_resp:
					packet = new SmppCancelSmResp(response);
					break;
				case Pdu.CommandIdType.data_sm_resp:
					packet = new SmppDataSmResp(response);
					break;
				case Pdu.CommandIdType.deliver_sm:
					packet = new SmppDeliverSm(response);
					break;
				case Pdu.CommandIdType.enquire_link_resp:
					packet = new SmppEnquireLinkResp(response);
					break;
				case Pdu.CommandIdType.outbind:
					packet = new SmppOutbind(response);
					break;
				case Pdu.CommandIdType.query_sm_resp:
					packet = new SmppQuerySmResp(response);
					break;
				case Pdu.CommandIdType.replace_sm_resp:
					packet = new SmppReplaceSmResp(response);
					break;
				case Pdu.CommandIdType.submit_multi_resp:
					packet = new SmppSubmitMultiResp(response);
					break;
				case Pdu.CommandIdType.submit_sm_resp:
					packet = new SmppSubmitSmResp(response);
					break;
				case Pdu.CommandIdType.unbind_resp:
					packet = new SmppUnbindResp(response);
					break;
				default:
					packet = null;
					break;
			}

			return packet;
		}
	}
}
