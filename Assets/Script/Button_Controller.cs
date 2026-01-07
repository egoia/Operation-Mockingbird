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

    private void OnCollisionEnter(Collision collision)
    {
        if (pressed) { return; }
        pressed = true;

        GameManager.Instance.TakePhoto();
    }

    private void OnCollisionExit(Collision collision)
    {
        pressed = false;
    }
}
