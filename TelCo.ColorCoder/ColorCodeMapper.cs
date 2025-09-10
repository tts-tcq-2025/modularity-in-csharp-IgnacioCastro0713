using System;
using System.Drawing;
using System.Linq;

namespace TelCo.ColorCoder;

public sealed class ColorCodeMapper
{
	private readonly Color[] _majorColors;
	private readonly Color[] _minorColors;

	public ColorCodeMapper(Color[] majorColors, Color[] minorColors)
	{
		_majorColors = majorColors ?? throw new ArgumentNullException(nameof(majorColors));
		_minorColors = minorColors ?? throw new ArgumentNullException(nameof(minorColors));

		if (majorColors.Length == 0 || minorColors.Length == 0)
			throw new ArgumentException("Color maps must be non-empty.");
	}

	public ColorPair GetColorFromPairNumber(int pairNumber)
	{
		int minorCount = _minorColors.Length, majorCount = _majorColors.Length;
		if (pairNumber < 1 || pairNumber > minorCount * majorCount)
			throw new ArgumentOutOfRangeException(nameof(pairNumber), $"PairNumber:{pairNumber} is outside the allowed range");

		int index = pairNumber - 1;
		return new ColorPair(_majorColors[index / minorCount], _minorColors[index % minorCount]);
	}

	public int GetPairNumberFromColor(ColorPair pair)
	{
		int majorIndex = Array.IndexOf(_majorColors, pair.MajorColor);
		int minorIndex = Array.IndexOf(_minorColors, pair.MinorColor);
		if (majorIndex < 0 || minorIndex < 0)
			throw new ArgumentException($"Unknown Colors: {pair}");

		return majorIndex * _minorColors.Length + minorIndex + 1;
	}

	public string BuildReferenceManual()
	{
		var header = "Pair  | Major        | Minor\n" +
					 "----- | ------------ | ------------\n";
		var lines = _majorColors.SelectMany((major, mi) => _minorColors.Select((minor, ni) => $"{mi * _minorColors.Length + ni + 1,4} | {major.Name,-12} | {minor.Name,-12}"));

		return header + string.Join(Environment.NewLine, lines);
	}
}