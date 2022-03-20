using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Représente les données de jeu
/// </summary>
[System.Serializable]
public class PlayerData
{
 
    [Range(-80, 0)]
    private float _volumeGeneral = 0;
    public float VolumeGeneral { get { return _volumeGeneral; } set { _volumeGeneral = value; } }

 
    [Range(-80, 0)]
    private float _volumeMusique = 0;
    public float VolumeMusique { get { return _volumeMusique; } set { _volumeMusique = value; } }

  
    [Range(-80, 0)]
    private float _volumeEffet = 0;
    public float VolumeEffet { get { return _volumeEffet; } set { _volumeEffet = value; } }


    private int _vie;

    private int _energie;

    private int _score;

    private List<string> _chestOpenList;

    private List<string> _helmetCollected;

    private int _maxLevel;

    public const int MAX_ENERGIE = 4;

    public System.Action UIPerteEnergie;

    public System.Action UIPerteVie;

    public System.Action Gameover;

    public int Energie { get { return this._energie; } }
    public int Vie { get { return this._vie; } }
    public int Score { get { return this._score; } }
    public string[] ListeCoffreOuvert { get { return this._chestOpenList.ToArray(); } }

    public string[] ListHelmetCollected { get { return this._helmetCollected.ToArray(); } }

    public int MaxLevel { get { return this._maxLevel;  } }


    public PlayerData()
    {
        this._vie = 0;
        this._energie = 0;
        this._score = 0;
        this._volumeGeneral = 0;
        this._volumeMusique = 0;
        this._volumeEffet = 0;
        this.UIPerteEnergie = null;
        this.UIPerteVie = null;
        this.Gameover = null;
        this._chestOpenList = new List<string>();
        this._helmetCollected = new List<string>();
        this._maxLevel = 0;
    }

    public PlayerData(int vie = 1, int energie = 2, int score = 0,
        float volumeGeneral = 0, float volumeMusique = 0, float volumeEffet = 0,
        System.Action uiPerteEnergie = null, System.Action uiPerteVie = null,
        System.Action gameOver = null, List<string> ChestList = null, int maxLevel = 0, List<string> HelmetList = null)
    {
        this._vie = vie;
        this._energie = energie;
        this._score = score;
        this._volumeGeneral = volumeGeneral;
        this._volumeMusique = volumeMusique;
        this._volumeEffet = volumeEffet;
        this.UIPerteEnergie += uiPerteEnergie;
        this.UIPerteVie += uiPerteVie;
        this.Gameover += gameOver;
        this._chestOpenList = new List<string>();
        if (ChestList != null)
            this._chestOpenList = ChestList;
        this._maxLevel = maxLevel;

        this._helmetCollected = new List<string>();
        if (HelmetList != null)
            this._helmetCollected = HelmetList;

    }

    /// <summary>
    /// Diminue l'énergie du personnage
    /// </summary>
    /// <param name="perte">Niveau de perte (par défaut 1)</param>
    public void DecrEnergie(int perte = 1)
    {
        this._energie -= perte;
        this.UIPerteEnergie();
        if (this._energie <= 0)
        {
            this.DecrVie();
        }
    }

    /// <summary>
    /// Permet de réduire la vie d'un personnage
    /// </summary>
    public void DecrVie()
    {
        this._vie--;
        this.UIPerteVie();
        if (this._vie <= 0)
        {
            this.Gameover();

        }
        else
        {
            this.IncrEnergie(MAX_ENERGIE);
            GameManager.Instance.RechargerNiveau();

        }
    }

    /// <summary>
    /// Permet d'augmenter l'énergie jusqu'à MAX_ENERGIE
    /// </summary>
    /// <param name="gain">Gain d'augmentation</param>
    public void IncrEnergie(int gain)
    {
        this._energie += gain;
        if (this._energie > MAX_ENERGIE)
        {
            this._energie = 1;
            this.IncrVie();
        }
        
        this.UIPerteEnergie();
    }

    public void LevelFinished()
    {
        this._maxLevel += 1;
    }

    /// <summary>
    /// Permet d'augmenter la vie
    /// </summary>
    /// <param name="gain">Gain d'augmentation</param>
    public void IncrVie(int gain = 1)
    {
        this._vie += gain;
        this.UIPerteVie();
    }

    /// <summary>
    /// Augmente le score du joueur
    /// </summary>
    /// <param name="gain">Point gagné</param>
    public void IncrScore(int gain = 1)
    {
        this._score += gain;
    }

    public void AjouterCoffreOuvert(string nom)
    {
        this._chestOpenList.Add(nom);
    }

    public void AddHelmet(string name)
    {
        this._helmetCollected.Add(name);
    }

    public bool AvoirOuvertureCoffre(string nom)
    {
        return this._chestOpenList.Contains(nom);
    }

    public bool HasCollectedHelmet(string name)
    {
        return this._helmetCollected.Contains(name);
    }
}
