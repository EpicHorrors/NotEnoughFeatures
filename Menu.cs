
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;

namespace PhantomPlus;

public partial class Menu
{
    public static class menu
    {
        private static AnnouncementPopUp popUp;



        [HarmonyPatch(typeof(MainMenuManager), nameof(MainMenuManager.Start))]


        private static void Prefix(MainMenuManager __instance)
        {
            var template = GameObject.Find("ExitGameButton");
            var template2 = GameObject.Find("CreditsButton");
            if (template == null || template2 == null) return;
            
            

            



            var buttonDiscord = Object.Instantiate(template, template.transform.parent);
            
            buttonDiscord.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.542f, 0.5f);

            var textDiscord = buttonDiscord.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textDiscord.SetText("NEF Discord");
            })));
            PassiveButton passiveButtonDiscord = buttonDiscord.GetComponent<PassiveButton>();

            passiveButtonDiscord.OnClick = new Button.ButtonClickedEvent();
            passiveButtonDiscord.OnClick.AddListener((System.Action)(() => Application.OpenURL("https://discord.gg/MP9JTPuVah")));



            // TOR credits button
            if (template == null) return;
            var creditsButton = Object.Instantiate(template, template.transform.parent);

            
            creditsButton.GetComponent<AspectPosition>().anchorPoint = new Vector2(0.462f, 0.5f);

            var textCreditsButton = creditsButton.transform.GetComponentInChildren<TMPro.TMP_Text>();
            __instance.StartCoroutine(Effects.Lerp(0.5f, new System.Action<float>((p) => {
                textCreditsButton.SetText("NEF Credits");
            })));
            PassiveButton passiveCreditsButton = creditsButton.GetComponent<PassiveButton>();

            passiveCreditsButton.OnClick = new Button.ButtonClickedEvent();

            passiveCreditsButton.OnClick.AddListener((System.Action)delegate {
                // do stuff
                if (popUp != null) Object.Destroy(popUp);
                var popUpTemplate = Object.FindObjectOfType<AnnouncementPopUp>(true);
                if (popUpTemplate == null)
                {

                    return;
                }
                popUp = Object.Instantiate(popUpTemplate);

                popUp.gameObject.SetActive(true);
                string creditsString = @$"<align=""center""><b>Developers:</b>
EpicHorrors TheLegend   Techiee








<b>[https://discord.gg/MP9JTPuVah]Discord[]:</b>
Thanks to all our discord helpers!
And modders that helped me!


-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------
-------------------------------------------------------";
                creditsString += "</align>";

                Assets.InnerNet.Announcement creditsAnnouncement = new()
                {
                    Id = "torCredits",
                    Language = 0,
                    Number = 500,
                    Title = "NotEnoughFeatures\nCredits & Thanks",
                    ShortTitle = "TOR Credits",
                    SubTitle = "",
                    PinState = false,
                    Date = "12/7/2024",
                    Text = creditsString,
                };

            });

        }
    }
}
