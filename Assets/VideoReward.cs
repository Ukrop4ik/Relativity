using UnityEngine;
using UnityEngine.Advertisements;

public class VideoReward : MonoBehaviour
{
    UILevel ui;

    void Start()
    {
        ui = gameObject.GetComponent<UILevel>();
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady("rewardedVideo"))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };
            Advertisement.Show("rewardedVideo", options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");

                int skillvalue = PlayerPrefs.GetInt("skill_value");
                skillvalue += 3;
                PlayerPrefs.SetInt("skill_value", skillvalue);
                PlayerPrefs.Save();
                ui.ShowSkills();
                ui.CloseReward();
                ui.OpenRewardFinalPanel();
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }
}
