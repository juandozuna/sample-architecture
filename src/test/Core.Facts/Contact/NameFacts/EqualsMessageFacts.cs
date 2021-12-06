using Wepsys.Core.Facts;
using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Core.Facts.Contact.NameFacts
{
    internal sealed class EqualsMessageFacts : AbstractEquatableTestFixture<Name>
    {
        protected override Context BuildContext()
        {
            const string rawName = "Onboarding";
            Name subject = new(rawName);

            return new AbstractEquatableTestFixture<Name>.Context(
                subject: subject, 
                subjectCopy: new Name(rawName),
                other: new Name("Sales"),
                otherSemanticallyEqualsToSubject: new Name("oNbOaRdInG"));
        }
    }
}