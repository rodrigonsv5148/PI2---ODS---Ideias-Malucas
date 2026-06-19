public static class FMOD_Names
{
    public static class VCA 
    {
        private const string vca = "vca:/";
        public const string sfx = vca + "VOL_SFX";
        public const string ost = vca + "VOL_OST";
        public const string vo = vca + "VOL_VO";
        public const string master = vca + "VOL_MASTER";
    }

    public static class Events 
    {
        private const string events = "event:/";

        public static class OSTS 
        {
            public const string gameIDLE    = events + "OST's/OST_GameIDLE";
            public const string loseScene   = events + "OST's/OST_LoseScene";
            public const string mainMenu    = events + "OST's/OST_MainMenu";
            public const string winScene    = events + "OST's/OST_WinScene";
        }

        public static class SFXS
        {
            public const string badChoice           = events + "SFX's/SFX_BadChoice";
            public const string clickInteractible   = events + "SFX's/SFX_Click_Interactable";
            public const string clickStamp          = events + "SFX's/SFX_Click_Stamp";
            public const string openDoor            = events + "SFX's/SFX_Door";
            public const string goodChoice          = events + "SFX's/SFX_GoodChoice";
            public const string steps               = events + "SFX's/SFX_Steps";
            public const string stomp               = events + "SFX's/SFX_Stomp";
            public const string objectInteractable  = events + "SFX's/SFX_ObjectInteractable";
        }

        public static class VOS
        {
            public const string proximo = events + "Voice Over/VO_Próximo";
        }
    }
}
