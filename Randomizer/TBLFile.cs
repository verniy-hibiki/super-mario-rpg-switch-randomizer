using BinaryFormatDataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Randomizer
{
    public class TBLFile
    {
        public NRBFReader? Reader { get; set; }
        public object[]? Content { get; set; }
        private readonly Lazy<List<BinaryObject>> WorkSetCache;
        public List<BinaryObject> WorkSet { get => WorkSetCache.Value; }
        public string? Destination { get; set; }

        public TBLFile()
        {
            WorkSetCache = new Lazy<List<BinaryObject>>(
           () =>
           {
               Console.WriteLine("Generating worklist for " + Destination);
               return Content?.Select(x => (BinaryObject)x)?.ToList() ?? new List<BinaryObject>();
           }
           );
        }
        public void Save()
        {
            if (Destination != null)
            {
                System.IO.File.Delete(Destination);
                using var stream_o = File.OpenWrite(Destination);
                Reader?.Replace(Content, WorkSet.ToArray<object>());
                Reader?.WriteStream(stream_o);
            }
        }
        public List<T> Wrap<T>()
        {
            var ctor = typeof(T).GetConstructors()[0];
            return WorkSet.Select(x => (T)ctor.Invoke(new object[] { x })).ToList();
        }

    }
}
