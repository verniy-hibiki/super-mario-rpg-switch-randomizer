using System;
using System.IO;

namespace BinaryFormatDataStructure
{
    public class ClassWithMembersAndTypesRecord : ClassSerializationRecord
    {
        public int LibraryId { get; internal set; }

        internal void Read(BinaryReader reader)
        {
            ClassInfo = new ClassInfo();
            ClassInfo.Read(reader);
            MemberTypeInfo = new MemberTypeInfo();
            MemberTypeInfo.Read(ClassInfo.MemberCount, reader);
            LibraryId = reader.ReadInt32();
        }

        internal void Write(BinaryWriter writer)
        {
            ClassInfo.Write(writer);
            MemberTypeInfo.Write(writer);
            writer.Write(LibraryId);
        }
    }
}
