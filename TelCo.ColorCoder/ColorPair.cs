using System.Drawing;

namespace TelCo.ColorCoder;

public readonly record struct ColorPair(Color MajorColor, Color MinorColor)
{
	public override string ToString() =>
		$"MajorColor:{MajorColor.Name}, MinorColor:{MinorColor.Name}";
}