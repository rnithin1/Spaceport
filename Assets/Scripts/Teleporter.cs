using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{

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
            CharacterController charController = other.GetComponent<CharacterController>();
            //other.transform.LookAt(transform);
            Vector3 closestPoint = coll.ClosestPointOnBounds(other.transform.position);
            float distance = Vector3.Distance(closestPoint, other.transform.position);
            Debug.Log(distance);
            charController.enabled = false;
            Vector3 new_pos = other.transform.position + 100 * distance * other.transform.forward;
            charController.transform.position = new Vector3(new_pos.x, other.transform.position.y, new_pos.z);
            charController.enabled = true;
            //other.transform.Translate(5 * distance * other.transform.forward);
            //other.transform.RotateAround(transform.position, transform.up, 180);
        }
    }
}
