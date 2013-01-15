//
// This software was written and developed by Scott Ferguson.
// The current version can be found at http://www.forestmoon.com/Software/.
// Comments and suggestions are encouraged and can be sent to mailto:contact@forestmoon.com?subject=Software.
// This free software is distributed under the GNU General Public License.
// See http://www.gnu.org/licenses/gpl.html for details.
// This license restricts your usage of the software in derivative works.
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.IO;

namespace Dynamixel
{
    /// <summary>
    /// An ErrorStatus value is returned in a packet from a Dynamixel
    /// and also represents AlarmLED and AlarmShutdown conditions.
    /// </summary>
    [Flags]
    public enum ErrorStatus : byte
    {
        /// <summary>
        /// Input Voltage Error
        /// </summary>
        [Description("Input Voltage Error")]
        InputVoltage = 1,
        /// <summary>
        /// Angle Limit Error
        /// </summary>
        [Description("Angle Limit Error")]
        AngleLimit = 2,
        /// <summary>
        /// Overheating Error
        /// </summary>
        [Description("Overheating Error")]
        Overheating = 4,
        /// <summary>
        /// Range Error
        /// </summary>
        [Description("Range Error")]
        Range = 8,
        /// <summary>
        /// Checksum Error
        /// </summary>
        [Description("Checksum Error")]
        Checksum = 0x10,
        /// <summary>
        /// Overload Error
        /// </summary>
        [Description("Overload Error")]
        Overload = 0x20,
        /// <summary>
        /// Instruction Error
        /// </summary>
        [Description("Instruction Error")]
        Instruction = 0x40,
    }

    /// <summary>
    /// Values for standard baudrate settings for Dynamixels (BaudRate property).
    /// </summary>
    public enum BaudRate : byte
    {
        /// <summary>
        /// Baud Rate setting for 1 M bps.
        /// </summary>
        Baud_1000000 = 1,
        /// <summary>
        /// Baud Rate setting for 500 K bps.
        /// </summary>
        Baud_500000 = 3,
        /// <summary>
        /// Baud Rate setting for 400 K bps.
        /// </summary>
        Baud_400000 = 4,
        /// <summary>
        /// Baud Rate setting for 250 K bps.
        /// </summary>
        Baud_250000 = 7,
        /// <summary>
        /// Baud Rate setting for 200 K bps.
        /// </summary>
        Baud_200000 = 9,
        /// <summary>
        /// Baud Rate setting for 115200 bps.
        /// </summary>
        Baud_115200 = 0x10,
        /// <summary>
        /// Baud Rate setting for 57600 bps.
        /// </summary>
        Baud_57600 = 0x22,
        /// <summary>
        /// Baud Rate setting for 19200 bps.
        /// </summary>
        Baud_19200 = 0x67,
        /// <summary>
        /// Baud Rate setting for 9600 bps.
        /// </summary>
        Baud_9600 = 0xcf
    }

    /// <summary>
    /// Registers present on each Dynamixel.
    /// </summary>
    public enum Register : byte
    {
        /// <summary>
        /// Register number for Model Number.
        /// </summary>
        [Description("Model Number")]
        ModelNumber = 0,
        /// <summary>
        /// Register number for Firmware Version.
        /// </summary>
        [Description("Firmware Version")]
        FirmwareVersion = 2,
        /// <summary>
        /// Register number for Id.
        /// </summary>
        [Description("Id")]
        Id = 3,
        /// <summary>
        /// Register number for Baud Rate.
        /// </summary>
        [Description("Baud Rate")]
        BaudRate = 4,
        /// <summary>
        /// Register number for Return Delay.
        /// </summary>
        [Description("Return Delay")]
        ReturnDelay = 5,
        /// <summary>
        /// Register number for CW Angle Limit.
        /// </summary>
        [Description("CW Angle Limit")]
        CWAngleLimit = 6,
        /// <summary>
        /// Register number for CCW Angle Limit.
        /// </summary>
        [Description("CCW Angle Limit")]
        CCWAngleLimit = 8,
        /// <summary>
        /// Register number for Temperature Limit.
        /// </summary>
        [Description("Temperature Limit")]
        TemperatureLimit = 11,
        /// <summary>
        /// Register number for Low Voltage Limit.
        /// </summary>
        [Description("Low Voltage Limit")]
        LowVoltageLimit = 12,
        /// <summary>
        /// Register number for High Voltage Limit.
        /// </summary>
        [Description("High Voltage Limit")]
        HighVoltageLimit = 13,
        /// <summary>
        /// Register number for Max Torque.
        /// </summary>
        [Description("Max Torque")]
        MaxTorque = 14,
        /// <summary>
        /// Register number for Status Return Level.
        /// </summary>
        [Description("Status Return Level")]
        StatusReturnLevel = 16,
        /// <summary>
        /// Register number for Alarm Led.
        /// </summary>
        [Description("Alarm Led")]
        AlarmLed = 17,
        /// <summary>
        /// Register number for Alarm Shutdown.
        /// </summary>
        [Description("Alarm Shutdown")]
        AlarmShutdown = 18,
        /// <summary>
        /// Register number for Down Calibration.
        /// </summary>
        [Description("Down Calibration")]
        DownCalibration = 20,
        /// <summary>
        /// Register number for Up Calibration.
        /// </summary>
        [Description("Up Calibration")]
        UpCalibration = 22,
        /// <summary>
        /// Register number for Torque Enable.
        /// </summary>
        [Description("Torque Enable")]
        TorqueEnable = 24,
        /// <summary>
        /// Register number for LED.
        /// </summary>
        [Description("LED")]
        LED = 25,
        /// <summary>
        /// Register number for CW Compliance Margin.
        /// </summary>
        [Description("CW Compliance Margin")]
        CWComplianceMargin = 26,
        /// <summary>
        /// Register number for CCW Compliance Margin.
        /// </summary>
        [Description("CCW Compliance Margin")]
        CCWComplianceMargin = 27,
        /// <summary>
        /// Register number for CW Compliance Slope.
        /// </summary>
        [Description("CW Compliance Slope")]
        CWComplianceSlope = 28,
        /// <summary>
        /// Register number for CCW Compliance Slope.
        /// </summary>
        [Description("CCW Compliance Slope")]
        CCWComplianceSlope = 29,
        /// <summary>
        /// Register number for Goal Position.
        /// </summary>
        [Description("Goal Position")]
        GoalPosition = 30,
        /// <summary>
        /// Register number for Moving Speed.
        /// </summary>
        [Description("Moving Speed")]
        MovingSpeed = 32,
        /// <summary>
        /// Register number for Torque Limit.
        /// </summary>
        [Description("Torque Limit")]
        TorqueLimit = 34,
        /// <summary>
        /// Register number for Current Position.
        /// </summary>
        [Description("Current Position")]
        CurrentPosition = 36,
        /// <summary>
        /// Register number for Current Speed.
        /// </summary>
        [Description("Current Speed")]
        CurrentSpeed = 38,
        /// <summary>
        /// Register number for Current Load.
        /// </summary>
        [Description("Current Load")]
        CurrentLoad = 40,
        /// <summary>
        /// Register number for Current Voltage.
        /// </summary>
        [Description("Current Voltage")]
        CurrentVoltage = 42,
        /// <summary>
        /// Register number for Current Temperature.
        /// </summary>
        [Description("Current Temperature")]
        CurrentTemperature = 43,
        /// <summary>
        /// Register number for Registered Instruction.
        /// </summary>
        [Description("Registered Instruction")]
        RegisteredInstruction = 44,
        /// <summary>
        /// Register number for Moving.
        /// </summary>
        [Description("Moving")]
        Moving = 46,
        /// <summary>
        /// Register number for Lock.
        /// </summary>
        [Description("Lock")]
        Lock = 47,
        /// <summary>
        /// Register number for Punch.
        /// </summary>
        [Description("Punch")]
        Punch = 48,
    }

