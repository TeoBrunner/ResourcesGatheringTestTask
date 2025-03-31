using System.Collections;
using TMPro;
using UnityEngine;

public class Popup : MonoBehaviour
{
    [SerializeField] float showTime = 3;
    [SerializeField] TMP_Text content;
    private Coroutine hideCoroutine;

    public void Show()
    {
        gameObject.SetActive(true);
        if (hideCoroutine != null)
        {
            StopCoroutine(hideCoroutine);
        }
        hideCoroutine = StartCoroutine(Hide());
    }
    public void UpdateContent(string newText)
    {
        content.text = newText;
    }
    private IEnumerator Hide()
    {
        yield return new WaitForSeconds(showTime);
        gameObject.SetActive(false);
    }
}
