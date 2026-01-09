using UnityEngine;

public class Interactable : MonoBehaviour
{
    private Vector3 initPos;
    private Quaternion initRot;
    private Vector3 initScale;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void OnEnable()
    {
        initPos = transform.position;
        initRot = transform.rotation;
        initScale = transform.localScale;
    }
        
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("respawn"))
        {
            transform.position = initPos;
            transform.rotation = initRot;
            transform.localScale = initScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        transform.position = initPos;
        transform.rotation = initRot;
    }
}
