using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    public float LifeTime;

    private Rigidbody rb;
    private Collider coll;

    public void Awake() {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    public void Start() {
        StartCoroutine(DestroySelf());
    }

    private IEnumerator DestroySelf() {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag != "Player") {
            if (collision.gameObject.tag != "Target") {
                GameManager.Instance.Miss();
            }
            transform.SetParent(collision.transform);
            //Destroy(transform.GetChild(0).gameObject);
            coll.enabled = false;
            rb.isKinematic = true;
               
        }
    }
}
