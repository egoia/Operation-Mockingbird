using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dummy : MonoBehaviour
{
    Animator animator;
    public List<AnimationClip> poses;
    int index = 0;
    Test inputActions;

    [SerializeField] List<Mesh> meshs;
    private int meshIndex;
    private Mesh mesh;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;

        animator.Play(poses[index].name);
        inputActions = new Test();
        inputActions.test_anim.Enable();
        inputActions.test_anim.change_pose.performed += ChangePos;

        mesh = GetComponent<MeshFilter>().mesh;
    }

    void ChangePos(InputAction.CallbackContext context)
    {
        index++;
        index%= poses.Count;
        animator.Play(poses[index].name);
    }

    [ContextMenu("test")]
    public void ChangeMesh()
    {
       
        meshIndex++;
        meshIndex %= meshs.Count;
        GetComponent<MeshFilter>().mesh= meshs[meshIndex];


    }

}
