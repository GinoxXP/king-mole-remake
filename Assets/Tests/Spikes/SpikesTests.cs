using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class SpikesTests : SceneTestFixture
{
    [UnityTest]
    public IEnumerator MovePlayer_SpikesStateIsChanged_ReturnFalse()
    {
        yield return LoadScene("Test_Spikes_StateChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var spikes = Object.FindObjectOfType<Spikes>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(spikes.IsActivated);
    }

    [UnityTest]
    public IEnumerator StateIsActive_EnemyIsKilled_ReturnFalse()
    {
        yield return LoadScene("Test_Spikes_EnemyKilled");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(peasant == null);
    }

    [UnityTest]
    public IEnumerator StateIsNotActive_EnemyIsNotKilled_ReturnFalse()
    {
        yield return LoadScene("Test_Spikes_EnemyIsNotKilled");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(peasant != null);
    }
}
