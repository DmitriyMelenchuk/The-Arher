using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenuScreen : Screen
{
    private const string MasterVolume = "MasterVolume";
    private const string MusicVolume = "MusicVolume";
    private const int MinMusicVolume = -80;

    [SerializeField] private Button _exitButton;
    [SerializeField] private Toggle _muteMusicToggle;
    [SerializeField] private Slider _valueMusicSlider;
    [SerializeField] private AudioMixerGroup _audioMixer;

    public event Action ExitButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        _exitButton.interactable = false;
        gameObject.SetActive(false);
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        _exitButton.interactable = true;
        gameObject.SetActive(true);
    }

    protected override void Enable()
    {
        _exitButton.onClick.AddListener(OnClickExitButton);
    }

    protected override void Disable()
    {
        _exitButton.onClick.RemoveListener(OnClickExitButton); 
    }

    public void ToggleMusic(bool isEnabled)
    {
        if (isEnabled == true)
            _audioMixer.audioMixer.SetFloat(MusicVolume, 0);
        else
            _audioMixer.audioMixer.SetFloat(MusicVolume, MinMusicVolume);
    }

    public void ChangeVolume(float volume)
    {
        _audioMixer.audioMixer.SetFloat(MasterVolume, Mathf.Lerp(MinMusicVolume, 20, volume));
    }

    private void OnClickExitButton()
    {
        ExitButtonClick?.Invoke();
    }
}
