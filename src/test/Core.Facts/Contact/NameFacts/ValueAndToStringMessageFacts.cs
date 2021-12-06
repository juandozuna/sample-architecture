using Wepsys.Core.Facts;
using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Core.Facts.Contact.NameFacts
{
    internal sealed class ValueAndToStringMessageFacts : AbstractPureStringWrapperTestFixture<Name>
    {
        protected override (Name subject, string rawValue) CreateSubject()
        {
            const string rawName = "New Employee Onboarding";

            return (new Name(rawName), rawName);
        }
    }
}