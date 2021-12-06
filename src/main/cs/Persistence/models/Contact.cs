using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wepsys.Polux.Sample.Persistence.models
{
    /// <summary>
    ///
    /// </summary>
    public sealed class Contact
    {
        /// <summary>
        /// ID
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [Required]
        [MaxLength(Core.Contact.Name.MaxLength)]
        [MinLength(Core.Contact.Name.MinLength)]
        public string Name { get; set; }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public Core.Contact.Contact ToEntity()
        {
            var contact = new Core.Contact.Contact.Builder()
                .WithId(Core.Contact.Id.From(Id))
                .WithName(new Core.Contact.Name(Name))
                .Build();

            return contact;
        }
    }
}