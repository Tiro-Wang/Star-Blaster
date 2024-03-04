using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsDialog : DialogBase
{
    [SerializeField] private Slider musicSlider;
     private AudioSource musicSource;

    private void Start()
    {
        musicSource=GameObject.Find("AudioManager").GetComponent<AudioSource>();
        //音乐监听器
        musicSlider.onValueChanged.AddListener((value) =>
        {
            musicSource.volume = musicSlider.value;
            DateManager.instance.musicSettingValue = musicSlider.value;//将值存在DateManager里

            //存储调用
            DateManager.instance.SaveMusicSetting();
        });
    }
    public override void OpenDialog()
    {
        base.OpenDialog();
        musicSlider.value=DateManager.instance.musicSettingValue;
    }
    /*    public void MusicChange(float value)
        {
            MusicSource.volume = MusicSlider.value;

        }*/
}
