using System;
using System.Text.RegularExpressions;
using Triplex.ProtoDomainPrimitives.Exceptions;
using Triplex.ProtoDomainPrimitives.Numerics;
using Triplex.ProtoDomainPrimitives.Strings;
using Wepsys.Core;

namespace Wepsys.Polux.Sample.Core.Contact
{
    /// <summary>
    /// Contact Phone
    /// </summary>
    public sealed class Phone : AbstractSimpleStringValue
    {
        protected override ConfigurableString InnerValue { get; }

        private static readonly Message GenericMessage = new("Invalid name.");

        private static readonly Regex ValidEmailRegex = new(
            @"^[+]*[(]{0,1}[0-9]{1,4}[)]{0,1}[-\s\./0-9]*$"
            ,
            RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);

        /// <summary>
        ///
        /// </summary>
        /// <param name="rawName"></param>
        public Phone(in string rawName)
        {
            ConfigurableString.Builder builder = new ConfigurableString.Builder(GenericMessage, useSingleMessage: true)
                .WithRequiresTrimmed(true)
                .WithValidFormatRegex(ValidEmailRegex)
                .WithComparisonStrategy(StringComparison.OrdinalIgnoreCase);

            InnerValue = builder.Build(rawName, rn => ThrowIfContainsControlCharacters(rn, GenericMessage.Value));
        }
    }
}