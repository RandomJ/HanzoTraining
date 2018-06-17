using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public static GUIManager Instance;

    public GameObject PauseMenu;
    public GameObject MainMenu;
    public GameObject Life;
    public Transform LivesContainer;
    public Text Score;
    public Text Multiplier;
    public Animation HitMarkerAnimation;
    public AudioClip HitMarkerSound;   

    private AudioSource _audioSource;

    public void Awake() {
        Instance = this;
        _audioSource = GetComponent<AudioSource>();
    }

    public void Start() {
        Score.text = "0";
        Multiplier.text = "x1";
    }

    public void InitializeLives(int lives) {
        Debug.Log(LivesContainer.childCount + " " + lives);
        for (int i = LivesContainer.childCount; i < lives; i++) {
            Instantiate(Life, LivesContainer);
            Debug.Log("+1");
        }
    }

    public void RemoveLife() {
        Destroy(LivesContainer.GetChild(LivesContainer.childCount - 1).gameObject);
        Debug.Log("-1");
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

    public void ShowMainMenu() {
        MainMenu.SetActive(true);
    }

    public void HideMainMenu() {
        MainMenu.SetActive(false);
    }

    public void ShowPauseMenu() {
        PauseMenu.SetActive(true);
    }

    public void HidePauseMenu() {
        PauseMenu.SetActive(false);
    }
}
