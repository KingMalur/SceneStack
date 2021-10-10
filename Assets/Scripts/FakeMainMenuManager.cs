using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeMainMenuManager : MonoBehaviour
{
	public void AddSceneInformation(SceneInformationList sceneInformationList)
	{
		FlowManager.Instance.AddSceneInformation(sceneInformationList);
	}

	public void ResetProgressionFlags()
	{
		FlowManager.Instance.FakeLoadProgressionFlags();
	}

	public void FakeGameStartButton()
	{
		StartCoroutine(FakeGameLoad());
	}

	private IEnumerator FakeGameLoad()
	{
		string sceneName = FlowManager.Instance.GetCurrentSceneInformation().SceneName;
		FlowManager.Instance.AccessNextSceneInformation();
		string newSceneName = FlowManager.Instance.GetCurrentSceneInformation().SceneName;
		if (sceneName == newSceneName)
			yield break;

		var async = SceneManager.LoadSceneAsync(newSceneName);
		async.allowSceneActivation = true;

		while (!async.isDone)
		{
			if (async.progress >= 0.9f && !async.allowSceneActivation)
			{
				async.allowSceneActivation = true;
			}
			yield return null;
		}
	}
}
