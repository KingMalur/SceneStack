using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(SceneStack))]
public class FlowManager : MonoBehaviour
{
	public string ID;

	public static FlowManager Instance;
	public SceneInformation FallbackSceneInformation;
	public ProgressionFlag FallbackSceneFlag = ProgressionFlag.None;

	[Header("Progression-Control")]
	Dictionary<ProgressionFlag, bool> ProgressionFlags;

	private SceneStack sceneStack;
	private SceneInformation currentSceneInformation;

	private void Awake()
	{
		if (Instance != null)
			Destroy(gameObject);
		else
			Instance = this;

		DontDestroyOnLoad(this);

		FakeLoadProgressionFlags();
		sceneStack = GetComponent<SceneStack>();
		currentSceneInformation = FallbackSceneInformation;
	}

	public void FakeLoadProgressionFlags()
	{
		ProgressionFlags = Enum.GetValues(typeof(ProgressionFlag))
			.Cast<ProgressionFlag>()
			.ToDictionary(k => k, v => false);
	}

	public void SetProgressionFlag()
	{
		SetProgressionFlag(currentSceneInformation.ProgressionFlagToSet);
	}

	public void SetProgressionFlag(ProgressionFlag progressionFlag)
	{
		if (ProgressionFlags.ContainsKey(progressionFlag))
			ProgressionFlags[progressionFlag] = true;
	}

	public void AccessNextSceneInformation()
	{
		currentSceneInformation = sceneStack.Pop() ?? FallbackSceneInformation;

		if (currentSceneInformation.ProgressionFlagToSet == FallbackSceneFlag)
			return;

		bool flagValue = false;
		if (ProgressionFlags.TryGetValue(currentSceneInformation.ProgressionFlagToSet, out flagValue) && flagValue)
			AccessNextSceneInformation();
	}

	public SceneInformation GetCurrentSceneInformation()
	{
		return currentSceneInformation;
	}

	public void AddSceneInformation(SceneInformationList sceneInformationList)
	{
		sceneStack.Clear();
		sceneStack.Push(sceneInformationList.ListOfSceneInformation);
	}

	public void AbortSceneFlow()
	{
		sceneStack.Clear();
		AccessNextSceneInformation();
	}
}
