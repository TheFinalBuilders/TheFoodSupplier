using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Button))]
public class BackQuestButton : MonoBehaviour
{
    private Button backButton = null;

    // Use this for initialization
    void Start()
    {
        backButton = gameObject.GetComponent<Button>();

        backButton.onClick.AddListener(() =>
        {
            SceneMoveManager.Instance.BackScene();
            SceneMoveManager.Instance.BackScene();
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
