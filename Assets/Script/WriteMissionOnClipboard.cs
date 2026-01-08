using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class WriteMissionOnClipboard : MonoBehaviour
{
    public TextMeshPro textMeshProOrder;
    public TextMeshPro textMeshProTitleRecap;
    public TextMeshPro textMeshProRecap;
    public TextMeshPro textMeshProTitle;

    private string recapText = "R�cap";


    public void ChangeMission(string missionTitle, string missionOrder, string thoughts)
    {

        textMeshProTitle.text = missionTitle;
        textMeshProOrder.text = missionOrder;
        textMeshProTitleRecap.text = thoughts == "" ? "" : recapText;
        textMeshProRecap.text = thoughts;
        
    }
}
