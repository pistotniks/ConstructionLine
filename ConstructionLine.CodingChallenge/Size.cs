﻿using System;
using System.Collections.Generic;

namespace ConstructionLine.CodingChallenge
{
    public class Size
    {
        public Guid Id { get; }

        public string Name { get; }

        private Size(Guid id, string name)
        {
            Id = id;
            Name = name;
        }


        public static Size Small = new Size(Guid.NewGuid(), "Small");
        public static Size Medium = new Size(Guid.NewGuid(), "Medium");
        public static Size Large = new Size(Guid.NewGuid(), "Large");


        public static List<Size> All = 
            new List<Size>
            {
                Small,
                Medium,
                Large
            };

        public static Dictionary<Size, int> AllAsDictionary()
        {
            var sizes = new Dictionary<Size, int>();
            foreach (var size in All)
            {
                sizes.Add(size, 0);
            }

            return sizes;
        } 
            
    }
}