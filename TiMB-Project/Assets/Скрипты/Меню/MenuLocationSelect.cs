using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuLocationSelect : MonoBehaviour
{
    public GameObject[] locationPrefab;
    public Material day;
    public Material night;
    public Light sun;

    public GameObject CanvasPeson;
    public GameObject SkinsPerson;
    public GameObject CanvasAchievements;



    //Объекты для CanvasTraining
    public Canvas CanvasTraining;
    public GameObject BackTraining;
    public VideoClip[] Video;
    public GameObject VideoTraining;
    public Canvas CanvasDailyBonus;
    public Canvas CanvasMenu;
    int count = 0;



    void Start()
    {

        


        int location = PlayerPrefs.GetInt("LocationNum");
        for (int i = 0; i < locationPrefab.Length; i++)
        {
            if (i == location)
            {
                if (location == 2)
                {
                    locationPrefab[i].SetActive(true);
                    FindObjectOfType<Skybox>().material = night;
                    sun.intensity = 0.5f;
                }
                else
                {
                    locationPrefab[i].SetActive(true);
                    FindObjectOfType<Skybox>().material = day;
                    sun.intensity = 1f;
                }
            }
            else locationPrefab[i].SetActive(false);
        }
        if(location>=locationPrefab.Length)
        {
            locationPrefab[2].SetActive(true);
            FindObjectOfType<Skybox>().material = night;
            sun.intensity = 0.5f;
        }


        if (PlayerPrefs.GetInt("PlayerTraining") == 1) //Если обучение пройдено
        {
            CanvasTraining.gameObject.SetActive(false); //отключаем canvas обучение
            BackTraining.SetActive(false); //отключаем задний фон
            VideoTraining.SetActive(false);
            


        }

        if (PlayerPrefs.GetInt("PlayerTraining") == 0) //Если обучение не пройдено
        {
            CanvasMenu.gameObject.SetActive(false);
            CanvasDailyBonus.gameObject.SetActive(false); //включаю бонусы
            //убираем все видео
            //задний план
            //кнопки даллее и пропустить а лучше убрать только canvas

            //сделать массив из видео идти по циклу и если доходим до конца то обучение пройдено
            CanvasTraining.gameObject.SetActive(true);

        }
    }

    public void Achievements()
    {
        CanvasPeson.gameObject.SetActive(false);
        SkinsPerson.gameObject.SetActive(false);
        CanvasAchievements.gameObject.SetActive(true);
    }

    public void SkipTraining()
    {
        
        PlayerPrefs.SetInt("PlayerTraining", 1); //Ставим значение что обучение было якобы пройдено

        CanvasTraining.gameObject.SetActive(false);
        VideoTraining.SetActive(false);
        BackTraining.SetActive(false); //отключаем задний фон
        CanvasDailyBonus.gameObject.SetActive(true); //включаю бонусы


    }

    public void ContinueTrainingVideo()
    {
        count++;

        for (int i = 0; i < Video.Length; i++)
        {
            if(count == 3)
            {
                SkipTraining();
            }
            VideoTraining.GetComponent<VideoPlayer>().clip = Video[count];
        }
    }





}
