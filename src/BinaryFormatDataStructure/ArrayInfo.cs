using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    internal class ArrayInfo
    {
        public int ObjectId { get; internal set; }
        public int Length { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            ObjectId = reader.ReadInt32();
            Length = reader.ReadInt32();
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(ObjectId);
            writer.Write(Length);
        }
        public override string ToString()
        {
            return $" ID:{ObjectId}, Length:{Length}" ;
        }
    }
}
