using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Offre un moteur de lecture/écriture du JSON
/// pour l'objet <code>PlayerData</code>
/// </summary>
   [System.Serializable]
    class PlayerDataJson
    {
        public int hp;
        public int energy;
        public int score;
        public float volumeGeneral;
        public float volumeMusic;
        public float volumeFX;
        public string[] chestOpenList;
        public string[] helmetCollected;
        public int currentLevel;

        public PlayerDataJson(int hp , int energy, int score, float volumeGeneral,float volumeMusic,float volumeFX,string[] chestOpened, string[] helmetCollected,int currentLevel)
        {
            this.hp = hp;
            this.energy = energy;
            this.score = score;
            this.volumeFX = volumeFX;
            this.volumeGeneral = volumeGeneral;
            this.volumeMusic = volumeMusic;
            this.chestOpenList = chestOpened;
            this.helmetCollected = helmetCollected;
            this.currentLevel = currentLevel;
        }
        public PlayerDataJson()
        {
            this.hp = 0;
            this.energy = 0;
            this.score = 0;
            this.volumeGeneral=0;
            this.currentLevel = 0;
            this.chestOpenList = null;
            this.helmetCollected = null;
            this.volumeFX=0;
            this.volumeMusic=0;
        }
    
    public static string WriteJson(PlayerData data)
    {
        PlayerDataJson json = new PlayerDataJson(data.Vie, data.Energie, data.Score, data.VolumeGeneral, data.VolumeMusique, data.VolumeEffet,data.ListeCoffreOuvert,data.ListHelmetCollected,data.CurrentLevel);
        return JsonUtility.ToJson(json);
       
    }

    public static PlayerData ReadJson(string json)
    {
        PlayerDataJson dataJson = JsonUtility.FromJson<PlayerDataJson>(json);
        List<string> chests = new List<string>();
        List<string> helmets = new List<string>();


        foreach (string chest in dataJson.chestOpenList)
            chests.Add(chest);
        

        foreach (string helmet in dataJson.helmetCollected)
            helmets.Add(helmet);

        return new PlayerData(dataJson.hp, 
            dataJson.energy, 
            dataJson.score, 
            dataJson.volumeGeneral, 
            dataJson.volumeMusic,
            dataJson.volumeFX, 
            ChestList: chests, 
            CurrentLevel: dataJson.currentLevel, 
            HelmetList: helmets);
    }
}

