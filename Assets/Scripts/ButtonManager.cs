using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class ButtonManager : MonoBehaviour
{
    private Button btn;
    public GameObject property;
    private bool autoClicked = false;
    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(SelectObject);
        autoClicked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ComponentManager.Instance.OnEntered(gameObject) && !autoClicked)
        {
            transform.DOScale(Vector3.one * 2, 0.3f);
            btn.onClick.Invoke();
            autoClicked = true;
            // transform.localScale = Vector3.one * 2;
        }
        else
        {
            transform.DOScale(Vector3.one, 0.3f);
            autoClicked = false;
            // transform.localScale = Vector3.one;
        }
    }

    void SelectObject()
    {
        DataHandler.Instance.property = property;
    }

    public void HomePage()
   {
    SceneManager.LoadScene("HomePage");
   }
}
