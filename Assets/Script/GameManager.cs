using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PhotoZone photoZone;
    public Mission mission;

    [ContextMenu("takephoto")]
    public void TakePhoto()
    {
        string rebelsThoughts = "";
        string dictatorThoughts = "";
        mission.CalculScore(photoZone.GetAllProps(), ref dictatorThoughts, ref rebelsThoughts);
        Debug.Log($" rebels : {rebelsThoughts}");
        Debug.Log($"dictator : {dictatorThoughts}");
    }
}
