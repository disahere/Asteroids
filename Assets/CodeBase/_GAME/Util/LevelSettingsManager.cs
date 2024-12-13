namespace CodeBase._GAME.Util
{
    public static class LevelSettingsManager
    {
        private static LevelSettings _currentLevelSettings;

        public static void SetLevelSettings(LevelSettings levelSettings)
        {
            _currentLevelSettings = levelSettings;
        }

        public static LevelSettings GetCurrentLevelSettings()
        {
            return _currentLevelSettings;
        }
    }
}