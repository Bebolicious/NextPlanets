using UnityEngine;
using UnityEngine.UI;

public class CharacterScreen : MonoBehaviour
{
    public Text levelText, hitPointText, creditsText, xpText, 
        beachQuestText, craterQuestText, flowerQuestText, caveQuestText, bossQuestText;

    private int currentCharacterSelection = 0;
    public Image characterSelectionSprite;
    public RectTransform xpBar;

    // Character Selection
    public void OnArrowClick(bool right)
    {
        if (right)
        {
            currentCharacterSelection++;

            if (currentCharacterSelection == GameManager.instance.playerSprites.Count)
                currentCharacterSelection = 0;

            OnSelectionChanged();
        }
        else
        {
            currentCharacterSelection--;
            if (currentCharacterSelection < 0)
                currentCharacterSelection = GameManager.instance.playerSprites.Count - 1;

            OnSelectionChanged();
        }

    }
    private void OnSelectionChanged()
    {
        characterSelectionSprite.sprite = GameManager.instance.playerSprites[currentCharacterSelection];
        //GameManager.instance.player.SwapSprite(currentCharacterSelection);
    }

public void UpdateCharacterScreen()
    {
        levelText.text = GameManager.instance.GetCurrentLevel().ToString();
        hitPointText.text = GameManager.instance.player.hitPoint.ToString();
        creditsText.text = GameManager.instance.credits.ToString();
        if (GameManager.instance.beachQuest == true)
        {
            beachQuestText.color = Color.green;
        }
        if (GameManager.instance.craterQuest == true)
        {
            craterQuestText.color = Color.green;
        }
        if (GameManager.instance.flowerQuest == true)
        {
            flowerQuestText.color = Color.green;
        }
        if (GameManager.instance.caveQuest == true)
        {
            caveQuestText.color = Color.green;
        }
        if (GameManager.instance.bossQuest == true)
        {
            bossQuestText.color = Color.green;
        }

        // Xp Bar
        int currentLevel = GameManager.instance.GetCurrentLevel();
        if (currentLevel == GameManager.instance.xpTable.Count)
        {
            xpText.text = GameManager.instance.experience.ToString() + " total experience points"; // Display total xp
            xpBar.localScale = Vector3.one;
        }
        else
        {
            int previousLevelXp = GameManager.instance.GetXpToLevel(currentLevel - 1);
            int currentLevelXp = GameManager.instance.GetXpToLevel(currentLevel);

            int difference = currentLevelXp - previousLevelXp;
            int currentXpIntoLevel = GameManager.instance.experience - previousLevelXp;

            float completionRatio = (float)currentXpIntoLevel / (float)difference;
            xpBar.localScale = new Vector3(completionRatio, 1, 1);
            xpText.text = currentXpIntoLevel.ToString() + " / " + difference;
        }
        

    }
}
