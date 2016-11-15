//#define TEST_LONG_MESSAGE

using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

namespace smppII
{
	public class CommandStatus
	{
		public const int
			ESME_ROK = 0x00000000,			// No Error
			ESME_RINVSRCADR = 0x0000000A,	// Invalid Source Address
			ESME_RUNKNOWNERR = 0x000000FF;	// Unknown Error
	}

	public class CommandId
	{
		public const uint
			generic_nack = 0x80000000,
			bind_receiver = 0x00000001,
			bind_receiver_resp = 0x80000001,
			bind_transmitter = 0x00000002,
			bind_transmitter_resp = 0x80000002,
			query_sm = 0x00000003,
			query_sm_resp = 0x80000003,
			submit_sm = 0x00000004,
			submit_sm_resp = 0x80000004,
			deliver_sm = 0x00000005,
			deliver_sm_resp = 0x80000005,
			unbind = 0x00000006,
			unbind_resp = 0x80000006,
			replace_sm = 0x00000007,
			replace_sm_resp = 0x80000007,
			cancel_sm = 0x00000008,
			cancel_sm_resp = 0x80000008,
			bind_transceiver = 0x00000009,
			bind_transceiver_resp = 0x80000009;
	}

	public class OptionalParameterTag
	{
		public const short
			sar_msg_ref_num = 0x020c,
			sar_segment_seqnum = 0x020f,
			sar_total_segments = 0x020e,
			more_messages_to_send = 0x0426,
			message_payload = 0x0424,
			sc_interface_version = 0x0210,
			message_state = 0x0427,
			receipted_message_id = 0x001E;
	}

	public class MessageState
	{
		public const int
			ENROUTE = 1,
			DELIVERED = 2,
			EXPIRED = 3,
			DELETED = 4,
			UNDELIVERABLE = 5,
			ACCEPTED = 6,
			UNKNOWN = 7,
			REJECTED = 8;
	}

	class Programm
	{
		const int
			MAX_LENGTH = 256;

		static int
			sequence_number = 0;

		static byte[]
			buffer = new byte[MAX_LENGTH];

		static ManualResetEvent
			UnbindDone = new ManualResetEvent(false);

		static bool
			IsSend = false;

		static void Main(string[] args)
		{
			IsSend = args.Length > 0;

			Socket
				socket = null;

			try
			{
				ConnectToSMSC(ref socket);
				UnbindDone.WaitOne();
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
			}
			finally
			{
				if (socket != null && socket.Connected)
				{
					Console.WriteLine("finally: Socket.Shutdown()/Socket.Close()");
					socket.Shutdown(SocketShutdown.Both);
					socket.Close();
				}
			}
		}

