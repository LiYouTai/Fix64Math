//using Fix64Math;
//using Fix64Physics.scr.Math;

//namespace Fix64Physics
//{
//    public class FS2DBoxCollision : FS2DCollisionBase
//    {
//        IFSCollision IFSBCollision;

//        public void SetData(FSGameObject fSGameObject, BoxCollider Collider, IFSCollision onCollision = null)
//        {
//            SetFSGameObject(fSGameObject);
//            IFSBCollision = onCollision;
//            Fix64Vector2 halfSize = new Fix64Vector2(0, 0);
//            center.X = (Fix64)(Collider.center.x);
//            center.Y = (Fix64)(Collider.center.y);
//            halfSize.X = (Fix64)(Collider.bounds.size.x / 2);
//            halfSize.Y = (Fix64)(Collider.bounds.size.y / 2);
//            vertex[0] = Fix64Vector2.SetVertex(halfSize.X, halfSize.Y);
//            vertex[1] = Fix64Vector2.SetVertex(halfSize.X, -halfSize.Y);
//            vertex[2] = Fix64Vector2.SetVertex(-halfSize.X, -halfSize.Y);
//            vertex[3] = Fix64Vector2.SetVertex(-halfSize.X, halfSize.Y);
//            lines.Add(new Fix64Vector2[2] { vertex[0], vertex[1] });
//            lines.Add(new Fix64Vector2[2] { vertex[1], vertex[2] });
//            lines.Add(new Fix64Vector2[2] { vertex[2], vertex[3] });
//            lines.Add(new Fix64Vector2[2] { vertex[3], vertex[0] });
//            for (int i = 0; i < vertex.Length; i++)
//            {
//                maxVertex.X = Fix64.Max(maxVertex.X, vertex[i].X);
//                maxVertex.Y = Fix64.Max(maxVertex.Y, vertex[i].Y);
//                minVertex.X = Fix64.Min(minVertex.X, vertex[i].X);
//                minVertex.Y = Fix64.Min(minVertex.Y, vertex[i].Y);
//            }
//            HalfSize.X = (maxVertex.X - minVertex.X) / Fix64.Two;
//            HalfSize.Y = (maxVertex.Y - minVertex.Y) / Fix64.Two;
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
