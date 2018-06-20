using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    public static GUIManager Instance;

    public GameObject HUD;
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
        for (int i = LivesContainer.childCount; i < lives; i++) {
            Instantiate(Life, LivesContainer);
        }
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

    public void ShowHUD() {
        Score.transform.SetParent(HUD.transform);
        Multiplier.transform.SetParent(HUD.transform);
        LivesContainer.transform.SetParent(HUD.transform);
        HUD.SetActive(true);
    }

    public void HideHUD() {
        HUD.SetActive(false);
    }

    public void ShowMainMenu() {
        MainMenu.SetActive(true);
    }

    public void HideMainMenu() {
        MainMenu.SetActive(false);
    }

    public void ShowPauseMenu() {
        Score.transform.SetParent(PauseMenu.transform);
        Multiplier.transform.SetParent(PauseMenu.transform);
        LivesContainer.transform.SetParent(PauseMenu.transform);
        PauseMenu.SetActive(true);
    }

    public void HidePauseMenu() {
        PauseMenu.SetActive(false);
    }
}
