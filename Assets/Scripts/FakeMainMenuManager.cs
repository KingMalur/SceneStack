using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FakeMainMenuManager : MonoBehaviour
{
	private void Start()
	{
		SceneInformation currentScene = FlowManager.Instance.GetCurrentScene();
		Instantiate(currentScene.PrefabToLoad, transform);
	}

	public void AddSceneFlow(SceneFlow sceneFlow)
	{
		FlowManager.Instance.AddSceneFlow(sceneFlow);
	}

	public void ResetProgressionFlags()
	{
		FlowManager.Instance.FakeLoadProgressionFlags();
	}

	public void FakeGameStartButton()
	{
		StartCoroutine(FakeSceneLoad());
	}

	private IEnumerator FakeSceneLoad()
	{
		string sceneName = FlowManager.Instance.GetSceneFromFlow().SceneName;
		if (FlowManager.Instance.CurrentSceneIsFallbackScene)
			yield break;

		var async = SceneManager.LoadSceneAsync(sceneName);
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
