//using Fix64Math;
//using Fix64Physics.scr.Math;

//namespace Fix64Physics
//{
//    public class FS2DSphereCollision : FS2DCollisionBase
//    {
//        IFSCollision IFSBCollision;
//        public Fix64 Radius { get; private set; }
//        public void SetData(FSGameObject fSGameObject, SphereCollider Collider, IFSCollision onCollision = null)
//        {
//            SetFSGameObject(fSGameObject);
//            IFSBCollision = onCollision;
//            Radius = new Fix64(Collider.radius);
//            Fix64Vector2 halfSize = new Fix64Vector2(0, 0);
//            center.X = (Fix64)(Collider.center.x);
//            center.Y = (Fix64)(Collider.center.y);
//            halfSize.X = (Fix64)(Collider.bounds.size.x / 2);
//            halfSize.Y = (Fix64)(Collider.bounds.size.y / 2);
//            vertex[0] = Fix64Vector2.SetVertex(halfSize.X, halfSize.Y);
//            vertex[1] = Fix64Vector2.SetVertex(halfSize.X, -halfSize.Y);
//            vertex[2] = Fix64Vector2.SetVertex(-halfSize.X, -halfSize.Y);
//            vertex[3] = Fix64Vector2.SetVertex(-halfSize.X, halfSize.Y);
//            //step1 分别计算4个轴向上最大/最小的x y 值
//            Fix64 MAXX = (Fix64)0;
//            Fix64 MAXY = (Fix64)0;
//            Fix64 MINX = (Fix64)0;
//            Fix64 MINY = (Fix64)0;
//            for (int i = 0; i < vertex.Length; i++)
//            {
//                MAXX = Fix64.Max(MAXX, vertex[i].X);
//                MAXY = Fix64.Max(MAXY, vertex[i].Y);
//                MINX = Fix64.Min(MINX, vertex[i].X);
//                MINY = Fix64.Min(MINY, vertex[i].Y);
//            }
//            HalfSize.X = (MAXX - MINX) / Fix64.Two;
//            HalfSize.Y = (MAXY - MINY) / Fix64.Two;
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
