using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unity.CodeEditor;

namespace AntigravityEditor
{
    public interface IDiscovery
    {
        CodeEditor.Installation[] PathCallback();
    }

    public class AntigravityDiscovery : IDiscovery
    {
        List<CodeEditor.Installation> m_Installations;

        public CodeEditor.Installation[] PathCallback()
        {
            if (m_Installations == null)
            {
                m_Installations = new List<CodeEditor.Installation>();
                FindInstallationPaths();
            }

            return m_Installations.ToArray();
        }

        public static string GetEditorName(string path)
        {
            return "Antigravity IDE";
        }

        void FindInstallationPaths()
        {
            string[] possiblePaths =
#if UNITY_EDITOR_OSX
            {
                "/Applications/Antigravity IDE.app"
            };
#elif UNITY_EDITOR_WIN
            {
                GetProgramFiles() + @"/Google/Antigravity IDE/bin/antigravity-ide.cmd",
                GetProgramFiles() + @"/Google/Antigravity IDE/bin/antigravity.cmd",
                GetProgramFiles() + @"/Google/Antigravity IDE/Antigravity IDE.exe",
                GetProgramFiles() + @"/Google/Antigravity IDE/Antigravity.exe",
                GetLocalAppData() + @"/Programs/Google/Antigravity IDE/bin/antigravity-ide.cmd",
                GetLocalAppData() + @"/Programs/Google/Antigravity IDE/bin/antigravity.cmd",
                GetLocalAppData() + @"/Programs/Google/Antigravity IDE/Antigravity IDE.exe",
                GetLocalAppData() + @"/Programs/Google/Antigravity IDE/Antigravity.exe",
            };
#else
            {
                "/usr/bin/antigravity-ide",
                "/usr/local/bin/antigravity-ide",
                "/snap/bin/antigravity-ide"
            };
#endif
            var existingPaths = possiblePaths.Where(AntigravityExists).ToList();
            if (!existingPaths.Any())
            {
                return;
            }

            var lcp = GetLongestCommonPrefix(existingPaths);
            switch (existingPaths.Count)
            {
                case 1:
                {
                    var path = existingPaths.First();
                    m_Installations = new List<CodeEditor.Installation>
                    {
                        new CodeEditor.Installation
                        {
                            Path = path,
                            Name = GetEditorName(path)
                        }
                    };
                    break;
                }
                case 2 when existingPaths.Any(path => !(path.Substring(lcp.Length).Contains("/") || path.Substring(lcp.Length).Contains("\\"))):
                {
                    goto case 1;
                }
                default:
                {
                    m_Installations = existingPaths.Select(path => new CodeEditor.Installation
                    {
                        Name = $"{GetEditorName(path)} ({path.Substring(lcp.Length)})",
                        Path = path
                    }).ToList();

                    break;
                }
            }
        }

#if UNITY_EDITOR_WIN
        static string GetProgramFiles()
        {
            return Environment.GetEnvironmentVariable("ProgramFiles")?.Replace("\\", "/");
        }

        static string GetLocalAppData()
        {
            return Environment.GetEnvironmentVariable("LOCALAPPDATA")?.Replace("\\", "/");
        }
#endif

        static string GetLongestCommonPrefix(List<string> paths)
        {
            var baseLength = paths.First().Length;
            for (var pathIndex = 1; pathIndex < paths.Count; pathIndex++)
            {
                baseLength = Math.Min(baseLength, paths[pathIndex].Length);
                for (var i = 0; i < baseLength; i++)
                {
                    if (paths[pathIndex][i] == paths[0][i]) continue;

                    baseLength = i;
                    break;
                }
            }

            return paths[0].Substring(0, baseLength);
        }

        static bool AntigravityExists(string path)
        {
#if UNITY_EDITOR_OSX
            return System.IO.Directory.Exists(path);
#else
            return new FileInfo(path).Exists;
#endif
        }
    }
}
