using System.IO;
using UnityEditor;
using UnityEngine;

public class ShowPicture : MonoBehaviour
{
    [SerializeField]
    public int fromLast = 0;
    private int lastPic = 0;
    private System.IO.DirectoryInfo dir;
    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        dir = new DirectoryInfo(Application.dataPath + "/Resources");
        FileInfo[] fileInfo = dir.GetFiles();
        foreach (FileInfo file in fileInfo)
            file.Delete();
    }

    // Update is called once per frame
    void Update()
    {
        if (dir.GetFiles().Length/2 - 1 != lastPic)
        {
            lastPic = dir.GetFiles().Length/2 - 1;
            var picNb = lastPic - fromLast;
            if (picNb < 0)
                return;

            var texture = Resources.Load<Texture2D>(picNb.ToString());
            var sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            spriteRenderer.sprite = sprite;
        }
    }
}
