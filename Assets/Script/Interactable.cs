using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 initPos;
    private Quaternion initRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("respawn"))
        {
            transform.position = initPos;
            transform.rotation = initRot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
