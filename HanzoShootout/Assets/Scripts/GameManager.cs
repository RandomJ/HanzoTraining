using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public FirstPersonController Controller;
    public Fire Fire;
    public int ScoreChunk;
    public int Lives;
    public float TargetEnableDelay;
    public float TargetEnableTime;
    public List<Target> Targets;

    private List<Target> _activeTargets;
    private Animation _hitAnimation;
    private AudioSource _hitSound;
    private float _delay;
    private int _score;
    private int _multiplier;

    private void Awake() {
        Instance = this;
        _activeTargets = new List<Target>();
    }

    private void Start() {
        _score = 0;
        _multiplier = 1;
        _delay = 0;

        for (int i = 0; i < Lives; i++) {
            GUIManager.Instance.AddLife();
        }
    }

    private void Update() {
        if (Input.GetButton("Cancel")) {
            Pause();
        }

        _delay += Time.deltaTime;
        if (_delay >= TargetEnableDelay) {
            _delay = 0;
            EnableRandomTarget();
        }
    }

    private void DisableCursor() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void EnableCursor() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void EnableRandomTarget() {
        int random = Random.Range(0, Targets.Count);
        Target target = Targets[random];
        _activeTargets.Add(target);
        target.Show(TargetEnableTime);
        Targets.Remove(target);
    }

    public void DisableTarget(Target target) {
        _activeTargets.Remove(target);
        Targets.Add(target);
    }

    public void Pause() {        
        EnableCursor();
        Controller.enabled = false;
        Fire.enabled = false;
        Time.timeScale = 0;
        GUIManager.Instance.ShowPauseMenu();
    }

    public void Resume() {
        DisableCursor();
        Fire.enabled = true;
        Controller.enabled = true;
        Time.timeScale = 1;
        GUIManager.Instance.HidePauseMenu();
    }

    public void Quit() {
        Application.Quit();
    }

    public void Hit() {
        _score += ScoreChunk * _multiplier;
        _multiplier++;

        GUIManager.Instance.PlayHitMarker();
        GUIManager.Instance.SetScore(_score);
        GUIManager.Instance.SetMultiplier(_multiplier);
    }

    public void Miss() {
        _multiplier = 1;
        Lives--;

        GUIManager.Instance.SetMultiplier(_multiplier);

        if (Lives > 0) {
            GUIManager.Instance.RemoveLife();
        } else {

        }
    }
}
