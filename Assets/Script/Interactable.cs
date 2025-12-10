using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 initPos;
    private Quaternion initRot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        initPos = transform.position;
        initRot = transform.rotation;
    }
        
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("jjj");
        if (other.gameObject.layer == LayerMask.NameToLayer("respawn"))
        {
            transform.position = initPos;
            transform.rotation = initRot;
            Debug.Log("hjhj");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
