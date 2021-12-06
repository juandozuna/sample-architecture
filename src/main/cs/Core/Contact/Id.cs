using System;
using Wepsys.Core;

namespace Wepsys.Polux.Sample.Core.Contact
{
    /// <summary>
    /// Represents Contact IDs
    /// </summary>
    public sealed class Id : AbstractGuidBasedIdPrimitive
    {
        /// <summary>
        /// Creates a new instance with a random <see cref="Guid"/>.
        /// </summary>
        /// <returns></returns>
        public static Id Generate() => new();

        /// <summary>
        /// Shortcut for constructor <see cref="Id"/>.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <returns></returns>
        public static Id From(in Guid rawValue) => new(rawValue);

        /// <summary>
        /// Shortcut for constructor <see cref="Id"/>.
        /// </summary>
        /// <param name="rawValue"></param>
        /// <returns></returns>
        public static Id From(in string rawValue) => new(rawValue);

        /// <summary>
        /// Creates a valid instance of an ID
        /// </summary>
        /// <param name="rawValue"></param>
        public Id(in Guid rawValue) : base(rawValue) { }

        /// <summary>
        /// Creates a valid instance of an id
        /// </summary>
        /// <param name="rawValue"></param>
        public Id(in string rawValue) : base(rawValue) { }

        /// <summary>
        /// Creates a new value
        /// </summary>
        private Id() : base(Guid.NewGuid()) { }
    }
}