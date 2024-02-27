namespace Fix64Math.Physics
{
    internal class CollisionsMath
    {
        public static bool CheckCollision(IFSCollisionBase a, IFSCollisionBase b)
        {
            if (a.Type == ECollisionType.BOX && b.Type == ECollisionType.BOX)
            {
                return CheckCollisionSize(a, b);
            }
            //else if (a is FS3DSphereCollision && b is FS3DSphereCollision)
            //{
            //    return CheckFS2DCollision(a as FS3DSphereCollision, b as FS3DSphereCollision);
            //}
            //else if ((a as Fix64BoxCollision) != null && (b as FS3DSphereCollision) != null)
            //{
            //    return CheckFS2DCollision(a as Fix64BoxCollision, b as FS3DSphereCollision);
            //}
            //else if ((a as FS3DSphereCollision) != null && (b as Fix64BoxCollision) != null)
            //{
            //    return CheckFS2DCollision(b as Fix64BoxCollision, a as FS3DSphereCollision);
            //}
            else
            {
                return false;
            }
        }
        //public static bool CheckFS2DCollision(Fix64BoxCollision a, FS3DSphereCollision b)
        //{
        //    if (CheckCollisionSize(a, b))
        //    {
        //        Fix64Vector3 posA = a.Position + a.Center;
        //        Fix64Vector3 posB = b.Position + b.Center;
        //        Fix64Vector3 localPos = posB;
        //        Fix64 x = localPos.X;
        //        x = Fix64.Min(a.MaxVertex.X + posA.X, x);
        //        x = Fix64.Max(a.MinVertex.X + posA.X, x);
        //        Fix64 y = localPos.Y;
        //        y = Fix64.Min(a.MaxVertex.Y + posA.Y, y);
        //        y = Fix64.Max(a.MinVertex.Y + posA.Y, y);
        //        Fix64 z = localPos.Z;
        //        z = Fix64.Min(a.MaxVertex.Z + posA.Z, z);
        //        z = Fix64.Max(a.MinVertex.Z + posA.Z, z);
        //        Fix64Vector3 point = new Fix64Vector3(x, y, z);
        //        return (localPos - point).Magnitude() < b.Radius;
        //    }
        //    return false;
        //}
        //public static bool CheckFS2DCollision(FS3DSphereCollision a, FS3DSphereCollision b)
        //{
        //    if (CheckCollisionSize(a, b))
        //    {
        //        Fix64Vector3 posA = a.Position + a.Center;
        //        Fix64Vector3 posB = b.Position + a.Center;
        //        return (posA - posB).Magnitude() < (a.Radius + b.Radius);
        //    }
        //    return false;
        //}
        private static bool CheckCollisionSize(IFSCollisionBase a, IFSCollisionBase b)
        {
            Fix64Vector3 posA = a.Position + a.Center;
            Fix64Vector3 posB = b.Position + b.Center;
            return Fix64.Abs(posA.X - posB.X) < a.HalfSize.X + b.HalfSize.X &&
                 Fix64.Abs(posA.Y - posB.Y) < a.HalfSize.Y + b.HalfSize.Y &&
                 Fix64.Abs(posA.Z - posB.Z) < a.HalfSize.Z + b.HalfSize.Z;
        }
        //public static bool RayCast3D(FS3DRay ray, Fix64CollisionBase Collision, out FS3DRaycastHit hit)
        //{
        //    hit = new FS3DRaycastHit();
        //    if (Collision.GetType() == typeof(Fix64BoxCollision))
        //    {
        //        return RayTo3DBox(ray, Collision as Fix64BoxCollision, out hit);
        //    }
        //    if (Collision.GetType() == typeof(FS3DSphereCollision))
        //    {
        //        return RayTo3DSphere(ray, Collision as FS3DSphereCollision, out hit);
        //    }
        //    return false;
        //}
        //static bool RayTo3DBox(FS3DRay ray, Fix64BoxCollision Collision, out FS3DRaycastHit hit)
        //{
        //    hit = new FS3DRaycastHit();
        //    Fix64BoxCollision item = Collision;
        //    Fix64Vector3 ptOnPlane; //射线与包围盒某面的交点
        //    Fix64Vector3 min = item.Position + item.Center + item.MinVertex; //aabb包围盒最小点坐标
        //    Fix64Vector3 max = item.Position + item.Center + item.MaxVertex; //aabb包围盒最大点坐标
        //    Fix64Vector3 origin = ray.origin; //射线起始点
        //    Fix64Vector3 dir = ray.direction; //方向矢量
        //    Fix64 t;
        //    //分别判断射线与各面的相交情况
        //    //判断射线与包围盒x轴方向的面是否有交点
        //    if (dir.X != Fix64.Zero) //射线x轴方向分量不为0 若射线方向矢量的x轴分量为0，射线不可能经过包围盒朝x轴方向的两个面
        //    {
        //        /*
        //          使用射线与平面相交的公式求交点
        //         */
        //        if (dir.X > Fix64.Zero)//若射线沿x轴正方向偏移
        //            t = (min.X - origin.X) / dir.X;
        //        else  //射线沿x轴负方向偏移
        //            t = (max.X - origin.X) / dir.X;

        //        if (t > Fix64.Zero) //t>0时则射线与平面相交
        //        {
        //            ptOnPlane = origin + dir * t; //计算交点坐标
        //                                          //判断交点是否在当前面内
        //            if (min.Y < ptOnPlane.Y && ptOnPlane.Y < max.Y && min.Z < ptOnPlane.Z && ptOnPlane.Z < max.Z)
        //            {
        //                hit = new FS3DRaycastHit();
        //                hit.collider = Collision;
        //                hit.distance = Fix64Vector3.Distance(origin, ptOnPlane);
        //                hit.point = ptOnPlane;
        //                return true; //射线与包围盒有交点
        //            }
        //        }
        //    }
        //    //若射线沿y轴方向有分量 判断是否与包围盒y轴方向有交点
        //    if (dir.Y != Fix64.Zero)
        //    {
        //        if (dir.Y > Fix64.Zero)
        //            t = (min.Y - origin.Y) / dir.Y;
        //        else
        //            t = (max.Y - origin.Y) / dir.Y;

        //        if (t > Fix64.Zero)
        //        {
        //            ptOnPlane = origin + dir * t;

        //            if (min.Z < ptOnPlane.Z && ptOnPlane.Z < max.Z && min.X < ptOnPlane.X && ptOnPlane.X < max.X)
        //            {
        //                hit = new FS3DRaycastHit();
        //                hit.collider = Collision;
        //                hit.distance = Fix64Vector3.Distance(origin, ptOnPlane);
        //                hit.point = ptOnPlane;
        //                return true;
        //            }
        //        }
        //    }
        //    //若射线沿z轴方向有分量 判断是否与包围盒y轴方向有交点
        //    if (dir.Z != Fix64.Zero)
        //    {
        //        if (dir.Z > Fix64.Zero)
        //            t = (min.Z - origin.Z) / dir.Z;
        //        else
        //            t = (max.Z - origin.Z) / dir.Z;

        //        if (t > Fix64.Zero)
        //        {
        //            ptOnPlane = origin + dir * t;

        //            if (min.X < ptOnPlane.X && ptOnPlane.X < max.X && min.Y < ptOnPlane.Y && ptOnPlane.Y < max.Y)
        //            {
        //                hit = new FS3DRaycastHit();
        //                hit.collider = Collision;
        //                hit.distance = Fix64Vector3.Distance(origin, ptOnPlane);
        //                hit.point = ptOnPlane;
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}
        //static bool RayTo3DSphere(FS3DRay ray, FS3DSphereCollision Collision, out FS3DRaycastHit hit)
        //{
        //    hit = new FS3DRaycastHit();
        //    Fix64Vector3 offset = Collision.Position + Collision.Center - ray.origin;
        //    Fix64 rayDist = Fix64Vector3.Dot(ray.direction, offset);
        //    Fix64 off2 = Fix64Vector3.Dot(offset, offset);
        //    Fix64 rad2 = Collision.Radius * Collision.Radius;
        //    // we're in the sphere
        //    if (off2 <= rad2)
        //    {
        //        hit.collider = Collision;
        //        hit.point = ray.origin;
        //        hit.normal = Fix64Vector3.Zero;
        //        hit.distance = Fix64.Zero;
        //        return true;
        //    }
        //    // moving away from object or too far away
        //    if (rayDist <= Fix64.Zero)
        //    {
        //        return false;
        //    }
        //    // find hit distance squared
        //    // ray passes by sphere without hitting
        //    Fix64 d = rad2 - (off2 - rayDist * rayDist);
        //    if (d <= Fix64.Zero)
        //    {
        //        return false;
        //    }
        //    // get the distance along the ray
        //    hit.distance = rayDist - Fix64.Sqrt(d);
        //    hit.collider = Collision;
        //    hit.point = ray.origin + ray.direction * hit.distance;
        //    return true;
        //}
    }
}
