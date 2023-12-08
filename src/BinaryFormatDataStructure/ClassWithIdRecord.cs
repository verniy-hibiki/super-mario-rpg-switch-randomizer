using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    internal class ClassWithIdRecord
    {
        public int ObjectId { get; internal set; }
        public int MetadataId { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            ObjectId = reader.ReadInt32();
            MetadataId = reader.ReadInt32();
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(ObjectId);
            writer.Write(MetadataId);
        }
    }
}
