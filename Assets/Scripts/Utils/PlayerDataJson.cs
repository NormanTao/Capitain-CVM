using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Offre un moteur de lecture/écriture du JSON
/// pour l'objet <code>PlayerData</code>
/// </summary>
   [System.Serializable]
    class PlayerDataJson
    {
        public int vie;
        public int energie;
        public int score;
        public float volumeGeneral;
        public float volumeMusique;
        public float volumeEffet;
        public string[] chestOpenList;
        public string[] helmetCollected;
        public int maxLevel;

        public PlayerDataJson(int vie , int energie, int score, float volgeneral,float volumemusique,float volumeeffet,string[] chestopen, string[] collectables,int maxlevel)
        {
            this.vie = vie;
            this.energie = energie;
            this.score = score;
            this.volumeEffet = volumeeffet;
            this.volumeGeneral = volgeneral;
            this.volumeMusique = volumemusique;
            this.chestOpenList = chestopen;
            this.helmetCollected = collectables;
            this.maxLevel = maxlevel;
        }
        public PlayerDataJson()
        {
            this.vie = 0;
            this.energie = 0;
            this.score = 0;
            this.volumeGeneral=0;
            this.maxLevel=0;
            this.chestOpenList = null;
            this.helmetCollected = null;
            this.volumeEffet=0;
            this.volumeMusique=0;
        }
    
    /// <summary>
    /// Sérialise un objet de type PlayerData au format JSON
    /// </summary>
    /// <param name="data">Paramètre à sérialiser</param>
    /// <returns>La chaîne contenant le format JSON</returns>
    public static string WriteJson(PlayerData data)
    {
        PlayerDataJson pdtj = new PlayerDataJson(data.Vie, data.Energie, data.Score, data.VolumeGeneral, data.VolumeMusique, data.VolumeEffet,data.ListeCoffreOuvert,data.ListHelmetCollected,data.MaxLevel);
        return JsonUtility.ToJson(pdtj);
       
    }

    /// <summary>
    /// Récupère un objet PlayerData depuis un format JSON
    /// </summary>
    /// <param name="json">Format JSON à traiter</param>
    /// <returns>L'objet converti</returns>
    /// <exception cref="JSONFormatExpcetion">La chaîne n'est pas
    /// au format JSON</exception>
    /// <exception cref="System.ArgumentException">La chaîne fournit
    /// ne peut pas contenir un format JSON</exception>
    public static PlayerData ReadJson(string json)
    {
        PlayerDataJson pdtj = JsonUtility.FromJson<PlayerDataJson>(json);
        List<string> chests = new List<string>();
        List<string> helmets = new List<string>();


        foreach (string chest in pdtj.chestOpenList)
        {
            chests.Add(chest);
        }

        foreach (string helmet in pdtj.helmetCollected)
        {
            helmets.Add(helmet);
        }
        return new PlayerData(pdtj.vie, pdtj.energie, pdtj.score, pdtj.volumeGeneral, pdtj.volumeMusique, pdtj.volumeEffet, ChestList: chests, maxLevel: pdtj.maxLevel, HelmetList: helmets);
    }
}

