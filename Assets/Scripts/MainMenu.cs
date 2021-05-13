using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Image background, black;
    [SerializeField] private Text text;
    [SerializeField] private AudioSource audioSource;
    private bool _hasClicked;
    float fadeAmount;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_hasClicked) return;
            _hasClicked = true;
            StartCoroutine(LoadFirstScene());
        }
    }

    private IEnumerator LoadFirstScene()
    {
        // delete the white background
        background.color = new Color(0, 0, 0, 0);
        var objectColor = black.color;
        // delete "Click to Start" text
        text.enabled = false;
        // SE
        audioSource.Play();
        
        yield return new WaitForSeconds(1);
        // black out
        while (objectColor.a < 1)
        {
            fadeAmount = objectColor.a + (1 * Time.deltaTime);
            if (fadeAmount > 1) fadeAmount = 1;

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            black.color = objectColor;
            yield return null;
        }
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(1);
    }
    
}
