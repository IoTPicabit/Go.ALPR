﻿using System.IO.Ports;
using System.Threading.Tasks;

namespace Go.ALPR.Sri.Common
{
    public static class SerialPortExtensions
    {
        /// <summary>
        /// Read a line from the SerialPort asynchronously
        /// </summary>
        /// <param name="serialPort">The port to read data from</param>
        /// <returns>A line read from the input</returns>
        public static async Task<string> ReadLineAsync(
            this SerialPort serialPort)
        {
            byte[] buffer = new byte[1];
            string ret = string.Empty;

            // Read the input one byte at a time, convert the
            // byte into a char, add that char to the overall
            // response string, once the response string ends
            // with the line ending then stop reading
            while (true)
            {
                await serialPort.BaseStream.ReadAsync(buffer, 0, 1);
                ret += serialPort.Encoding.GetString(buffer);

                if (ret.EndsWith(serialPort.NewLine))
                    // Truncate the line ending
                    return ret.Substring(0, ret.Length - serialPort.NewLine.Length);
            }
        }

        /// <summary>
        /// Write a line to the SerialPort asynchronously
        /// </summary>
        /// <param name="serialPort">The port to send text to</param>
        /// <param name="str">The text to send</param>
        /// <returns></returns>
        public static async Task WriteLineAsync(
            this SerialPort serialPort, string str)
        {
            byte[] encodedStr =
                serialPort.Encoding.GetBytes(str + serialPort.NewLine);

            await serialPort.BaseStream.WriteAsync(encodedStr, 0, encodedStr.Length);
            await serialPort.BaseStream.FlushAsync();
        }

        /// <summary>
        /// Write a line to the ICommunicationPortAdaptor asynchronously followed
        /// immediately by attempting to read a line from the same port. Useful
        /// for COMMAND --> RESPONSE type communication.
        /// </summary>
        /// <param name="serialPort">The port to process commands through</param>
        /// <param name="command">The command to send through the port</param>
        /// <returns>The response from the port</returns>
        public static async Task<string> SendCommandAsync(
            this SerialPort serialPort, string command)
        {
            await serialPort.WriteLineAsync(command);
            return await serialPort.ReadLineAsync();
        }

        public static Task<int> ReadAsync(this SerialPort port, byte[] buffer, int offset, int count)
        {
            return Task.Run(() =>
            {
                return port.Read(buffer, offset, count);
            });
        }

    }
}
