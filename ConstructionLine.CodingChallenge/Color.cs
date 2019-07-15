using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Color
    {
        public Guid Id { get; }

        public string Name { get; }

        private Color(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Color Red = new Color(Guid.NewGuid(), "Red");
        public static Color Blue = new Color(Guid.NewGuid(), "Blue");
        public static Color Yellow = new Color(Guid.NewGuid(), "Yellow");
        public static Color White = new Color(Guid.NewGuid(), "White");
        public static Color Black = new Color(Guid.NewGuid(), "Black");


        public static List<Color> All =
            new List<Color>
            {
                Red,
                Blue,
                Yellow,
                White,
                Black
            };

        public static Dictionary<Color, int> AllAsDictionary()
        {
            var result = new Dictionary<Color, int>();
            foreach (var item in All)
            {
                result.Add(item, 0);
            }
            return result;
        }
    }
}