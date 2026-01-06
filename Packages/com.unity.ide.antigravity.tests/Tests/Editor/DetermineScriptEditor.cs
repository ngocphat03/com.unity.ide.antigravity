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
        [TestCase("/Applications/Antigravity.app")]
        [UnityPlatform(RuntimePlatform.OSXEditor)]
        public void OSXPathDiscovery(string path)
        {
            Discover(path);
        }

        [TestCase(@"C:\Program Files\Google\Antigravity\bin\antigravity.cmd")]
        [TestCase(@"C:\Program Files\Google\Antigravity\Antigravity.exe")]
        [TestCase(@"C:\Users\Username\AppData\Local\Programs\Google\Antigravity\bin\antigravity.cmd")]
        [TestCase(@"C:\Users\Username\AppData\Local\Programs\Google\Antigravity\Antigravity.exe")]
        [UnityPlatform(RuntimePlatform.WindowsEditor)]
        public void WindowsPathDiscovery(string path)
        {
            Discover(path);
        }

        [TestCase("/usr/bin/antigravity")]
        [TestCase("/usr/local/bin/antigravity")]
        [TestCase("/snap/bin/antigravity")]
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
                    Name = "Antigravity"
                }
            });

            var editor = new AntigravityScriptEditor(discovery.Object, generator.Object);

            editor.TryGetInstallationForPath(path, out var installation);

            Assert.AreEqual(path, installation.Path);
        }
    }
}

