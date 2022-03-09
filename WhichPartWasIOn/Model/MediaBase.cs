using System;
using System.Collections.Generic;
using WhichPartWasIOn.Enum;

namespace WhichPartWasIOn.Model
{
    public abstract class MediaBase
    {
        public long Id { get; set; } = -1;
        public List<Genre> Genres { get; init; }
        public string Title { get; init; }
        public string Author { get; init; }
        public string Summary { get; init; }
        public DateTime Release { get; init; }

        public override bool Equals(object obj)
        {
            return obj is MediaBase @base &&
                   Id == @base.Id &&
                   Title == @base.Title;
        }

        public override int GetHashCode() => HashCode.Combine(Id, Title);
    }
}
