using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SceneInformationList", menuName = "Scene Information/List of Scene Information", order = 0)]
public class SceneInformationList : ScriptableObject
{
	public List<SceneInformation> ListOfSceneInformation;
}
