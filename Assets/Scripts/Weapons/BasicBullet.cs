using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour {

    public List<ParticleCollisionEvent> collisionEvents;
    string[] normalBullet = { "KnockBack", "FireDamage" };
    private void Start () {
        collisionEvents = new List<ParticleCollisionEvent> ();
    }
    private void OnParticleCollision (GameObject other) {
        // print ("Hit: " + other.transform.ToString ());
        if (other.CompareTag ("Enemy")) {
            PlayerAtacks playerAtacks = PlayerAtacks.GetInstance ();
            int numColEvent = GetComponent<ParticleSystem> ().GetCollisionEvents (other, collisionEvents);
            playerAtacks.MakeDamage (normalBullet, collisionEvents[numColEvent - 1].velocity, other);
        }
    }
}