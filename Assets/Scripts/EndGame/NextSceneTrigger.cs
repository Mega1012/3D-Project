using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class NextSceneTrigger : MonoBehaviour
{
    public string nextSceneName;

    public float delay = 2.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(LoadNextSceneAfterDelay());
        }
    }

    
    private IEnumerator LoadNextSceneAfterDelay()
    {
        yield return new WaitForSeconds(delay);

        SceneManager.LoadScene(nextSceneName);
    }
}
