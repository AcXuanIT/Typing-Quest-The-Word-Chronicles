using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class TypingController : MonoBehaviour
{
    [SerializeField] private Transform LetterParent;
    [SerializeField] private GameObject LetterPrefab;

    private void Awake()
    {
        SpawnLetter("jump01");
    }
    public void SpawnLetter(string word)
    {
        int index = word.Length * -10;
        foreach(char c in word)
        {
            GameObject letter =  PoolingManager.Spawn(LetterPrefab, new Vector3(0f,0f,0f), Quaternion.identity, LetterParent);

            RectTransform rectletter = letter.GetComponent<RectTransform>();
            rectletter.anchoredPosition = new Vector2(index, 13f);

            TextMeshProUGUI text = letter.GetComponent<TextMeshProUGUI>();
            text.text = c.ToString();
            text.color = Color.white;

            index += 20;
        }
    }
}
