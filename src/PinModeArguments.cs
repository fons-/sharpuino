using System;
using Sharpuino;

namespace Sharpuino
{
	public class PinModeArguments
	{
		public PinMode[] pinModes = new PinMode[12];
		public PinModeArguments(PinMode pinMode2,
		                        PinMode pinMode3,
		                        PinMode pinMode4,
		                        PinMode pinMode5,
		                        PinMode pinMode6,
		                        PinMode pinMode7,
		                        PinMode pinMode8,
		                        PinMode pinMode9,
		                        PinMode pinMode10,
		                        PinMode pinMode11,
		                        PinMode pinMode12,
		                        PinMode pinMode13)
		{
			pinModes = new PinMode[] {pinMode2, pinMode3, pinMode4, pinMode5, pinMode6, pinMode7, pinMode8, pinMode9, pinMode10, pinMode11, pinMode12, pinMode13};
		}
		public PinModeArguments()
		{
			pinModes = new PinMode[] {PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output, PinMode.Output};
		}

		public void SetPinMode(Pin pin, PinMode pinMode)
		{
			pinModes[(int)pin] = pinMode;
		}

		public PinMode GetPinMode(Pin pin)
		{
			return pinModes[(int)pin];
		}
	}
}

