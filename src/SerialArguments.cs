using System;

namespace Sharpuino
{
	public class SerialArguments
	{
		public int baudRate = 9600;
		public string portName;
		public SerialArguments(string portName, int baudRate)
		{
			this.baudRate = baudRate;
			this.portName = portName;
		}
		public SerialArguments(string portName)
		{
			this.portName = portName;
		}
	}
}

