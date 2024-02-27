//using System.Collections.Generic;

//namespace Fix64Physics
//{
//    public class FSComponentEngine
//    {
//        public static bool IsStart { get; private set; }
//        static List<IComponentBase> Components = new List<IComponentBase>();
//        public static T Add<T>(T Component) where T : IComponentBase
//        {
//            Components.Add(Component);
//            return Component;
//        }
//        public static void Remove<T>(T Component) where T : IComponentBase
//        {
//            if (Components.Contains(Component))
//            {
//                Components.Remove(Component);
//            }
//        }
//        public static void Update()
//        {
//            if (!IsStart) return;
//            Components.ForEach(a => a.Update());
//        }
//        public static void Start()
//        {
//            IsStart = true;
//        }
//        public static void Exit()
//        {
//            IsStart = false;
//            for (int i = 0; i < Components.Count; i++)
//            {
//                Components[i] = null;
//            }
//            Components.Clear();
//        }
//    }
//}
