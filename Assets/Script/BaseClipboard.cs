using TMPro;
using UnityEngine;

public class BaseClipboard : MonoBehaviour
{
    public TextMeshPro text;

    public void SetOrder(string order)
    {
        text.text = order;
    }
}
