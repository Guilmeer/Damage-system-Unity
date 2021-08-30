using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAtacks : MonoBehaviour {

    #region Singleton
    private static PlayerAtacks _instance;

    private PlayerAtacks () { }
    public static PlayerAtacks GetInstance () {

        return _instance;
    }
    void Awake () {

        if (_instance == null) {

            _instance = this;
            DontDestroyOnLoad (this.gameObject);

            //Rest of Awake code

        } else {
            Destroy (this);
        }
    }

    #endregion

    [SerializeField] GameObject player;

    void Update () {
        if (Input.GetMouseButtonDown (0)) {
            //change second Getchild to get which gun the player will use
            player.transform.GetChild (2).GetChild (0).GetComponent<ParticleSystem> ().Play ();
        }
    }
    public void MakeDamage (string[] methods, Vector3 colPos, GameObject enemy) {
        // print (colPos);
        object[] target = new object[] { enemy, colPos };
        foreach (string item in methods) {
            GetType ().GetMethod (item).Invoke (this, target);
        }
    }
    public void KnockBack (GameObject enemy, Vector3 colpos) {
        if (enemy.transform) {

            Transform enemyTransform = enemy.transform;
            enemyTransform.GetComponent<NavMeshAgent> ().isStopped = true;

            StartCoroutine (KnockBackNavMeshTimeOffEnum (enemyTransform, colpos));

            enemyTransform.GetComponent<EnemiesHealth> ().UpdateHealth (-1);

            Debug.Log ("KnockBack ");
        }
    }

    IEnumerator KnockBackNavMeshTimeOffEnum (Transform enemyTransform, Vector3 colpos) {
        if (enemyTransform) {
            enemyTransform.GetComponent<Rigidbody> ().isKinematic = false;
            enemyTransform.GetComponent<Rigidbody> ().AddForce (colpos * 200);
            yield return new WaitForSeconds (0.2f);
            enemyTransform.GetComponent<Rigidbody> ().velocity = Vector3.zero;
            enemyTransform.GetComponent<Rigidbody> ().isKinematic = true;
            enemyTransform.GetComponent<NavMeshAgent> ().isStopped = false;

        }
    }
    public void FireDamage (GameObject enemy, Vector3 colpos) {
        Transform enemyTransform = enemy.transform;

        StartCoroutine (FireDamageEnum (enemyTransform));

    }

    IEnumerator FireDamageEnum (Transform enemyTransform) {
        int i = 0;
        while (i < 2) {
            if (enemyTransform && enemyTransform.GetComponent<EnemiesHealth> ().GetHealth() > 0) {
                print ("\rFireDamage " + i+1);
                enemyTransform.GetComponent<EnemiesHealth> ().UpdateHealth (-1);
                yield return new WaitForSeconds (1);
                i++;
            }
            else{i++;}
        }
    }

}