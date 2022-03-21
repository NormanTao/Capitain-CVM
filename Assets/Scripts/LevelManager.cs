using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private Button[] _listButton;
    private int _maxLevel;
    // Start is called before the first frame update
    void Start()
    {
        _maxLevel = GameManager.Instance.PlayerData.MaxLevel;
        for (int i = 0; i < _maxLevel-1; i++)
        {
            _listButton[i].interactable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