    /// <summary>
    /// Controls how Dynamixels respond to instructions (StatusReturnLevel property).
    /// NOTE: This library may not function properly unless Dynamixels are set to
    /// the default of 'RespondToAll'.
    /// </summary>
    public enum StatusReturnLevel : byte
    {
        /// <summary>
        /// Dynamixel will never respond to command packets.
        /// </summary>
        [Description("No Response")]
        NoResponse = 0,
        /// <summary>
        /// Dynamixel will respond only to ReadData packets.
        /// </summary>
        [Description("Respond To ReadData")]
        RespondToReadData = 1,
        /// <summary>
        /// Dynamixel will respond to all command packets.
        /// </summary>
        [Description("Respond To All")]
        RespondToAll = 2
    }

    /// <summary>
    /// Implements the communications interaction with Dynamixels on the network.
    /// </summary>
    /// <remarks>
    /// This class implements the very low level interface for access to a Dynamixel network.
    /// For most applications, the DynamixelNetwork and Dynamixel classes provide functionality
    /// at a more useful and higher level of abstraction.
    /// </remarks>
    public class DynamixelInterface
    {
        /// <summary>
        /// The stream for reading and writing bytes when communicating
        /// with the Dynamixel network.
        /// </summary>
        protected Stream Stream;

        /// <summary>
        /// The Dynamixel Id used to broadcast to all Dynamixels on the network.
        /// </summary>
        public const int BroadcastId = 254;

        /// <summary>
        /// The types of instructions that can be sent to Dynamixels using WriteInstruction.
        /// </summary>
        /// <seealso cref="WriteInstruction"/>
        protected enum Instruction : byte
        {
            /// <summary>
            /// Respond only with a status packet.
            /// </summary>
            Ping = 1,
            /// <summary>
            /// Read register data.
            /// </summary>
            ReadData = 2,
            /// <summary>
            /// Write register data.
            /// </summary>
            WriteData = 3,
            /// <summary>
            /// Delay writing register data
            /// until an Action instruction is received.
            /// </summary>
            RegWrite = 4,
            /// <summary>
            /// Perform pending RegWrite instructions.
            /// </summary>
            Action = 5,
            /// <summary>
            /// Reset all registers (including ID) to default values.
            /// </summary>
            Reset = 6,
            /// <summary>
            /// Write register data to multiple Dynamixels at once.
            /// </summary>
            SyncWrite = 0x83,
        }

        /// <summary>
        /// Returns a textual representation of the ErrorStatus value.
        /// </summary>
        /// <param name="errorType">The ErrorStatus value to examine.</param>
        /// <returns>A list with a text string for each error flagged in the ErrorStatus value.</returns>
        public static List<string> ErrorText(ErrorStatus errorType)
        {
            List<string> text = new List<string>();
            foreach (ErrorStatus e in Enum.GetValues(typeof(ErrorStatus)))
            {
                // check each ErrorStatus flag
                if ((errorType & e) != 0)
                {
                    // get a friendlier text string from the enum value's Description attribute
                    FieldInfo fi = e.GetType().GetField(e.ToString());
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    text.Add(attributes[0].Description);
                }
            }
            return text;
        }

        /// <summary>
        /// Return a Register's length.
        /// </summary>
        /// <param name="reg">The Register to examine.</param>
        /// <returns>The length of the Register (1 or 2 bytes).</returns>
        public static int RegisterLength(Register reg)
        {
            switch (reg)
            {
                case Register.ModelNumber:
                case Register.CWAngleLimit:
                case Register.CCWAngleLimit:
                case Register.MaxTorque:
                case Register.DownCalibration:
                case Register.UpCalibration:
                case Register.GoalPosition:
                case Register.MovingSpeed:
                case Register.TorqueLimit:
                case Register.CurrentPosition:
                case Register.CurrentSpeed:
                case Register.CurrentLoad:
                case Register.Punch:
                    return 2;
            }
            return 1;
        }

        /// <summary>
        /// Arguments passed to events responding to errors in return status packets.
        /// </summary>
        public class DynamixelErrorArgs : EventArgs
        {
            private int _Id;
            /// <summary>
            /// The Id of the Dynamixel reporting an error.
            /// </summary>
            public int Id { get { return _Id; } }

            private ErrorStatus _errorStatus;

            /// <summary>
            /// The ErrorStatus value being reported.
            /// </summary>
            public ErrorStatus ErrorStatus { get { return _errorStatus; } }

            /// <summary>
            /// Constructor.
            /// </summary>
            /// <param name="id">The Id of the Dynamixel reporting an error.</param>
            /// <param name="errorStatus">The ErrorStatus value being reported.</param>
            public DynamixelErrorArgs(int id, ErrorStatus errorStatus)
            {
                _Id = id;
                _errorStatus = errorStatus;
            }
        }

        /// <summary>
        /// An event handler for handling errors flagged in a return packet from a Dynamixel.
        /// </summary>
        public delegate void DynamixelErrorHandler(object sender, DynamixelErrorArgs e);

        /// <summary>
        /// An event for handling errors flagged in a return packet from a Dynamixel.
        /// </summary>
        public event DynamixelErrorHandler DynamixelError;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <remarks>
        /// This Stream supplied can be, for example, the BaseStream parameter of a SerialPort instance.
        /// </remarks>
        /// <param name="stream">The Stream used to exchange command and status packets with the Dynamixel network.</param>
        public DynamixelInterface(Stream stream)
        {
            Stream = stream;
        }

        private bool InErrorHandler;
        private int ErrorCnt1stHeaderByte;
        private int ErrorCnt2ndHeaderByte;
        private int ErrorCnt3rdHeaderByte;
        private int ErrorCntInvalidLength;
        private int ErrorCntUnexpectedID;
        private int ErrorCntUnexpectedLength;
        private long ResponseTotalElapsed;
        private long ResponseMaxElapsed;
        private long ResponseCount;

        /// <summary>
        /// Attempts to enter "Toss Mode" with a CM-5 connected to the stream.
        /// </summary>
        /// <returns>True if Toss Mode was successfully entered.</returns>
        /// <remarks>
        /// If the stream responds to a CR with a CID prompt indicating connection to
        /// a CM-5 in Manage Mode, then a 't' and CR are sent to enter Toss Mode.
        /// The CM-5 must first be manually placed in Managed mode by pressing the
        /// Mode button until the Manage LED is lit.
        /// If the CM-5 is responding, but not in Manage Mode an exception will be generated.
        /// Calling this method should generally be OK, even if not connected to a CM-5.
        /// </remarks>
        public bool EnterTossMode()
        {
            int state = 0;
            string s = "";
            int SaveTimeout = Stream.ReadTimeout;
            while (state < 5)
            {
                try
                {
                    switch (state)
                    {
                        case 0:
                            // send a CR and look for a response from a CM-5 in manage mode
                            Stream.WriteByte((byte)'\r');
                            state = 1;
                            break;
                        case 1:
                            // look for a response from a CM-5
                            s += (char)Stream.ReadByte();
                            if (s.Length >= 3 && s.Substring(s.Length - 3) == "[CM")
                            {
                                // a CM-5 that has just been put into manage mode
                                // will respond to the first CR with a version string, e.g. "[CM-5 Version 1.15]"
                                // lengthen the timeout because the CM-5 will scan for Dynamixels
                                Stream.ReadTimeout = 750;
                                state = 2;
                            }
                            if (s.Length >= 3 && s.Substring(s.Length - 3) == "[CI")
                            {
                                // a CM-5 in manage mode that has already scanned will respond with a
                                // prompt string containing the ID of the current Dynamixel, e.g. "[CID:001(0x01)]"
                                // restore the shorter timeout
                                Stream.ReadTimeout = SaveTimeout;
                                state = 3;
                            }
                            break;
                        case 2:
                            s += (char)Stream.ReadByte();
                            if (s.Length >= 3 && s.Substring(s.Length - 3) == "[CI")
                            {
                                // a CM-5 in manage mode that has already scanned will respond with a
                                // prompt string containing the ID of the current Dynamixel, e.g. "[CID:001(0x01)]"
                                // restore the shorter timeout
                                Stream.ReadTimeout = SaveTimeout;
                                state = 3;
                            }
                            break;
                        case 3:
                            s += (char)Stream.ReadByte();
                            if (s.Length >= 2 && s.Substring(s.Length - 2) == "] ")
                            {
                                // found the end of the CID prompt
                                // put the CM-5 in Toss Mode
                                Stream.WriteByte((byte)'t');
                                Stream.WriteByte((byte)'\r');
                                state = 4;
                            }
                            break;
                        case 4:
                            s += (char)Stream.ReadByte();
                            if (s.Length >= 9 && s.Substring(s.Length - 9) == "Toss Mode")
                            {
                                // found the "Toss Mode" response verification
                                // we're good to go
                                state = 5;
                            }
                            break;
                    }
                }
                catch (Exception)
                {
                    Stream.ReadTimeout = SaveTimeout;
                    if (state > 1)
                    {
                        // if we saw prompt, but timed out in later stages
                        // then it is a CM-5 but probably in Play Mode or Program Mode
                        throw new Exception("CM-5 detected, but not in Manage Mode");
                    }
                    break;
                }
            }
            return state == 5;
        }

