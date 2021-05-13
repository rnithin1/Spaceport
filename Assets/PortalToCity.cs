using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalToCity : MonoBehaviour
{

    public Canvas canvas;

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StopAllCoroutines();
            StartCoroutine(TeleportAndFadeIn(other));
        }
        else
        {
            Destroy(other);
        }
    }

    IEnumerator TeleportAndFadeIn(Collider other)
    {
        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(true));
        yield return new WaitForSeconds(2);

        SceneManager.LoadScene(5);

        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(false));
    }
}
