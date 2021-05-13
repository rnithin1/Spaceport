using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public Canvas canvas;
    private Collider coll;
    private float timeToWait = 0.5f;
    private float done = 0.0f;
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
            StopAllCoroutines();
            StartCoroutine(TeleportAndFadeIn(other));
        }
    }

    IEnumerator TeleportAndFadeIn(Collider other)
    {
        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(true));
        yield return new WaitForSeconds(2);
        CharacterController charController = other.GetComponent<CharacterController>();
        charController.enabled = false;
        Vector3 closestPoint = coll.ClosestPointOnBounds(other.transform.position);
        LookAtWallNormal(other);
        float distance = Vector3.Distance(closestPoint, other.transform.position);
        Vector3 new_pos = other.transform.position + 2 * distance * other.transform.forward;
        charController.transform.position = new Vector3(new_pos.x, other.transform.position.y, new_pos.z);
        charController.enabled = true;
        StartCoroutine(canvas.GetComponent<UIController>().FadeBlackOutSquare(false));
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
