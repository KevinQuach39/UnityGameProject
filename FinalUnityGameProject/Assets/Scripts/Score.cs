using UnityEngine;
using UnityEngine.UI; 
public class Score : MonoBehaviour
{
    public static Score Instance;
    private int killCount = 0;
    [SerializeField] private Text killText; 
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        UpdateKillText();
    }
    public void AddKill()
    {
        killCount++;
        print("Zombies Killed: " + killCount);
        UpdateKillText();
    }
    private void UpdateKillText()
    {
        if (killText != null)
        {
            killText.text = "Zombies Killed: " + killCount;
        }
    }
    public int GetKillCount()
    {
        return killCount;
    }
    public void ResetKills()
    {
        killCount = 0;
        UpdateKillText();
    }
}