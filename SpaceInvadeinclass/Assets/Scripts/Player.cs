using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
  public AudioClip pdeath;
  private Rigidbody2D rb;
  private Vector2 direction;
  public GameObject bullet;
  public float speed = 10f;
  public AudioClip shooting;
  public Transform shottingOffset;
    // Update is called once per frame
    private void Awake()
    {
      rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        //Debug.Log("Bang!");
        AudioSource.PlayClipAtPoint(shooting,transform.position); 
        Destroy(shot, 10f);

      }
      
      float horizontalVal = Input.GetAxis("Horizontal");
      direction = Vector2.right * horizontalVal;

    }
    private void FixedUpdate()
    {
      if (direction.sqrMagnitude != 0)
      {
        rb.AddForce(direction * speed);
      }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
      if(col.gameObject.CompareTag("Missle"))
      {
            
        AudioSource.PlayClipAtPoint(pdeath, transform.position);
        //StartCoroutine(ExampleCoroutine());
        Debug.Log("YEEE");

      } 
    }
    
    IEnumerator ExampleCoroutine()
    {
      //Print the time of when the function is first called.
      Debug.Log("Started Coroutine at timestamp : " + Time.time);

      //yield on a new YieldInstruction that waits for 5 seconds.
      yield return new WaitForSeconds(20);

      //After we have waited 5 seconds print the time again.
      Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
