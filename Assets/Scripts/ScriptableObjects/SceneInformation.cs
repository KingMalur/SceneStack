using UnityEngine;

[System.Serializable]
public abstract class SceneInformation : ScriptableObject
{
	public string SceneName;
	public GameObject PrefabToLoad;
	public ProgressionFlag ProgressionFlagToSet;
}
