﻿namespace TestStack.ConventionTests.Conventions
{
    using System.Linq;
    using TestStack.ConventionTests.Helpers;
    using TestStack.ConventionTests.Internal;

    public class AllClassesHaveDefaultConstructor : IConvention<Types>
    {
        public AllClassesHaveDefaultConstructor()
        {
            HeaderMessage = "The following types do not have default constructor";
        }

        public string HeaderMessage { get; set; }

        public ConventionResult Execute(Types data)
        {
            var invalid = data.ApplicableTypes.Where(t => t.HasDefaultConstructor() == false);
            return ConventionResult.For(invalid, HeaderMessage, (t, m) => m.AppendLine("\t" + t));
        }
    }
}