        /// <summary>
        /// Return a textual dump of interesting statistics.
        /// </summary>
        /// <returns>
        /// A list of strings representing lines of interesting statistics.
        /// </returns>
        public List<string> DumpStatistics()
        {
            List<string> list = new List<string>();
            if (ResponseCount != 0)
            {
                list.Add(string.Format("Average ms per Dynamixel response: {0:F1}", (double)ResponseTotalElapsed / (double)ResponseCount));
                list.Add(string.Format("Maximum ms per Dynamixel response: {0}", ResponseMaxElapsed));
            }
            if (ErrorCnt1stHeaderByte != 0)
                list.Add(string.Format("1st Header Byte: {0}", ErrorCnt1stHeaderByte));
            if (ErrorCnt2ndHeaderByte != 0)
                list.Add(string.Format("2nd Header Byte: {0}", ErrorCnt2ndHeaderByte));
            if (ErrorCnt3rdHeaderByte != 0)
                list.Add(string.Format("3rd Header Byte: {0}", ErrorCnt3rdHeaderByte));
            if (ErrorCntInvalidLength != 0)
                list.Add(string.Format("Invalid Length: {0}", ErrorCntInvalidLength));
            if (ErrorCntUnexpectedID != 0)
                list.Add(string.Format("Unexpected ID: {0}", ErrorCntUnexpectedID));
            if (ErrorCntUnexpectedLength != 0)
                list.Add(string.Format("Unexpected Length: {0}", ErrorCntUnexpectedLength));
            return list;
        }

        /// <summary>
        /// Read a raw packet with basic structure validation.
        /// </summary>
        /// <param name="id">The id from the packet if valid, or 0xFF if not.</param>
        /// <returns>The data present in the packet, or null if none.</returns>
        /// <exception cref="TimeoutException">
        /// A TimeoutException is the only expected Exception, since any other packet error
        /// results in a retry and wait until valid packet data is received.
        /// If the return packet is actually corrupted and never arrives, a timeout will occur.
        /// </exception>
        protected byte[] ReadPacket(out int id)
        {
            // ReadPacket is only ever called immediately following a WriteInstruction (sent packet)
            // So we can use this opportunity to time the response from the Dynamixel
            System.Diagnostics.Stopwatch watch = System.Diagnostics.Stopwatch.StartNew();

            // set an invalid id for error return cases
            id = 0xFF;
            //
            // status packet returned from Dynamixel servo:
            // 0      1      2    3        4       5            5 + data-length
            // [0xFF] [0xFF] [id] [length] [error] [...data...] [checksum]
            //
            // 1st header byte
            int b = Stream.ReadByte();

            // Stop the Stopwatch and record the statistics for later
            watch.Stop();
            ResponseTotalElapsed += watch.ElapsedMilliseconds;
            ResponseCount++;
            if (watch.ElapsedMilliseconds > ResponseMaxElapsed)
                ResponseMaxElapsed = watch.ElapsedMilliseconds;

            if (b != 0xFF)
            {
                ++ErrorCnt1stHeaderByte;
                return null;
            }
            // 2nd header byte
            b = Stream.ReadByte();
            if (b != 0xFF)
            {
                ++ErrorCnt2ndHeaderByte;
                return null;
            }
            // id (or 3rd header byte??)
            b = Stream.ReadByte();
            if (b == 0xFF)		// have seen a third header byte! not sure why/how
            {
                ++ErrorCnt3rdHeaderByte;
                b = Stream.ReadByte();
            }
            id = b;
            // packet length (includes data-length plus 2)
            int len = Stream.ReadByte() - 2;
            if (len < 0)
            {
                ++ErrorCntInvalidLength;
                return null;
            }
            // save the ErrorStatus
            ErrorStatus error = (ErrorStatus)Stream.ReadByte();
            byte[] data = null;
            if (len > 0)
            {
                // read the data, if any
                data = new byte[len];
                int offset = 0;
                while (len > 0)
                {
                    int cnt = Stream.Read(data, offset, len);
                    len -= cnt;
                    offset += cnt;
                }
            }
            // get the CheckSum byte
            // CONSIDER: Could validate the checksum and reject the packet.
            int CheckSum = Stream.ReadByte();
            // let anyone listening know about any errors reported in the packet
            // use the 'InErrorHandler' flag to avoid recursion from the user's handler
            if (error != 0 && DynamixelError != null && !InErrorHandler)
            {
                InErrorHandler = true;
                DynamixelError(this, new DynamixelErrorArgs(id, error));
                InErrorHandler = false;
            }
            return data;
        }

        /// <summary>
        /// Read a return packet from a Dynamixel, validating the id and length,
        /// retrying until a valid packet is received.
        /// </summary>
        /// <param name="id">The id expected in the packet.</param>
        /// <param name="length">The expected length of data (only) in the packet.</param>
        /// <returns>Data bytes in the packet, or null if none.</returns>
        protected byte[] ReadPacket(int id, int length)
        {
            // never expect a return packet from a broadcast instruction.
            if (id == BroadcastId)
                return null;
            do
            {
                // read a packet
                int pid;
                byte[] data = ReadPacket(out pid);
                // calculate the length, accounting for a null return
                int plen = data == null ? 0 : data.Length;
                // validate the id and length
                if (pid == id && plen == length)
                    return data;	// this is the normal return case
                // count errors (just FYI) and try again
                if (pid != id)
                    ++ErrorCntUnexpectedID;
                if (plen != length)
                    ++ErrorCntUnexpectedLength;
            } while (true);
        }

