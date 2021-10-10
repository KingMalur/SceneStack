using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeSceneManager : MonoBehaviour
{
	public Text DataText;

	private void Start()
	{
		SceneInformation currentScene = FlowManager.Instance.GetCurrentSceneInformation();
		DataText.text = currentScene.PrefabToLoad.name;
		Instantiate(currentScene.PrefabToLoad, transform);
	}

	public void FakeContinueButton()
	{
		StartCoroutine(FakeGameLoad());
	}

	public void FakeSetProgressionFlagOfCurrentScene()
	{
		FlowManager.Instance.SetProgressionFlag();
	}

	public void FakeGoToMainMenu()
	{
		FlowManager.Instance.AbortSceneFlow();
		StartCoroutine(FakeGameLoad());
	}

	private IEnumerator FakeGameLoad()
	{
		FlowManager.Instance.AccessNextSceneInformation();
		string sceneName = FlowManager.Instance.GetCurrentSceneInformation().SceneName;

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
