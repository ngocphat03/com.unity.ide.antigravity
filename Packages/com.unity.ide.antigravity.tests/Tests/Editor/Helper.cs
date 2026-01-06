using UnityEditor.Compilation;

namespace AntigravityEditor.Tests
{
    public static class Helper
    {
        public static string GetLangVersion()
        {
            var languageVersion =
#if UNITY_2020_2_OR_NEWER
                new ScriptCompilerOptions().LanguageVersion;
#else
                "latest";
#endif
            return languageVersion;
        }
    }
}