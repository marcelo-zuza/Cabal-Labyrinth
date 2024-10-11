using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectPickUp : MonoBehaviour
{
    public bool potion = false;
    bool book = false;
    public TextMeshProUGUI bookMessage;
    public TextMeshProUGUI potionMessage;

    [Header("Display Settings")]
    public float displayTime = 3.0f;

    public TextMeshProUGUI gotBook;
    public TextMeshProUGUI gotPotion;

    [Header("Audio Settings")]
    public AudioClip colectSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null)
        {
            Debug.LogWarning("AudioSource not found");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            if(other.CompareTag("Potion"))
            {
                potion = true;
                StartCoroutine(ShowMessageGotObject(potionMessage));
                gotPotion.gameObject.SetActive(true);
                Destroy(other.gameObject);
                if(colectSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(colectSound);
                    
                }

            }else if(other.CompareTag("Book"))
            {
                book = true;
                StartCoroutine(ShowMessageGotObject(bookMessage));
                gotBook.gameObject.SetActive(true);
                Destroy(other.gameObject);
                if(colectSound != null && audioSource != null)
                {
                    audioSource.PlayOneShot(colectSound);
                    
                }
            }

            // if(colectSound != null && audioSource != null)
            // {
            //     audioSource.PlayOneShot(colectSound);
                
            // }

            if(other.CompareTag("Calderon"))
            {
                if(potion && book)
                {
                    SceneManager.LoadScene(3);
                }
            }
    }

    IEnumerator ShowMessageGotObject(TextMeshProUGUI text)
    {
        text.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        text.gameObject.SetActive(false);
    }
}
