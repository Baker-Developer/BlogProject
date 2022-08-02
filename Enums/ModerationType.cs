using System.ComponentModel;

namespace BlogProject.Enums
{
    public enum ModerationType
    {
        [Description("Threatening Language")]
        Threatening,
        [Description("Spamming The Comments Section")]
        Spam,
        [Description("Political Talk On A Article")]
        Political,
        [Description("Foul Languge On A Artcile")]
        Language,
        [Description("Drug References On A Artcile")]
        Drugs,
        [Description("Targeted Bullying")] 
        Bullying
    }
}
