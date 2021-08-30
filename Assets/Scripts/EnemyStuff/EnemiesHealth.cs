using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHealth : MonoBehaviour {
    private float health;

    private void Start () {
        health = 11;
    }

    public void UpdateHealth (float amount) {
        this.health += amount;
        CheckHealth ();
    }
    private void CheckHealth () {
        if (health <= 0 && transform) gameObject.SetActive (false);
    }
}