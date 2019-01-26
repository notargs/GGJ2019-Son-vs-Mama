using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameoverManager : MonoBehaviour
{
    public Slider slider;
    int AngerPoint = 10;

    //フェードインイメージ
    public RawImage sceneimag;
    private Texture2D texture2d;

    //透明度を変わるスピード
    float fadeSpeed = 0.01f;
    float red, green, blue, alfa;

    //フェードイン処理の開始と完了のフラグ
    public bool isFadeIn;
    public bool Scenechanege;

    // Start is called before the first frame update
    void Start()
    {
        //フェードインイメージの表示を消す
        sceneimag.gameObject.SetActive(false);
        //フラグの初期化
        isFadeIn = false;
        Scenechanege = false;
        //フェードインイメージをカラーを取得
        red = sceneimag.color.r;
        green = sceneimag.color.g;
        blue = sceneimag.color.b;
        alfa = sceneimag.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        //怒りゲージがMAX時に実行
        if (slider.value == AngerPoint)
        {
            sceneimag.gameObject.SetActive(true);
            isFadeIn = true;
        }

        //フェードインを実行
        if (isFadeIn)
        {
            StartFadeIn();
        }

        if (Scenechanege)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void StartFadeIn()
    {
        alfa += fadeSpeed;
        SetAlpha();
        if (alfa >= 1.0f)
        {
            isFadeIn = false;

            Scenechanege = true;
        }
    }

    void SetAlpha()
    {
        sceneimag.color = new Color(red, green, blue, alfa);
    }
}
