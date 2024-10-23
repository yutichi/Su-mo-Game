using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeScripts : MonoBehaviour
{
    public Image _fadePanel;
    public float _fadeDuration = 1.0f;

    public static Image FadePanel;
    public static float FadeDuration;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    void Awake()
    {
        FadePanel = _fadePanel;
        FadeDuration = _fadeDuration;
    }

    public void LoadButton()
    {
        StartCoroutine(FadeOutLoad(0));
    }

    public IEnumerator FadeOut()
    {
        _fadePanel.enabled = true;             
        float elapsedTime = 0.0f;              
        Color startColor = _fadePanel.color;       
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); 

        // フェードアウトアニメーションを実行
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;                       
            float t = Mathf.Clamp01(elapsedTime / _fadeDuration);  
            _fadePanel.color = Color.Lerp(startColor, endColor, t); 
            yield return null;                                   
        }

        _fadePanel.color = endColor;
        _fadePanel.enabled = false;
    }

    public IEnumerator FadeIn()
    {
        _fadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = _fadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0.0f);

        // フェードアウトアニメーションを実行
        while (elapsedTime < _fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / _fadeDuration);
            _fadePanel.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        _fadePanel.color = endColor;
        _fadePanel.enabled = false;
    }

    public IEnumerator FadeOutLoad(int sceneNumber)
    {
        FadePanel.enabled = true;
        float elapsedTime = 0.0f;
        Color startColor = FadePanel.color;
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f);

        // フェードアウトアニメーションを実行
        while (elapsedTime < FadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / FadeDuration);
            FadePanel.color = Color.Lerp(startColor, endColor, t);
            yield return null;
        }

        FadePanel.color = endColor;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber + 1);
    }
}
