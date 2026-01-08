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

    public void TakePhoto()
    {
        string rebelsThoughts = "";
        string dictatorThoughts = "";
        missions[missionIndex].CalculScore(photoZone.GetAllProps(), ref dictatorThoughts, ref rebelsThoughts);
        photoCamera.Capture();
    }

    


}
