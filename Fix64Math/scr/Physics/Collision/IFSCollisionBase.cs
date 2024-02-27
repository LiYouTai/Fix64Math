using Fix64Math.Component;
using System;

namespace Fix64Math.Physics
{
    public interface IFSCollisionBase : IDisposable
    {
        string Name { get; }
        ECollisionType Type { get; }
        Fix64Vector3 Center { get; }
        Fix64Vector3 HalfSize { get; }
        bool IsCollsioning { get; set; }
        Fix64Vector3 MaxVertex { get; }
        Fix64Vector3 MinVertex { get; }
        FSObject Object { get; }
        Fix64Vector3 Position { get; }
        void OnCollision(IFSCollisionBase Collision);
    }
}