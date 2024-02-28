using Fix64Math.Component;
using System;
using System.Numerics;

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
        /// <summary>
        /// Gets the center point of the bounding box.
        /// </summary>
        /// <returns>获取中心点</returns>
        Fix64Vector3 GetCenter();
        /// <summary>
        ///  Near face, specified counter-clockwise looking towards the origin from the positive z-axis.
        ///  verts[0] : left top front
        ///  verts[1] : left bottom front
        ///  verts[2] : right bottom front
        ///  verts[3] : right top front
        ///  Far face, specified counter-clockwise looking towards the origin from the negative z-axis.
        ///  verts[4] : right top back
        ///  verts[5] : right bottom back
        ///  verts[6] : left bottom back
        ///  verts[7] : left top back
        /// </summary>
        /// <returns>获取包围盒八个顶点信息</returns>
        void GetCorners();
        /// <summary>
        /// Tests whether this bounding box intersects the specified bounding object.
        /// </summary>
        /// <returns>判断两个包围盒是否碰撞</returns>
        void SetMinMax(Fix64Vector3 min, Fix64Vector3 max);
        /// <summary>
        /// reset min and max value.
        /// </summary>
        /// <returns>重置</returns>
        void ResetMinMax();
        bool IsEmpty();
    }
}