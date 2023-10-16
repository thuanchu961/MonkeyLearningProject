using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UiManager : Singleton<UiManager>
{
    [Header("Popup References")]
    [SerializeField] private PopupVictory popupVictory;
    [SerializeField] private PopupSetting popupSetting;
    [SerializeField] private GameObject wordPanel;
    [SerializeField] private TMP_Text wordText;
    private string word;
    public void ReceiveWord(string value)
    {
        word = value;
    }
    public void ShowWordText()
    {
        StartCoroutine(ShowWord());
    }
    private IEnumerator ShowWord()
    {
        wordPanel.SetActive(true);
        wordText.text = word;
        yield return new WaitForSeconds(1f);
        wordText.text = "";
        wordPanel.SetActive(false);
    }
    public void ShowPopupVictory()
    {
        popupVictory.SetActive(true);
        popupVictory.Show();
    }
    public void ShowPopupSetting()
    {
        popupSetting.gameObject.SetActive(true);
        popupSetting.Show();
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }
}
