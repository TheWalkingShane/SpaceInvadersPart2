using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class Invaders : MonoBehaviour
{
    //public float val = Random.value < 0.5f ? -1.0f : 1.0f;
    public GameObject bullet;
    public Animate[] prefabs;
    public int rows = 5;
    public int columns = 11;
    public static float speed = 1f;
    private Vector3 _direction = Vector2.right;
    public float attackrate = 1.0f;
    public static float amountalive = 55;
    public Enemyshots missleprefab;
    
    private void Awake()
    {
        for (int row = 0; row < rows; row++)
        {
            float width = 2.0f * (columns - 1);
            float height = 2.0f * (rows - 1);
            Vector2 centering = new Vector2(-width/2, -height/2);
            Vector3 rowPosition = new Vector3(centering.x, centering.y +(row * 2.0f), 0.0f);
            for (int col = 0; col < columns; col++)
            {
                Animate invader = Instantiate(prefabs[row], transform);
                
                Vector3 position = rowPosition;
                position.x += col * 2.0f;
                invader.transform.localPosition = position;
            }
        }
    }

    private void Start()
    {
        
        InvokeRepeating(nameof(MissleAttack),attackrate,attackrate);
    }

    private void Update()
    {
        transform.position += _direction * speed * Time.deltaTime;

        Vector3 leftEdge = Camera.main.ViewportToWorldPoint(Vector3.zero);
        Vector3 rightEdge = Camera.main.ViewportToWorldPoint(Vector3.right);

        foreach (Transform invader in transform)
        {
            if(!invader.gameObject.activeInHierarchy)
            {
                continue;
            }

            if (_direction == Vector3.right && invader.position.x >= (rightEdge.x - 1.0f))
            {
                AdvanceRow();
            } else if (_direction == Vector3.left && invader.position.x <= leftEdge.x + 1.0f)
            {
                AdvanceRow();
            }
        }

        if (amountalive == 0)
        {
            Debug.Log("they are all dead");
            amountalive = 55;
            speed = 1f;
            SceneManager.LoadScene("Credit");
            
        }
    }
    private void MissleAttack()
    {
        foreach (Transform invader in transform)
        {
            if (!invader.gameObject.activeInHierarchy)
            {
                Debug.Log("checkingbread");
                continue;
            }

           
            if (Random.value < (1.0 / (float)amountalive))
            {
                 Instantiate(missleprefab, invader.position, Quaternion.identity);
                
                break;
            }
            
        }  
    }
    
    private void AdvanceRow()
    {
        _direction.x *= -1.0f;
        Vector3 position = transform.position;
        position.y -= 1.0f;
        transform.position = position;
    }
    
}
