using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFS.Repository;

public class CharacterShower : MonoBehaviour {

    [SerializeField]
    GameObject showArea = null;

    [SerializeField]
    RuntimeAnimatorController[] controller = null;

    public GameObject soundManager = null;

	// Use this for initialization
	void Start () {

        var playerSettingRepository = new PlayerSettingRepository();
        var playerSettingModel = playerSettingRepository.Get(0);

        var characterRepository = new CharacterRepository();
        var characterModel = characterRepository.Get(playerSettingModel.CharacterID);

        if (characterModel != null) {

            var prefab = ResourceLoader.LoadCharacterSelectPrefab(characterModel.iconPath);
            var characterObject = Instantiate(prefab);

            characterObject.transform.position = new Vector3(0, 0.225f, 0);
            characterObject.transform.rotation = Quaternion.Euler(29.6f, 0, 0);
            characterObject.transform.localScale = Vector3.one * 0.2f;
            characterObject.transform.SetParent(showArea.transform,false);

            var animator = characterObject.GetComponent<Animator>();
            animator.runtimeAnimatorController = controller[characterModel.ID];
        }
        
        if(GameObject.Find(soundManager.name) == null && soundManager != null){
            GameObject sound = Instantiate(soundManager);
            sound.name = soundManager.name;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
