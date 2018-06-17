using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    public Animator animator;

    private bool _active;
    private float _timeElapsed;
    private float _enableTime;

    private void Start() {       
        _timeElapsed = 0;
        _enableTime = 0;
        Hide();
    }

    private void OnCollisionEnter(Collision collision) {
        if (_active) {
            GameManager.Instance.Hit();
            GameManager.Instance.DisableTarget(this);
            Hide();
            _timeElapsed = 0;
        }
    }

    private void Update() {
        if (_active) {
            _timeElapsed += Time.deltaTime;
            if (_timeElapsed > _enableTime) {
                GameManager.Instance.Miss();
                GameManager.Instance.DisableTarget(this);
                Hide();
                _timeElapsed = 0;
            }
        }
    }

    public void Show(float enableTime) {
        animator.SetTrigger("Show");
        _active = true;
        _enableTime = enableTime;
    }

    public void Hide() {
        animator.SetTrigger("Hide");
        _active = false;
    }
}