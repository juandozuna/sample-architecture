using System;
using Triplex.ProtoDomainPrimitives.Exceptions;
using Triplex.ProtoDomainPrimitives.Numerics;
using Triplex.ProtoDomainPrimitives.Strings;
using Wepsys.Core;

namespace Wepsys.Polux.Sample.Core.Contact
{
    /// <summary>
    /// Contact Last Name
    /// </summary>
    public sealed class LastName : AbstractSimpleStringValue
    {
        /// <summary>
        ///
        /// </summary>
        public const int MinLength = 4;

        /// <summary>
        ///
        /// </summary>
        public const int MaxLength = 30;

        protected override ConfigurableString InnerValue { get; }

        private static readonly Message GenericMessage = new("Invalid LastName.");

        /// <summary>
        ///
        /// </summary>
        /// <param name="rawName"></param>
        public LastName(in string rawName)
        {
            StringLengthRange LengthRange =
                new(new StringLength(MinLength), new StringLength(MaxLength));

            ConfigurableString.Builder builder = new ConfigurableString.Builder(GenericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
                .WithLengthRange(LengthRange, GenericMessage, GenericMessage);

            InnerValue = builder.Build(rawName, rn => ThrowIfContainsControlCharacters(rn, GenericMessage.Value));
        }
    }
}