using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.Monetization;
//using UnityEngine.Advertisement;

public class Menu : MonoBehaviour
{
    //monetization
    public string playstore_id = "3438016";
    public string appstore_id = "3438017";

    private string video_ad = "video";
    public bool isPlayStore;
    public bool isTestAd;
    //monetization

    public GameObject MainCam;
    public GameObject SoundActive;
    public GameObject NotActiveSound;
    public GameObject Panelback;
    public AudioSource CliclS;

    public bool activesound = true;
    //
    MovePlayer player;
    //
    public GameObject SettingsPanel;
    public GameObject OpenPanelExit;
    public GameObject OpenPanelLvl;
    public GameObject ResetPanel;

    public void Start()
    {
            InitalizeMonetization();
       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<MovePlayer>();
        if (PlayerPrefs.GetInt("SoundInt") == 1)
        {
            NotActiveSound.SetActive(true);
            SoundActive.SetActive(false);
            MainCam.GetComponent<AudioListener>().enabled = false;
        }

        if (PlayerPrefs.GetInt("SoundInt") == 2)
        {
            NotActiveSound.SetActive(false);
            SoundActive.SetActive(true);
            MainCam.GetComponent<AudioListener>().enabled = true;
        }
    }

    private void InitalizeMonetization()
    {     
       // if (isPlayStore == true)
         // {
              Monetization.Initialize(playstore_id, true);
            //  return;
         // }
        // Monetization.Initialize(appstore_id, isTestAd = true);

    }

    public void PlayVideoAd()
    {
        if (Monetization.IsReady(video_ad))
        {
            ShowAdPlacementContent videoAd = null;
            videoAd = Monetization.GetPlacementContent(video_ad) as ShowAdPlacementContent;
            if (videoAd != null)
            {
                videoAd.Show();
            }
        }
    }

    public void OnClickStart()
    {
        SceneManager.LoadScene("TestedScene");
    }

    public void OnClickSettings()
    {
        SettingsPanel.SetActive(true);
        CliclS.Play();
    }

    public void OnClickQuit()
    {
        OpenPanelExit.SetActive(true);
        CliclS.Play();
    }
    public void OnClickYesExit()
    {
        Application.Quit();
        CliclS.Play();
    }
    public void OnClickNoExit()
    {
        OpenPanelExit.SetActive(false);
        CliclS.Play();
    }

    public void OnClickMenu()
    {
        SceneManager.LoadScene("MenuScene");
        CliclS.Play();
    }

    public void OnClickMenuForAdd()
    {
        PlayVideoAd();
        SceneManager.LoadScene("MenuScene");
        CliclS.Play();
    }
    public void OnClickLvl()
    {
        OpenPanelLvl.SetActive(true);
        CliclS.Play();
    }

    public void OnClickOpenSound()
    {
        CliclS.Play();
        SoundActive.SetActive(false);
        NotActiveSound.SetActive(true);
        PlayerPrefs.SetInt("SoundInt", 1);
        MainCam.GetComponent<AudioListener>().enabled = false;
    }
    //
    public void OnClickCloseSound()
    {
        SoundActive.SetActive(true);
        NotActiveSound.SetActive(false);
        PlayerPrefs.SetInt("SoundInt", 2);
        MainCam.GetComponent<AudioListener>().enabled = true;
    }
    public void OnClickLv1(int Lvl)
    {
        SceneManager.LoadScene(Lvl);
        CliclS.Play();
    }

    public void OnClickLvlForAdd(int lvl)
    {
        PlayVideoAd();
        SceneManager.LoadScene(lvl);
        CliclS.Play();
    }
    public void OnClickBackMenu()
    {
        OpenPanelLvl.SetActive(false);
        CliclS.Play();
        
    }
    public void OnClickBackMenuForSettings()
    {
        SettingsPanel.SetActive(false);
        CliclS.Play();

    }

    public void OnClickBonus()
    {
        SceneManager.LoadScene("TestedScene");
        CliclS.Play();
    }

    public void OnClickResetPanel()
    {
        ResetPanel.SetActive(true);
        CliclS.Play();
        //PlayerPrefs.DeleteAll();
        //SceneManager.LoadScene("MenuScene");
    }

    public void OnClickReset()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("MenuScene");
    }

    public void OnClickInst()
    {
        Application.OpenURL("https://www.instagram.com/lapoushkko/");
    }

    public void OnClickPolicy()
    {
        Application.OpenURL("https://github.com/Lapoushko/privacy-policy/blob/master/README");
    }

    public void OnClickGP()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.lapoushko.wancastle.game");
    }

    public void OnClickVK()
    {
        Application.OpenURL("https://vk.com/etoyadyadyavadya");
    }
    //
}
