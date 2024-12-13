namespace CodeBase._GAME.Util
{
    public static class GameProgressManager
    {
        private static LevelProgress _levelProgress;

        public static void Initialize(LevelProgress levelProgress)
        {
            _levelProgress = levelProgress;
            _levelProgress.LoadProgress();
        }

        public static void UnlockNextLevel()
        {
            _levelProgress.UnlockNextLevel(_levelProgress.unlockedLevels);
            _levelProgress.SaveProgress();
        }

        public static int GetUnlockedLevels() => 
            _levelProgress.unlockedLevels;

        public static void LoadProgress() => 
            _levelProgress.LoadProgress();
    }
}