using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public GameObject Arrow;
    public Camera Camera;
    public float MinVelocity;
    public float MaxVelocity;
    public float MaxChargeTime;
    public float Delay;
    public AudioClip FireWeak;
    public AudioClip FireStrong;
    public AudioClip Draw;
    public AudioClip Keep;

    private AudioSource _sound;
    private float _velocity;
    private float _drawTime;
    private float _delay;

    private void Awake() {
        _sound = GetComponent<AudioSource>();
        _velocity = MinVelocity;
        _drawTime = 0;
        _delay = Delay;
    }

    void Update() {

        if (_delay < Delay) {
            _delay += Time.deltaTime;
        } else {

            if (Input.GetButtonUp("Fire")) {
                GameObject arrow = Instantiate(Arrow, transform.position, transform.rotation);
                Rigidbody rigidBody = arrow.GetComponent<Rigidbody>();

                Ray ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
                rigidBody.velocity = ray.direction * _velocity;

                if (_velocity >= MaxVelocity) {
                    _sound.clip = FireStrong;
                } else {
                    _sound.clip = FireWeak;
                }
                _sound.loop = false;
                _sound.Play();

                _velocity = MinVelocity;
                _drawTime = 0;
                _delay = 0;

            } else if (Input.GetButton("Fire")) {
                if (_drawTime == 0) {
                    _sound.clip = Draw;
                    _sound.Play();
                }
        
                _velocity = Mathf.Lerp(MinVelocity, MaxVelocity, _drawTime / MaxChargeTime);
                _drawTime += Time.deltaTime;

                if (!_sound.loop && _drawTime > MaxChargeTime) {
                    _sound.clip = Keep;          
                    _sound.loop = true;
                    _sound.Play();
                }
            }
        }
    }
}
