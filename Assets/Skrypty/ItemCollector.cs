using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI wisnieText;

    private int wisnie = 0;

    [SerializeField] private AudioSource dzwiekZbieranie;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wisnia"))
        {
            dzwiekZbieranie.Play();
            Destroy(collision.gameObject);
            wisnie++;
            wisnieText.text = $"Wiœnie: {wisnie}";
        }
    }

}
