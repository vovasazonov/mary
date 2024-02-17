using System.Collections.Generic;
using Project.GameDomain.ScreensDomain.LoadingDomain;
using Project.GameDomain.ScreensDomain.MainDomain;
using Project.GameDomain.ScreensDomain.SplashDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EighthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.EleventhMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FifthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FirstMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.FourthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.NinthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.SecondMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.TenthMinigameDomain;
using Project.Scripts.GameDomain.ScreensDomain.MinigamesDomain.ThirdMinigameDomain;

namespace Project.GameDomain.ScreensDomain
{
    public static class ScreensIds
    {
        public static List<string> Ids => new()
        {
            SplashScreen.Id,
            LoadingScreen.Id,
            MainScreen.Id,
            FirstMinigameScreen.Id,
            SecondMinigameScreen.Id,
            ThirdMinigameScreen.Id,
            FourthMinigameScreen.Id,
            FifthMinigameScreen.Id,
            EighthMinigameScreen.Id,
            NinthMinigameScreen.Id,
            TenthMinigameScreen.Id,
            EleventhMinigameScreen.Id,
        };
    }}