        /// <summary>
        /// Send a command packet instruction.
        /// </summary>
        /// <param name="id">The id of the destination dynamixel, or 'BroadcastId' to send to all.</param>
        /// <param name="ins">The Instruction to send.</param>
        /// <param name="parms">The parameters required by the instruction; or null if none.</param>
        protected void WriteInstruction(int id, Instruction ins, List<byte> parms)
        {
            List<byte> cmd = new List<byte>();
            //
            // command packet sent to Dynamixel servo:
            // 0      1      2    3        4            4 + data-length
            // [0xFF] [0xFF] [id] [length] [...data...] [checksum]
            //
            // header bytes & id
            cmd.Add(0xff);
            cmd.Add(0xff);
            cmd.Add((byte)id);
            // length is the data-length + 2
            cmd.Add((byte)(((parms != null) ? parms.Count : 0) + 2));
            // instruction
            cmd.Add((byte)ins);
            // parameter bytes, if any
            if (parms != null && parms.Count != 0)
                cmd.AddRange(parms);
            // calculate a checksum that doesn't include the header bytes
            int chksum = 0;
            for (int i = 2; i < cmd.Count; i++)
                chksum += cmd[i];
            // the checksum is inverted
            cmd.Add((byte)(~chksum & 0xff));
            // send the packet
            Stream.Write(cmd.ToArray(), 0, cmd.Count);
        }

        /// <summary>
        /// Check for the presence of a specific Dynamixel on the network.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to look for.</param>
        /// <returns>True iff the Dynamixel is present on the network.</returns>
        public bool Ping(int id)
        {
            // send the Ping instruction (no params)
            WriteInstruction(id, Instruction.Ping, null);
            try
            {
                ReadPacket(id, 0);
            }
            catch (TimeoutException)
            {
                // timeout just means the unit is not there
                return false;
            }
            return true;
        }

        /// <summary>
        /// Read register data from a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to read.</param>
        /// <param name="startAddress">The starting register to read from.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The byte data from the specified registers.</returns>
        /// <remarks>
        /// Some logical registers are one byte long and some are two.
        /// The count is for the number of bytes, not the number of registers.
        /// </remarks>
        protected byte[] ReadData(int id, Register startAddress, int count)
        {
            List<byte> cmd = new List<byte>();
            // the start address and count form the parameters for the command packet
            cmd.Add((byte)startAddress);
            cmd.Add((byte)count);
            WriteInstruction(id, Instruction.ReadData, cmd);
            return ReadPacket(id, count);
        }

        /// <summary>
        /// Read the value of one logical register from a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to read.</param>
        /// <param name="reg">The logical register to read.</param>
        /// <returns>The integer value of the logical register.</returns>
        /// <remarks>
        /// This function takes into account the byte length of the logical register.
        /// </remarks>
        public int ReadRegister(int id, Register reg)
        {
            byte[] data = ReadData(id, reg, RegisterLength(reg));
            if (data.Length == 1)
                return data[0];
            return (data[1] << 8) + data[0];
        }

        /// <summary>
        /// Read the value of multiple logical registers from a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to read.</param>
        /// <param name="regFirst">The first logical register to read.</param>
        /// <param name="regLast">The last logical register to read.</param>
        /// <returns>An array of register values.</returns>
        /// <remarks>
        /// This function takes into account the byte length of the logical register.
        /// </remarks>
        public int[] ReadRegisters(int id, Register regFirst, Register regLast)
        {
            int byteCount = (int)regLast + RegisterLength(regLast) - (int)regFirst;
            Register[] regs = (Register[])Enum.GetValues(typeof(Register));
            int first = Array.FindIndex(regs, delegate(Register r) { return r == regFirst; });
            int last = Array.FindIndex(regs, delegate(Register r) { return r == regLast; });
            int[] values = new int[last - first + 1];
            byte[] data = ReadData(id, regFirst, byteCount);
            for (int i = first; i <= last; i++)
            {
                Register reg = regs[i];
                int l = RegisterLength(reg);
                int offset = (int)reg - (int)regFirst;
                if (l == 1)
                    values[i - first] = data[offset];
                else
                    values[i - first] = (data[offset + 1] << 8) + data[offset];
            }
            return values;
        }

        /// <summary>
        /// Write register data to a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to write.</param>
        /// <param name="startAddress">The starting register to write to.</param>
        /// <param name="parms">The data to be written.</param>
        /// <param name="deferred">If true, the Dynamixel will store the request until an Action command is received.</param>
        /// <remarks>
        /// The length of the 'parms' data will determine the number of sequential registers being written to.
        /// The 'deferred' flag allows many Dynamixels to be written to, deferring the actual
        /// write to the register until an Action instruction is sent.
        /// </remarks>
        protected void WriteData(int id, Register startAddress, byte[] parms, bool deferred)
        {
            List<byte> cmd = new List<byte>();
            cmd.Add((byte)startAddress);
            cmd.AddRange(parms);
            WriteInstruction(id, deferred ? Instruction.RegWrite : Instruction.WriteData, cmd);
            // a RegWrite instruction will not return a status packet
            if (!deferred)
                ReadPacket(id, 0);
        }

        /// <summary>
        /// Write the value of one logical register to a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to write.</param>
        /// <param name="reg">The logical register to write.</param>
        /// <param name="value">The integer value to write.</param>
        /// <param name="deferred">Whether or not to defer until an Action instruction is sent.</param>
        /// <remarks>
        /// This function takes into account the byte length of the logical register.
        /// </remarks>
        public void WriteRegister(int id, Register reg, int value, bool deferred)
        {
            if (RegisterLength(reg) == 1)
                WriteData(id, reg, new byte[] { (byte)value }, deferred);
            else
                WriteData(id, reg, new byte[] { (byte)(value & 0xFF), (byte)(value >> 8) }, deferred);
        }

        /// <summary>
        /// Broadcasts an Action instruction for all Dynamixels with deferred writes pending.
        /// </summary>
        public void Action()
        {
            WriteInstruction(BroadcastId, Instruction.Action, null);
        }

        /// <summary>
        /// Reset a Dynamixel.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to reset.</param>
        /// <remarks>
        /// This function should be used carefully, if at all.
        /// It resets the unit ID to 1, so careful planning is required to to
        /// avoid collisions on a network with more than one Dynamixel.
        /// </remarks>
        public void Reset(int id)
        {
            WriteInstruction(id, Instruction.Reset, null);
            ReadPacket(id, 0);
        }

        /// <summary>
        /// Write to multiple registers on multiple Dynamixels using one instruction.
        /// </summary>
        /// <param name="startAddress">The starting register to write to.</param>
        /// <param name="numberOfDynamixels">The number of Dynamixels being addressed.</param>
        /// <param name="parms">The data being written, including the id and data for each Dynamixel.</param>
        /// <remarks>
        /// This function provides the most efficient way of updating the same registers on each
        /// of many different Dynaixels with different values at the same time.
        /// The length of the 'parms' data will determine the number of sequential registers being written to.
        /// For each Dynamixel the 'parms' data must include the id followed by the register data.
        /// </remarks>
        public void SyncWrite(Register startAddress, int numberOfDynamixels, List<byte> parms)
        {
            if ((parms.Count % numberOfDynamixels) != 0)
                throw new ArgumentException("Dyanmixel SyncWrite parms Length error");
            int len = parms.Count / numberOfDynamixels - 1;
            List<byte> cmd = new List<byte>();
            cmd.Add((byte)startAddress);
            cmd.Add((byte)len);
            cmd.AddRange(parms);
            WriteInstruction(BroadcastId, Instruction.SyncWrite, cmd);
        }

        /// <summary>
        /// Determine which Dynamixel IDs are present.
        /// </summary>
        /// <param name="startID">The id for the start of the search.</param>
        /// <param name="endID">The id for the end of the search.</param>
        /// <returns>A list of integer IDs of Dynamixels present on the network.</returns>
        /// <remarks>
        /// Scanning for all possible IDs (0 thru 254) can be time consuming.
        /// So if the range can be constrained to predetermined values it can speed up the process.
        /// </remarks>
        public List<int> ScanIds(int startID, int endID)
        {
            if (endID > 253 || endID < 0)
                throw new ArgumentException("endID must be 0 to 253");
            if (startID > endID || startID < 0)
                throw new OverflowException("startID must be 0 to endID");
            // Ping all IDs in the specified range and build a list of those found.
            List<int> ids = new List<int>();
            for (int id = startID; id <= endID; id++)
            {
                if (Ping(id))
                    ids.Add(id);
            }
            return ids;
        }
    }

