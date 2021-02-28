using System;

namespace ByteArrayTest.Data
{
    public class MyObject
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public byte[] RowVersion { get; set; }
    }
}