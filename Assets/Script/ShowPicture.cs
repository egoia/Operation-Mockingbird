using UnityEngine;

public class ShowPicture : MonoBehaviour
{
    [SerializeField]
    public int fromLast = 0;
    private int nbOfPic = 0;
    private System.IO.DirectoryInfo dir;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dir = new System.IO.DirectoryInfo(Application.dataPath + "/Photos/");
    }

    // Update is called once per frame
    void Update()
    {
        if (dir.GetFiles().Length != nbOfPic)
        {
            nbOfPic = dir.GetFiles().Length;
            //spriteRenderer.sprite = //retrieve sprite at nb - 1 - fromlast
        }
    }
}