    /// <summary>
    /// An abstract model of a Dynamixel network represented as a collection of Dynamixel objects.
    /// </summary>
    /// <remarks>
    /// This class wraps all of the low level functionality of the DynamixelInterface
    /// as a collection of higher level Dynamixel objects.
    /// </remarks>
    public class DynamixelNetwork : DynamixelInterface
    {
        // Map IDs to Dynamixels for those present on the network
        private Dictionary<int, Dynamixel> DynamixelMap = new Dictionary<int, Dynamixel>();

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <remarks>
        /// This Stream supplied can be, for example, the BaseStream parameter of a SerialPort instance.
        /// </remarks>
        /// <param name="stream">The Stream used to exchange command and status packets with the Dynamixel network.</param>
        public DynamixelNetwork(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Array access to the Dynamixels, indexed by id.
        /// </summary>
        /// <param name="id">The id of the Dynamixel to retrieve.</param>
        /// <returns>The Dynamixel with the specified id, or null if that id is not present on the network.</returns>
        public Dynamixel this[int id]
        {
            get
            {
                Dynamixel dyn;
                DynamixelMap.TryGetValue(id, out dyn);
                return dyn;
            }
        }

        /// <summary>
        /// A list of Dynamixels present on the network.
        /// </summary>
        public List<Dynamixel> Dynamixels
        {
            get
            {
                // build the list from the map
                List<Dynamixel> list = new List<Dynamixel>();
                foreach (KeyValuePair<int, Dynamixel> d in DynamixelMap)
                {
                    list.Add(d.Value);
                }
                return list;
            }
        }

        /// <summary>
        /// Scan the network to discover the Dynamixels present.
        /// </summary>
        /// <param name="startID">The id for the start of the search.</param>
        /// <param name="endID">The id for the end of the search.</param>
        /// <remarks>
        /// This function builds an internal list of Dynamixels present on the network.
        /// NOTE: Typically call this function only once per DynamixelNetwork instance
        /// since it will rebuild the list and create new Dynamixel instances to fill it,
        /// orphaning any previously retrieved Dynamixels.
        /// Scanning for all possible IDs (0 thru 254) can be time consuming.
        /// So if the range can be constrained to predetermined values it can speed up the process.
        /// </remarks>
        public void Scan(int startID, int endID)
        {
            DynamixelMap = new Dictionary<int, Dynamixel>();
            List<int> ids = ScanIds(startID, endID);
            foreach (int id in ids)
            {
                DynamixelMap.Add(id, new Dynamixel(id, this));
            }
        }

        private bool _Stopped;
        /// <summary>
        /// Stop all Dynamixels and prevent further movement
        /// activity for Dynamixels that are synchronized.
        /// </summary>
        public bool Stopped
        {
            get { return _Stopped; }
            set
            {
                if (value)
                {
                    // stop all Dynamixels
                    foreach (KeyValuePair<int, Dynamixel> d in DynamixelMap)
                        d.Value.Stop();
                    // make sure the synchronized ones perform
                    Synchronize();
                }
                _Stopped = value;
            }
        }

        /// <summary>
        /// Send GoalPosition and MovingSpeed data for all Dynamixels in Synchronized mode.
        /// </summary>
        /// <remarks>
        /// This function collects all the changed GoalPosition and MovingSpeed data that has been
        /// stored for each Dynamixel flagged as Synchronized and sends it all out at once
        /// using a SyncWrite instruction.
        /// If the network is 'Stopped', no data is sent.
        /// </remarks>
        public void Synchronize()
        {
            List<byte> data = null;
            int cnt = 0;
            foreach (KeyValuePair<int, Dynamixel> p in DynamixelMap)
            {
                Dynamixel d = p.Value;
                // ignore Dynamixels that have not changed since the last Synchronize call
                if (d.Changed)
                {
                    // only move if we're not in a Stopped state
                    if (!Stopped)
                    {
                        if (++cnt == 1)
                            data = new List<byte>();
                        data.Add((byte)d.Id);
                        data.Add((byte)(d.GoalPosition & 0xFF));
                        data.Add((byte)(d.GoalPosition >> 8));
                        data.Add((byte)(d.MovingSpeed & 0xFF));
                        data.Add((byte)(d.MovingSpeed >> 8));
                    }
                    // clear each 'Changed' flag regardless
                    d.Changed = false;
                }
            }
            if (cnt != 0)
                SyncWrite(Register.GoalPosition, cnt, data);
        }

        /// <summary>
        /// Write the value of one logical register to all Dynamixels.
        /// </summary>
        /// <param name="reg">The logical register to write.</param>
        /// <param name="value">The integer value to write.</param>
        /// <remarks>
        /// Updates the cache value of the register for all Dynamixels.
        /// </remarks>
        public void BroadcastRegister(Register reg, int value)
        {
            // set the cache value for each dynamixel
            foreach (KeyValuePair<int, Dynamixel> d in DynamixelMap)
            {
                d.Value[reg] = value;
            }
            WriteRegister(BroadcastId, reg, value, false);
        }

        // prepare for a pending change in the Id of a Dynamixel
        internal void DynamixelIdChange(Dynamixel dyn, int newId)
        {
            Dynamixel dynOld = this[newId];
            if (dynOld != null && dynOld != dyn)
                throw new ArgumentException(string.Format("Dynamixel Id ({0}) already in use", newId));
            // remap the Dynamixel from the old Id to the new Id
            DynamixelMap.Remove(dyn.Id);
            DynamixelMap.Add(newId, dyn);
        }
    }

    /// <summary>
    /// An abstract model of an AX-12 Dynamixel.
    /// </summary>
    public class Dynamixel
    {
        // the unit ID for this Dynamixel
        private int _Id;
        /// <summary>
        /// The parent network.
        /// </summary>
        protected DynamixelNetwork DynNet;
        // a cache of register values
        private Dictionary<Register, int> Cache = new Dictionary<Register, int>();

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="id">The unit ID for this Dynamixel.</param>
        /// <param name="DynNet">The parent DynamixelNetwork.</param>
        public Dynamixel(int id, DynamixelNetwork DynNet)
        {
            _Id = id;
            this.DynNet = DynNet;
            // initialize these cached register values so we'll never actually read them
            int[] v = DynNet.ReadRegisters(id, Register.GoalPosition, Register.MovingSpeed);
            this[Register.GoalPosition] = v[0];
            this[Register.MovingSpeed] = v[1];
        }

