using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private static float delay = 0.5f;

    [SerializeField]
    private string sceneName;

    private bool isOnProgress;

    public void Load(bool isPermanent = false)
    {
        if (isOnProgress)
            return;

        isOnProgress = true;

        var loadCoroutine = LoadCoroutine(isPermanent);
        StartCoroutine(loadCoroutine);
    }

    public void Reload(bool isPermanent = false)
    {
        if (isOnProgress)
            return;

        isOnProgress = true;

        var reloadCoroutine = ReloadCoroutine(isPermanent);
        StartCoroutine(reloadCoroutine);
    }

    private IEnumerator LoadCoroutine(bool isPermanent)
    {
        if (string.IsNullOrEmpty(sceneName) || string.IsNullOrWhiteSpace(sceneName))
            yield break;

        if (!isPermanent)
            yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(sceneName);

        yield return null;
    }

    private IEnumerator ReloadCoroutine(bool isPermanent)
    {
        if (!isPermanent)
            yield return new WaitForSeconds(delay);

        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        yield return null;
    }
}
