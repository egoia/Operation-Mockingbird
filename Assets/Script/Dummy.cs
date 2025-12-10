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
    }
}
