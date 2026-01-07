using TMPro;
using Unity.Tutorials.Core.Editor;
using UnityEngine;

public class WriteMissionOnClipboard : MonoBehaviour
{
    [SerializeField] private bool isDictatorSide = true;
    private TextMeshPro textMeshProOrder;
    private TextMeshPro textMeshProTitleRecap;
    private TextMeshPro textMeshProRecap;

    private string previousDictatorThoughtsIfSuccess;
    private string previousRebelsThoughtsIfSuccess;
    private string previousRebelsThoughtsIfFailure;
    private string previousDictatorThoughtsIfFailure;

    private string recapText = "Récap";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textMeshProOrder = transform.Find("MissionOrder").GetComponent<TextMeshPro>();
        textMeshProTitleRecap = transform.Find("TitleRecap").GetComponent<TextMeshPro>();
        textMeshProRecap = transform.Find("Recap").GetComponent<TextMeshPro>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeMission(Mission mission, bool isFirstMission, bool previousMissionIsSucces)
    {
        textMeshProTitleRecap.gameObject.SetActive(!isFirstMission);
        textMeshProRecap.gameObject.SetActive(!isFirstMission);


        if (isDictatorSide)
        {
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
