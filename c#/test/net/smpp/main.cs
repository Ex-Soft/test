//#define TEST_SUBMIT_SM
//#define TEST_LONG_MESSAGE
#define TEST_QUERY_SM
#define SEND_QUERY_SM

using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TestSMPP
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

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				const int
					MAX_LENGTH = 256;

				byte[]
					data = new byte[MAX_LENGTH];

				int
					sequence_number = 1,
					pos = 4;
				
				CopyIntToArray(CommandId.bind_transceiver, data, pos); // command_id
				pos += 4;

				CopyIntToArray(CommandStatus.ESME_ROK, data, pos); // command_status
				pos += 4;

				CopyIntToArray(sequence_number, data, pos); // sequence_number
				pos += 4;

				byte[]
					tmpData = System.Text.Encoding.ASCII.GetBytes("Entri"); // system_id

				Array.Copy(tmpData, 0, data, pos, tmpData.Length);
				pos += tmpData.Length;
				data[pos++] = 0;

				tmpData = System.Text.Encoding.ASCII.GetBytes("73Nsy2Mw"); // password
				Array.Copy(tmpData, 0, data, pos, tmpData.Length);
				pos += tmpData.Length;
				data[pos++] = 0;

				data[pos++] = 0; // system_type
				data[pos++] = 0x34; // interface_version
				data[pos++] = 0x05; // addr_ton
				data[pos++] = 0x0; // addr_npi

				tmpData = System.Text.Encoding.ASCII.GetBytes("N3"); // address_range
				Array.Copy(tmpData, 0, data, pos, tmpData.Length);
				pos += tmpData.Length;
				data[pos++] = 0;

				CopyIntToArray(pos, data, 0); // command_length
				
				TcpClient
					TcpClient = new TcpClient();

				bool
					Send;

				NetworkStream
					NetworkStream = null;

				BinaryWriter
					bw;

				int
					command_length,
					command_status,
					sequence_number_;

				uint
					command_id;

				short
					OptionalParameterTagId,
					OptionalParameterTagLength;

				int
					OptionalParameterTagValueInt;

				if (Send = File.Exists("send"))
				{
					TcpClient.Connect("212.58.160.139", 16001);

					NetworkStream = TcpClient.GetStream();

					NetworkStream.Write(data, 0, pos);

					data = new byte[MAX_LENGTH];
					NetworkStream.Read(data, 0, MAX_LENGTH);

					bw = new BinaryWriter(new FileStream("resp" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
					bw.Write(data, 0, ConvertArrayToInt(data, 0));
					bw.Close();

					command_length = ConvertArrayToInt(data, pos = 0);
					pos += 4;
					command_id = ConvertArrayToUInt(data, pos);
					pos += 4;
					command_status = ConvertArrayToInt(data, pos);
					pos += 4;
					sequence_number_ = ConvertArrayToInt(data, pos);
					pos += 4;

					string
						system_id = GetStringFromArray(data, pos);

					pos += system_id.Length + 1;
					OptionalParameterTagId = ConvertArrayToShort(data,pos);
					pos += 2;
					OptionalParameterTagLength = ConvertArrayToShort(data, pos);
					pos += 2;

					OptionalParameterTagValueInt = (int)data[pos];

					if (command_id == CommandId.bind_transceiver_resp)
						Console.WriteLine("bind_transceiver_resp");
					Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}system_id: {5}{0}OptionalParameterTagId: {6:X4}{0}OptionalParameterTagLength: {7:X4}{0}OptionalParameterTagValueInt: {8:X2}", Environment.NewLine, command_length, command_id, command_status, sequence_number_, system_id, OptionalParameterTagId, OptionalParameterTagLength, OptionalParameterTagValueInt);
					if (OptionalParameterTagId == OptionalParameterTag.sc_interface_version)
						Console.WriteLine("sc_interface_version");
					Console.WriteLine();
				}

				//---------------------------------------------------------------------------

				#if TEST_SUBMIT_SM
					sequence_number++;
					pos = 4;

					CopyIntToArray(CommandId.submit_sm, data, pos); // command_id
					pos += 4;

					CopyIntToArray(CommandStatus.ESME_ROK, data, pos); // command_status
					pos += 4;

					CopyIntToArray(sequence_number, data, pos); // sequence_number
					pos += 4;

					data[pos++] = 0; // service_type
					data[pos++] = 0x05; // source_addr_ton
					data[pos++] = 0x0; // source_addr_npi

					tmpData = System.Text.Encoding.ASCII.GetBytes("N3"); // source_addr
					Array.Copy(tmpData, 0, data, pos, tmpData.Length);
					pos += tmpData.Length;
					data[pos++] = 0;
				
					data[pos++] = 0x1; // dest_addr_ton
					data[pos++] = 0x1; // dest_addr_npi

					tmpData = System.Text.Encoding.ASCII.GetBytes("380638588373"); // destination_addr
					Array.Copy(tmpData, 0, data, pos, tmpData.Length);
					pos += tmpData.Length;
					data[pos++] = 0;

					data[pos++] = 0x0; // esm_class
					data[pos++] = 0x0; // protocol_id
					data[pos++] = 0x0; // priority_flag
					data[pos++] = 0x0; // schedule_delivery_time
					data[pos++] = 0x0; // validity_period
					data[pos++] = 0x1; // registered_delivery
					data[pos++] = 0x0; // replace_if_present_flag
					data[pos++] = 0x8; // data_coding
					data[pos++] = 0x0; // sm_default_msg_id
				
					string
						msg = "Test Тест";

					tmpData = System.Text.Encoding.BigEndianUnicode.GetBytes(msg);

					// sm_length
					data[pos++] =
					#if !TEST_LONG_MESSAGE
						(byte)tmpData.Length
					#else
						0
					#endif
					;

					#if TEST_LONG_MESSAGE
						data[pos++] = 0; //short_message

						CopyShortToArray(OptionalParameterTag.sar_msg_ref_num, data, pos); // sar_msg_ref_num 0x020c Parameter Tag
						pos += 2;
						CopyShortToArray(2, data, pos); // sar_msg_ref_num Length
						pos += 2;
						CopyShortToArray(1, data, pos); // sar_msg_ref_num Value
						pos += 2;

						CopyShortToArray(OptionalParameterTag.sar_segment_seqnum, data, pos); // sar_segment_seqnum 0x020f Parameter Tag
						pos += 2;
						CopyShortToArray(1, data, pos); // sar_segment_seqnum Length
						pos += 2;
						data[pos++] = 0x1; // sar_segment_seqnum Value

						CopyShortToArray(OptionalParameterTag.sar_total_segments, data, pos); // sar_total_segments 0x020e Parameter Tag
						pos += 2;
						CopyShortToArray(1, data, pos); // sar_total_segments Length
						pos += 2;
						data[pos++] = 0x1; // sar_total_segments Value

						CopyShortToArray(OptionalParameterTag.more_messages_to_send, data, pos); // more_messages_to_send 0x0426 Parameter Tag
						pos += 2;
						CopyShortToArray(1, data, pos); // more_messages_to_send Length
						pos += 2;
						data[pos++] = 0x0; // more_messages_to_send Value

						CopyShortToArray(OptionalParameterTag.message_payload, data, pos); // message_payload 0x0424 Parameter Tag
						pos += 2;
						CopyShortToArray((short)tmpData.Length, data, pos); // Length
						pos += 2;
					#endif
					Array.Copy(tmpData, 0, data, pos, tmpData.Length); // short_message || Value
					pos += tmpData.Length;

					CopyIntToArray(pos, data, 0); // command_length

					bw = new BinaryWriter(new FileStream("requ" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
					if (File.Exists("bitconverter"))
						bw.Write(BitConverter.ToString(data, 0, data.Length));
					else
						bw.Write(data, 0, pos);
					bw.Close();

					if(Send)
					{
						NetworkStream.Write(data, 0, pos);

						data = new byte[MAX_LENGTH];
						NetworkStream.Read(data, 0, MAX_LENGTH);

						bw = new BinaryWriter(new FileStream("resp" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
						bw.Write(data, 0, ConvertArrayToInt(data, 0));
						bw.Close();

						command_length = ConvertArrayToInt(data, 0);
						command_id = ConvertArrayToUInt(data, 4);
						command_status = ConvertArrayToInt(data, 8);
						sequence_number_ = ConvertArrayToInt(data, 12);

						string
							message_id = Encoding.ASCII.GetString(data, 16, command_length - 16);

						if (command_id == CommandId.submit_sm_resp)
							Console.WriteLine("submit_sm_resp");
						Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}message_id: {5}{0}", Environment.NewLine, command_length, command_id, command_status, sequence_number_, message_id);
					}
				#endif

				#if TEST_QUERY_SM
					sequence_number++;
					pos = 4;

					CopyIntToArray(CommandId.query_sm, data, pos); // command_id
					pos += 4;

					CopyIntToArray(CommandStatus.ESME_ROK, data, pos); // command_status
					pos += 4;

					CopyIntToArray(sequence_number, data, pos); // sequence_number
					pos += 4;

					tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685841539"); // message_id (1) delivery_sm
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685387265"); // message_id (2) 0x07
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685411138"); // message_id (4) 0x07
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685368558"); // message_id (8) 0x07
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685438462"); // message_id (9) delivery_sm
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685552565"); // message_id (c) 0x07
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685531922"); // message_id (d) delivery_sm
					//tmpData = System.Text.Encoding.ASCII.GetBytes("SM1685604003"); // message_id (0x15) delivery_sm
					Array.Copy(tmpData, 0, data, pos, tmpData.Length);
					pos += tmpData.Length;
					data[pos++] = 0;

					data[pos++] = 0x05; // source_addr_ton
					data[pos++] = 0x0; // source_addr_npi

					tmpData = System.Text.Encoding.ASCII.GetBytes("N3"); // source_addr
					Array.Copy(tmpData, 0, data, pos, tmpData.Length);
					pos += tmpData.Length;
					data[pos++] = 0;

					CopyIntToArray(pos, data, 0); // command_length

					bw = new BinaryWriter(new FileStream("requ" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
					if (File.Exists("bitconverter"))
						bw.Write(BitConverter.ToString(data, 0, data.Length));
					else
						bw.Write(data, 0, pos);
					bw.Close();

					if(Send)
					{
						#if SEND_QUERY_SM
							NetworkStream.Write(data, 0, pos);
						#endif

						data = new byte[MAX_LENGTH];
						NetworkStream.Read(data, 0, MAX_LENGTH);

						bw = new BinaryWriter(new FileStream("resp" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
						bw.Write(data, 0, ConvertArrayToInt(data, 0));
						bw.Close();

						command_length = ConvertArrayToInt(data, pos = 0);
						pos += 4;
						command_id = ConvertArrayToUInt(data, pos);
						pos += 4;
						command_status = ConvertArrayToInt(data, pos);
						pos += 4;
						sequence_number_ = ConvertArrayToInt(data, pos);
						pos += 4;

						switch (command_id)
						{
							case CommandId.query_sm_resp:
							{
								string
									message_id = GetStringFromArray(data, pos);

								pos += message_id.Length + 1;

								string
									final_date = data[pos] == 0 ? string.Empty : Encoding.ASCII.GetString(data, pos, 17);

								pos += data[pos] == 0 ? 1 : 17;

								int
									message_state = data[pos++],
									error_code = data[pos];

								Console.WriteLine("query_sm_resp");
								Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}message_id: {5}{0}final_date: {6}{0}message_state: {7:X2}{0}error_code: {8:X2}{0}", Environment.NewLine, command_length, command_id, command_status, sequence_number_, message_id, final_date, message_state, error_code);

								break;
							}
							case CommandId.deliver_sm:
							{
								string
									service_type = GetStringFromArray(data, pos);

								pos += service_type.Length + 1;

								int
									source_addr_ton = data[pos++],
									source_addr_npi = data[pos++];

								string
									source_addr = GetStringFromArray(data, pos);

								pos += source_addr.Length + 1;

								int
									dest_addr_ton = data[pos++],
									dest_addr_npi = data[pos++];

								string
									destination_addr = GetStringFromArray(data, pos);

								pos += destination_addr.Length + 1;

								int
									esm_class = data[pos++],
									protocol_id = data[pos++],
									priority_flag = data[pos++],
									schedule_delivery_time = data[pos++],
									validity_period = data[pos++],
									registered_delivery = data[pos++],
									replace_if_present_flag = data[pos++],
									data_coding = data[pos++],
									sm_default_msg_id = data[pos++],
									sm_length = data[pos++];

								string
									short_message = Encoding.ASCII.GetString(data, pos, sm_length);

								pos += short_message.Length;

								short
									OptionalParameterTagId1 = ConvertArrayToShort(data, pos);

								pos += 2;

								short
									OptionalParameterTagLength1 = ConvertArrayToShort(data, pos);

								pos += 2;

								int
									OptionalParameterTagValue1 = data[pos++];

								short
									OptionalParameterTagId2 = ConvertArrayToShort(data, pos);

								pos += 2;

								short
									OptionalParameterTagLength2 = ConvertArrayToShort(data, pos);

								pos += 2;

								string
									OptionalParameterTagValue2 = GetStringFromArray(data, pos);

								Console.WriteLine("deliver_sm");
								Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}service_type: {5}{0}source_addr_ton: {6:X2}{0}source_addr_npi: {7:X2}{0}source_addr: {8}{0}dest_addr_ton: {9:X2}{0}dest_addr_npi: {10:X2}{0}destination_addr: {11}{0}esm_class: {12:X2}{0}protocol_id: {13:X2}{0}priority_flag: {14:X2}{0}registered_delivery: {15:X2}{0}data_coding: {16:X2}{0}sm_length: {17:X2}{0}short_message: {18}{0}message_state: {19:X2}{0}receipted_message_id: {20}{0}", Environment.NewLine, command_length, command_id, command_status, sequence_number_, service_type, source_addr_ton, source_addr_npi, source_addr, dest_addr_ton, dest_addr_npi, destination_addr, esm_class, protocol_id, priority_flag, registered_delivery, data_coding, sm_length, short_message, OptionalParameterTagValue1, OptionalParameterTagValue2);

								pos = 4;

								CopyIntToArray(CommandId.deliver_sm_resp, data, pos); // command_id
								pos += 4;

								CopyIntToArray(CommandStatus.ESME_ROK, data, pos); // command_status
								pos += 4;

								CopyIntToArray(sequence_number_, data, pos); // sequence_number
								pos += 4;

								data[pos++] = 0x0; // message_id

								CopyIntToArray(pos, data, 0); // command_length

								if (Send)
								{
									NetworkStream.Write(data, 0, pos);
									#if SEND_QUERY_SM
										data = new byte[MAX_LENGTH];
										NetworkStream.Read(data, 0, MAX_LENGTH);

										bw = new BinaryWriter(new FileStream("resp" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
										bw.Write(data, 0, ConvertArrayToInt(data, 0));
										bw.Close();

										command_length = ConvertArrayToInt(data, pos = 0);
										pos += 4;
										command_id = ConvertArrayToUInt(data, pos);
										pos += 4;
										command_status = ConvertArrayToInt(data, pos);
										pos += 4;
										sequence_number_ = ConvertArrayToInt(data, pos);
										pos += 4;

										string
											message_id = GetStringFromArray(data, pos);

										pos += message_id.Length + 1;

										string
											final_date = data[pos] == 0 ? string.Empty : Encoding.ASCII.GetString(data, pos, 17);

										pos += data[pos] == 0 ? 1 : 17;

										int
											message_state = data[pos++],
											error_code = data[pos];

										Console.WriteLine("query_sm_resp");
										Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}message_id: {5}{0}final_date: {6}{0}message_state: {7:X2}{0}error_code: {8:X2}{0}", Environment.NewLine, command_length, command_id, command_status, sequence_number_, message_id, final_date, message_state, error_code);
									#endif
								}

								break;
							}
						}
					}
				#endif

				//---------------------------------------------------------------------------

				sequence_number++;
				pos = 4;

				CopyIntToArray(CommandId.unbind, data, pos); // command_id
				pos += 4;

				CopyIntToArray(CommandStatus.ESME_ROK, data, pos); // command_status
				pos += 4;

				CopyIntToArray(sequence_number, data, pos); // sequence_number
				pos += 4;

				CopyIntToArray(pos, data, 0); // command_length

				if (Send)
				{
					NetworkStream.Write(data, 0, pos);

					data = new byte[MAX_LENGTH];
					NetworkStream.Read(data, 0, MAX_LENGTH);

					bw = new BinaryWriter(new FileStream("resp" + sequence_number, FileMode.Create, FileAccess.Write), System.Text.Encoding.ASCII);
					bw.Write(data, 0, ConvertArrayToInt(data, 0));
					bw.Close();

					command_length = ConvertArrayToInt(data, 0);
					command_id = ConvertArrayToUInt(data, 4);
					command_status = ConvertArrayToInt(data, 8);
					sequence_number_ = ConvertArrayToInt(data, 12);

					if (command_id == CommandId.unbind_resp)
						Console.WriteLine("unbind_resp");
					Console.WriteLine("command_length: {1:X8}{0}command_id: {2:X8}{0}command_status: {3:X8}{0}sequence_number: {4:X8}{0}", Environment.NewLine, command_length, command_id, command_status, sequence_number_);

					TcpClient.Close();
				}

				Console.WriteLine("oB!");
			}
			catch (Exception eException)
			{
				Console.WriteLine(eException.GetType().FullName + Environment.NewLine + "Message: " + eException.Message + Environment.NewLine + (eException.InnerException != null && !string.IsNullOrEmpty(eException.InnerException.Message) ? "InnerException.Message" + eException.InnerException.Message + Environment.NewLine : string.Empty) + "StackTrace:" + Environment.NewLine + eException.StackTrace);
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

		public static void CopyShortToArray(short x, byte[] ar, int pos)
		{
			byte[] arTmp;
			ConvertShortToArray(x, out arTmp);
			Array.Copy(arTmp, 0, ar, pos, 2);
		}

		public static void ConvertIntToArray(uint x, out byte[] ar)
		{
			ar = new byte[4];
			ar[3] = Convert.ToByte(x & 0xFF);
			ar[2] = Convert.ToByte((x >> 8) & 0xFF);
			ar[1] = Convert.ToByte((x >> 16) & 0xFF);
			ar[0] = Convert.ToByte((x >> 24) & 0xFF);
		}

		public static void ConvertIntToArray(int x, out byte[] ar)
		{
			ar = new byte[4];
			ar[3] = Convert.ToByte(x & 0xFF);
			ar[2] = Convert.ToByte((x >> 8) & 0xFF);
			ar[1] = Convert.ToByte((x >> 16) & 0xFF);
			ar[0] = Convert.ToByte((x >> 24) & 0xFF);
		}

		public static void ConvertShortToArray(short x, out byte[] ar)
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

		public static short ConvertArrayToShort(byte[] ar, int pos)
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

		public static string GetStringFromArray(byte[] ar, int index)
		{
			int
				i = index;

			while (ar[i++] != 0) ;

			return Encoding.ASCII.GetString(ar, index, i - index - 1);
		}
	}
}
