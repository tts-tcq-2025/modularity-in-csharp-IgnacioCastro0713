using System;
using System.Collections.Generic;
using System.Linq;

namespace TelCo.ColorCoder;

public static class ColorCodeManualFormatter
{
	public static string BuildTable(IEnumerable<(int PairNumber, ColorPair Pair)> entries) =>
		"Pair  | Major        | Minor\n----- | ------------ | ------------\n" +
		string.Join(Environment.NewLine, entries.Select(e =>
			$"{e.PairNumber,4} | {e.Pair.MajorColor.Name,-12} | {e.Pair.MinorColor.Name,-12}"));
}