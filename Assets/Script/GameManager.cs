using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PhotoZone photoZone;
    public CameraCapture photoCamera;
    public int missionIndex;
    public List<Mission> missions;
    public GameObject clipBoardDictator;
    public GameObject clipBoardRebels;
    public GameObject spawnPosition;
    public GameObject player;

    void Awake()
    {
         Instance = this;
    }
    void Start()
    {
        LoadClipboard("", "");
        player.transform.position = spawnPosition.transform.position;
    }

    public void TakePhoto()
    {
        string rebelsThoughts = "";
        string dictatorThoughts = "";
        missions[missionIndex].CalculScore(photoZone.GetAllProps(), ref dictatorThoughts, ref rebelsThoughts);
        photoCamera.Capture();
        //photo
        missionIndex++;
        LoadClipboard(dictatorThoughts, rebelsThoughts);
        clipBoardDictator.GetComponent<Interactable>().Respawn();
        clipBoardRebels.GetComponent<Interactable>().Respawn();
        if (missionIndex > missions.Count)
        {
            GameOver();
        }
        player.transform.position = spawnPosition.transform.position;
        Debug.Log("ahouuuuuuuuuuuuu");
    }

    void LoadClipboard( string dictatorthoughts, string rebelsthoughts)
    {
        Mission current = missions[missionIndex];
        clipBoardDictator.GetComponent<WriteMissionOnClipboard>().ChangeMission(current.dictatorTitle, current.dictatorMissionOrder, dictatorthoughts);
        clipBoardRebels.GetComponent<WriteMissionOnClipboard>().ChangeMission(current.rebelTitle, current.rebelsMissionOrder, rebelsthoughts);
    }

    void GameOver()
    {
        Debug.Log("lala c'est fini merci d'avoir joué");
    }

    


}
