namespace Glitch9.Toolkits.Tweener
{
    public class TweenSettings
    {
        private static class DefaultValues
        {
            internal const int DEFAULT_FRAME_RATE = 30;
            internal const float DEFAULT_TWEEN_DURATION = 0.3f;
        }

        public static int DefaultFrameRate { get; set; } = DefaultValues.DEFAULT_FRAME_RATE;
        public static float DefaultTweenDuration { get; set; } = DefaultValues.DEFAULT_TWEEN_DURATION;
    }
}