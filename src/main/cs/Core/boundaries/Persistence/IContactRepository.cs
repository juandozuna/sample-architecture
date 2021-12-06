using Wepsys.Polux.Sample.Core.Contact;

namespace Wepsys.Polux.Sample.Core.boundaries.Persistence
{
    /// <summary>
    /// 
    /// </summary>
    public interface IContactRepository
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="contact"></param>
        /// <returns></returns>
        Id Persist(in Contact.Contact contact);
    }
}