using AmazingTowerDefenseGame.Infrastructure;
using Assets._Game.Scripts.Extensions;
using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace AmazingTowerDefenseGame
{
    public class WaveSpawnerView : MonoBehaviour
    {
        private WaveSpawnerModel _model;

        [SerializeField] private Button waveTimerButton;
        [SerializeField] private Image waveTimerFillImg;
        [SerializeField] private Image waveTimerHighlightImg;

        [SerializeField] private TMP_Text totalWaveCountInfo;

        [Inject]
        public void Constructor(WaveSpawnerModel model)
        {
            _model = model;
        }

        private void OnEnable() => ConfigureSubscription(true);
        private void OnDisable() => ConfigureSubscription(false);

        void ConfigureSubscription(bool status)
        {
            waveTimerButton.onClick.Subscribe(WaveTimer_Click, status);
            Events.Wave.OnWaveSpawnerReset.Subscribe(ResetView, status);
            Events.Wave.OnNextWaveCooldownTick.Subscribe(UpdateClock, status);
            Events.Wave.OnNextWaveCooldownEnd.Subscribe(() => HighlightClock(2, SetClockDefaultAndDisable), status);
        }

        private void ResetView()
        {
            waveTimerButton.gameObject.SetActive(true);
            waveTimerHighlightImg.gameObject.SetActive(false);
            waveTimerFillImg.fillAmount = 0;

            totalWaveCountInfo.text = $"0 / {_model.WaveCountOnThisLevel}";
        }


        private void UpdateClock()
        {
            waveTimerFillImg.DOFillAmount(
                (float)Math.Max(_model.NextWaveStartRemainingCooldown, 1) / _model.NextWaveOriginalCooldown, .3f);
        }

        void HighlightClock(int iterationCount, Action callback = null)
        {
            Sequence seq = DOTween.Sequence();

            seq.Join(waveTimerHighlightImg.DOFade(1, .5f))
               .AppendInterval(.1f)
               .Append(waveTimerHighlightImg.DOFade(0, .5f))
               .SetLoops(iterationCount)
               .OnComplete(() => callback?.Invoke());

            seq.Play();
        }

        void WaveTimer_Click()
        {
            Events.Wave.OnWaveTimerClicked?.Invoke();

            HighlightClock(1, SetClockDefaultAndDisable);
        }

        void SetClockDefaultAndDisable()
        {
            waveTimerHighlightImg.gameObject.SetActive(false);
            waveTimerFillImg.fillAmount = 1;
        }
    }
}
