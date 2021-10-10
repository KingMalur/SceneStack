using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "SceneFlow", menuName = "Scene Information/Scene Stack", order = 0)]
public class SceneFlowStack : ScriptableObject
{
	public Stack<SceneInformation> SceneInformation;
}
