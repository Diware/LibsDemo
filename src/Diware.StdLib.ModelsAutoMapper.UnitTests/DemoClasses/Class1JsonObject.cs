using Newtonsoft.Json;
using System;

namespace Diware.StdLib.ModelsAutoMapper.UnitTests.DemoClasses
{
    [JsonObject]
    internal class Class1JsonObject
    {
        public string? Name { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;

            var o = (obj as Class1JsonObject)!;
            return Equals(o.Name, Name);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }
    }
}
