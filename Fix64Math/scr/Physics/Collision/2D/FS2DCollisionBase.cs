//using Fix64Math;
//using Fix64Physics.scr.Math;
//using System.Collections.Generic;

//namespace Fix64Physics
//{
//    public class FS2DCollisionBase : FSCollisionBase
//    {
//        protected Fix64Vector2 HalfSize;
//        protected Fix64Vector2 maxVertex;
//        protected Fix64Vector2 minVertex;
//        protected Fix64Vector2 center;
//        public Fix64Vector2 Center { get { return center; } }
//        public Fix64Vector2 MaxVertex { get { return maxVertex; } }
//        public Fix64Vector2 MinVertex { get { return minVertex; } }
//        public List<Fix64Vector2[]> lines = new List<Fix64Vector2[]>();
//        protected Fix64Vector2[] vertex = new Fix64Vector2[4];
//        public Fix64Vector2 GetHalfSize()
//        {
//            return HalfSize;
//        }
//        public override bool CheckCollision(FSCollisionBase Collision)
//        {
//            if ((Collision as FS2DCollisionBase) == null) return false;
//            return CheckFS2DCollision(this, Collision as FS2DCollisionBase);
//        }
//        public static bool CheckFS2DCollision(FS2DCollisionBase a, FS2DCollisionBase b)
//        {
//            if ((a as FS2DBoxCollision) != null && (b as FS2DBoxCollision) != null)
//            {
//                return CheckFS2DCollision(a as FS2DBoxCollision, b as FS2DBoxCollision);
//            }
//            else if ((a as FS2DSphereCollision) != null && (b as FS2DSphereCollision) != null)
//            {
//                return CheckFS2DCollision(a as FS2DSphereCollision, b as FS2DSphereCollision);
//            }
//            else if ((a as FS2DBoxCollision) != null && (b as FS2DSphereCollision) != null)
//            {
//                return CheckFS2DCollision(a as FS2DBoxCollision, b as FS2DSphereCollision);
//            }
//            else if ((a as FS2DSphereCollision) != null && (b as FS2DBoxCollision) != null)
//            {
//                return CheckFS2DCollision(b as FS2DBoxCollision, a as FS2DSphereCollision);
//            }
//            else
//            {
//                return false;
//            }
//        }
//        public static bool CheckFS2DCollision(FS2DBoxCollision box, FS2DSphereCollision Sphere)
//        {
//            if (CheckCollisionSize(box, Sphere))
//            {
//                Fix64Vector2 posA = box.GetPos().ToFix64Vector2() + box.Center;
//                Fix64Vector2 posB = Sphere.GetPos().ToFix64Vector2() + Sphere.Center;
//                Fix64Vector2 localPos = posB;
//                Fix64 x = localPos.X;
//                x = Fix64.Min(box.MaxVertex.X + posA.X, x);
//                x = Fix64.Max(box.minVertex.X + posA.X, x);
//                Fix64 y = localPos.Y;
//                y = Fix64.Min(box.MaxVertex.Y + posA.Y, y);
//                y = Fix64.Max(box.minVertex.Y + posA.Y, y);
//                Fix64Vector2 point = new Fix64Vector2(x, y);
//                Fix64 distance = (localPos - point).Magnitude();
//                return (localPos - point).Magnitude() < Sphere.Radius;
//            }
//            return false;
//        }
//        public static bool CheckFS2DCollision(FS2DSphereCollision Sphereba, FS2DSphereCollision Sphereb)
//        {
//            if (CheckCollisionSize(Sphereba, Sphereb))
//            {
//                Fix64Vector2 posA = Sphereba.GetPos().ToFix64Vector2() + Sphereba.Center;
//                Fix64Vector2 posB = Sphereb.GetPos().ToFix64Vector2() + Sphereba.Center;
//                return (posA - posB).Magnitude() < (Sphereba.Radius + Sphereb.Radius);
//            }
//            return false;
//        }
//        public static bool CheckFS2DCollision(FS2DBoxCollision boxa, FS2DBoxCollision boxb)
//        {
//            return CheckCollisionSize(boxa, boxb);
//        }
//        static bool CheckCollisionSize(FS2DCollisionBase a, FS2DCollisionBase b)
//        {
//            Fix64Vector2 posA = a.GetPos().ToFix64Vector2() + a.Center;
//            Fix64Vector2 posB = b.GetPos().ToFix64Vector2() + b.Center;
//            return Fix64.Abs(posA.X - posB.X) < a.GetHalfSize().X + b.GetHalfSize().X &&
//                 Fix64.Abs(posA.Y - posB.Y) < a.GetHalfSize().Y + b.GetHalfSize().Y;
//        }
//        public static bool RayCast2D(FS2DRay ray, FS2DCollisionBase Collision, out FS2DRaycastHit hit)
//        {
//            hit = new FS2DRaycastHit();
//            if (Collision.GetType() == typeof(FS2DBoxCollision))
//            {
//                return RayTo3DBox(ray, Collision as FS2DBoxCollision, out hit);
//            }
//            if (Collision.GetType() == typeof(FS2DSphereCollision))
//            {
//                return RayTo3DSphere(ray, Collision as FS2DSphereCollision, out hit);
//            }
//            return false;
//        }

