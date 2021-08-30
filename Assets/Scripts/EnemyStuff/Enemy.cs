using UnityEngine;

public class Enemy : MonoBehaviour {
    public Transform target;
    public float speed;
    private void Awake () {
        target = GameObject.FindGameObjectWithTag ("Player").transform;
    }

}