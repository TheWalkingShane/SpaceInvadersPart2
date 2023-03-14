using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Bullet : MonoBehaviour
{
  private Rigidbody2D myRigidbody2D;
  public AudioClip weewamp;

  public float speed = 200;
    // Start is called before the first frame update
    void Start()
    {
      myRigidbody2D = GetComponent<Rigidbody2D>();
      Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
      myRigidbody2D.velocity = Vector2.up * speed; 
     // Debug.Log("Wwweeeeee");
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
      if (col.gameObject.CompareTag("Front"))
      {
        AudioSource.PlayClipAtPoint(weewamp,transform.position);
        Invaders.amountalive -= 1;
        ScoreManager.recentScore += 0010;
        Invaders.speed += 0.2f;
        Debug.Log(Invaders.amountalive);
        Destroy(col.gameObject);
      }
      if (col.gameObject.CompareTag("Middle"))
      {
        AudioSource.PlayClipAtPoint(weewamp,transform.position);
        Invaders.amountalive -= 1;
        ScoreManager.recentScore += 0020;
        Invaders.speed += 0.2f;
        //Debug.Log("red dead");
        Debug.Log(Invaders.amountalive);
        Destroy(col.gameObject);
      }
      if (col.gameObject.CompareTag("Back"))
      {
        AudioSource.PlayClipAtPoint(weewamp,transform.position);
        Invaders.amountalive -= 1;
        ScoreManager.recentScore += 0030;
        Invaders.speed += 0.2f;
        //Debug.Log("blue dead");
        Debug.Log(Invaders.amountalive);
        Destroy(col.gameObject);
      }
      if (col.gameObject.CompareTag("Sus"))
      {
        AudioSource.PlayClipAtPoint(weewamp,transform.position);
        Invaders.amountalive -= 1;
        ScoreManager.recentScore += 0050;
        Invaders.speed += 0.2f;
        //Debug.Log("blue dead");
        Debug.Log(Invaders.amountalive);
        Destroy(col.gameObject);
      }

      if (col.gameObject.CompareTag("Rock"))
      {
        Debug.Log("HUMANS");
        Destroy(col.gameObject);
      }
    }
}