		static void ConnectToSMSC(ref Socket socket)
		{
			Console.WriteLine("ConnectToSMSC");

			IPAddress
				ipAddress = IPAddress.Parse("212.58.160.139");

			IPEndPoint
				remoteEP = new IPEndPoint(ipAddress, 16001);

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), socket);
		}

		static void ConnectCallback(IAsyncResult ar)
		{
			Console.WriteLine("ConnectCallback");

			Socket
				socket = (Socket)ar.AsyncState;

			socket.EndConnect(ar);
			BindTransceiver(socket);
		}

		static void BindTransceiver(Socket socket)
		{
			Console.WriteLine("BindTransceiver");

			byte[]
				PDU = new byte[MAX_LENGTH];

			int
				pos;

			CopyIntToArray(CommandId.bind_transceiver, PDU, pos = 4); // command_id
			pos += 4;

			CopyIntToArray(CommandStatus.ESME_ROK, PDU, pos); // command_status
			pos += 4;

			CopyIntToArray(++sequence_number, PDU, pos); // sequence_number
			pos += 4;

			byte[]
				tmpData = System.Text.Encoding.ASCII.GetBytes("Entri"); // system_id

			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length);
			pos += tmpData.Length;
			PDU[pos++] = 0;

			tmpData = System.Text.Encoding.ASCII.GetBytes("73Nsy2Mw"); // password
			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length);
			pos += tmpData.Length;
			PDU[pos++] = 0;

			PDU[pos++] = 0; // system_type
			PDU[pos++] = 0x34; // interface_version
			PDU[pos++] = 0x05; // addr_ton
			PDU[pos++] = 0x0; // addr_npi

			tmpData = System.Text.Encoding.ASCII.GetBytes("N3"); // address_range
			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length);
			pos += tmpData.Length;
			PDU[pos++] = 0;

			CopyIntToArray(pos, PDU, 0); // command_length

			Send(PDU, socket, pos);
			Receive(socket);
		}

		static void SubmitSM(Socket socket)
		{
			Console.WriteLine("SubmitSM");

			byte[]
				PDU = new byte[MAX_LENGTH],
				tmpData;

			int
				pos;

			CopyIntToArray(CommandId.submit_sm, PDU, pos = 4); // command_id
			pos += 4;

			CopyIntToArray(CommandStatus.ESME_ROK, PDU, pos); // command_status
			pos += 4;

			CopyIntToArray(sequence_number, PDU, pos); // sequence_number
			pos += 4;

			PDU[pos++] = 0; // service_type
			PDU[pos++] = 0x05; // source_addr_ton
			PDU[pos++] = 0x0; // source_addr_npi

			tmpData = System.Text.Encoding.ASCII.GetBytes("N3"); // source_addr
			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length);
			pos += tmpData.Length;
			PDU[pos++] = 0;

			PDU[pos++] = 0x1; // dest_addr_ton
			PDU[pos++] = 0x1; // dest_addr_npi

			tmpData = System.Text.Encoding.ASCII.GetBytes("380638588373"); // destination_addr
			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length);
			pos += tmpData.Length;
			PDU[pos++] = 0;

			PDU[pos++] = 0x0; // esm_class
			PDU[pos++] = 0x0; // protocol_id
			PDU[pos++] = 0x0; // priority_flag
			PDU[pos++] = 0x0; // schedule_delivery_time
			PDU[pos++] = 0x0; // validity_period
			PDU[pos++] = 0x1; // registered_delivery
			PDU[pos++] = 0x0; // replace_if_present_flag
			PDU[pos++] = 0x8; // data_coding
			PDU[pos++] = 0x0; // sm_default_msg_id

			string
				msg = "Test Тест";

			tmpData = System.Text.Encoding.BigEndianUnicode.GetBytes(msg);

			// sm_length
			PDU[pos++] =
			#if !TEST_LONG_MESSAGE
				(byte)tmpData.Length
			#else
				0
			#endif
			;

			#if TEST_LONG_MESSAGE
				PDU[pos++] = 0; //short_message

				CopyShortToArray(OptionalParameterTag.sar_msg_ref_num, PDU, pos); // sar_msg_ref_num 0x020c Parameter Tag
				pos += 2;
				CopyShortToArray(2, PDU, pos); // sar_msg_ref_num Length
				pos += 2;
				CopyShortToArray(1, PDU, pos); // sar_msg_ref_num Value
				pos += 2;

				CopyShortToArray(OptionalParameterTag.sar_segment_seqnum, PDU, pos); // sar_segment_seqnum 0x020f Parameter Tag
				pos += 2;
				CopyShortToArray(1, PDU, pos); // sar_segment_seqnum Length
				pos += 2;
				PDU[pos++] = 0x1; // sar_segment_seqnum Value

				CopyShortToArray(OptionalParameterTag.sar_total_segments, PDU, pos); // sar_total_segments 0x020e Parameter Tag
				pos += 2;
				CopyShortToArray(1, PDU, pos); // sar_total_segments Length
				pos += 2;
				PDU[pos++] = 0x1; // sar_total_segments Value

				CopyShortToArray(OptionalParameterTag.more_messages_to_send, PDU, pos); // more_messages_to_send 0x0426 Parameter Tag
				pos += 2;
				CopyShortToArray(1, PDU, pos); // more_messages_to_send Length
				pos += 2;
				PDU[pos++] = 0x0; // more_messages_to_send Value

				CopyShortToArray(OptionalParameterTag.message_payload, PDU, pos); // message_payload 0x0424 Parameter Tag
				pos += 2;
				CopyShortToArray((short)tmpData.Length, PDU, pos); // Length
				pos += 2;
			#endif
			Array.Copy(tmpData, 0, PDU, pos, tmpData.Length); // short_message || Value
			pos += tmpData.Length;

			CopyIntToArray(pos, PDU, 0); // command_length

			Send(PDU, socket, pos);
			Receive(socket);
		}

		static void SubmitSMResp()
		{
			int
				_command_length,
				_command_status,
				_sequence_number,
				pos;

			uint
				_command_id;

			_command_length = ConvertArrayToInt(buffer, pos = 0);
			pos += 4;
			_command_id = ConvertArrayToUInt(buffer, pos);
			pos += 4;
			_command_status = ConvertArrayToInt(buffer, pos);
			pos += 4;
			_sequence_number = ConvertArrayToInt(buffer, pos);
			pos += 4;

			string
				MsgId = Encoding.ASCII.GetString(buffer, pos, _command_length - pos - 1);
		}

		static int DeliverSM()
		{
			int
				_command_length,
				_command_status,
				_sequence_number,
				pos;

			uint
				_command_id;

			_command_length = ConvertArrayToInt(buffer, pos = 0);
			pos += 4;
			_command_id = ConvertArrayToUInt(buffer, pos);
			pos += 4;
			_command_status = ConvertArrayToInt(buffer, pos);
			pos += 4;
			_sequence_number = ConvertArrayToInt(buffer, pos);
			pos += 4;

			string
				service_type = GetStringFromArray(buffer, pos);

			pos += service_type.Length + 1;

			int
				source_addr_ton = buffer[pos++],
				source_addr_npi = buffer[pos++];

			string
				source_addr = GetStringFromArray(buffer, pos);

			pos += source_addr.Length + 1;

			int
				dest_addr_ton = buffer[pos++],
				dest_addr_npi = buffer[pos++];

			string
				destination_addr = GetStringFromArray(buffer, pos);

			pos += destination_addr.Length + 1;

			int
				esm_class = buffer[pos++],
				protocol_id = buffer[pos++],
				priority_flag = buffer[pos++],
				schedule_delivery_time = buffer[pos++],
				validity_period = buffer[pos++],
				registered_delivery = buffer[pos++],
				replace_if_present_flag = buffer[pos++],
				data_coding = buffer[pos++],
				sm_default_msg_id = buffer[pos++],
				sm_length = buffer[pos++];

			string
				short_message = Encoding.ASCII.GetString(buffer, pos, sm_length);

			pos += short_message.Length;

			short
				OptionalParameterTagId1 = ConvertArrayToShort(buffer, pos);

			pos += 2;

			short
				OptionalParameterTagLength1 = ConvertArrayToShort(buffer, pos);

			pos += 2;

			int
				OptionalParameterTagValue1 = buffer[pos++];

			short
				OptionalParameterTagId2 = ConvertArrayToShort(buffer, pos);

			pos += 2;

			short
				OptionalParameterTagLength2 = ConvertArrayToShort(buffer, pos);

			pos += 2;

			string
				OptionalParameterTagValue2 = GetStringFromArray(buffer, pos);

			Console.WriteLine("deliver_sm");
			Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}service_type: {5}{0}source_addr_ton: {6:X2}{0}source_addr_npi: {7:X2}{0}source_addr: {8}{0}dest_addr_ton: {9:X2}{0}dest_addr_npi: {10:X2}{0}destination_addr: {11}{0}esm_class: {12:X2}{0}protocol_id: {13:X2}{0}priority_flag: {14:X2}{0}registered_delivery: {15:X2}{0}data_coding: {16:X2}{0}sm_length: {17:X2}{0}short_message: {18}{0}message_state: {19:X2}{0}receipted_message_id: {20}{0}", Environment.NewLine, _command_length, _command_id, _command_status, _sequence_number, service_type, source_addr_ton, source_addr_npi, source_addr, dest_addr_ton, dest_addr_npi, destination_addr, esm_class, protocol_id, priority_flag, registered_delivery, data_coding, sm_length, short_message, OptionalParameterTagValue1, OptionalParameterTagValue2);

			return _sequence_number;
		}

		static void DeliverSMResp(Socket socket, int sequence_number)
		{
			Console.WriteLine("DeliverSMResp");

			byte[]
				PDU = new byte[MAX_LENGTH];

			int
				pos;

			CopyIntToArray(CommandId.deliver_sm_resp, PDU, pos = 4); // command_id
			pos += 4;

			CopyIntToArray(CommandStatus.ESME_ROK, PDU, pos); // command_status
			pos += 4;

			CopyIntToArray(sequence_number, PDU, pos); // sequence_number
			pos += 4;

			PDU[pos++] = 0x0; // message_id

			CopyIntToArray(pos, PDU, 0); // command_length

			Send(PDU, socket, pos);
			Receive(socket);
		}

		static void Unbind(Socket socket)
		{
			Console.WriteLine("Unbind");

			byte[]
				PDU = new byte[MAX_LENGTH];

			int
				pos;

			CopyIntToArray(CommandId.unbind, PDU, pos = 4); // command_id
			pos += 4;

			CopyIntToArray(CommandStatus.ESME_ROK, PDU, pos); // command_status
			pos += 4;

			CopyIntToArray(++sequence_number, PDU, pos); // sequence_number
			pos += 4;

			CopyIntToArray(pos, PDU, 0); // command_length

			Send(PDU, socket, pos);
			Receive(socket);
		}

		static void Send(byte[] data, Socket socket, int n)
		{
			Console.WriteLine("Send");

			socket.BeginSend(data, 0, n, 0, new AsyncCallback(SendCallback), socket);
		}

		static void SendCallback(IAsyncResult ar)
		{
			Console.WriteLine("SendCallback");

			Socket
				socket = (Socket)ar.AsyncState;

			int
				bytesSent = socket.EndSend(ar);
		}

		static void Receive(Socket socket)
		{
			Console.WriteLine("Receive");

			socket.BeginReceive(buffer, 0, MAX_LENGTH, 0, new AsyncCallback(ReceiveCallback), socket);
		}

		static void ReceiveCallback(IAsyncResult ar)
		{
			Console.WriteLine("ReceiveCallback");

			Socket
				socket = (Socket)ar.AsyncState;

			int
				bytesRead = socket.EndReceive(ar);

			Console.WriteLine("Received {0} bytes", bytesRead);

			int
				_command_length,
				_command_status,
				_sequence_number,
				pos;

			uint
				_command_id;

			_command_length = ConvertArrayToInt(buffer, pos = 0);
			pos += 4;
			_command_id = ConvertArrayToUInt(buffer, pos);
			pos += 4;
			_command_status = ConvertArrayToInt(buffer, pos);
			pos += 4;
			_sequence_number = ConvertArrayToInt(buffer, pos);
			pos += 4;

			switch (_command_id)
			{
				case CommandId.bind_transceiver_resp:
				{
					Console.WriteLine("bind_transceiver_resp (command_status: {0:X4})", _command_status);

					if(IsSend)
						SubmitSM(socket);
					else
						Unbind(socket);

					break;
				}
				case CommandId.submit_sm_resp:
				{
					Console.WriteLine("submit_sm_resp (command_status: {0:X4})", _command_status);

					SubmitSMResp();
					Unbind(socket);

					break;
				}
				case CommandId.deliver_sm:
				{
					DeliverSMResp(socket, DeliverSM());

					break;
				}
				case CommandId.unbind_resp:
				{
					Console.WriteLine("unbind_resp (command_status: {0:X4})", _command_status);

					UnbindDone.Set();

					break;
				}
			}
		}

		public static void CopyIntToArray(uint x, byte[] ar, int pos)
		{
			byte[] arTmp;
			ConvertIntToArray(x, out arTmp);
			Array.Copy(arTmp, 0, ar, pos, 4);
		}

		public static void CopyIntToArray(int x, byte[] ar, int pos)
		{
			byte[] arTmp;
			ConvertIntToArray(x, out arTmp);
			Array.Copy(arTmp, 0, ar, pos, 4);
		}
		
		static void CopyShortToArray(short x, byte[] ar, int pos)
		{
			byte[] arTmp;
			ConvertShortToArray(x, out arTmp);
			Array.Copy(arTmp, 0, ar, pos, 2);
		}

		static void ConvertIntToArray(uint x, out byte[] ar)
		{
			ar = new byte[4];
			ar[3] = Convert.ToByte(x & 0xFF);
			ar[2] = Convert.ToByte((x >> 8) & 0xFF);
			ar[1] = Convert.ToByte((x >> 16) & 0xFF);
			ar[0] = Convert.ToByte((x >> 24) & 0xFF);
		}

		static void ConvertIntToArray(int x, out byte[] ar)
		{
			ar = new byte[4];
			ar[3] = Convert.ToByte(x & 0xFF);
			ar[2] = Convert.ToByte((x >> 8) & 0xFF);
			ar[1] = Convert.ToByte((x >> 16) & 0xFF);
			ar[0] = Convert.ToByte((x >> 24) & 0xFF);
		}

		static void ConvertShortToArray(short x, out byte[] ar)
		{
			ar = new byte[2];
			ar[1] = Convert.ToByte(x & 0xFF);
			ar[0] = Convert.ToByte((x >> 8) & 0xFF);
		}

		public static int ConvertArrayToInt(byte[] ar, int pos)
		{
			int
				result = ar[pos];

			for (int i = 1; i < 4; ++i)
			{
				result <<= 8;
				result |= ar[pos + i];
			}

			return result;
		}

		public static uint ConvertArrayToUInt(byte[] ar, int pos)
		{
			uint
				result = ar[pos];

			for (int i = 1; i < 4; ++i)
			{
				result <<= 8;
				result |= ar[pos + i];
			}

			return result;
		}

		static short ConvertArrayToShort(byte[] ar, int pos)
		{
			short
				result = ar[pos];

			for (int i = 1; i < 2; ++i)
			{
				result <<= 8;
				result |= ar[pos + i];
			}

			return result;
		}

		static string GetStringFromArray(byte[] ar, int index)
		{
			int
				i = index;

			while (ar[i++] != 0) ;

			return Encoding.ASCII.GetString(ar, index, i - index - 1);
		}
	}
}
