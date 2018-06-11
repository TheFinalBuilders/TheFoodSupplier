using UnityEngine;
using System.Collections;

public class ResourceLoader
{
    static public Sprite LoadSceneSprite(string filename)
    {
        var sprite = Resources.Load<Sprite>("CommonSprite/"+filename);

        Debug.Assert(sprite != null, "スプライトが存在しません");

        return sprite;
    }
}
