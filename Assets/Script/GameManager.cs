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
    public GameObject baseClipboard;
    public GameObject spawnPosition;
    public GameObject player;

    public UI_Animation_Controller ui;

    void Awake()
    {
         Instance = this;
    }
    void Start()
    {
        LoadClipboard("", "", "Suite à l'apparition des groupes terroristes  dans un village rural déconnecté des grandes villes et  d'organismes étatiques, la zone a été déclarée comme une menace par l'État. Depuis cela, une guerre civile à éclaté entre le gouvernement et un groupe armée de résistants");
        player.transform.position = spawnPosition.transform.position;
        ui.fadeInNOutTransition();
    }

    public void TakePhoto()
    {
        ui.fadeInNOutTransition();
        string rebelsThoughts = "";
        string dictatorThoughts = "";
        string journal = "";
        missions[missionIndex].CalculScore(photoZone.GetAllProps(), ref dictatorThoughts, ref rebelsThoughts, ref journal);
        photoCamera.Capture();
        //photo
        missionIndex++;
        LoadClipboard(dictatorThoughts, rebelsThoughts, journal);
        clipBoardDictator.GetComponent<Interactable>().Respawn();
        clipBoardRebels.GetComponent<Interactable>().Respawn();
        if (missionIndex > missions.Count)
        {
            GameOver();
        }
        player.transform.position = spawnPosition.transform.position;
    }

    void LoadClipboard( string dictatorthoughts, string rebelsthoughts, string journal)
    {
        Mission current = missions[missionIndex];
        clipBoardDictator.GetComponent<WriteMissionOnClipboard>().ChangeMission(current.dictatorNouvelle, current.dictatorOrdre, dictatorthoughts);
        clipBoardDictator.GetComponent<Interactable>().Respawn();

        clipBoardRebels.GetComponent<WriteMissionOnClipboard>().ChangeMission(current.rebelNouvelle, current.rebelOrdre, rebelsthoughts);
        clipBoardRebels.GetComponent<Interactable>().Respawn();

        baseClipboard.GetComponent<BaseClipboard>().SetOrder(journal);
    }

    void GameOver()
    {
        Debug.Log("lala c'est fini merci d'avoir joué");
    }

    


}
