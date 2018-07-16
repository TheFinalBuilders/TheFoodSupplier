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

    static public GameObject LoadCharacterSelectPrefab(string filename)
    {
        var prefab = Resources.Load<GameObject>("CommonPrefab/CharacterSelect/" + filename);

        Debug.Assert(prefab != null, "スプライトが存在しません");

        return prefab;
    }

    static public GameObject LoadSceneManagerPrefab()
    {
        var sprite = Resources.Load<GameObject>("Scene/SceneMoveManager");

        Debug.Assert(sprite != null, "Scene/SceneMoveManager");

        return sprite;
    }
}
