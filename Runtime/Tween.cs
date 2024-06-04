using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Glitch9.Toolkits.Tweener
{
    public static class Tween
    {
        #region Tweener (MonoBehaviour)
        private const string TWEENER_NAME = "Tweener (Generated)";

        internal class Tweener : MonoBehaviour { }
        private static Tweener _tweener;
        internal static Tweener TweenerInstance
        {
            get
            {
                if (_tweener == null)
                {
                    GameObject gameObject = new(TWEENER_NAME);
                    _tweener = gameObject.AddComponent<Tweener>();
                }
                return _tweener;
            }
        }
        #endregion

        internal static List<TweenTask> Tasks = new();

        public static TweenTask TweenPos(this RectTransform rectTransform, Vector3 position, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            Vector3 localPosition = rectTransform.localPosition;
            task.from = new float[3] { localPosition.x, localPosition.y, localPosition.z };
            task.to = new float[3] { position.x, position.y, position.z };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.localPosition = new Vector3(pos[0], pos[1], pos[2]));
            return task;
        }

        public static TweenTask TweenLocalPos(this RectTransform rectTransform, Vector3 position, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            Vector3 localPosition = rectTransform.localPosition;
            task.from = new float[3] { localPosition.x, localPosition.y, localPosition.z };
            task.to = new float[3] { position.x, position.y, position.z };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.localPosition = new Vector3(pos[0], pos[1], pos[2]));
            return task;
        }

        public static TweenTask TweenLocalPosX(this RectTransform rectTransform, float positionX, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            task.from = new float[1] { rectTransform.localPosition.x };
            task.to = new float[1] { positionX };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.localPosition = new Vector3(pos[0], rectTransform.localPosition.y, rectTransform.localPosition.z));
            return task;
        }

        public static TweenTask TweenLocalPosY(this RectTransform rectTransform, float positionY, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            task.from = new float[1] { rectTransform.localPosition.y };
            task.to = new float[1] { positionY };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, pos[0], rectTransform.localPosition.z));
            return task;
        }

        public static TweenTask TweenAnchorPos(this RectTransform rectTransform, Vector2 position, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            Vector2 anchoredPosition = rectTransform.anchoredPosition;
            task.from = new float[2] { anchoredPosition.x, anchoredPosition.y };
            task.to = new float[2] { position.x, position.y };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.anchoredPosition = new Vector2(pos[0], pos[1]));
            return task;
        }

        public static TweenTask TweenAnchorPosX(this RectTransform rectTransform, float positionX, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            task.from = new float[1] { rectTransform.anchoredPosition.x };
            task.to = new float[1] { positionX };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.anchoredPosition = new Vector2(pos[0], rectTransform.anchoredPosition.y));
            return task;
        }

        public static TweenTask TweenAnchorPosY(this RectTransform rectTransform, float positionY, float duration = -1f)
        {
            TweenTask task = new(TweenType.Position);
            task.from = new float[1] { rectTransform.anchoredPosition.y };
            task.to = new float[1] { positionY };
            task.duration = duration;
            rectTransform.StartTweening(task, (pos) => rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, pos[0]));
            return task;
        }

        public static TweenTask TweenOffsetMin(this RectTransform rectTransform, Vector2 targetOffsetMin, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            Vector2 offsetMin = rectTransform.offsetMin;
            task.from = new float[2] { offsetMin.x, offsetMin.y };
            task.to = new float[2] { targetOffsetMin.x, targetOffsetMin.y };
            task.duration = duration;
            rectTransform.StartTweening(task, (offset) => rectTransform.offsetMin = new Vector2(offset[0], offset[1]));
            return task;
        }

        public static TweenTask TweenOffsetMax(this RectTransform rectTransform, Vector2 targetOffsetMax, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            Vector2 offsetMax = rectTransform.offsetMax;
            task.from = new float[2] { offsetMax.x, offsetMax.y };
            task.to = new float[2] { targetOffsetMax.x, targetOffsetMax.y };
            task.duration = duration;
            rectTransform.StartTweening(task, (offset) => rectTransform.offsetMax = new Vector2(offset[0], offset[1]));
            return task;
        }

        public static TweenTask TweenOffset(this RectTransform rectTransform, Vector2 targetOffsetMin, Vector2 targetOffsetMax, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            Vector2 offsetMin = rectTransform.offsetMin;
            task.from = new float[4] { offsetMin.x, offsetMin.y, rectTransform.offsetMax.x, rectTransform.offsetMax.y };
            task.to = new float[4] { targetOffsetMin.x, targetOffsetMin.y, targetOffsetMax.x, targetOffsetMax.y };
            task.duration = duration;
            rectTransform.StartTweening(task, (offset) =>
            {
                rectTransform.offsetMin = new Vector2(offset[0], offset[1]);
                rectTransform.offsetMax = new Vector2(offset[2], offset[3]);
            });
            return task;
        }

        public static TweenTask TweenRotation(this RectTransform rectTransform, float rotation, float duration = -1f)
        {
            TweenTask task = new(TweenType.Rotation);
            task.from = new float[] { rectTransform.localRotation.eulerAngles.z };
            task.to = new float[] { rotation };
            task.duration = duration;
            rectTransform.StartTweening(task, (rot) => rectTransform.localRotation = Quaternion.Euler(0, 0, rot[0]));
            return task;
        }

        public static TweenTask TweenFillAmount(this Image image, float from, float to, float duration = -1f)
        {
            TweenTask task = new(TweenType.FillAmount);
            task.from = new float[1] { from };
            task.to = new float[1] { to };
            task.duration = duration;
            image.StartTweening(task, (fill) => image.fillAmount = fill[0]);
            return task;
        }

        public static TweenTask TweenSizeDelta(this RectTransform rectTransform, Vector2 size, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            Vector2 delta = rectTransform.sizeDelta;
            task.from = new float[2] { delta.x, delta.y };
            task.to = new float[2] { size.x, size.y };
            task.duration = duration;
            rectTransform.StartTweening(task, (sizeDelta) => rectTransform.sizeDelta = new Vector2(sizeDelta[0], sizeDelta[1]));
            return task;
        }

        public static TweenTask TweenSizeDeltaX(this RectTransform rectTransform, float sizeX, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            task.from = new float[1] { rectTransform.sizeDelta.x };
            task.to = new float[1] { sizeX };
            task.duration = duration;
            rectTransform.StartTweening(task, (sizeDelta) => rectTransform.sizeDelta = new Vector2(sizeDelta[0], rectTransform.sizeDelta.y));
            return task;
        }

        public static TweenTask TweenSizeDeltaY(this RectTransform rectTransform, float sizeY, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            task.from = new float[1] { rectTransform.sizeDelta.y };
            task.to = new float[1] { sizeY };
            task.duration = duration;
            rectTransform.StartTweening(task, (sizeDelta) => rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, sizeDelta[0]));
            return task;
        }

        public static TweenTask TweenMinWidth(this LayoutElement layoutElement, float minWidth, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            task.from = new float[1] { layoutElement.minWidth };
            task.to = new float[1] { minWidth };
            task.duration = duration;
            layoutElement.StartTweening(task, (width) => layoutElement.minWidth = width[0]);
            return task;
        }

        public static TweenTask TweenMinHeight(this LayoutElement layoutElement, float minHeight, float duration = -1f)
        {
            TweenTask task = new(TweenType.Size);
            task.from = new float[1] { layoutElement.minHeight };
            task.to = new float[1] { minHeight };
            task.duration = duration;
            layoutElement.StartTweening(task, (height) => layoutElement.minHeight = height[0]);
            return task;
        }

        public static TweenTask TweenColor(this Graphic graphic, Color color, float duration = -1f)
        {
            TweenTask task = new(TweenType.Color);
            task.from = new float[4] { graphic.color.r, graphic.color.g, graphic.color.b, graphic.color.a };
            task.to = new float[4] { color.r, color.g, color.b, color.a };
            task.duration = duration;
            graphic.StartTweening(task, (c) => graphic.color = new Color(c[0], c[1], c[2], c[3]));
            return task;
        }

        public static TweenTask TweenScale(this RectTransform rectTransform, Vector3 targetScale, float duration = -1f)
        {
            TweenTask task = new(TweenType.Scale);
            Vector3 localScale = rectTransform.localScale;
            task.from = new float[3] { localScale.x, localScale.y, localScale.z };
            task.to = new float[3] { targetScale.x, targetScale.y, targetScale.z };
            task.duration = duration;
            rectTransform.StartTweening(task, (scale) => rectTransform.localScale = new Vector3(scale[0], scale[1], scale[2]));
            return task;
        }

        public static TweenTask FadeIn(this CanvasGroup canvasGroup, float duration = -1f)
        {
            canvasGroup.alpha = 0;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;

            TweenTask task = new(TweenType.Alpha);
            task.from = new float[1] { 0 };
            task.to = new float[1] { 1 };
            task.duration = duration;
            canvasGroup.StartTweening(task, (alpha) => canvasGroup.alpha = alpha[0]);
            return task;
        }

        public static TweenTask FadeOut(this CanvasGroup canvasGroup, float duration = -1f)
        {
            TweenTask task = new(TweenType.Alpha);
            task.from = new float[1] { 1 };
            task.to = new float[1] { 0 };
            task.duration = duration;
            task.onComplete += () =>
            {
                canvasGroup.interactable = false;
                canvasGroup.blocksRaycasts = false;
            };

            canvasGroup.StartTweening(task, (alpha) => canvasGroup.alpha = alpha[0]);
            return task;
        }

        private static void StartTweening(this object obj, TweenTask task, Action<float[]> onUpdate)
        {
            int objHashCode = obj.GetHashCode();

            if (Tasks != null && Tasks.Count > 0)
            {
                foreach (TweenTask taskInList in Tasks)
                {
                    if (taskInList != task) continue;
                    taskInList.StopCoroutine();
                    Tasks.Remove(taskInList);
                }
            }

            task.objHashCode = objHashCode;
            Tasks ??= new List<TweenTask>();
            Tasks.Add(task);

            task.StartCoroutine(onUpdate);
        }

        /// <summary>
        /// all should be able to be used with GameObject, and check if the gameObject has the necessary component, if not, add it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="gameObject"></param>
        /// <returns></returns>
        private static T GetOrAdd<T>(this GameObject gameObject) where T : Component
        => gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        public static TweenTask TweenPos(this GameObject gameObject, Vector3 position, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenPos(position, duration);
        public static TweenTask TweenLocalPos(this GameObject gameObject, Vector3 position, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenLocalPos(position, duration);
        public static TweenTask TweenLocalPosX(this GameObject gameObject, float positionX, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenLocalPosX(positionX, duration);
        public static TweenTask TweenLocalPosY(this GameObject gameObject, float positionY, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenLocalPosY(positionY, duration);
        public static TweenTask TweenAnchoredPos(this GameObject gameObject, Vector2 position, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenAnchorPos(position, duration);
        public static TweenTask TweenAnchoredPosX(this GameObject gameObject, float positionX, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenAnchorPosX(positionX, duration);
        public static TweenTask TweenAnchoredPosY(this GameObject gameObject, float positionY, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenAnchorPosY(positionY, duration);
        public static TweenTask TweenRotation(this GameObject gameObject, float rotation, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenRotation(rotation, duration);
        public static TweenTask TweenFillAmount(this GameObject gameObject, float from, float to, float duration = -1f)
        => gameObject.GetOrAdd<Image>().TweenFillAmount(from, to, duration);
        public static TweenTask TweenSize(this GameObject gameObject, Vector2 size, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenSizeDelta(size, duration);
        public static TweenTask TweenColor<TGraphic>(this GameObject gameObject, Color color, float duration = -1f) where TGraphic : Graphic
        => gameObject.GetOrAdd<TGraphic>().TweenColor(color, duration);
        public static TweenTask TweenScale(this GameObject gameObject, Vector3 targetScale, float duration = -1f)
        => gameObject.GetOrAdd<RectTransform>().TweenScale(targetScale, duration);
        public static TweenTask FadeIn(this GameObject gameObject, float duration = -1f)
        => gameObject.GetOrAdd<CanvasGroup>().FadeIn(duration);
        public static TweenTask FadeOut(this GameObject gameObject, float duration = -1f)
        => gameObject.GetOrAdd<CanvasGroup>().FadeOut(duration);
    }
}