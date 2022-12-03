using System;
using System.Collections;
using DG.Tweening;
using ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCaption;
    [SerializeField] private TextMeshProUGUI _boostedCaption;
    [SerializeField] private Slider _slider;

    [SerializeField] private float _showingPermBoosterTime = 2;
    [SerializeField] private float _scoreSettingTime = 2;

    [SerializeField] private Player.Player player;
    
    private int _currentScore;
    private Coroutine _showingCoroutine;

    private void OnEnable()
    {
        player.OnScoreChanged += ScoreChangedHandler;
        player.OnPermanentBoosterActivated += PermanentBoosterHandler;
        player.OnTemporaryBoosterActivated += TemporaryBoosterHandler;
    }

    private void ScoreChangedHandler(int newValue)
    {
        DOTween.To(() => _currentScore,
            value => _currentScore = value,
            newValue,
            _scoreSettingTime)
            .OnUpdate(() =>
            {
                _scoreCaption.text = _currentScore.ToString();
            });
    }

    private void PermanentBoosterHandler(PermanentBoosterSO boosterSo)
    {
        if (_showingCoroutine != null)
        {
            StopCoroutine(_showingCoroutine);
            _slider.gameObject.SetActive(false);
        }
        _boostedCaption.color = boosterSo.MessageColor;
        _boostedCaption.text = boosterSo.ActivationMessage;
        _showingCoroutine = StartCoroutine(ShowPermBoosterInfo());
    }

    private IEnumerator ShowPermBoosterInfo()
    {
        _boostedCaption.gameObject.SetActive(true);
        yield return new WaitForSeconds(_showingPermBoosterTime);
        _boostedCaption.gameObject.SetActive(false);
    }

    private void TemporaryBoosterHandler(TemporaryBoosterSO boosterSo)
    {
        if (_showingCoroutine != null)
        {
            StopCoroutine(_showingCoroutine);
        }
        _boostedCaption.color = boosterSo.MessageColor;
        _boostedCaption.text = boosterSo.ActivationMessage;
     
        _showingCoroutine = StartCoroutine(ShowTempBoosterInfo(boosterSo.Duration));
    }
    
    private IEnumerator ShowTempBoosterInfo(float duration)
    {
        _boostedCaption.gameObject.SetActive(true);
        _slider.gameObject.SetActive(true);
        _slider.value = 1;
        float currentTime = duration;
        while (currentTime > 0)
        {
            currentTime -= Time.fixedDeltaTime;
            _slider.value = currentTime / duration;
            yield return new WaitForFixedUpdate();
        }
        _boostedCaption.gameObject.SetActive(false);
        _slider.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        player.OnScoreChanged -= ScoreChangedHandler;
        player.OnPermanentBoosterActivated -= PermanentBoosterHandler;
        player.OnTemporaryBoosterActivated -= TemporaryBoosterHandler;
    }
}
