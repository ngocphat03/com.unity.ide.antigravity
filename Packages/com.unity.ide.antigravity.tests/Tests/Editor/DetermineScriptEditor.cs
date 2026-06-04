using NUnit.Framework;
using Moq;
using UnityEngine;
using UnityEngine.TestTools;
using Unity.CodeEditor;

namespace AntigravityEditor.Tests
{
    [TestFixture]
    class DetermineScriptEditor
    {
        [TestCase("/Applications/Antigravity IDE.app")]
        [UnityPlatform(RuntimePlatform.OSXEditor)]
        public void OSXPathDiscovery(string path)
        {
            Discover(path);
        }

        [TestCase(@"C:\Program Files\Google\Antigravity IDE\bin\antigravity-ide.cmd")]
        [TestCase(@"C:\Program Files\Google\Antigravity IDE\Antigravity IDE.exe")]
        [TestCase(@"C:\Users\Username\AppData\Local\Programs\Google\Antigravity IDE\bin\antigravity-ide.cmd")]
        [TestCase(@"C:\Users\Username\AppData\Local\Programs\Google\Antigravity IDE\Antigravity IDE.exe")]
        [UnityPlatform(RuntimePlatform.WindowsEditor)]
        public void WindowsPathDiscovery(string path)
        {
            Discover(path);
        }

        [TestCase("/usr/bin/antigravity-ide")]
        [TestCase("/usr/local/bin/antigravity-ide")]
        [TestCase("/snap/bin/antigravity-ide")]
        [UnityPlatform(RuntimePlatform.LinuxEditor)]
        public void LinuxPathDiscovery(string path)
        {
            Discover(path);
        }

        static void Discover(string path)
        {
            var discovery = new Mock<IDiscovery>();
            var generator = new Mock<IGenerator>();

            discovery.Setup(x => x.PathCallback()).Returns(new[]
            {
                new CodeEditor.Installation
                {
                    Path = path,
                    Name = "Antigravity IDE"
                }
            });

            var editor = new AntigravityScriptEditor(discovery.Object, generator.Object);

            editor.TryGetInstallationForPath(path, out var installation);

            Assert.AreEqual(path, installation.Path);
        }

        [TestCase("/Applications/Antigravity IDE.app", "Antigravity IDE")]
        [TestCase("/Applications/Antigravity.app", "Antigravity IDE")]
        [TestCase("/usr/bin/antigravity", "Antigravity IDE")]
        [TestCase("/usr/bin/antigravity-ide", "Antigravity IDE")]
        [TestCase(@"C:\Program Files\Google\Antigravity IDE\Antigravity IDE.exe", "Antigravity IDE")]
        [TestCase(@"C:\Program Files\Google\Antigravity\Antigravity.exe", "Antigravity IDE")]
        public void VerifyEditorNameMapping(string path, string expectedName)
        {
            Assert.AreEqual(expectedName, AntigravityDiscovery.GetEditorName(path));
        }
    }
}

