//using System;
//namespace Fix64Physics
//{
//    public interface IComponentBase
//    {
//        void Update();
//        void Destory();
//    }

//    public abstract class ComponentBase : IComponentBase, IDisposable
//    {
//        public ComponentBase()
//        {
//            OnInit();
//            FSComponentEngine.Add(this);
//        }
//        public void Update() { }
//        public void Destory()
//        {
//            OnDestory();
//            Dispose(true);
//        }
//        public virtual void OnInit() { }
//        public virtual void OnDestory() { }
//        public virtual void OnUpdate() { }

//        #region IDisposable Support
//        private bool disposed = false;
//        ~ComponentBase()
//        {
//            this.Dispose(false);
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposed)
//            {
//                if (disposing) { }
//                FSComponentEngine.Remove(this);
//                disposed = true;
//            }
//        }

//        public void Dispose()
//        {
//            this.Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//        #endregion
//    }
//}