using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dummy : MonoBehaviour
{
    Animator animator;
    List<SkinnedMeshRenderer> meshRenderer = new List<SkinnedMeshRenderer>();
    public List<AnimationClip> poses;
    int index = 0;
    public List<GameObject> additionalProp;
    public List<int> propPosNb;
    Test inputActions;
    bool hovered = false;

    [SerializeField] List<Mesh> meshes;
    private int meshIndex;

    void Start()
    {
        meshRenderer.Add(transform.GetChild(0).GetComponent<SkinnedMeshRenderer>());
        meshRenderer.Add(transform.GetChild(1).GetComponent<SkinnedMeshRenderer>());
        animator = GetComponent<Animator>();
        animator.applyRootMotion = false;

        animator.Play(poses[index].name);
        inputActions = new Test();
        inputActions.test_anim.Enable();
        inputActions.test_anim.change_pose.performed += ChangePos;
        inputActions.test_anim.change_mesh.performed += ChangeMesh;
    }

    void ChangePos(InputAction.CallbackContext context)
    {
       if (!hovered) return;
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

    public void ChangeMesh(InputAction.CallbackContext context)
    {
       if (!hovered) return;
        meshIndex++;
        meshIndex %= meshes.Count;
        foreach (SkinnedMeshRenderer renderer in meshRenderer) {
            renderer.sharedMesh = meshes[meshIndex];
        }


    }

    public void isTargeted(bool target)
    {
        hovered = target;
    }

}
