//using Fix64Math;
//using Fix64Physics.scr.Component;
//using System.Collections.Generic;
//namespace Fix64Physics
//{
//    public interface IFSAnimatorEvent
//    {
//        void OnFSAnimatorEvent(string animKey, string parameter, int frame);
//    }
//    public interface IFSAnimatorState
//    {
//        void OnStateEnter(FsAnimationClip Clip);
//        void OnStateUpdate(FsAnimationClip Clip, int curFrame);
//        void OnStateExit(FsAnimationClip Clip);
//    }
//    [System.Serializable]
//    public class FS_Animator : ComponentBase
//    {
//        IFSAnimatorState OnAnimState;

//        static Fix64 MaxPer = new Fix64(100);
//        public string curState { get; private set; }
//        public string defaultState { get { return "Standby"; } }
//        public int curFrame { get; private set; }
//        public Dictionary<string, List<FsAnimationEvent>> AnimEventDic = new Dictionary<string, List<FsAnimationEvent>>();
//        public Dictionary<string, FsAnimationClip> AnimationClipDic = new Dictionary<string, FsAnimationClip>();
//        public Dictionary<string, int> MaxEventFrameDic = new Dictionary<string, int>();
//        public void Init(IFSAnimatorState IFSAnimatorState)
//        {
//            OnAnimState = IFSAnimatorState;
//        }
//        public void AddAnimationClip(FsAnimationClip clip)
//        {
//            if (!AnimationClipDic.ContainsKey(clip.state))
//            {
//                AnimationClipDic.Add(clip.state, clip);
//            }
//        }
//        public void AddAnimationClip(string state, UnityEngine.AnimationClip clip, Fix64 frameRate)
//        {
//            AddAnimationClip(AnimationClipToFs(state, clip, frameRate));
//        }
//        public void AddEvent(string ClipName, int frame, string parameter, IFSAnimatorEvent fsEvent = null)
//        {
//            if (!AnimEventDic.ContainsKey(ClipName))
//            {
//                AnimEventDic.Add(ClipName, new List<FsAnimationEvent>());
//                MaxEventFrameDic.Add(ClipName, 0);
//            }
//            FsAnimationEvent data = new FsAnimationEvent();
//            data.animKey = ClipName;
//            data.frame = frame;
//            data.parameter = parameter;
//            data.fSAnimatorEvent = fsEvent;
//            AnimEventDic[ClipName].Add(data);
//            if (data.frame > MaxEventFrameDic[ClipName])
//            {
//                MaxEventFrameDic[ClipName] = data.frame;
//            }
//        }
//        public void Play(string key)
//        {
//            curFrame = 0;
//            curState = key;
//        }
//        public override void Update()
//        {
//            base.Update();
//            if (curState == null) return;
//            if (!AnimEventDic.ContainsKey(curState)) return;
//            if (curFrame <= MaxEventFrameDic[curState])
//            {
//                List<FsAnimationEvent> events = AnimEventDic[curState];
//                for (int i = 0; i < events.Count; i++)
//                {
//                    if (events[i].frame == curFrame)
//                    {
//                        events[i].PostEvent();
//                    }
//                }
//            }
//            curFrame++;
//            if (AnimationClipDic.ContainsKey(curState))
//            {
//                if (curFrame == 2)
//                {
//                    if (OnAnimState != null) OnAnimState.OnStateEnter(AnimationClipDic[curState]);
//                }
//                else if (curFrame >= AnimationClipDic[curState].frameLength)
//                {
//                    if (OnAnimState != null) OnAnimState.OnStateExit(AnimationClipDic[curState]);
//                    Play(defaultState);
//                }
//                else
//                {
//                    if (OnAnimState != null) OnAnimState.OnStateUpdate(AnimationClipDic[curState], curFrame);
//                }
//            }
//        }

//        public static int FrameRateToFrame(float clipTime, float per, float frameRate)
//        {
//            return FrameRateToFrame(new Fix64(clipTime), new Fix64(per), new Fix64(frameRate));
//        }
//        public static int FrameRateToFrame(Fix64 clipTime, Fix64 per, Fix64 frameRate)
//        {
//            return (int)(per / MaxPer * clipTime / frameRate);
//        }
//        public static FsAnimationClip AnimationClipToFs(string stateName, UnityEngine.AnimationClip clip, Fix64 frameRate)
//        {
//            FsAnimationClip fsClip = new FsAnimationClip();
//            fsClip.state = stateName;
//            fsClip.length = new Fix64(clip.length);
//            fsClip.frameRate = frameRate;
//            fsClip.frameLength = FrameRateToFrame(fsClip.length, MaxPer, frameRate);
//            return fsClip;
//        }
//    }
//    public class FsAnimationEvent
//    {
//        public string animKey;
//        public int frame;
//        public string parameter;
//        public IFSAnimatorEvent fSAnimatorEvent;
//        public void PostEvent()
//        {
//            if (fSAnimatorEvent != null)
//            {
//                fSAnimatorEvent.OnFSAnimatorEvent(animKey, parameter, frame);
//            }
//        }
//    }

//    public class FsAnimationClip
//    {
//        public string state;
//        public Fix64 length;
//        public Fix64 frameRate;
//        public int frameLength;
//    }
//}
