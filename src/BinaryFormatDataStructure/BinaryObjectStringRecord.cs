using System.IO;

namespace BinaryFormatDataStructure
{
    public class BinaryObjectStringRecord
    {
        public int ObjectId { get; set; }
        public string Value { get; set; }

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
        public override string ToString()
        {
            return this.Value;
        }
    }
}
