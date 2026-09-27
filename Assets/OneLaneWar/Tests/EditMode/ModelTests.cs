using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using OneLaneWar.Presentation;
using UnityEngine;

namespace OneLaneWar.Tests
{
    public sealed class ModelTests
    {
        static IEnumerable<string> Names { get { return ModelFixtures.Cases.Keys; } }
        [OneTimeSetUp] public void Setup()
        {
            string source = Path.Combine(Path.GetDirectoryName(Application.dataPath), "One_Lane_War_Codex_Source_v1.0.0");
            ModelFixtures.Read = name => File.ReadAllBytes(Path.Combine(source, name));
        }
        [TestCaseSource(nameof(Names))] public void ModelFixture(string name) { ModelFixtures.Cases[name](); }
        [Test] public void GeneratedContentMatchesSealedSource() { Assert.AreEqual(Content.ManifestHash, ContentResources.Load().SourceHash); }
    }
}
