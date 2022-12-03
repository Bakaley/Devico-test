using System;
using System.Collections;
using DG.Tweening;
using ScriptableObjects;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private BlackHoleCore _core;
        [SerializeField] private BlackHoleOrbit _orbit;
        [SerializeField] private MovementController _movementController;
        [SerializeField] private SpriteRenderer _sphereIcon;

        private float _boosterOfSizeTimeLeft;
        private float _boosterOfSpeedTimeLeft;

        public event Action<TemporaryBoosterSO> OnTemporaryBoosterActivated;
        public event Action<PermanentBoosterSO> OnPermanentBoosterActivated;
        public event Action<int> OnScoreChanged;

        private int _score;
        private int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
        }

        private void OnEnable()
        {
            _core.OnItemAbsorbed += ItemAbsorbHandler;
        }

        private void ItemAbsorbHandler(Item item)
        {
            item.ApplyAbsorbEffect(this);
        }

        public void Feed(int feedValue)
        {
            //there should be size changing or something
            Score += feedValue;
        }

        public void ApplyTempOrbitSizeBooster(TempOrbitSizeBoosterSO boosterSo)
        {
            OnTemporaryBoosterActivated?.Invoke(boosterSo);
            if (_boosterOfSizeTimeLeft <= 0)
            {
                StartCoroutine(SetSizeCoroutine(
                    boosterSo.NewSizeValue,
                    boosterSo.EffectApplyingTime,
                    boosterSo.Duration));
            }
            else _boosterOfSizeTimeLeft = Mathf.Max(_boosterOfSizeTimeLeft, boosterSo.Duration);
        }
        
        public void ApplyTempSpeedBooster(TempSpeedBoosterSO boosterSo)
        {
            OnTemporaryBoosterActivated?.Invoke(boosterSo);
            if (_boosterOfSpeedTimeLeft <= 0)
            {
                StartCoroutine(SetSpeedCoroutine(
                    boosterSo.NewSpeedValue, 
                    boosterSo.EffectApplyingTime, 
                    boosterSo.Duration));
            }
            else _boosterOfSpeedTimeLeft = Mathf.Max(_boosterOfSpeedTimeLeft, boosterSo.Duration);
        }

        public void ApplyFireBooster(PermFireBoosterSO boosterSo)
        {
            //in real game there would some fire logic here, but for now we just setting color
            
            ApplyNewColor(boosterSo);
            OnPermanentBoosterActivated?.Invoke(boosterSo);
        }

        public void ApplyWaterBooster(PermWaterBoosterSO boosterSo)
        {
            //in real game there would some water logic here, but for now we just setting color
            
            ApplyNewColor(boosterSo);
            OnPermanentBoosterActivated?.Invoke(boosterSo);
        }

        public void ApplyAirBooster(PermAirBoosterSO boosterSo)
        {
            //in real game there would some earth logic here, but for now we just setting color
            
            ApplyNewColor(boosterSo);
            OnPermanentBoosterActivated?.Invoke(boosterSo);
        }

        public void ApplyEarthBooster(PermEarthBoosterSO boosterSo)
        {
            //in real game there would some air logic here, but for now we just setting color
            
            ApplyNewColor(boosterSo);
            OnPermanentBoosterActivated?.Invoke(boosterSo);
        }

        private void ApplyNewColor(PermanentBoosterSO boosterSo)
        {
            _orbit.SetOrbitColor(boosterSo.OrbitGradient, boosterSo.EffectApplyingTime);
            _sphereIcon.color = boosterSo.IconColor;
        }

        private IEnumerator SetSizeCoroutine(float newSize, float effectApplyingTime, float duration)
        {
            Vector3 currentSize = transform.localScale;
            _boosterOfSizeTimeLeft = duration;
            transform.DOScale(newSize, effectApplyingTime);
            
            while (_boosterOfSizeTimeLeft > 0)
            {
                _boosterOfSizeTimeLeft -= Time.unscaledDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            transform.DOScale(currentSize, effectApplyingTime);
        }
        
        private IEnumerator SetSpeedCoroutine(float newSpeed, float effectApplyingTime, float duration)
        {
            float currentSpeed = _movementController.CurrentSpeed;
            _boosterOfSpeedTimeLeft = duration;
            
            DOTween.To(() => _movementController.CurrentSpeed,
                speed => _movementController.CurrentSpeed = speed,
                newSpeed,
                effectApplyingTime
            );
            while (_boosterOfSpeedTimeLeft > 0)
            {
                _boosterOfSpeedTimeLeft -= Time.unscaledDeltaTime;
                yield return new WaitForFixedUpdate();
            }
            DOTween.To(() => _movementController.CurrentSpeed,
                speed => _movementController.CurrentSpeed = speed,
                currentSpeed,
                effectApplyingTime
            );
        }

        private void OnDisable()
        {
            _core.OnItemAbsorbed -= ItemAbsorbHandler;
        }
    }
}
