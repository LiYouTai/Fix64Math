using Fix64Math.Physics;

namespace Fix64Math.Component
{
    public class FSBoxCollision : FSCollisionBase
    {
        public override ECollisionType Type => ECollisionType.BOX;
        public override string Name => Object.Name;
        public FSBoxCollision(FSObject @object, Fix64Vector3 colliderCenter, Fix64Vector3 size) : base(@object)
        {
            center = colliderCenter;
            Fix64Vector3 halfSize = size / (Fix64)2;
            vertex[0] = Fix64Vector3.SetVertex(halfSize.X, halfSize.Y, -halfSize.Z);
            vertex[1] = Fix64Vector3.SetVertex(halfSize.X, -halfSize.Y, -halfSize.Z);
            vertex[2] = Fix64Vector3.SetVertex(-halfSize.X, -halfSize.Y, -halfSize.Z);
            vertex[3] = Fix64Vector3.SetVertex(-halfSize.X, halfSize.Y, -halfSize.Z);
            vertex[4] = Fix64Vector3.SetVertex(halfSize.X, halfSize.Y, halfSize.Z);
            vertex[5] = Fix64Vector3.SetVertex(halfSize.X, -halfSize.Y, halfSize.Z);
            vertex[6] = Fix64Vector3.SetVertex(-halfSize.X, -halfSize.Y, halfSize.Z);
            vertex[7] = Fix64Vector3.SetVertex(-halfSize.X, halfSize.Y, halfSize.Z);

            lines.Add(new Fix64Vector3[2] { vertex[0], vertex[1] });
            lines.Add(new Fix64Vector3[2] { vertex[1], vertex[2] });
            lines.Add(new Fix64Vector3[2] { vertex[2], vertex[3] });
            lines.Add(new Fix64Vector3[2] { vertex[3], vertex[0] });

            lines.Add(new Fix64Vector3[2] { vertex[4], vertex[5] });
            lines.Add(new Fix64Vector3[2] { vertex[5], vertex[6] });
            lines.Add(new Fix64Vector3[2] { vertex[6], vertex[7] });
            lines.Add(new Fix64Vector3[2] { vertex[7], vertex[4] });

            lines.Add(new Fix64Vector3[2] { vertex[0], vertex[4] });
            lines.Add(new Fix64Vector3[2] { vertex[1], vertex[5] });
            lines.Add(new Fix64Vector3[2] { vertex[2], vertex[3] });
            lines.Add(new Fix64Vector3[2] { vertex[3], vertex[7] });

            for (int i = 0; i < vertex.Length; i++)
            {
                maxVertex.X = Fix64.Max(maxVertex.X, vertex[i].X);
                maxVertex.Y = Fix64.Max(maxVertex.Y, vertex[i].Y);
                maxVertex.Z = Fix64.Max(maxVertex.Z, vertex[i].Z);

                minVertex.X = Fix64.Min(minVertex.X, vertex[i].X);
                minVertex.Y = Fix64.Min(minVertex.Y, vertex[i].Y);
                minVertex.Z = Fix64.Min(minVertex.Z, vertex[i].Z);
            }
            halfSize.X = (maxVertex.X - minVertex.X) / Fix64.Two;
            halfSize.Y = (maxVertex.Y - minVertex.Y) / Fix64.Two;
            halfSize.Z = (maxVertex.Z - minVertex.Z) / Fix64.Two;
        }
    }
}
