using System.Drawing;
using TelCo.ColorCoder;

namespace TestProject;

public class ColorCodeMapperTests
{
	private readonly ColorCodeMapper _mapper;

	public ColorCodeMapperTests()
	{
		var majorColors = new[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
		var minorColors = new[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
		_mapper = new ColorCodeMapper(majorColors, minorColors);
	}

	[Theory]
	[InlineData(4, "White", "Brown")]
	[InlineData(5, "White", "SlateGray")]
	[InlineData(23, "Violet", "Green")]
	public void GetColorFromPairNumber_ReturnsExpectedColors(int pairNumber, string expectedMajor, string expectedMinor)
	{
		var pair = _mapper.GetColorFromPairNumber(pairNumber);

		Assert.Equal(expectedMajor, pair.MajorColor.Name);
		Assert.Equal(expectedMinor, pair.MinorColor.Name);
	}

	[Theory]
	[InlineData("Yellow", "Green", 18)]
	[InlineData("Red", "Blue", 6)]
	public void GetPairNumberFromColor_ReturnsExpectedPairNumber(string major, string minor, int expectedPairNumber)
	{
		var pair = new ColorPair(Color.FromName(major), Color.FromName(minor));

		var pairNumber = _mapper.GetPairNumberFromColor(pair);

		Assert.Equal(expectedPairNumber, pairNumber);
	}
}