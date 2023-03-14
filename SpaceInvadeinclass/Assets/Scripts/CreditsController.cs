using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    public float delay = 6f; // Time to wait before switching to the next scene
    //public string nextSceneName; // Name of the next scene to load

    private float timeElapsed = 0f;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        // Check if the animation has finished and the delay time has elapsed
        if (timeElapsed >= delay)
        {
            Debug.Log("hi");
            SceneManager.LoadScene("Menu"); // Load the next scene
        }
    }
}