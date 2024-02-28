using Fix64Math.Component;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Xml.Linq;

namespace Fix64Math.Physics
{
    public abstract class FSCollisionBase : IFSCollisionBase
    {
        public abstract string Name { get; }
        public abstract ECollisionType Type { get; }
        protected Fix64Vector3 halfSize;
        protected Fix64Vector3 center;
        protected Fix64Vector3 maxVertex;
        protected Fix64Vector3 minVertex;
        public List<Fix64Vector3[]> lines = new List<Fix64Vector3[]>();
        protected Fix64Vector3[] vertex = new Fix64Vector3[8];
        public Fix64Vector3 HalfSize => halfSize;
        public Fix64Vector3 Center => center;
        public Fix64Vector3 MaxVertex => maxVertex;
        public Fix64Vector3 MinVertex => minVertex;
        public Fix64Vector3 Position => Object.Position;
        public bool IsCollsioning { get; set; }
        public FSObject Object { get; private set; }
        public Action<IFSCollisionBase>? OnCollisionEvent { get; set; }

        public virtual void OnCollision(IFSCollisionBase Collision)
        {
            OnCollisionEvent?.Invoke(Collision);
        }
        public FSCollisionBase(FSObject @object)
        {
            Object = @object;
            FSPhysicsEngine.Add(this);
        }
        public void Destory()
        {
            Dispose(true);
        }
        /// <summary>
        /// 更新位置
        /// </summary>
        public void UpdatePosition(Fix64Vector3 colliderCenter, Fix64Vector3 halfSize, Fix64Vector3 Position)
        {
            var currCenter = colliderCenter + Position;
            //左下最小值，右上最大值
            minVertex = Fix64Vector3.SetVertex(-halfSize.X + currCenter.X, -halfSize.Y + currCenter.Y, -halfSize.Z + currCenter.Z);
            maxVertex = Fix64Vector3.SetVertex(halfSize.X + currCenter.X, halfSize.Y + currCenter.Y, halfSize.Z + currCenter.Z);
            SetMinMax(minVertex, maxVertex);
        }
        public Fix64Vector3 GetCenter()
        {
            center.X = (minVertex.X + maxVertex.X)/ Fix64.Two;
            center.Y = (minVertex.Y + maxVertex.Y) / Fix64.Two;
            center.Z = (minVertex.Z + maxVertex.Z) / Fix64.Two;
            return center;
        }
        public void GetCorners()
        {
            // 朝着Z轴正方向的面
            // 左上顶点坐标
            vertex[0] = Fix64Vector3.SetVertex(minVertex.X, maxVertex.Y, maxVertex.Z);
            // 左下顶点坐标
            vertex[1] = Fix64Vector3.SetVertex(minVertex.X, minVertex.Y, maxVertex.Z);
            // 右下顶点坐标
            vertex[2] = Fix64Vector3.SetVertex(maxVertex.X, minVertex.Y, maxVertex.Z);
            // 右上顶点坐标
            vertex[3] = Fix64Vector3.SetVertex(maxVertex.X, maxVertex.Y, maxVertex.Z);
            // 朝着Z轴负方向的面
            // 右上顶点坐标
            vertex[4] = Fix64Vector3.SetVertex(maxVertex.X, maxVertex.Y, minVertex.Z);
            // 右下顶点坐标.
            vertex[5] = Fix64Vector3.SetVertex(maxVertex.X, minVertex.Y, minVertex.Z);
            // 左下顶点坐标.
            vertex[6] = Fix64Vector3.SetVertex(minVertex.X, minVertex.Y, minVertex.Z);
            // 左上顶点坐标.
            vertex[7] = Fix64Vector3.SetVertex(minVertex.X, maxVertex.Y, minVertex.Z);
        }
        public void SetMinMax(Fix64Vector3 min, Fix64Vector3 max)
        {
            this.minVertex = min;
            this.maxVertex = max;
            GetCenter();
            GetCorners();
        }
        public bool IsEmpty()
        {
            return minVertex.X > maxVertex.X || minVertex.Y > maxVertex.Y || minVertex.Z > maxVertex.Z;
        }
        public void ResetMinMax()
        {
            minVertex = Fix64Vector3.SetVertex(-Fix64.One, -Fix64.One, -Fix64.One);
            maxVertex = Fix64Vector3.SetVertex(Fix64.One, Fix64.One, Fix64.One);
            GetCenter();
            GetCorners();
        }
        #region IDisposable Support
        private bool disposed = false;
        ~FSCollisionBase()
        {
            this.Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) { }
                FSPhysicsEngine.Remove(this);
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
