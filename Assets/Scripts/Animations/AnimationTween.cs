using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Animations
{
    [System.Serializable]
    public static class AnimationTween
    {
        public static void PlayBounceToTop(this Transform transform)
        {
            transform.DOComplete(true);
            transform.DOShakeScale(1f, 1f, 8, 1f,true);
        }
        
        public static void PlayBounceToTop(this Transform transform, TweenCallback onComplete)
        {
            transform.DOComplete(true);
            transform.DOShakeScale(1f, 1f, 8, 1f,true).OnComplete(onComplete);;
        }
        
        public static void PlaySideBounce(this Transform transform)
        {
            transform.DOComplete(true);
            transform.DOShakePosition(1.0f, strength: new Vector3(10, 0, 0), vibrato: 8, randomness: 1, snapping: true, fadeOut: true);
        }

        public static void PlayFide(this Image image, float endValue, float durationValue)
        {
            image.DOKill(true);
            image.DOFade(endValue, durationValue);
        }
        
        public static void PlayFide(this Text text, float endValue, float durationValue)
        {
            text.DOKill(true);
            text.DOFade(endValue, durationValue);
        }
    }
}