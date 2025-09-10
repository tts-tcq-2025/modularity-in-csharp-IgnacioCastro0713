using System;
using System.Diagnostics;
using System.Drawing;
using TelCo.ColorCoder;

var majorColors = new[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
var minorColors = new[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };

var mapper = new ColorCodeMapper(majorColors, minorColors);

int pairNumber = 4;
var pair = mapper.GetColorFromPairNumber(pairNumber);
Console.WriteLine($"[In]Pair Number: {pairNumber}, [Out] Colors: {pair}\n");
Debug.Assert(pair.MajorColor == Color.White);
Debug.Assert(pair.MinorColor == Color.Brown);

pairNumber = 5;
pair = mapper.GetColorFromPairNumber(pairNumber);
Console.WriteLine($"[In]Pair Number: {pairNumber}, [Out] Colors: {pair}\n");
Debug.Assert(pair.MajorColor == Color.White);
Debug.Assert(pair.MinorColor == Color.SlateGray);

pairNumber = 23;
pair = mapper.GetColorFromPairNumber(pairNumber);
Console.WriteLine($"[In]Pair Number: {pairNumber}, [Out] Colors: {pair}\n");
Debug.Assert(pair.MajorColor == Color.Violet);
Debug.Assert(pair.MinorColor == Color.Green);

var pair2 = new ColorPair(Color.Yellow, Color.Green);
pairNumber = mapper.GetPairNumberFromColor(pair2);
Console.WriteLine($"[In]Colors: {pair2}, [Out] PairNumber: {pairNumber}\n");
Debug.Assert(pairNumber == 18);

pair2 = new ColorPair(Color.Red, Color.Blue);
pairNumber = mapper.GetPairNumberFromColor(pair2);
Console.WriteLine($"[In]Colors: {pair2}, [Out] PairNumber: {pairNumber}");
Debug.Assert(pairNumber == 6);

string manual = ColorCodeManualFormatter.BuildTable(mapper.GetAllPairs());
Console.WriteLine(manual);