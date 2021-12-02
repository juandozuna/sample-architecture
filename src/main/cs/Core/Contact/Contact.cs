using Optional;
using Optional.Unsafe;
using System;
using Triplex.Validations;
using Wepsys.Core;

namespace Wepsys.Polux.Sample.Core.Contact
{
    /// <summary>
    /// Contact
    /// </summary>
    public sealed class Contact
    {
        private Contact(Builder builder)
        {
            Name = builder.NameOption.ValueOrFailure();
            LastName = builder.LastNameOption.ValueOrFailure();
            Email = builder.EmailOption;
            Phone = builder.PhoneOption;
        }

        /// <summary>
        ///
        /// </summary>
        public Name Name { get; }

        /// <summary>
        ///
        /// </summary>
        public LastName LastName { get; }

        /// <summary>
        ///
        /// </summary>
        public Option<Email> Email { get; }

        /// <summary>
        ///
        /// </summary>
        public Option<Phone> Phone { get; }

        /// <summary>
        ///
        /// </summary>
        public sealed class Builder : AbstractEntityBuilder<Contact>
        {

            internal Option<Name> NameOption { get; private set; }
            internal Option<LastName> LastNameOption { get; private set; }
            internal Option<Email> EmailOption { get; private set; }
            internal Option<Phone> PhoneOption { get; private set; }

            /// <summary>
            ///
            /// </summary>
            /// <param name="name"></param>
            /// <returns></returns>
            public Builder WithName(Name name)
                => SetProperty(() => NameOption = Arguments.NotNull(name, nameof(name)).SomeNotNull());

            /// <summary>
            ///
            /// </summary>
            /// <param name="lastName"></param>
            /// <returns></returns>
            public Builder WithLastName(LastName lastName)
                => SetProperty(() => LastNameOption = Arguments.NotNull(lastName, nameof(lastName)).SomeNotNull());

            /// <summary>
            ///
            /// </summary>
            /// <param name="email"></param>
            /// <returns></returns>
            public Builder WithEmail(Email email)
                => SetProperty(() => EmailOption = Arguments.NotNull(email, nameof(email)).SomeNotNull());

            /// <summary>
            ///
            /// </summary>
            /// <param name="phone"></param>
            /// <returns></returns>
            public Builder WithPhone(Phone phone)
                => SetProperty(() => PhoneOption = Arguments.NotNull(phone, nameof(phone)).SomeNotNull());

            /// <summary>
            ///
            /// </summary>
            /// <returns></returns>
            public override Contact DoBuild()
            {
                State.IsTrue(NameOption.HasValue, nameof(NameOption));
                State.IsTrue(LastNameOption.HasValue, nameof(LastNameOption));

                return new Contact(this);
            }

            /// <summary>
            /// Built message error
            /// </summary>
            protected override Option<string> AlreadyBuiltErrorMessage { get; } = "Contact already built.".SomeNotNull();

            /// <summary>
            /// Must be built
            /// </summary>
            protected override Option<string> MustBeBuiltErrorMessage { get; } = "Contact must be built.".SomeNotNull();

            private new Builder SetProperty(Action setter) => (Builder)base.SetProperty(setter);

        }
    }
}