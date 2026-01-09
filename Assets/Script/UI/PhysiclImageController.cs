using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using static GLTFast.Schema.AnimationChannelBase;

public class PhysiclImageController : MonoBehaviour
{
    private string ImagesDir;
    public int currentPng;
    public Image Uiimg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ImagesDir = Application.dataPath + "/Resources";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            nextImage();
        }
    }

    public void setSprite(int png)
    {
        currentPng = png;
        pngTosprite(ImagesDir+"/Img"+currentPng+".png");
    }

    public void nextImage()
    {
        int nbImgs = Directory.GetFiles(ImagesDir, "*.png").Length;
        Debug.Log("nbImages = " + nbImgs);

        if (currentPng + 1 == nbImgs) {
            currentPng = 0;
        }
        else
        {
            currentPng++;
        }

        pngTosprite(ImagesDir + "/Img" + currentPng+".png");
    }

    public void backImage()
    {
        int nbImgs = Directory.GetFiles(ImagesDir, "*.png").Length;
        Debug.Log("nbImages = " + nbImgs);

        if (currentPng - 1 == 0)
        {
            currentPng = 0;
        }
        else
        {
            currentPng--;
        }

        pngTosprite(ImagesDir + "/Img" + currentPng + ".png");
    }
    private void pngTosprite(string path)
    {
        byte[] pngData = File.ReadAllBytes(path);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngData); // Automatically resizes texture

         Uiimg.sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100f);
    }
}
