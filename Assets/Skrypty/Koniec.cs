using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Koniec : MonoBehaviour
{

    private AudioSource dzwiekKoniec;

    private bool levelCompleted = false;

    private void Start()
    {
        dzwiekKoniec = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Gracz" && !levelCompleted)
        {
            dzwiekKoniec.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }    

}
