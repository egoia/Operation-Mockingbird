using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class WriteMissionOnClipboard : MonoBehaviour
{
    [SerializeField] private bool isDictatorSide = true;
    public TextMeshPro textMeshProOrder;
    public TextMeshPro textMeshProTitleRecap;
    public TextMeshPro textMeshProRecap;
    public TextMeshPro textMeshProTitle;

    private string previousDictatorThoughtsIfSuccess;
    private string previousRebelsThoughtsIfSuccess;
    private string previousRebelsThoughtsIfFailure;
    private string previousDictatorThoughtsIfFailure;

    private string recapText = "R�cap";


    public void ChangeMission(Mission mission, bool isFirstMission, bool previousMissionIsSucces)
    {
        textMeshProTitleRecap.gameObject.SetActive(!isFirstMission);
        textMeshProRecap.gameObject.SetActive(!isFirstMission);


        if (isDictatorSide)
        {
            textMeshProTitle.text = mission.title;
            textMeshProOrder.text = mission.dictatorMissionOrder;
            if(!isFirstMission)
            {
                textMeshProTitleRecap.text = recapText;
                textMeshProTitleRecap.color = previousMissionIsSucces ? Color.green : Color.red;
                textMeshProRecap.text = previousMissionIsSucces ? previousDictatorThoughtsIfSuccess : previousDictatorThoughtsIfFailure;
            }
        }
        else
        {
            textMeshProOrder.text = mission.rebelsMissionOrder;
            if(!isFirstMission)
            {
                textMeshProTitleRecap.text = recapText;
                textMeshProTitleRecap.color = previousMissionIsSucces ? Color.green : Color.red;
                textMeshProRecap.text = previousMissionIsSucces ? previousRebelsThoughtsIfSuccess : previousRebelsThoughtsIfFailure;
            }
        }

        previousDictatorThoughtsIfSuccess = mission.dictatorThoughtsIfSuccess;
        previousRebelsThoughtsIfSuccess = mission.rebelsThoughtsIfSuccess;
        previousRebelsThoughtsIfFailure = mission.rebelsThoughtsIfFailure;
        previousDictatorThoughtsIfFailure = mission.dictatorThoughtsIfFailure;
    }
}
