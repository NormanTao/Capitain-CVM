using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectableMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private bool _unlocked;

    [SerializeField]
    private TextMeshProUGUI _textMesh;
    void Start()
    {
        _unlocked = GameManager.Instance.PlayerData.HasCollectedHelmet(this.gameObject.name);

        if (_unlocked)
        {
            _textMesh.text = "Obtenu";
        }
        else
            _textMesh.text = "Non-obtenu";
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
