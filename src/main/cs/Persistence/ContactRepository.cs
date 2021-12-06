using Wepsys.Polux.Sample.Core.boundaries.Persistence;
using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Persistence
{
    /// <summary>
    ///
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        private readonly SampleContext _context;

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        public ContactRepository(SampleContext context)
        {
            _context = context;
        }

        Id IContactRepository.Persist(in Contact contact)
        {
            var persistenceContact = new models.Contact { Id = contact.Id.Value, Name = contact.Name.Value };
             _context.Contacts.Add(persistenceContact);

             _context.SaveChanges();

             return Id.From(persistenceContact.Id);
        }
    }
}