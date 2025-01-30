using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] float scale = 0.15f;
    [SerializeField] Button btn;
    private Vector3 _originalScale;

    // Start is called before the first frame update
    void Start()
    {
        if(btn != null)
        _originalScale = btn.transform.localScale;
    }

    // Update is called once per frame
    public void ReloadGameOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void OnPointerEnter()
    {
        AudioManager.Instance.PlayOneShot(
            AudioManager.Instance.sfxSource,
            AudioManager.Instance.pop[Random.Range(0,AudioManager.Instance.pop.Length)],
            1);
        btn.transform.localScale += new Vector3(scale, scale, scale);
    }

    public void OnPointerExit()
    {
        AudioManager.Instance.PlayOneShot(
            AudioManager.Instance.sfxSource,
            AudioManager.Instance.pop[Random.Range(0, AudioManager.Instance.pop.Length)],
            1);
        btn.transform.localScale = _originalScale;
    }
}
