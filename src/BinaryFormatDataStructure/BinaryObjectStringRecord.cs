using System.IO;

namespace BinaryFormatDataStructure
{
    internal class BinaryObjectStringRecord
    {
        public int ObjectId { get; internal set; }
        public string Value { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            ObjectId = reader.ReadInt32();
            Value = reader.ReadString();
        }
        internal void Write(BinaryWriter bw)
        {
            bw.Write((byte)RecordType.BinaryObjectString);
            bw.Write(ObjectId);
            bw.Write(Value);
        }
    }
}
