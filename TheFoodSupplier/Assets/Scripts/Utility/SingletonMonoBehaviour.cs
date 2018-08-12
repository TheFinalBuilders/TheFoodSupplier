using UnityEngine;
using System.Collections;

/**
 *  SingletonMonoBehaviour。これで作成すると T.Instanceでどこからでもアクセスできる。
 *  なお、これはシーンをまたぐと死ぬので注意。
 **/
public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

	protected static T instance;
	public static T Instance{
		get{
			if (instance == null) {
				instance = (T)FindObjectOfType (typeof(T)); // Editor上ではinstanceが生成されてない時に使う
				if (instance == null) {
					Debug.LogError (typeof(T) + " is nothing.");
				}
			}
			return instance;
		}
	}

	public static bool IsValidInstance(){
		return (instance != null);
	}

	protected virtual void Awake(){
		CheckInstance ();
	}

	protected virtual bool CheckInstance(){
		if (instance == null) {
			instance = this as T;
			if (instance != null) {
				return true;
			}
		}

		Debug.Log ("error instance destory : " + this.gameObject.name);
		Destroy (this.gameObject);
		return false;
	}

	void OnDestroy(){
		instance = null;
	}
}