namespace Fix64Math.Component
{
    public class FSObject
    {
        public string Name { get; private set; }
        public object Data { get; private set; }
        public Fix64Vector3 Position { get; set; }
        public Fix64Vector3 Scale { get; set; }

        public FSObject(string name, object data)
        {
            Name = name;
            Data = data;
        }
    }
}
