using Fix64Math.Component;
using System;
using System.Collections.Generic;

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
        public FSCollisionBase(FSObject @object)
        {
            Object = @object;
            FSPhysicsEngine.Add(this);
        }
        public void Destory()
        {
            Dispose(true);
        }

        public Action<IFSCollisionBase>? OnCollisionEvent { get; set; }
        public virtual void OnCollision(IFSCollisionBase Collision)
        {
            OnCollisionEvent?.Invoke(Collision);
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