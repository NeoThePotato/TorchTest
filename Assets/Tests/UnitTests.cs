using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;

public class UnitTests
{
	private static readonly Shader TORCH_SHADER = Shader.Find("Universal Render Pipeline/Lit");
	private static readonly System.Type[] REQUIRED_COMPONENTS = { typeof(Torch), typeof(MeshRenderer) };

	private Torch _torch;

	[UnitySetUp]
	public IEnumerator SetUp()
	{
		yield return null;
		var go = new GameObject("Test Torch", REQUIRED_COMPONENTS);
		_torch = go.GetComponent<Torch>();
		_torch.rend = go.GetComponent<MeshRenderer>();
		_torch.rend.material = new(TORCH_SHADER);
	}

	[UnityTearDown]
	public IEnumerator TearDown()
	{
		yield return null;
		Object.Destroy(_torch.gameObject);
	}

	[UnityTest]
	public IEnumerator TorchIsUnlitByDefault()
	{
		yield return null;
		Assert.IsFalse(_torch.isLit, "Torch.isLit is true without Torch.LightUp.");
	}

	[UnityTest]
	public IEnumerator TorchStaysLitAfterCallingLightUp()
	{
		yield return null;
		_torch.LightUp();
		Assert.IsTrue(_torch.isLit, "Torch.isLit is false after calling Torch.LightUp.");
	}

	[UnityTest]
	public IEnumerator TorchIsLitAfterCallingLightUp()
	{
		yield return null;
		_torch.LightUp();
		_torch.LightUp();
		Assert.IsTrue(_torch.isLit, "Torch.isLit is not true after calling Torch.LightUp twice.");
	}

	[UnityTest]
	public IEnumerator UnLitTorchRendersCorrectly()
	{
		yield return null;
		Assert.AreEqual(_torch.rend.material.color, Torch.UNLIT_COLOR, "Unlit Torch renderer has incorrect color.");
	}

	[UnityTest]
	public IEnumerator LitTorchRendersCorrectly()
	{
		yield return null;
		_torch.LightUp();
		Assert.AreEqual(_torch.rend.material.color, Torch.LIT_COLOR, "Lit Torch renderer has incorrect color.");
	}
}
