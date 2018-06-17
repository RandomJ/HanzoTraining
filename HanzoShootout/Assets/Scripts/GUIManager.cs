using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public static GUIManager Instance;

    public GameObject Life;
    public Transform LivesContainer;
    public Text Score;
    public Text Multiplier;
    public Animation HitMarkerAnimation;
    public AudioClip HitMarkerSound;
    public GameObject PauseMenu;

    private AudioSource _audioSource;

    public void Awake() {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start() {
        Score.text = "0";
        Multiplier.text = "x1";
        PauseMenu.SetActive(false);
    }

    public void AddLife() {
        Instantiate(Life, LivesContainer);
    }

    public void RemoveLife() {
        Destroy(LivesContainer.GetChild(LivesContainer.childCount - 1).gameObject);
    }

    public void SetScore(int score) {
        Score.text = score + "";
    }

    public void SetMultiplier(int multiplier) { 
        Multiplier.text = "x" + multiplier;
    }

    public void PlayHitMarker() {
        HitMarkerAnimation.Play();
        _audioSource.clip = HitMarkerSound;
        _audioSource.Play();
    }

    public void ShowPauseMenu() {
        PauseMenu.SetActive(true);
    }

    public void HidePauseMenu() {
        PauseMenu.SetActive(false);
    }
}
