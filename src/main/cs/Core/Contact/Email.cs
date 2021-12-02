using System;
using System.Text.RegularExpressions;
using Triplex.ProtoDomainPrimitives.Exceptions;
using Triplex.ProtoDomainPrimitives.Numerics;
using Triplex.ProtoDomainPrimitives.Strings;
using Wepsys.Core;

namespace Wepsys.Polux.Sample.Core.Contact
{
    /// <summary>
    /// Contact email
    /// </summary>
    public sealed class Email : AbstractSimpleStringValue
    {
        /// <summary>
        ///
        /// </summary>
        public const int MinLength = 5;

        /// <summary>
        ///
        /// </summary>
        public const int MaxLength = 256;

        protected override ConfigurableString InnerValue { get; }

        private static readonly Message GenericMessage = new("Invalid name.");

        private static readonly Regex ValidEmailRegex = new(
            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$"
            ,
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        ///
        /// </summary>
        /// <param name="rawName"></param>
        public Email(in string rawName)
        {
            StringLengthRange LengthRange =
                new(new StringLength(MinLength), new StringLength(MaxLength));

            ConfigurableString.Builder builder = new ConfigurableString.Builder(GenericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithValidFormatRegex(ValidEmailRegex)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase)
                .WithLengthRange(LengthRange, GenericMessage, GenericMessage);

            InnerValue = builder.Build(rawName, rn => ThrowIfContainsControlCharacters(rn, GenericMessage.Value));
        }
    }
}