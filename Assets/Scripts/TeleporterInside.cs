using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterInside : MonoBehaviour
{
    public Canvas canvas;
    private Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            StartCoroutine(TeleportAndFadeIn(other));
        }
    }

    IEnumerator TeleportAndFadeIn(Collider other)
    {
        //StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(true));
        yield return new WaitForSeconds(2);

        LookAtWallNormal(other);
        SceneManager.LoadScene(1);

        //StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(false));
    }

    void LookAtWallNormal(Collider other)
    {
        float rayDistance = 100;
        RaycastHit hit;
        if (Physics.Raycast(other.transform.position, transform.position, out hit, rayDistance))
        {
            // TODO: Need to fix this
            // other.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}
