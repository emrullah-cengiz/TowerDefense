using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Game
{

    public class HoverAnimationTrigger : MonoBehaviour, IPointerEnterHandler
    {
        [SerializeField] private Animation _animation;
        [SerializeField] private bool _usePunchScale;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _animation?.Play();

            if (_usePunchScale)
                transform.DOPunchScale(Vector3.one * .05f, .15f, 1);
        }
    }
}