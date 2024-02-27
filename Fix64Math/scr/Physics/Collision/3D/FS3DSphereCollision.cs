//using Fix64Math;
//using Fix64Physics.scr.Math;

//namespace Fix64Physics
//{
//    public class FS3DSphereCollision : Fix64CollisionBase
//    {
//        IFSCollision IFSBCollision;
//        public Fix64 Radius { get; private set; }
//        public void SetData(FSGameObject fSGameObject, SphereCollider Collider, IFSCollision onCollision = null)
//        {
//            SetFSGameObject(fSGameObject);
//            IFSBCollision = onCollision;
//            Radius = new Fix64(Collider.radius);
//            Fix64Vector3 halfSize = new Fix64Vector3(0, 0, 0);
//            center.X = (Fix64)(Collider.center.x);
//            center.Y = (Fix64)(Collider.center.y);
//            center.Z = (Fix64)(Collider.center.z);

//            halfSize.X = (Fix64)(Collider.bounds.size.x / 2);
//            halfSize.Y = (Fix64)(Collider.bounds.size.y / 2);
//            halfSize.Z = (Fix64)(Collider.bounds.size.y / 2);

//            vertex[0] = Fix64Vector3.SetVertex(halfSize.X, halfSize.Y, -halfSize.Z);
//            vertex[1] = Fix64Vector3.SetVertex(halfSize.X, -halfSize.Y, -halfSize.Z);
//            vertex[2] = Fix64Vector3.SetVertex(-halfSize.X, -halfSize.Y, -halfSize.Z);
//            vertex[3] = Fix64Vector3.SetVertex(-halfSize.X, halfSize.Y, -halfSize.Z);
//            vertex[4] = Fix64Vector3.SetVertex(halfSize.X, halfSize.Y, halfSize.Z);
//            vertex[5] = Fix64Vector3.SetVertex(halfSize.X, -halfSize.Y, halfSize.Z);
//            vertex[6] = Fix64Vector3.SetVertex(-halfSize.X, -halfSize.Y, halfSize.Z);
//            vertex[7] = Fix64Vector3.SetVertex(-halfSize.X, halfSize.Y, halfSize.Z);

//            for (int i = 0; i < vertex.Length; i++)
//            {
//                maxVertex.X = Fix64.Max(maxVertex.X, vertex[i].X);
//                maxVertex.Y = Fix64.Max(maxVertex.Y, vertex[i].Y);
//                maxVertex.Z = Fix64.Max(maxVertex.Z, vertex[i].Z);

//                minVertex.X = Fix64.Min(minVertex.X, vertex[i].X);
//                minVertex.Y = Fix64.Min(minVertex.Y, vertex[i].Y);
//                minVertex.Z = Fix64.Min(minVertex.Z, vertex[i].Z);
//            }
//            HalfSize.X = (maxVertex.X - minVertex.X) / Fix64.Two;
//            HalfSize.Y = (maxVertex.Y - minVertex.Y) / Fix64.Two;
//            HalfSize.Z = (maxVertex.Z - minVertex.Z) / Fix64.Two;
//        }
//        public override void OnCollision(FSCollisionBase Collision)
//        {
//            base.OnCollision(Collision);
//            if (IFSBCollision != null)
//            {
//                IFSBCollision.OnCollision(Collision);
//            }
//        }
//    }
//}
