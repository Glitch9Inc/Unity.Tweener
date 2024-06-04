using System;
using UnityEngine;
#if UNITY_EDITOR && UNITY_EDITOR_COROUTINES
using Unity.EditorCoroutines.Editor;
#endif
#if UNITASK
using Cysharp.Threading.Tasks;
#endif

// ReSharper disable All

namespace Glitch9.Toolkits.Tweener
{
    public class TweenTask
    {
        internal int objHashCode;
        internal float[] from;
        internal float[] to;
        internal float duration;
        internal float delay;
        internal float elapsed;
        internal Ease easeType;
        internal TweenType tweenType;
        internal Action<float[]> onUpdate;
        internal bool relative;
        internal Action onComplete;
        internal Coroutine coroutine;

#if UNITY_EDITOR && UNITY_EDITOR_COROUTINES
        internal EditorCoroutine editorCoroutine;
#endif

        internal TweenTask(TweenType tweenType)
        {
            this.tweenType = tweenType;
        }

        public TweenTask SetDuration(float duration)
        {
            this.duration = duration;
            return this;
        }

        public TweenTask SetDelay(float delay)
        {
            this.delay = delay;
            return this;
        }

        public TweenTask SetEase(Ease easeType)
        {
            this.easeType = easeType;
            return this;
        }

        public TweenTask SetRelative(bool relative)
        {
            this.relative = relative;
            return this;
        }

        public TweenTask OnComplete(Action onComplete)
        {
            this.onComplete = onComplete;
            return this;
        }

        public TweenTask HideOnComplete(GameObject gameObject)
        {
            this.onComplete += () => gameObject.SetActive(false);
            return this;
        }

        public void StartCoroutine(Action<float[]> onUpdate)
        {
            if (Application.isPlaying)
            {
                coroutine = Tween.TweenerInstance.StartCoroutine(TweenUtils.TweenRoutine(this, onUpdate));
            }
            else
            {
#if UNITY_EDITOR && UNITY_EDITOR_COROUTINES
                // Consider removing frame rate manipulation or make it conditional
                editorCoroutine = EditorCoroutineUtility.StartCoroutineOwnerless(TweenUtils.TweenRoutine(this, onUpdate));
#endif
            }
        }

        public void StopCoroutine()
        {
            if (Application.isPlaying)
            {
                if (coroutine != null) Tween.TweenerInstance.StopCoroutine(coroutine);
            }
            else
            {
#if UNITY_EDITOR && UNITY_EDITOR_COROUTINES
                if (editorCoroutine != null) EditorCoroutineUtility.StopCoroutine(editorCoroutine);
#endif
            }
        }

        public static bool operator ==(TweenTask a, TweenTask b)
        {
            return a?.objHashCode == b?.objHashCode && a?.tweenType == b?.tweenType;
        }

        public static bool operator !=(TweenTask a, TweenTask b)
        {
            return a?.objHashCode != b?.objHashCode || a?.tweenType != b?.tweenType;
        }

        public override bool Equals(object obj)
        {
            TweenTask task = obj as TweenTask;
            return objHashCode == task?.objHashCode && tweenType == task?.tweenType;
        }

        public override int GetHashCode()
        {
            return objHashCode;
        }

#if UNITASK
        public async UniTask ToUniTask()
        {
            await UniTask.Yield();
            await UniTask.WaitUntil(() => elapsed >= duration);
        }
#endif
    }
}