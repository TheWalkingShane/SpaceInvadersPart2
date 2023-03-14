using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class Enemyshots : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    public AudioClip sound;
    public AudioClip pdeath;
    public float speed = 100;
    

    // Start is called before the first frame update
    void Start()
    {
        
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        AudioSource.PlayClipAtPoint(sound,transform.position);
        myRigidbody2D.velocity = Vector2.down * speed; 
        //Debug.Log("ZAP!!!");
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Rock"))
        {
            Debug.Log("ALIENS");
            Destroy(col.gameObject);
        }
        if(col.gameObject.CompareTag("Player"))
        {
            

            Debug.Log("i've been shot by enemys");
            Invaders.amountalive = 55;
            Invaders.speed = 1f;
            //Debug.Log(Invaders.amountalive);
            
            SceneManager.LoadScene("Credit");
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



