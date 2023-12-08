using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    internal class BinaryLibraryRecord
    {
        public int LibraryId { get; internal set; }
        public string LibraryName { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            LibraryId = reader.ReadInt32();
            LibraryName = reader.ReadString();
        }

        internal static void Write(BinaryWriter writer, int key, string value)
        {
            writer.Write((Int32)key);
            writer.Write((string)value);
        }
    }
}
