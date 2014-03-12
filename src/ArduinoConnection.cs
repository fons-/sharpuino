using System;
using System.IO.Ports;

namespace Sharpuino
{
	public class ArduinoConnection
	{
		private SerialPort serialPort;
		public SerialArguments serialArguments;
		private PinModeArguments pinModes;
		private bool isInitiated = false;
		private string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

		public ArduinoConnection(SerialArguments serialArguments, PinModeArguments pinModeArguments)
		{
			this.serialArguments = serialArguments;
			this.pinModes = pinModeArguments;
		}

		public void Init()
		{
			//Serial port initialization
			try {
				serialPort = new SerialPort(serialArguments.portName, serialArguments.baudRate);
				serialPort.Open();
			} catch(Exception exc) {
				throw(exc);
			}
			//Arduino initialization

			isInitiated = true;
		}

		public void DigitalWrite(Pin pin, DigitalValue value)
		{
			if(isInitiated && serialPort.IsOpen) {
				serialPort.Write(new string(alphabet[(int)pin + ((int)value * 12)], 1));
				if (pinModes.GetPinMode(pin) == PinMode.Input)
				{

				}
			}
		}

		public void setPinMode(Pin pin, PinMode pinMode)
		{
			pinModes.SetPinMode(pin, pinMode);
		}

		public void Dispose()
		{
			if(serialPort.IsOpen) {
				serialPort.Close();
			}
		}
	}
}