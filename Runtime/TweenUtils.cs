using System;
using System.Collections;
using UnityEngine;

namespace Glitch9.Toolkits.Tweener
{
    public static class TweenUtils
    {
        public static IEnumerator TweenRoutine(TweenTask task, Action<float[]> onUpdate)
        {
            if (task.from == null || task.from.Length == 0 ||
                task.to == null || task.to.Length == 0 ||
                task.from.Length != task.to.Length)
            {
                throw new Exception("Tweening Failed. From and To values must be set and have the same length.");
            }

            if (task.delay > 0) yield return new WaitForSeconds(task.delay);
            if (task.duration <= 0) task.duration = TweenSettings.DefaultTweenDuration;
            task.elapsed = 0;

            while (task.elapsed < task.duration)
            {
                task.elapsed += Time.deltaTime;
                float t = task.elapsed / task.duration;

                float[] values = new float[task.from.Length];
                for (int i = 0; i < task.from.Length; i++)
                {
                    // Adjusted for proper relative tweening
                    float targetValue = task.relative ? task.from[i] + task.to[i] : task.to[i];
                    values[i] = TweenUtils.Interpolate(task.from[i], targetValue, t, task.easeType);
                }

                onUpdate?.Invoke(values);
                yield return null;
            }

            try
            {
                // ensure that the final value is set
                onUpdate?.Invoke(task.to);
            }
            catch
            {
                // ignore out of range exceptions
            }

            task.onComplete?.Invoke();

            if (Tween.Tasks.Count == 0)
            {
                Application.targetFrameRate = TweenSettings.DefaultFrameRate;
            }
        }

        public static float Interpolate(float from, float to, float t, Ease easeType)
        {
            try
            {
                return easeType switch
                {
                    Ease.Linear => Linear(from, to, t),
                    Ease.InSine => InSine(from, to, t),
                    Ease.OutSine => OutSine(from, to, t),
                    Ease.InOutSine => InOutSine(from, to, t),
                    Ease.InQuad => InQuad(from, to, t),
                    Ease.OutQuad => OutQuad(from, to, t),
                    Ease.InOutQuad => InOutQuad(from, to, t),
                    Ease.InCubic => InCubic(from, to, t),
                    Ease.OutCubic => OutCubic(from, to, t),
                    Ease.InOutCubic => InOutCubic(from, to, t),
                    Ease.InQuart => InQuart(from, to, t),
                    Ease.OutQuart => OutQuart(from, to, t),
                    Ease.InOutQuart => InOutQuart(from, to, t),
                    Ease.InQuint => InQuint(from, to, t),
                    Ease.OutQuint => OutQuint(from, to, t),
                    Ease.InOutQuint => InOutQuint(from, to, t),
                    Ease.InExpo => InExpo(from, to, t),
                    Ease.OutExpo => OutExpo(from, to, t),
                    Ease.InOutExpo => InOutExpo(from, to, t),
                    Ease.InCirc => InCirc(from, to, t),
                    Ease.OutCirc => OutCirc(from, to, t),
                    Ease.InOutCirc => InOutCirc(from, to, t),
                    Ease.InElastic => InElastic(from, to, t),
                    Ease.OutElastic => OutElastic(from, to, t),
                    Ease.InOutElastic => InOutElastic(from, to, t),
                    Ease.InBack => InBack(from, to, t),
                    Ease.OutBack => OutBack(from, to, t),
                    Ease.InOutBack => InOutBack(from, to, t),
                    Ease.InBounce => InBounce(from, to, t),
                    Ease.OutBounce => OutBounce(from, to, t),
                    Ease.InOutBounce => InOutBounce(from, to, t),
                    Ease.Flash => Flash(from, to, t),
                    Ease.InFlash => InFlash(from, to, t),
                    Ease.OutFlash => OutFlash(from, to, t),
                    Ease.InOutFlash => InOutFlash(from, to, t),
                    _ => throw new NotImplementedException("Easing type not implemented")
                };
            }
            catch (NotImplementedException e)
            {
                Debug.LogWarning($"Easing type {easeType} not implemented. Defaulting to Linear. Error: {e.Message}");
                return Linear(from, to, t);
            }
        }

        private static float Linear(float from, float to, float t)
        {
            return from + (to - from) * t;
        }

        private static float InSine(float from, float to, float t)
        {
            return (float)(-(to - from) * Math.Cos(t * (Math.PI / 2)) + (to - from) + from);
        }

        private static float OutSine(float from, float to, float t)
        {
            return (float)((to - from) * Math.Sin(t * (Math.PI / 2)) + from);
        }

        private static float InOutSine(float from, float to, float t)
        {
            return (float)(-(to - from) / 2 * (Math.Cos(Math.PI * t) - 1) + from);
        }

        private static float InQuad(float from, float to, float t)
        {
            return (to - from) * t * t + from;
        }

        private static float OutQuad(float from, float to, float t)
        {
            return -(to - from) * t * (t - 2) + from;
        }

        private static float InOutQuad(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (to - from) / 2 * t * t + from;
            t--;
            return -(to - from) / 2 * (t * (t - 2) - 1) + from;
        }

        private static float InCubic(float from, float to, float t)
        {
            return (to - from) * t * t * t + from;
        }

        private static float OutCubic(float from, float to, float t)
        {
            t--;
            return (to - from) * (t * t * t + 1) + from;
        }

        private static float InOutCubic(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (to - from) / 2 * t * t * t + from;
            t -= 2;
            return (to - from) / 2 * (t * t * t + 2) + from;
        }

