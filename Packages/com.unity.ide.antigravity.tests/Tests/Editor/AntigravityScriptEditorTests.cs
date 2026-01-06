using Moq;
using NUnit.Framework;
using Unity.CodeEditor;

namespace AntigravityEditor.Tests
{
    [TestFixture]
    public class AntigravityScriptEditorTests
    {
        IExternalCodeEditor editor;

        [SetUp]
        public void OneTimeSetUp()
        {
            var discovery = new Mock<IDiscovery>();
            var generator = new Mock<IGenerator>();
            editor = new AntigravityScriptEditor(discovery.Object, generator.Object);
        }

        [TearDown]
        public void Dispose()
        {
            CodeEditor.Unregister(editor);
        }

        [Test]
        public void WillNotOpenUnknownExtensions()
        {
            Assert.False(editor.OpenProject("/file/with/unknown.extension", 1, 1));
        }
    }
}
