using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private TransiitionEffect transition;
    public void SceneLoad(int index)
    {
        StartCoroutine(wait(index));
    }
    IEnumerator wait(int index)
    {
        transition.Fade();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(index);
    }
}
