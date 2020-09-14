﻿using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ControllerEvent : MonoBehaviour
{
    public Text Dialog;

    public Camera camera;
    public Rect rect;
    
   public void ButtonMail_Click()
    {
        Dialog.text = "ButtonMail_Click";
    }

    public void PrintScence()
    {
        Texture2D t2d = CaptureCamera(camera, rect);
        byte[] buffer = t2d.EncodeToPNG();

        FileInfo info = new FileInfo("./Logs/cutting.png");
        int index = 0;
        while (info.Exists)
        {
            info = new FileInfo($"./Logs/cutting{++index}.png");
        }
        FileStream stream = new FileStream(info.FullName, FileMode.CreateNew, FileAccess.Write);
        BinaryWriter writer = new BinaryWriter(stream);
        writer.Write(buffer);
        writer.Flush();
        writer.Close();
        stream.Close();
    }

    public Texture2D CaptureCamera(Camera camera, Rect rect)
    {
        // 创建一个RenderTexture对象    
        RenderTexture rt = new RenderTexture((int)rect.width, (int)rect.height, 0);
        // 临时设置相关相机的targetTexture为rt, 并手动渲染相关相机    
        camera.targetTexture = rt;
        camera.Render();
        //ps: --- 如果这样加上第二个相机，可以实现只截图某几个指定的相机一起看到的图像。    
        //ps: camera2.targetTexture = rt;    
        //ps: camera2.Render();    
        //ps: -------------------------------------------------------------------    
        // 激活这个rt, 并从中中读取像素。    
        RenderTexture.active = rt;
        Texture2D screenShot = new Texture2D((int)rect.width, (int)rect.height, TextureFormat.RGB24, false);
        screenShot.ReadPixels(rect, 0, 0);// 注：这个时候，它是从RenderTexture.active中读取像素    
        screenShot.Apply();
        // 重置相关参数，以使用camera继续在屏幕上显示    
        camera.targetTexture = null;
        //ps: camera2.targetTexture = null;    
        RenderTexture.active = null; // JC: added to avoid errors    
        GameObject.Destroy(rt);
        // 最后将这些纹理数据，成一个png图片文件    
        byte[] bytes = screenShot.EncodeToPNG();
        string filename = Application.dataPath + "/Screenshot.png";
        System.IO.File.WriteAllBytes(filename, bytes);
        Debug.Log(string.Format("截屏了一张照片: ｛0｝", filename));
        return screenShot;
    }

}
