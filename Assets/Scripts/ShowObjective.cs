using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShowObjective : MonoBehaviour
{
    public TextMeshProUGUI messageText;
    public float displayTime = 8.0f;

    void Start()
    {
        StartCoroutine(ShowMesssageCoroutine());
    }

    IEnumerator ShowMesssageCoroutine()
    {
        messageText.gameObject.SetActive(true);
        yield return new WaitForSeconds(displayTime);
        messageText.gameObject.SetActive(false);
    }
}
