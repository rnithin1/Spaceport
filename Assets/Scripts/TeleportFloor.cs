using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportFloor : MonoBehaviour
{
    public Canvas canvas;
    public GameObject elevatorMenu;
    private KeyCode pressed;

    // Start is called before the first frame update
    void Start()
    {
        elevatorMenu = GameObject.Find("ElevatorMenu");
        elevatorMenu.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            elevatorMenu.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            elevatorMenu.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(kcode))
                {
                    pressed = kcode;
                    if (pressed == KeyCode.Alpha1 || pressed == KeyCode.Alpha2 || pressed == KeyCode.Alpha3)
                    {
                        StopAllCoroutines();
                        StartCoroutine(TeleportAndFadeIn(other, pressed));
                    }
                }
            }
        }
    }

    IEnumerator TeleportAndFadeIn(Collider other, KeyCode kcode)
    {
        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(true));
        yield return new WaitForSeconds(2);

        if (kcode == KeyCode.Alpha1)
        {
            elevatorMenu.SetActive(false);
            SceneManager.LoadScene(1);
        }

        if (kcode == KeyCode.Alpha2)
        {
            elevatorMenu.SetActive(false);
            SceneManager.LoadScene(2);

        }

        if (kcode == KeyCode.Alpha3)
        {
            elevatorMenu.SetActive(false);
            SceneManager.LoadScene(3);

        }

        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(false));
    }
}
