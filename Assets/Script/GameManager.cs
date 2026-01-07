using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PhotoZone photoZone;
    public CameraCapture photoCamera;
    public Mission mission;


    [ContextMenu("takephoto")]
    public void TakePhoto()
    {
        string rebelsThoughts = "";
        string dictatorThoughts = "";
        mission.CalculScore(photoZone.GetAllProps(), ref dictatorThoughts, ref rebelsThoughts);
        photoCamera.Capture();
    }
}
