using System;
using System.Drawing;

namespace TelCo.ColorCoder;

/// <summary>
/// data type defined to hold the two colors of color pair
/// </summary>
public class ColorPair
{
	static Color[] _majorColors, _minorColors;
	internal Color MajorColor, MinorColor;

	public ColorPair() { }
	public ColorPair(Color[] majorColors, Color[] minorColors) { _majorColors = majorColors; _minorColors = minorColors; }

	public override string ToString() => $"MajorColor:{MajorColor.Name}, MinorColor:{MinorColor.Name}";


	/// <summary>
	/// Given a pair number function returns the major and minor colors in that order
	/// </summary>
	/// <param name="pairNumber">Pair number of the color to be fetched</param>
	/// <returns></returns>
	public ColorPair GetColorFromPairNumber(int pairNumber)
	{
		int minorCount = _minorColors.Length, majorCount = _majorColors.Length;
		if (pairNumber < 1 || pairNumber > minorCount * majorCount)
			throw new ArgumentOutOfRangeException(nameof(pairNumber), $"PairNumber:{pairNumber} is outside the allowed range");

		int index = pairNumber - 1;
		return new ColorPair { MajorColor = _majorColors[index / minorCount], MinorColor = _minorColors[index % minorCount] };
	}

	/// <summary>
	/// Given the two colors the function returns the pair number corresponding to them
	/// </summary>
	/// <param name="pair">Color pair with major and minor color</param>
	/// <returns></returns>
	public int GetPairNumberFromColor(ColorPair pair)
	{
		int majorIndex = Array.IndexOf(_majorColors, pair.MajorColor);
		int minorIndex = Array.IndexOf(_minorColors, pair.MinorColor);
		if (majorIndex < 0 || minorIndex < 0)
			throw new ArgumentException($"Unknown Colors: {pair}");

		return majorIndex * _minorColors.Length + minorIndex + 1;
	}
}