using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlayDialog : DialogBase
{
    [SerializeField] private GameObject controlsPage;
    [SerializeField] private GameObject infoPage;

    [SerializeField] private Button controlButton;
    [SerializeField] private Button infoButton;


    private void Start()
    {
       // base.CloseDialog();
       // /*base 关键字是用来引用当前类的直接基类，*/
        controlsPage.SetActive(false);
        infoPage.SetActive(true);
        controlButton.interactable=true;
        infoButton.interactable=false;
    }
    public void ControllersPage()
    {
        infoPage.SetActive(false);
        controlsPage.SetActive(true);
        infoButton.interactable = true;
        controlButton.interactable = false;
    }
    public void InfoPage()
    {
        infoPage.SetActive(true);
        controlsPage.SetActive(false);
        infoButton.interactable = false;
        controlButton.interactable = true;
    }
}
