using Wepsys.Core.Facts;
using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Core.Facts.Contact.NameFacts
{
    internal sealed class CompareToMessageFacts : AbstractComparableTestFixture<Name>
    {
        protected override Context BuildContext()
        {
            const string rawName = "Onboarding";
            Name subject = new(rawName);
            
            return new AbstractComparableTestFixture<Name>.Context(
                lessThanSubject: new Name("Managing"),
                subject: subject, 
                subjectCopy: new Name(rawName),
                otherSemanticallyEqualsToSubject: new Name("oNbOaRdInG"),
                greatherThanSubject: new Name("Sales"),
                testRelationalOperatorsOverload: true);
        }

        protected override bool ExecuteEqualsOperator(in Name left, in Name right) => left == right;
        protected override bool ExecuteNotEqualsOperator(in Name left, in Name right) => left != right;
        protected override bool ExecuteLessThanOperator(in Name left, in Name right) => left < right;
        protected override bool ExecuteLessThanOrEqualsToOperator(in Name left, in Name right) => left <= right;
        protected override bool ExecuteGreaterThanOperator(in Name left, in Name right) => left > right;
        protected override bool ExecuteGreaterThanOrEqualsToOperator(in Name left, in Name right) => left >= right;
    }
}