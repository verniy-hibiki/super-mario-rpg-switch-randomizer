using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    internal class ClassTypeInfo
    {
        public string TypeName { get; internal set; }
        public int LibraryId { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            TypeName = reader.ReadString();
            LibraryId = reader.ReadInt32();
        }

        internal void Write(BinaryWriter writer)
        {
            writer.Write(TypeName);
            writer.Write(LibraryId);
        }
    }
}
