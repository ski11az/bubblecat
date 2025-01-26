using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PlayAgainButton : MonoBehaviour
{
    [SerializeField] float scale = 0.15f;
    [SerializeField] TMP_Text stopwatchText;
    public Canvas targetCanvas;  // Assign the UI Canvas in the Inspector

    private Button _btn;
    private Vector3 _originalScale;

    // Start is called before the first frame update
    void Start()
    {
        _btn = gameObject.GetComponent<Button>();
        _btn.onClick.AddListener(ReloadGameOnClick);

        _originalScale = _btn.transform.localScale;
    }

    // Update is called once per frame
    void ReloadGameOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       
        if (targetCanvas != null && targetCanvas.enabled)
        {
            targetCanvas.enabled = false;
        }
        else if (targetCanvas == null)
        {
            Debug.LogWarning("No canvas assigned to CloseCanvasOnSpace script!");
        }
    }

    public void OnPointerEnter()
    {
        _btn.transform.localScale += new Vector3(scale, scale, scale);
    }

    public void OnPointerExit()
    {
        _btn.transform.localScale = _originalScale;
    }
}
