using System.Collections.Generic;
using System.Linq;

namespace ConstructionLine.CodingChallenge
{
    public class SearchEngine
    {
        private readonly List<Shirt> _shirts;
        private readonly IDictionary<Size, int> _sizes;
        private readonly IDictionary<Color, int> _colors;
        private readonly List<Shirt> _resultsShirts = new List<Shirt>();

        public SearchEngine(List<Shirt> shirts)
        {
            _shirts = shirts;
            _sizes = Size.AllAsDictionary();
            _colors = Color.AllAsDictionary();
        }


        public SearchResults Search(SearchOptions options)
        {
            foreach (var shirt in _shirts)
            {
                ProcessShirt(options, shirt);
            }

            return new SearchResults
            {
                Shirts = _resultsShirts, ColorCounts = ColorCounts(), SizeCounts = SizeCounts()
            };
        }

        private void ProcessShirt(SearchOptions options, Shirt shirt)
        {
            if (options.Sizes == null || options.Sizes.Count == 0)
            {
                FilterWhenNoSizesGiven(options, shirt);
            }
            else
            {
                Filter(options, shirt);
            }
        }

        private void FilterWhenNoSizesGiven(SearchOptions options, Shirt shirt)
        {
            if (options.Colors.Contains(shirt.Color))
            {
                _resultsShirts.Add(shirt);

                _sizes.TryGetValue(shirt.Size, out var currentCount);
                _sizes[shirt.Size] = currentCount + 1;
            }

            _colors.TryGetValue(shirt.Color, out var currentColorCount);
            _colors[shirt.Color] = currentColorCount + 1;
        }

        private void Filter(SearchOptions options, Shirt shirt)
        {
            if (options.Colors.Contains(shirt.Color))
            {
                if (options.Sizes.Contains(shirt.Size))
                {
                    _resultsShirts.Add(shirt);

                    _colors.TryGetValue(shirt.Color, out var currentColorCount);
                    _colors[shirt.Color] = currentColorCount + 1;
                }

                _sizes.TryGetValue(shirt.Size, out var currentCount);
                _sizes[shirt.Size] = currentCount + 1;
            }
            else
            {
                if (options.Sizes.Contains(shirt.Size))
                {
                    _colors.TryGetValue(shirt.Color, out var currentColorCount);
                    _colors[shirt.Color] = currentColorCount + 1;
                }
            }
        }

        private List<ColorCount> ColorCounts()
        {
            return _colors.Select(color => new ColorCount {Color = color.Key, Count = color.Value}).ToList();
        }

        private List<SizeCount> SizeCounts()
        {
            return _sizes.Select(size => new SizeCount {Size = size.Key, Count = size.Value}).ToList();
        }
    }
}