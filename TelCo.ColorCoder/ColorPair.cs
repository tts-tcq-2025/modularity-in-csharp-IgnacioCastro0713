using System;
using System.Drawing;

namespace TelCo.ColorCoder;
/// <summary>
/// data type defined to hold the two colors of clor pair
/// </summary>
public class ColorPair
{
	private static Color[] _colorMapMajor;
	/// <summary>
	/// Array of minor colors
	/// </summary>
	private static Color[] _colorMapMinor;


	internal Color MajorColor;
	internal Color MinorColor;
	public override string ToString()
	{
		return $"MajorColor:{MajorColor.Name}, MinorColor:{MinorColor.Name}";
	}

	public ColorPair(Color[] majorColor, Color[] minorColors)
	{
		_colorMapMajor = majorColor;
		_colorMapMinor = minorColors;
	}



	public ColorPair()
	{
	}


	/// <summary>
	/// Given a pair number function returns the major and minor colors in that order
	/// </summary>
	/// <param name="pairNumber">Pair number of the color to be fetched</param>
	/// <returns></returns>
	public ColorPair GetColorFromPairNumber(int pairNumber)
	{
		// The function supports only 1 based index. Pair numbers valid are from 1 to 25
		int minorSize = _colorMapMinor.Length;
		int majorSize = _colorMapMajor.Length;
		if (pairNumber < 1 || pairNumber > minorSize * majorSize)
		{
			throw new ArgumentOutOfRangeException($"Argument PairNumber:{pairNumber} is outside the allowed range");
		}

		// Find index of major and minor color from pair number
		int zeroBasedPairNumber = pairNumber - 1;
		int majorIndex = zeroBasedPairNumber / minorSize;
		int minorIndex = zeroBasedPairNumber % minorSize;

		// Construct the return val from the arrays
		ColorPair pair = new ColorPair
		{
			MajorColor = _colorMapMajor[majorIndex],
			MinorColor = _colorMapMinor[minorIndex]
		};

		// return the value
		return pair;
	}
	/// <summary>
	/// Given the two colors the function returns the pair number corresponding to them
	/// </summary>
	/// <param name="pair">Color pair with major and minor color</param>
	/// <returns></returns>
	public int GetPairNumberFromColor(ColorPair pair)
	{
		// Find the major color in the array and get the index
		int majorIndex = -1;
		for (int i = 0; i < _colorMapMajor.Length; i++)
		{
			if (_colorMapMajor[i] == pair.MajorColor)
			{
				majorIndex = i;
				break;
			}
		}

		// Find the minor color in the array and get the index
		int minorIndex = -1;
		for (int i = 0; i < _colorMapMinor.Length; i++)
		{
			if (_colorMapMinor[i] == pair.MinorColor)
			{
				minorIndex = i;
				break;
			}
		}
		// If colors can not be found throw an exception
		if (majorIndex == -1 || minorIndex == -1)
		{
			throw new ArgumentException($"Unknown Colors: {pair.ToString()}");
		}

		// Compute pair number and Return  
		// (Note: +1 in compute is because pair number is 1 based, not zero)
		return (majorIndex * _colorMapMinor.Length) + (minorIndex + 1);
	}
}