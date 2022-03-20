using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SpriteRenderer))]
public class ChestInteraction : BaseInteraction
{
    [SerializeField, Range(0, 25)]
    private int _scoreBonus;

    [SerializeField]
    private bool _estOuvert = false;

    [SerializeField]
    private Sprite _coffreOuvert;

    private string _name;

    private void Start()
    {
        _name = SceneManager.GetActiveScene().name.Replace(' ', '_')
            + $"__{(int)this.transform.position.x}_{(int)this.transform.position.y}";

        this._estOuvert = GameManager.Instance.PlayerData.AvoirOuvertureCoffre(_name);

        if (_estOuvert)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _coffreOuvert;
    }

    public override void DoAction()
    {
        if(!_estOuvert)
        {
            GameManager.Instance.PlayerData.IncrScore(this._scoreBonus);
            _estOuvert = true;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = _coffreOuvert;
            this.ArreterInteraction();
            GameManager.Instance.PlayerData.AjouterCoffreOuvert(_name);
        }
    }
}
