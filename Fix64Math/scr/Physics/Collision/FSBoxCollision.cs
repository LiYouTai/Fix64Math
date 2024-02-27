//using LookStep.VGLookStep.Math;
//using UnityEngine;

//namespace LookStep.VGLookStep
//{
//    public class FSBoxCollision : FSCollisionBase
//    {
//        IFSCollision IFSBCollision;
//        public Fix64Vector2 Forward = new Fix64Vector2(0, 1);
//        public Fix64Vector2 CollisionDir = new Fix64Vector2(0, 1);
//        private Fix64Vector2 HalfSize = new Fix64Vector2(0, 0);

//        public void SetData(FSGameObject fSGameObject, BoxCollider Collider, IFSCollision onCollision = null)
//        {
//            SetFSGameObject(fSGameObject);
//            IFSBCollision = onCollision;
//            Fix64Vector2 halfSize = new Fix64Vector2(0, 0);
//            Fix64Vector2 center = new Fix64Vector2(0, 0);
//            center.X = (Fix64)(Collider.center.x);
//            center.Y = (Fix64)(Collider.center.y);
//            halfSize.X = (Fix64)(Collider.bounds.size.x / 2) + center.X;
//            halfSize.Y = (Fix64)(Collider.bounds.size.y / 2) + center.Y;
//            vertex[0] = Fix64Vector2.SetVertex(halfSize.X, halfSize.Y);
//            vertex[1] = Fix64Vector2.SetVertex(halfSize.X, -halfSize.Y);
//            vertex[2] = Fix64Vector2.SetVertex(-halfSize.X, -halfSize.Y);
//            vertex[3] = Fix64Vector2.SetVertex(-halfSize.X, halfSize.Y);
//            CalcBoundings();
//        }

//        /// <summary>
//        /// 计算包围盒尺寸
//        /// </summary>
//        public void CalcBoundings()
//        {
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
//        /// <summary>
//        /// 获得包围盒的尺寸
//        /// </summary>
//        /// <returns></returns>
//        public override Fix64Vector2 GetHalfSize()
//        {
//            return HalfSize;
//        }
//        public override Fix64Vector2 GetPos()
//        {
//            return FSTransform.FSPosition;
//        }
//        public override Fix64Vector2 Support(Fix64Vector2 d)
//        {
//            Fix64 maxDot = Fix64Vector2.Dot(vertex[0], d);
//            Fix64Vector2 point = vertex[0];
//            for (int i = 1; i < vertex.Length; i++)
//            {
//                Fix64 now = Fix64Vector2.Dot(vertex[i], d);
//                if (now > maxDot)
//                {
//                    maxDot = now;
//                    point = vertex[i];
//                }
//            }
//            return point + GetPos();
//        }
//        public override void OnCollision(FSCollisionBase Collision)
//        {
//            if (IFSBCollision != null)
//            {
//                IFSBCollision.OnCollision(Collision);
//            }
//        }
//    }
//}
