using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class WriteMissionOnClipboard : MonoBehaviour
{
    public TextMeshPro demande;
    public TextMeshPro order;
    public TextMeshPro title;
    public TextMeshPro thoughts;
    public TextMeshPro titreThoughts;



    public void ChangeMission(string missionOrder, string demande , string thoughts)
    {
        order.text = missionOrder;
        this.thoughts.text = thoughts; 
        this.demande.text = demande;
        if(thoughts =="")titreThoughts.gameObject.SetActive(false);
    }
}