        private static float InQuart(float from, float to, float t)
        {
            return (to - from) * t * t * t * t + from;
        }

        private static float OutQuart(float from, float to, float t)
        {
            t--;
            return -(to - from) * (t * t * t * t - 1) + from;
        }

        private static float InOutQuart(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (to - from) / 2 * t * t * t * t + from;
            t -= 2;
            return -(to - from) / 2 * (t * t * t * t - 2) + from;
        }

        private static float InQuint(float from, float to, float t)
        {
            return (to - from) * t * t * t * t * t + from;
        }

        private static float OutQuint(float from, float to, float t)
        {
            t--;
            return (to - from) * (t * t * t * t * t + 1) + from;
        }

        private static float InOutQuint(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (to - from) / 2 * t * t * t * t * t + from;
            t -= 2;
            return (to - from) / 2 * (t * t * t * t * t + 2) + from;
        }

        private static float InExpo(float from, float to, float t)
        {
            return (float)(t == 0 ? from : (to - from) * Math.Pow(2, 10 * (t - 1)) + from);
        }

        private static float OutExpo(float from, float to, float t)
        {
            return (float)(t == 1 ? to : (to - from) * (-Math.Pow(2, -10 * t) + 1) + from);
        }

        private static float InOutExpo(float from, float to, float t)
        {
            if (t == 0) return from;
            if (t == 1) return to;
            t /= .5f;
            if (t < 1) return (float)((to - from) / 2 * Math.Pow(2, 10 * (t - 1)) + from);
            t--;
            return (float)((to - from) / 2 * (-Math.Pow(2, -10 * t) + 2) + from);
        }

        private static float InCirc(float from, float to, float t)
        {
            return (float)(-(to - from) * (Math.Sqrt(1 - t * t) - 1) + from);
        }

        private static float OutCirc(float from, float to, float t)
        {
            t--;
            return (float)((to - from) * Math.Sqrt(1 - t * t) + from);
        }

        private static float InOutCirc(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (float)(-(to - from) / 2 * (Math.Sqrt(1 - t * t) - 1) + from);
            t -= 2;
            return (float)((to - from) / 2 * (Math.Sqrt(1 - t * t) + 1) + from);
        }

        private static float InElastic(float from, float to, float t)
        {
            if (t == 0) return from;
            if (t == 1) return to;
            return (float)(-(to - from) * Math.Pow(2, 10 * (t - 1)) * Math.Sin((t - 1.1f) * (2 * Math.PI) / .4f) + from);
        }

        private static float OutElastic(float from, float to, float t)
        {
            if (t == 0) return from;
            if (t == 1) return to;
            return (float)((to - from) * Math.Pow(2, -10 * t) * Math.Sin((t - .1f) * (2 * Math.PI) / .4f) + to);
        }

        private static float InOutElastic(float from, float to, float t)
        {
            if (t == 0) return from;
            if (t == 1) return to;
            t /= .5f;
            if (t < 1) return (float)(-(to - from) / 2 * Math.Pow(2, 10 * (t - 1)) * Math.Sin((t - 1.1f) * (2 * Math.PI) / .4f) + from);
            t--;
            return (float)((to - from) / 2 * Math.Pow(2, -10 * t) * Math.Sin((t - .1f) * (2 * Math.PI) / .4f) + to);
        }

        private static float InBack(float from, float to, float t)
        {
            return (to - from) * t * t * (2.70158f * t - 1.70158f) + from;
        }

        private static float OutBack(float from, float to, float t)
        {
            t--;
            return (to - from) * (t * t * (2.70158f * t + 1.70158f) + 1) + from;
        }

        private static float InOutBack(float from, float to, float t)
        {
            t /= .5f;
            if (t < 1) return (to - from) / 2 * t * t * (2.70158f * t - 1.70158f) + from;
            t -= 2;
            return (to - from) / 2 * (t * t * (2.70158f * t + 1.70158f) + 2) + from;
        }

        private static float InBounce(float from, float to, float t)
        {
            return (to - from) - OutBounce(0, to - from, 1 - t) + from;
        }

        private static float OutBounce(float from, float to, float t)
        {
            if (t < 1 / 2.75f)
            {
                return (to - from) * (7.5625f * t * t) + from;
            }
            else if (t < 2 / 2.75f)
            {
                t -= 1.5f / 2.75f;
                return (to - from) * (7.5625f * t * t + .75f) + from;
            }
            else if (t < 2.5 / 2.75f)
            {
                t -= 2.25f / 2.75f;
                return (to - from) * (7.5625f * t * t + .9375f) + from;
            }
            else
            {
                t -= 2.625f / 2.75f;
                return (to - from) * (7.5625f * t * t + .984375f) + from;
            }
        }

        private static float InOutBounce(float from, float to, float t)
        {
            if (t < .5f) return InBounce(0, to - from, t * 2) * .5f + from;
            return OutBounce(0, to - from, t * 2 - 1) * .5f + (to - from) * .5f + from;
        }

        private static float Flash(float from, float to, float t)
        {
            return (float)(Math.Sin(t * 10) * 0.5f + 0.5f);
        }

        private static float InFlash(float from, float to, float t)
        {
            return (float)(Math.Sin(t * 10) * 0.5f + 0.5f);
        }

        private static float OutFlash(float from, float to, float t)
        {
            return (float)(Math.Sin(t * 10) * 0.5f + 0.5f);
        }

        private static float InOutFlash(float from, float to, float t)
        {
            return (float)(Math.Sin(t * 10) * 0.5f + 0.5f);
        }
    }
}