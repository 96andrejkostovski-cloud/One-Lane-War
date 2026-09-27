using System;
using System.IO;
using OneLaneWar.Tests;
internal static class PureTestRunner
{
    static int Main(string[] args)
    {
        ModelFixtures.Read = name => File.ReadAllBytes(Path.Combine(args[0], name));
        int passed = 0, failed = 0;
        foreach (var fixture in ModelFixtures.Cases)
        {
            try { fixture.Value(); Console.WriteLine("PASS " + fixture.Key); passed++; }
            catch (Exception ex) { Console.WriteLine("FAIL " + fixture.Key + ": " + ex); failed++; }
        }
        Console.WriteLine("RESULT passed=" + passed + " failed=" + failed + " total=" + (passed + failed));
        return failed == 0 ? 0 : 1;
    }
}
