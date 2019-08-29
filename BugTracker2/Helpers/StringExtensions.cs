using System;

namespace BugTracker2.Helpers
{
    public static class StringExtensions
    {
        public static string SomeCoolNewStringFeature(this String myString)
        {
            return "My Feature was hit";
        }

        public static void TestStringExtension()
        {
            var newString = "Foo";
            var message = newString.SomeCoolNewStringFeature();
        }
    }
}