using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dummy : MonoBehaviour
{
    Animator animator;
    public List<AnimationClip> poses;
    int index = 0;
    public List<GameObject> additionalProp;
    public List<int> propPosNb;
    Test inputActions;

    [SerializeField] List<Mesh> meshes;
    private int meshIndex;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;

        animator.Play(poses[index].name);
        inputActions = new Test();
        inputActions.test_anim.Enable();
        inputActions.test_anim.change_pose.performed += ChangePos;
    }

    void ChangePos(InputAction.CallbackContext context)
    {
        index++;
        index%= poses.Count;
        animator.Play(poses[index].name);
        if (propPosNb.Count != additionalProp.Count) return;
        for (int i = 0; i < propPosNb.Count; i++)
        {
            if (propPosNb[i] == index)
            {
                additionalProp[i].SetActive(true);
            }
            else
            {
                additionalProp[i].SetActive(false);
            }
        }
    }

    public void ChangeMesh()
    {
       
        meshIndex++;
        meshIndex %= meshes.Count;
        GetComponent<MeshFilter>().mesh= meshes[meshIndex];


    }

}
