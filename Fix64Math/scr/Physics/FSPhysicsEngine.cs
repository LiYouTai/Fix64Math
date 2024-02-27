using System.Collections.Generic;

namespace Fix64Math.Physics
{
    public static class FSPhysicsEngine
    {
        internal static bool isStart;
        internal static List<IFSCollisionBase> Collisions = new List<IFSCollisionBase>();
        internal static T Add<T>(T collision) where T : IFSCollisionBase
        {
            Collisions.Add(collision);
            return collision;
        }
        internal static void Remove(IFSCollisionBase Collision)
        {
            Collisions.Remove(Collision);
        }
        public static void Start()
        {
            isStart = true;
            Collisions.Clear();
        }
        public static void Exit()
        {
            isStart = false;
            Collisions.Clear();
        }
        public static void Update()
        {
            if (!isStart) return;
            for (int i = 0; i < Collisions.Count; i++)
            {
                bool flag = false;
                var A = Collisions[i];
                if (A == null)
                {
                    Collisions.RemoveAt(i);
                    continue;
                }
                for (int j = 0; j < Collisions.Count; j++)
                {
                    var B = Collisions[j];
                    if (B == A) continue;
                    if (CollisionsMath.CheckCollision(A, B))
                    {
                        flag = true;
                        A.OnCollision(B);
                    }
                }
                A.IsCollsioning = flag;
            }
        }

        ///// <summary>
        ///// 三维射线检测
        ///// </summary>
        //public static FS3DRaycastHit[] RayCast3D(FS3DRay ray, Fix64 distance)
        //{
        //    List<FS3DRaycastHit> outBase = new List<FS3DRaycastHit>();
        //    for (int i = 0; i < Collisions.Count; i++)
        //    {
        //        Fix64CollisionBase item = Collisions[i] as Fix64CollisionBase;
        //        if (item == null) continue;
        //        FS3DRaycastHit hit;
        //        if (CollisionMath.RayCast3D(ray, item, out hit))
        //        {
        //            if (hit.distance <= distance)
        //            {
        //                outBase.Add(hit);
        //            }
        //        }
        //    }
        //    return outBase.ToArray();
        //}
        ///// <summary>
        ///// 二维射线检测
        ///// </summary>
        //public static FS2DRaycastHit[] RayCast2D(FS2DRay ray, Fix64 distance)
        //{
        //    List<FS2DRaycastHit> outBase = new List<FS2DRaycastHit>();
        //    for (int i = 0; i < Collisions.Count; i++)
        //    {
        //        FS2DCollisionBase item = Collisions[i] as FS2DCollisionBase;
        //        if (item == null) continue;
        //        FS2DRaycastHit hit;
        //        if (FS2DCollisionBase.RayCast2D(ray, item, out hit))
        //        {
        //            if (hit.distance <= distance)
        //            {
        //                outBase.Add(hit);
        //            }
        //        }
        //    }
        //    return outBase.ToArray();
        //}
    }
    public struct FS3DRay
    {
        public Fix64Vector3 origin;
        public Fix64Vector3 direction;

        public FS3DRay(Fix64Vector3 origin, Fix64Vector3 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
    public struct FS2DRay
    {
        public Fix64Vector2 origin;
        public Fix64Vector2 direction;
        public FS2DRay(Fix64Vector2 origin, Fix64Vector2 direction)
        {
            this.origin = origin;
            this.direction = direction;
        }
    }
    public struct FS3DRaycastHit
    {
        public FSCollisionBase collider;
        public Fix64Vector3 point { get; set; }
        public Fix64Vector3 normal { get; set; }
        public Fix64 distance { get; set; }
    }
    public struct FS2DRaycastHit
    {
        public FSCollisionBase collider;
        public Fix64Vector2 point { get; set; }
        public Fix64Vector2 normal { get; set; }
        public Fix64 distance { get; set; }
    }
}
