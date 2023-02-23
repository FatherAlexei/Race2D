using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameView : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button _buttonBack;

    public void Init(UnityAction BackToMainMenu)
    {
        _buttonBack.onClick.AddListener(BackToMainMenu);
    }

    public void OnDestroy()
    {
        _buttonBack.onClick.RemoveAllListeners();

    }
}
