using System.Collections;
using UnityEngine;

public class Button_Controller : MonoBehaviour
{
    private BoxCollider myBXC;
    public Rigidbody rb; 
    private bool pressed = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myBXC = GetComponent<BoxCollider>();
        StartCoroutine(waitToActivate());
    }

    private IEnumerator waitToActivate()
    {
        yield return new WaitForSeconds(0.5f);
        myBXC.enabled = true;   
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rb.IsSleeping());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (pressed) { return; }
        
        Debug.Log("Button Pressed");
        Debug.Log("Collision obj = "+ collision.gameObject.name);
        pressed = true;
    }

    private void OnCollisionStay(Collision collision)
    {
       // Debug.Log("Button Pressed stay");
    }

    private void OnCollisionExit(Collision collision)
    {

        Debug.Log("Button UnPressed");
        Debug.Log("Collision obj = " + collision.gameObject.name);
        pressed = false;

    }
}
