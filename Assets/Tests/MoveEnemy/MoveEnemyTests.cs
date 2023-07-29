using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using Zenject;

public class MoveEnemyTests : SceneTestFixture
{
    [UnityTest]
    public IEnumerator MovePeasant_PositionChange_ReturnFalse()
    {
        yield return LoadScene("Test_MovePeasant_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            player.transform.position == Vector3.zero &&
            peasant.transform.position == new Vector3(2, 0));
    }

    [UnityTest]
    public IEnumerator KillPeasant_PeasantDeath_ReturnFalse()
    {
        yield return LoadScene("Test_KillPeasant_PeasantDeath");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var peasant = Object.FindObjectOfType<Peasant>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(peasant == null);
    }

    [UnityTest]
    public IEnumerator MoveKnight_PositionChanged_ReturnFalse()
    {
        yield return LoadScene("Test_MoveKnight_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var knight = Object.FindObjectOfType<Knight>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            player.transform.position == Vector3.zero &&
            knight.transform.position == new Vector3(2, 0));
    }

    [UnityTest]
    public IEnumerator KillKnight_KnightDeath_ReturnFalse()
    {
        yield return LoadScene("Test_KillKnight_KnightDeath");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var knight = Object.FindObjectOfType<Knight>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(knight == null);
    }

    [UnityTest]
    public IEnumerator ChangeDefenseStateKnight_PositionChanged_ReturnFalse()
    {
        yield return LoadScene("Test_ChangeDefenseStateKnight_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var knight = Object.FindObjectOfType<Knight>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            knight.transform.position == new Vector3(3, 0) &&
            player.transform.position == new Vector3(1, 0) &&
            knight.IsDefense);
    }

    [UnityTest]
    public IEnumerator MoveThief_PositionChanged_ReturnFalse()
    {
        yield return LoadScene("Test_MoveThief_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var thief = Object.FindObjectOfType<Thief>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            thief.transform.position == new Vector3(4, 0) &&
            player.transform.position == new Vector3(0, 0));
    }

    [UnityTest]
    public IEnumerator KillThief_ThiefDeath_ReturnFalse()
    {
        yield return LoadScene("Test_KillThief_ThiefDeath");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var thief = Object.FindObjectOfType<Thief>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(thief == null);
    }

    [UnityTest]
    public IEnumerator MoveBerserker_PositionChanged_ReturnFalse()
    {
        yield return LoadScene("Test_MoveBerserker_PositionChanged");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var berserker = Object.FindObjectOfType<Berserker>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(
            berserker.transform.position == new Vector3(2, 0) &&
            player.transform.position == new Vector3(0, 0));
    }

    [UnityTest]
    public IEnumerator KillBerserker_BerserkerDeath_ReturnFalse()
    {
        yield return LoadScene("Test_KillBerserker_BerserkerDeath");
        yield return new WaitForSeconds(1.0f);

        var player = SceneContainer.Resolve<Player>();

        var berserker = Object.FindObjectOfType<Berserker>();

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        player.SetMoveDirection(Vector3.right);
        yield return new WaitForSeconds(1.0f);

        Assert.IsTrue(berserker == null);
    }
}
