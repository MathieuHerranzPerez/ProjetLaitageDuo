using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    [Header("Animations")]
    public GameObject deathEffect;
    public GameObject hitEffect;
    //[Header("Sound")]
    //public AudioClip soundExplosion;
    //[Range(0.05f, 1f)]
    //public float volume = 0.5f;
    //public GameObject audioPlayer;

    // intern
    private Transform target;
    private float delta = 0.6f; // if the enemy is at pos + or - this
    private Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        if (target)
        {
            Vector3 direction = target.position - transform.position;  // get the direction of the target
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10).eulerAngles;  // rotate

            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            transform.Translate(direction.normalized * enemy.stats.moveSpeed * Time.deltaTime, Space.World);        // move

            // the enemy has reached the point
            if (Vector3.Distance(transform.position, target.position) <= delta)
            {
                Explode();
            }
        }
    }

    public void SetTarget(Transform targetTransformWaypoint)
    {
        this.target = targetTransformWaypoint;
    }


    private void Explode()
    {
        if (enemy.stats.isBoss)
        {
            //
        }
        PlayerStats.Lives -= enemy.stats.damage;
        // effect on death
        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);

        //if (soundExplosion)
        //{
            // invoke another gameobject to play the sound
            //GameObject soundGO = (GameObject)Instantiate(audioPlayer, transform.position, transform.rotation);
            //AudioPlayer _audioPlayer = soundGO.GetComponent<AudioPlayer>();
            //_audioPlayer.Play(soundExplosion, volume);
            //Destroy(soundGO, 1f);
            
        //}
        

        Destroy(gameObject);
    }
}
