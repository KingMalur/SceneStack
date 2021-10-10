using System.Collections.Generic;
using UnityEngine;

public class SceneStack : MonoBehaviour
{
	private Stack<SceneInformation> sceneInformationStack = new Stack<SceneInformation>();

	public void Push(List<SceneInformation> sceneInformationList, bool reverseListBeforePush = true)
	{
		if (reverseListBeforePush)
			sceneInformationList.Reverse();

		foreach (SceneInformation sceneInformation in sceneInformationList)
			sceneInformationStack.Push(sceneInformation);
	}

	public SceneInformation Pop()
	{
		if (sceneInformationStack.Count != 0)
			return sceneInformationStack.Pop();

		return null;
	}

	public void Clear()
	{
		sceneInformationStack.Clear();
	}
}