//        static bool RayTo3DBox(FS2DRay ray, FS2DBoxCollision Collision, out FS2DRaycastHit hit)
//        {
//            hit = new FS2DRaycastHit();
//            FS2DBoxCollision item = Collision;
//            Fix64Vector2 ptOnPlane; //射线与包围盒某面的交点
//            Fix64Vector2 min = item.GetPos().ToFix64Vector2() + item.Center + item.MinVertex; //aabb包围盒最小点坐标
//            Fix64Vector2 max = item.GetPos().ToFix64Vector2() + item.Center + item.MaxVertex; //aabb包围盒最大点坐标
//            Fix64Vector2 origin = ray.origin; //射线起始点
//            Fix64Vector2 dir = ray.direction; //方向矢量
//            Fix64 t;
//            //分别判断射线与各面的相交情况
//            //判断射线与包围盒x轴方向的面是否有交点
//            if (dir.X != Fix64.Zero) //射线x轴方向分量不为0 若射线方向矢量的x轴分量为0，射线不可能经过包围盒朝x轴方向的两个面
//            {
//                /*
//                  使用射线与平面相交的公式求交点
//                 */
//                if (dir.X > Fix64.Zero)//若射线沿x轴正方向偏移
//                    t = (min.X - origin.X) / dir.X;
//                else  //射线沿x轴负方向偏移
//                    t = (max.X - origin.X) / dir.X;

//                if (t > Fix64.Zero) //t>0时则射线与平面相交
//                {
//                    ptOnPlane = origin + dir * t; //计算交点坐标
//                                                  //判断交点是否在当前面内
//                    if (min.Y < ptOnPlane.Y && ptOnPlane.Y < max.Y)
//                    {
//                        hit.collider = Collision;
//                        hit.distance = Fix64Vector2.Distance(origin, ptOnPlane);
//                        hit.point = ptOnPlane;
//                        return true; //射线与包围盒有交点
//                    }
//                }
//            }
//            //若射线沿y轴方向有分量 判断是否与包围盒y轴方向有交点
//            if (dir.Y != Fix64.Zero)
//            {
//                if (dir.Y > Fix64.Zero)
//                    t = (min.Y - origin.Y) / dir.Y;
//                else
//                    t = (max.Y - origin.Y) / dir.Y;

//                if (t > Fix64.Zero)
//                {
//                    ptOnPlane = origin + dir * t;

//                    if (min.X < ptOnPlane.X && ptOnPlane.X < max.X)
//                    {
//                        hit.collider = Collision;
//                        hit.distance = Fix64Vector2.Distance(origin, ptOnPlane);
//                        hit.point = ptOnPlane;
//                        return true;
//                    }
//                }
//            }
//            return false;
//        }
//        static bool RayTo3DSphere(FS2DRay ray, FS2DSphereCollision Collision, out FS2DRaycastHit hit)
//        {
//            hit = new FS2DRaycastHit();
//            Fix64Vector2 offset = Collision.GetPos().ToFix64Vector2() + Collision.Center - ray.origin;
//            Fix64 rayDist = Fix64Vector2.Dot(ray.direction, offset);
//            Fix64 off2 = Fix64Vector2.Dot(offset, offset);
//            Fix64 rad2 = Collision.Radius * Collision.Radius;
//            // we're in the sphere
//            if (off2 <= rad2)
//            {
//                hit.collider = Collision;
//                hit.point = ray.origin;
//                hit.normal = Fix64Vector2.Zero;
//                hit.distance = Fix64.Zero;
//                return true;
//            }
//            // moving away from object or too far away
//            if (rayDist <= Fix64.Zero)
//            {
//                return false;
//            }
//            // find hit distance squared
//            // ray passes by sphere without hitting
//            Fix64 d = rad2 - (off2 - rayDist * rayDist);
//            if (d <= Fix64.Zero)
//            {
//                return false;
//            }
//            // get the distance along the ray
//            hit.distance = rayDist - Fix64.Sqrt(d);
//            hit.collider = Collision;
//            hit.point = ray.origin + ray.direction * hit.distance;
//            return true;
//        }
//    }
//}