        /// <summary>
        /// Determine if a register value should be cached or not.
        /// </summary>
        /// <param name="reg">The register in question.</param>
        /// <returns>True if the register should be cached.</returns>
        protected bool NoCache(Register reg)
        {
            switch (reg)
            {
                // never cache these registers as they contain volatile data
                case Register.CurrentLoad:
                case Register.CurrentPosition:
                case Register.CurrentSpeed:
                case Register.CurrentTemperature:
                case Register.CurrentVoltage:
                case Register.Moving:
                case Register.TorqueEnable:
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Array access to the register values in the cache.
        /// </summary>
        /// <param name="reg">The register value to retrieve.</param>
        /// <returns>The cached value of the register, or -1 if not in the cache.</returns>
        /// <remarks>
        /// All registers are unsigned at this low level,
        /// so a return value of -1 indicates a value not in the cache.
        /// </remarks>
        public int this[Register reg]
        {
            get
            {
                int v;
                if (!Cache.TryGetValue(reg, out v))
                    v = -1;
                return v;
            }
            set
            {
                Cache[reg] = value;
            }
        }

        /// <summary>
        /// Get a register value from the cache, if present,
        /// or by reading the value from the Dynamixel.
        /// </summary>
        /// <param name="reg">The register to read.</param>
        /// <returns>The register value.</returns>
        protected int GetRegisterValue(Register reg)
        {
            switch (reg)
            {
                // always just get these registers from the cache
                case Register.GoalPosition:
                case Register.MovingSpeed:
                    return this[reg];
            }

            if (NoCache(reg))
                return DynNet.ReadRegister(_Id, reg);

            // get the cached value
            int v = this[reg];
            if (v == -1)
                // not cached, read the value
                v = this[reg] = DynNet.ReadRegister(_Id, reg);
            return v;
        }

        /// <summary>
        /// Set a register value and record in the cache, if applicable.
        /// </summary>
        /// <param name="reg">The register to write.</param>
        /// <param name="value">The registeer value to write.</param>
        protected void SetRegisterValue(Register reg, int value)
        {
            switch (reg)
            {
                // handle special SYNCHRONIZED case
                case Register.GoalPosition:
                case Register.MovingSpeed:
                    if (Synchronized)
                    {
                        this[reg] = value;
                        Changed = true;
                        return;
                    }
                    break;
                // the following are READ-ONLY registers
                case Register.ModelNumber:
                case Register.FirmwareVersion:
                case Register.CurrentPosition:
                case Register.CurrentSpeed:
                case Register.CurrentLoad:
                case Register.CurrentVoltage:
                case Register.CurrentTemperature:
                case Register.Moving:
                    throw new ArgumentException("register may not be set");
            }
            if (NoCache(reg))
            {
                // write the value
                DynNet.WriteRegister(_Id, reg, value, false);
                return;
            }
            int v = this[reg];
            if (v == value)
                // no change, so ignore
                return;
            // write the value
            DynNet.WriteRegister(_Id, reg, value, false);
            // record in the cache
            this[reg] = value;
        }

        /// <summary>
        /// Read all register values into the cache.
        /// </summary>
        public void ReadAll()
        {
            Register[] regs = (Register[])Enum.GetValues(typeof(Register));
            int[] values = DynNet.ReadRegisters(_Id, Register.ModelNumber, Register.Punch);
            for (int i = 0; i < regs.Length; i++)
            {
                this[regs[i]] = values[i];
            }
        }

        /// <summary>
        /// Reset all register values to the factory defaults.
        /// </summary>
        /// <remarks>
        /// WARNING: This will reset the Id to 1!
        /// </remarks>
        public void Reset()
        {
            DynNet.DynamixelIdChange(this, 1);
            DynNet.Reset(_Id);
            _Id = 1;
            // there's an apparent delay while the Dynamixel recovers from reset
            // sleeping for 250 ms seemed to be enough, but we'll add a safety margin
            System.Threading.Thread.Sleep(300);
            ReadAll();
        }

        /// <summary>
        /// For a Dynamixel in Synchronized mode, remember if the
        /// GoalPosition or MovingSpeed have changed.
        /// </summary>
        public bool Changed;
        private bool _Synchronized = true;
        /// <summary>
        /// Set or get the Synchronized mode for this Dynamixel.
        /// </summary>
        /// <remarks>
        /// For a Dynamixel in Synchronized mode, any change to the
        /// GoalPosition or MovingSpeed is only recorded in the cache.
        /// Then when 'DynamixelNextwork.Synchronize' is called, all
        /// position and speed data for all changed and Synchronized
        /// Dynamixels will be sent at once in one SyncWrite instruction.
        /// </remarks>
        [Browsable(false)]
        public bool Synchronized
        {
            get { return _Synchronized; }
            set { _Synchronized = value; }
        }

        /// <summary>
        /// Get or set the GoalPosition register.
        /// </summary>
        /// <remarks>
        /// If this Dynamixel is in Synchronized mode, a set value will be
        /// saved in the cache until 'DynamixelNextwork.Synchronize' is called
        /// when all changed Dynamixel positions and speeds will be set at once.
        /// </remarks>
        [Description("The goal position of the Dynamixel [30-31]")]
        [DisplayName("Goal Position")]
        public int GoalPosition
        {
            get { return GetRegisterValue(Register.GoalPosition); }
            set { SetRegisterValue(Register.GoalPosition, value); }
        }

        /// <summary>
        /// Get or set the MovingSpeed register.
        /// </summary>
        /// <remarks>
        /// If this Dynamixel is in Synchronized mode, a set value will be
        /// saved in the cache until 'DynamixelNextwork.Synchronize' is called
        /// when all changed Dynamixel positions and speeds will be set at once.
        /// </remarks>
        [Description("The moving speed [32-33]")]
        [DisplayName("Moving Speed")]
        public int MovingSpeed
        {
            get { return GetRegisterValue(Register.MovingSpeed); }
            set { SetRegisterValue(Register.MovingSpeed, value); }
        }

        /// <summary>
        /// Stop the Dynamixel from moving.
        /// </summary>
        /// <remarks>
        /// There is no direct way to command a Dynamixel to stop.
        /// And there is no way to set the speed to 0, since the value 0 is
        /// specially interpreted to mean 'as fast as possibly'.
        /// The best we can do is command it to move to its current position
        /// and set the speed to 1 to slow it down as much as possible.
        /// If there is any significant lag between receiving the CurrentPosition
        /// and setting it and the speed, there will be some residual movement
        /// as the Dynamixel moves to its observed but stale CurrentPosition.
        /// If the Dynamixel is in Sychronized mode, a call to 
        /// 'DynamixelNextwork.Synchronize' will be required to complete the operation.
        /// </remarks>
        public void Stop()
        {
            GoalPosition = CurrentPosition;
            MovingSpeed = 1;
        }

        /// <summary>
        /// Get or set the error conditions that will result in lighting the LED.
        /// </summary>
        [Description("The error conditions that will result in lighting the LED [17]")]
        [DisplayName("Alarm LED")]
        public ErrorStatus AlarmLed
        {
            get { return (ErrorStatus)GetRegisterValue(Register.AlarmLed); }
            set { SetRegisterValue(Register.AlarmLed, (int)value); }
        }

        /// <summary>
        /// Get or set the error conditions that will result in Dynamixel shutdown.
        /// </summary>
        [Description("The error conditions that will result in Dynamixel shutdown [18]")]
        [DisplayName("Alarm Shutdown")]
        public ErrorStatus AlarmShutdown
        {
            get { return (ErrorStatus)GetRegisterValue(Register.AlarmShutdown); }
            set { SetRegisterValue(Register.AlarmShutdown, (int)value); }
        }

        /// <summary>
        /// Get or set the baud rate the Dynamixel will communicate at.
        /// </summary>
        /// <remarks>
        /// Note that setting the BaudRate will require a corresponding change
        /// to the stream associated with the DynamixelNetwork.
        /// </remarks>
        [Description("The baud rate the Dynamixel will communicate at [4]")]
        [DisplayName("Baud Rate")]
        public BaudRate BaudRate
        {
            get { return (BaudRate)GetRegisterValue(Register.BaudRate); }
            set { SetRegisterValue(Register.BaudRate, (int)value); }
        }

        /// <summary>
        /// Get or set the CCW (toward 1023) angle limit for the Dynamixel's movement.
        /// </summary>
        [Description("The CCW (toward 1023) angle limit for movement [8-9]")]
        [DisplayName("CCW Angle Limit")]
        public int CCWAngleLimit
        {
            get { return GetRegisterValue(Register.CCWAngleLimit); }
            set { SetRegisterValue(Register.CCWAngleLimit, value); }
        }

        /// <summary>
        /// Get or set the CW (toward 0) angle limit for the Dynamixel's movement.
        /// </summary>
        [Description("The CW (toward 0) angle limit for movement [6-7]")]
        [DisplayName("CW Angle Limit")]
        public int CWAngleLimit
        {
            get { return GetRegisterValue(Register.CWAngleLimit); }
            set { SetRegisterValue(Register.CWAngleLimit, value); }
        }

        /// <summary>
        /// Get or set the CCW compliance margin.
        /// </summary>
        [Description("The CCW compliance margin [27]")]
        [DisplayName("CCW Compliance Margin")]
        public int CCWComplianceMargin
        {
            get { return GetRegisterValue(Register.CCWComplianceMargin); }
            set { SetRegisterValue(Register.CCWComplianceMargin, value); }
        }

        /// <summary>
        /// Get or set the CW compliance margin.
        /// </summary>
        [Description("The CW compliance margin [26]")]
        [DisplayName("CW Compliance Margin")]
        public int CWComplianceMargin
        {
            get { return GetRegisterValue(Register.CWComplianceMargin); }
            set { SetRegisterValue(Register.CWComplianceMargin, value); }
        }

        /// <summary>
        /// Get or set the CCW compliance slope.
        /// </summary>
        [Description("The CCW compliance slope [29]")]
        [DisplayName("CCW Compliance Slope")]
        public int CCWComplianceSlope
        {
            get { return GetRegisterValue(Register.CCWComplianceSlope); }
            set { SetRegisterValue(Register.CCWComplianceSlope, value); }
        }

        /// <summary>
        /// Get or set the CW compliance slope.
        /// </summary>
        [Description("The CW compliance slope [28]")]
        [DisplayName("CW Compliance Slope")]
        public int CWComplianceSlope
        {
            get { return GetRegisterValue(Register.CWComplianceSlope); }
            set { SetRegisterValue(Register.CWComplianceSlope, value); }
        }

        /// <summary>
        /// Get the current torque load on the Dynamixel.
        /// </summary>
        /// <remarks>
        /// A negative value indicates torque in the CW direction,
        /// positive in the CCW direction.
        /// </remarks>
        [Description("The current torque load [40-41]")]
        [DisplayName("Current Load")]
        public int CurrentLoad
        {
            get
            {
                int v = DynNet.ReadRegister(_Id, Register.CurrentLoad);
                // bit 10 indicates the direction
                if ((v & 0x400) != 0)
                    return -(v & 0x3ff);
                return v;
            }
        }

        /// <summary>
        /// Get the current position.
        /// </summary>
        [Description("The current position [36-37]")]
        [DisplayName("Current Position")]
        public int CurrentPosition
        {
            get { return DynNet.ReadRegister(_Id, Register.CurrentPosition); }
        }

        /// <summary>
        /// Get the current speed.
        /// </summary>
        [Description("The current speed [38-39]")]
        [DisplayName("Current Speed")]
        public int CurrentSpeed
        {
            get
            {
                int v = DynNet.ReadRegister(_Id, Register.CurrentSpeed);
                // bit 10 indicates the direction
                if ((v & 0x400) != 0)
                    return -(v & 0x3ff);
                return v;
            }
        }

        /// <summary>
        /// Get the current temperature.
        /// </summary>
        [Description("The current temperature [43]")]
        [DisplayName("Current Temperature")]
        public int CurrentTemperature
        {
            get { return DynNet.ReadRegister(_Id, Register.CurrentTemperature); }
        }

        /// <summary>
        /// Get the current voltage.
        /// </summary>
        [Description("The current voltage [42]")]
        [DisplayName("Current Voltage")]
        public float CurrentVoltage
        {
            // the reported value is actually ten times the actual voltage
            get { return (float)(DynNet.ReadRegister(_Id, Register.CurrentVoltage) / 10.0); }
        }

        /// <summary>
        /// Get or set the torque enable.
        /// </summary>
        [Description("The torque enable [24]")]
        [DisplayName("Torque Enable")]
        public bool TorqueEnable
        {
            get { return GetRegisterValue(Register.TorqueEnable) != 0; }
            set { SetRegisterValue(Register.TorqueEnable, value ? 1 : 0); }
        }

        /// <summary>
        /// Get the firmware version.
        /// </summary>
        [Description("The firmware version [2]")]
        [DisplayName("Firmware Version")]
        public int FirmwareVersion
        {
            get { return GetRegisterValue(Register.FirmwareVersion); }
        }

        /// <summary>
        /// Get or set the Dynamixel unit ID.
        /// </summary>
        [Description("The Dynamixel unit ID [3]")]
        public int Id
        {
            get { return _Id; }
            set
            {
                if (value < 0 || value >= DynamixelInterface.BroadcastId)
                    throw new ArgumentOutOfRangeException("Id", "Must be in the range 0 to 253");
                if (value == _Id)
                    return;
                DynNet.DynamixelIdChange(this, value);
                DynNet.WriteRegister(_Id, Register.Id, value, false);
                _Id = value;
            }
        }

        /// <summary>
        /// Turn the LED on or off.
        /// </summary>
        [Description("Turn the LED on or off [25]")]
        public bool LED
        {
            get { return GetRegisterValue(Register.LED) != 0; }
            set { SetRegisterValue(Register.LED, value ? 1 : 0); }
        }

        /// <summary>
        /// Determine if the Dynamixel is locked.
        /// </summary>
        /// <remarks>
        /// To set the Lock use the lower level DynamixelInterface functions.
        /// This is an uncommon requirement, since only powering off the system
        /// can turn off the lock.
        /// </remarks>
        [Description("Determine if the Dynamixel is locked [47]")]
        public bool Lock
        {
            get { return GetRegisterValue(Register.Lock) != 0; }
        }

        /// <summary>
        /// Get or set the temperature limit.
        /// </summary>
        [Description("The temperature limit [11]")]
        [DisplayName("Temperature Limit")]
        public int TemperatureLimit
        {
            get { return GetRegisterValue(Register.TemperatureLimit); }
            set { SetRegisterValue(Register.TemperatureLimit, value); }
        }

        /// <summary>
        /// Get or set the maximum torque.
        /// </summary>
        [Description("The maximum torque [14-15]")]
        [DisplayName("Max Torque")]
        public int MaxTorque
        {
            get { return GetRegisterValue(Register.MaxTorque); }
            set { SetRegisterValue(Register.MaxTorque, value); }
        }

        /// <summary>
        /// Get or set the high voltage limit.
        /// </summary>
        [Description("The high voltage limit [13]")]
        [DisplayName("High Voltage Limit")]
        public float HighVoltageLimit
        {
            get { return (float)(GetRegisterValue(Register.HighVoltageLimit) / 10.0); }
            set { SetRegisterValue(Register.HighVoltageLimit, (int)Math.Round(value * 10.0)); }
        }

        /// <summary>
        ///  Get or set the low voltage limit.
        /// </summary>
        [Description("The low voltage limit [12]")]
        [DisplayName("Low Voltage Limit")]
        public float LowVoltageLimit
        {
            get { return (float)(GetRegisterValue(Register.LowVoltageLimit) / 10.0); }
            set { SetRegisterValue(Register.LowVoltageLimit, (int)Math.Round(value * 10.0)); }
        }

        /// <summary>
        /// Get the model number.
        /// </summary>
        [Description("The model number [0-1]")]
        [DisplayName("Model Number")]
        public int ModelNumber
        {
            get { return GetRegisterValue(Register.ModelNumber); }
        }

        /// <summary>
        /// Get an indication if the Dynamixel is moving or not.
        /// </summary>
        [Description("An indication if the Dynamixel is moving or not [46]")]
        public bool Moving
        {
            get { return Changed || DynNet.ReadRegister(_Id, Register.Moving) != 0; }
        }

        /// <summary>
        /// Get or set the punch value.
        /// </summary>
        [Description("The punch value [48-49]")]
        public int Punch
        {
            get { return GetRegisterValue(Register.Punch); }
            set { SetRegisterValue(Register.Punch, value); }
        }

        /// <summary>
        /// Get or set an indication of whether or not a RegWrite instruction
        /// is awaiting an Action command.
        /// </summary>
        [Description("Whether or not a RegWrite instruction is awaiting an Action command [44]")]
        [DisplayName("Registered Instruction")]
        public bool RegisteredInstruction
        {
            get { return DynNet.ReadRegister(_Id, Register.RegisteredInstruction) != 0; }
            set { SetRegisterValue(Register.RegisteredInstruction, value ? 1 : 0); }
        }

        /// <summary>
        /// Get or set the return delay, in microseconds.
        /// </summary>
        /// <remarks>
        /// The return delay is the time it takes for a status packet
        /// to return after a command packet is sent.
        /// </remarks>
        [Description("The return delay, in microseconds [5]")]
        [DisplayName("Return Delay")]
        public int ReturnDelay
        {
            get { return GetRegisterValue(Register.ReturnDelay) * 2; }
            set { SetRegisterValue(Register.ReturnDelay, value / 2); }
        }

        /// <summary>
        /// Get or set the status return level that determines when the
        /// dynamixel will respond to command packets with a status packet.
        /// </summary>
        /// <remarks>
        /// Currently this library will function properly only if the StatusReturnLevel
        /// is set to 'RespondToAll' for all Dynamixels in the system.
        /// </remarks>
        [Description("The status return level that determines when the dynamixel will respond to command packets with a status packet [16]")]
        [DisplayName("Status Return Level")]
        public StatusReturnLevel StatusReturnLevel
        {
            get { return (StatusReturnLevel)GetRegisterValue(Register.StatusReturnLevel); }
            set { SetRegisterValue(Register.StatusReturnLevel, (int)value); }
        }

        /// <summary>
        /// Get or set the torque limit.
        /// </summary>
        /// <remarks>
        /// When an AlarmShutdown is caused by a torque overload, the Dynamixel
        /// will set its TorqueLimit to 0 and it must be reset, e.g. to 1023,
        /// to resume normal operation.
        /// </remarks>
        [Description("The torque limit [34-35]")]
        [DisplayName("Torque Limit")]
        public int TorqueLimit
        {
            get { return GetRegisterValue(Register.TorqueLimit); }
            set { SetRegisterValue(Register.TorqueLimit, value); }
        }

        /// <summary>
        /// Return the string representation of the object.
        /// </summary>
        /// <returns>The string representation of the object.</returns>
        public override string ToString()
        {
            return string.Format("Dyn {0}", Id);
        }
    }

    /// <summary>
    /// A class for debugging purposes to echo stream reads and writes to the output Console.
    /// </summary>
    public class EchoStream : Stream
    {
        private Stream Stream;

        private bool _Writing;
        /// <summary>
        /// True is the EchoByte is being written, false if being read.
        /// </summary>
        public bool Writing { get { return _Writing; } }

        private byte _EchoByte;
        /// <summary>
        /// The byte being echoed.
        /// </summary>
        public int EchoByte { get { return _EchoByte; } }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="stream">The source stream (e.g. SerialPort.BaseStream).</param>
        public EchoStream(Stream stream)
        {
            Stream = stream;
        }

        /// <summary>
        /// An event for handling echoing of bytes in the stream.
        /// </summary>
        public event EventHandler Echo;

        /// <summary>
        /// Echo a written byte.
        /// </summary>
        /// <param name="b">The byte value to echo.</param>
        protected void EchoWrite(byte b)
        {
            _Writing = true;
            _EchoByte = b;
            if (Echo != null)
                Echo(this, null);
        }

        /// <summary>
        /// Echo a read byte.
        /// </summary>
        /// <param name="b">The byte value to echo.</param>
        protected void EchoRead(byte b)
        {
            _Writing = false;
            _EchoByte = b;
            if (Echo != null)
                Echo(this, null);
        }

        /// <summary>
        /// True if the stream supports reading.
        /// </summary>
        public override bool CanRead
        {
            get { return Stream.CanRead; }
        }

        /// <summary>
        /// True if the stream supports seeking.
        /// </summary>
        public override bool CanSeek
        {
            get { return Stream.CanSeek; }
        }

        /// <summary>
        /// True if the stream supports writing.
        /// </summary>
        public override bool CanWrite
        {
            get { return Stream.CanWrite; }
        }

        /// <summary>
        /// Clears all buffers for this stream and causes any buffered data
        /// to be written to the underlying device.
        /// </summary>
        public override void Flush()
        {
            Stream.Flush();
        }

        /// <summary>
        /// Gets the length in bytes of the stream.
        /// </summary>
        public override long Length
        {
            get { return Stream.Length; }
        }

        /// <summary>
        /// Gets or sets the position within the current stream.
        /// </summary>
        public override long Position
        {
            get
            {
                return Stream.Position;
            }
            set
            {
                Stream.Position = value;
            }
        }

        /// <summary>
        /// Reads a sequence of bytes from the current stream.
        /// </summary>
        /// <param name="buffer">Buffer to receive bytes read.</param>
        /// <param name="offset">Offset into buffer to receive bytes read.</param>
        /// <param name="count">Number of bytes to read.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the
        /// number of bytes requested if that many bytes are not currently available,
        /// or zero (0) if the end of the stream has been reached.
        /// </returns>
        public override int Read(byte[] buffer, int offset, int count)
        {
            int cnt = Stream.Read(buffer, offset, count);
            for (int i = 0; i < cnt; i++)
            {
                EchoRead(buffer[i]);
            }
            return cnt;
        }

        /// <summary>
        /// Sets the position within the current stream.
        /// </summary>
        /// <param name="offset">A byte offset relative to the origin parameter.</param>
        /// <param name="origin">
        /// A value of type System.IO.SeekOrigin indicating the reference point used
        ///  to obtain the new position.
        /// </param>
        /// <returns>The new position within the current stream.</returns>
        public override long Seek(long offset, SeekOrigin origin)
        {
            return Stream.Seek(offset, origin);
        }

        /// <summary>
        /// Sets the length of the current stream.
        /// </summary>
        /// <param name="value">The desired length of the current stream in bytes.</param>
        public override void SetLength(long value)
        {
            Stream.SetLength(value);
        }

        /// <summary>
        /// Writes a sequence of bytes to the current stream.
        /// </summary>
        /// <param name="buffer">Buffer containing bytes to write.</param>
        /// <param name="offset">Offset into buffer for bytes to write.</param>
        /// <param name="count">Number of bytes to write.</param>
        public override void Write(byte[] buffer, int offset, int count)
        {
            foreach (byte b in buffer)
            {
                EchoWrite(b);
            }
            Stream.Write(buffer, offset, count);
        }

        /// <summary>
        /// Reads a byte from the stream.
        /// </summary>
        /// <returns>The unsigned byte cast to an Int32.</returns>
        public override int ReadByte()
        {
            int b = Stream.ReadByte();
            EchoRead((byte)b);
            return b;
        }

        /// <summary>
        /// Writes a byte to the stream.
        /// </summary>
        /// <param name="value">The byte to write to the stream.</param>
        public override void WriteByte(byte value)
        {
            EchoWrite(value);
            Stream.WriteByte(value);
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream
        /// will attempt to read before timing out.
        /// </summary>
        public override int ReadTimeout
        {
            get { return Stream.ReadTimeout; }
            set { Stream.ReadTimeout = value; }
        }

        /// <summary>
        /// Gets or sets a value, in milliseconds, that determines how long the stream
        /// will attempt to write before timing out.
        /// </summary>
        public override int WriteTimeout
        {
            get { return Stream.WriteTimeout; }
            set { Stream.WriteTimeout = value; }
        }
    }
}
