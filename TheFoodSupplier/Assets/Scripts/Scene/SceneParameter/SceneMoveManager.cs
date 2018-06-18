using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class SceneMoveManager : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage = null;

    [SerializeField]
    private float fadeInOutTime = 1.0f;

    private static SceneMoveManager instance;
    public static SceneMoveManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SceneMoveManager)FindObjectOfType(typeof(SceneMoveManager)); // Editor上ではinstanceが生成されてない時に使う
                if (instance == null)
                {
                    // 生成
                    instance = Instantiate(ResourceLoader.LoadSceneManagerPrefab()).GetComponent<SceneMoveManager>();
                    DontDestroyOnLoad(instance);

                    //一旦消す
                    instance.fadeImage.gameObject.SetActive(false);
                }
            }
            return instance;
        }
    }

    [RuntimeInitializeOnLoadMethod()]
    static void Init()
    {
        var manager = SceneMoveManager.Instance;
    }

    private Stack<string> prevScene = new Stack<string>();

    private ISceneParameter currentSceneParameter = null;
    public ISceneParameter CurrentSceneParameter{
        get { return currentSceneParameter; }
    }

    private Dictionary<string, System.Type> sceneToParamterType = new Dictionary<string, System.Type>()
    {
        {"InGame", typeof(InGameSceneParameter) },
        {"QuestResultScene", typeof(QuestResultSceneParameter)},
        {"QuestSelect", typeof(QuestSelectSceneParamter) },
        {"CharacterSelectScene", typeof(CharacterSelectSceneParameter)}
    };

    public void MoveScene(string sceneName, ISceneParameter sceneParameter)
    {
        if (!sceneToParamterType.ContainsKey(sceneName)){
            Debug.Assert(false, "シーン遷移時のパラメータの型が存在しません。");
            return;
        }

        if (sceneToParamterType[sceneName].IsInstanceOfType(sceneParameter.GetType())) {
            Debug.Assert(false, "シーン遷移時のパラメータが異なります。");
            return;
        }

        currentSceneParameter = sceneParameter;

        prevScene.Push(SceneManager.GetActiveScene().name);
        FadeInAndMoveScene("Scenes/" + sceneName);
    }

    public void BackScene()
    {
        if (prevScene.Count <= 0) {
            return;
        }
        
        var sceneName = prevScene.Pop();
        FadeInAndMoveScene(sceneName);
    }

    private string movingSceneName = "";

    private void FadeInAndMoveScene(string sceneName)
    {
        movingSceneName = sceneName;

        instance.fadeImage.gameObject.SetActive(true);
        OnFading(0f);

        Hashtable hash = new Hashtable(){
            {"from", 0f},
            {"to", 1f},
            {"time", fadeInOutTime},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.none},
            {"oncomplete", "OnFadeOut"},
            {"oncompletetarget", this.gameObject},
            {"onupdate", "OnFading"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hash);
    }

    private void OnFading(float alpha)
    {
        instance.fadeImage.color = new Color(
            instance.fadeImage.color.r, 
            instance.fadeImage.color.g, 
            instance.fadeImage.color.b, 
            alpha);
    }

    private void OnFadeOut()
    {
        SceneManager.LoadScene(movingSceneName);
        OnFading(1f);

        Hashtable hash = new Hashtable(){
            {"from", 1f},
            {"to", 0f},
            {"time", fadeInOutTime},
            {"delay", 0f},
            {"easeType",iTween.EaseType.linear},
            {"loopType",iTween.LoopType.none},
            {"oncomplete", "OnFadeEnd"},
            {"oncompletetarget", this.gameObject},
            {"onupdate", "OnFading"},
            {"onupdatetarget", gameObject},
        };
        iTween.ValueTo(gameObject, hash);
    }

    private void OnFadeEnd()
    {
        instance.fadeImage.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        instance = null;
    }
}
