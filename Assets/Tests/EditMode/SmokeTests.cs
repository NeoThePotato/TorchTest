using UnityEngine;
using UnityEditor.SceneManagement;
using NUnit.Framework;

public class SmokeTests
{
	private const string TORCH_TEST_SCENE = "Assets\\Scenes\\Torch Test.unity";

	[OneTimeSetUp]
	public void SetUp()
	{
		EditorSceneManager.OpenScene(TORCH_TEST_SCENE);
	}

	[OneTimeTearDown]
	public void TearDown()
	{
		EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
	}

	[Test]
	public void TorchAndPlayerExist()
	{
		Assert.NotNull(Object.FindAnyObjectByType<Torch>(), "No Torch found in scene \"{0}\".", EditorSceneManager.GetActiveScene().name);
		Assert.NotNull(Object.FindAnyObjectByType<PlayerTorchInteractor>(), "No PlayerTorchInteractor found in scene \"{0}\".", EditorSceneManager.GetActiveScene().name);
	}
}
