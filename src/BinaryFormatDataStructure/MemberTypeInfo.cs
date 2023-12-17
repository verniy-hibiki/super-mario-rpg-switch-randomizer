using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    public class MemberTypeInfo
    {
        public BinaryType[] BinaryType { get; internal set; }
        public object[] AdditionalInfos { get; internal set; }

        internal void Read(int count, BinaryReader reader)
        {
            BinaryType = new BinaryType[count];

            for (int i = 0; i < count; i++)
            {
                BinaryType[i] = (BinaryType)reader.ReadByte();
            }

            AdditionalInfos = new object[count];

            for (int i = 0; i < count; i++)
            {
                if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.Primitive || BinaryType[i] == BinaryFormatDataStructure.BinaryType.PrimitiveArray)
                {
                    AdditionalInfos[i] = (PrimitiveType)reader.ReadByte();
                }
                else if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.SystemClass)
                {
                    AdditionalInfos[i] = reader.ReadString(); // System class name
                }
                else if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.Class)
                {
                    var typeInfo = new ClassTypeInfo();
                    typeInfo.Read(reader);
                    AdditionalInfos[i] = typeInfo;
                }
            }
        }

        internal void Write(BinaryWriter writer)
        {
            for (int i = 0; i < BinaryType.Length; i++)
            {
                writer.Write((byte)BinaryType[i]);
            }
            for (int i = 0; i < AdditionalInfos.Length; i++)
            {
                if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.Primitive || BinaryType[i] == BinaryFormatDataStructure.BinaryType.PrimitiveArray)
                {
                    writer.Write((byte)(PrimitiveType)AdditionalInfos[i]);
                }
                else if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.SystemClass)
                {
                    writer.Write((string)AdditionalInfos[i]);
                }
                else if (BinaryType[i] == BinaryFormatDataStructure.BinaryType.Class)
                {
                    var typeInfo = (ClassTypeInfo)AdditionalInfos[i];
                    typeInfo.Write(writer);
                }
            }
        }
    }
}
