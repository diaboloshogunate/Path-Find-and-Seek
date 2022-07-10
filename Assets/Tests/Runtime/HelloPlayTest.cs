using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class HelloPlayTest
{
    [Test]
    public void HelloPlayTestSimplePasses()
    {
        GameObject obj = new GameObject();
        HelloPlayMode mine = obj.AddComponent<HelloPlayMode>();
        Assert.AreEqual("Hello Play Mode", mine.Speak());
    }

    [UnityTest]
    public IEnumerator HelloPlayTestWithEnumeratorPasses()
    {
        GameObject obj = GameObject.Instantiate(new GameObject());
        yield return null;
        HelloPlayMode mine = obj.AddComponent<HelloPlayMode>();
        Assert.AreEqual("Hello Play Mode", mine.Speak());
    }
}
