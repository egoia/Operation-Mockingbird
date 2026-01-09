using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using static Mission;

public class Dummy : MonoBehaviour
{
    Animator animator;
    List<SkinnedMeshRenderer> meshRenderer = new List<SkinnedMeshRenderer>();
    public List<AnimationClip> poses;
    public List<PhotoProp> posesType;
    int index = 0;
    public List<GameObject> additionalProp;
    public List<int> propPosNb;
    Test inputActions;
    bool hovered = false;

    public List<Mesh> meshes;
    public List<PhotoProp> meshType;
    private int meshIndex;
    public PhotoProp propValue = PhotoProp.CIVILIAN;

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
        if (propPosNb.Count == additionalProp.Count) {
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
        changePhotProp();
    }

    public void ChangeMesh(InputAction.CallbackContext context)
    {
       if (!hovered) return;
        meshIndex++;
        meshIndex %= meshes.Count;
        foreach (SkinnedMeshRenderer renderer in meshRenderer) {
            renderer.sharedMesh = meshes[meshIndex];
        }
        changePhotoProp();
    }

    public void isTargeted(bool target)
    {
        hovered = target;
    }

    public void changePhotoProp()
    {
        if (poses.Count != posesType.Count) return;
        if (meshes.Count != meshType.Count) return;
        //si défaut on prend w/ever is dans posestype
        if (meshType[meshIndex] == PhotoProp.CIVILIAN)
        {
            propValue = posesType[index];
        }
        //si mort on prend l'équivalent mort du mesh
        else if (posesType[index] == PhotoProp.DEAD_CIVILIAN)
        {
            if (meshType[meshIndex] == PhotoProp.POLICE_MAN)
            {
                propValue = PhotoProp.DEAD_SOLDIER;
            }
            if (meshType[meshIndex] == PhotoProp.CIVILIAN)
            {
                propValue = PhotoProp.DEAD_CIVILIAN;
            }
            if (meshType[meshIndex] == PhotoProp.SOLDIER)
            {
                propValue = PhotoProp.DEAD_SOLDIER;
            }
        }
        //si soldat
        else if (meshType[meshIndex] == PhotoProp.SOLDIER)
        {
            propValue = PhotoProp.SOLDIER;
        }
        //si soldat
        else if (meshType[meshIndex] == PhotoProp.POLICE_MAN)
        {
            propValue = PhotoProp.POLICE_MAN;
        }
    }

}
