using System;
namespace GLCore.Objects
{
    public interface IWear : IStuff
    {
        int WearSlot { get; set; }
        int Durability { get; set; }
        int Heat { get; set; }
        int Beauty { get; set; }
        int ConflictSlot { get; }
        int DressType { get; }
    }
}
