using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactsWebAPI.Models
{
    public class FakeContactDatabase
    {
        private static List<Contact> _contacts = new List<Contact>();

        static FakeContactDatabase()
        {
            _contacts.AddRange(new[]
            {
                new Contact() {ContactID = 1, Name = "Jenny", PhoneNumber = "867-5309"},
                new Contact() {ContactID = 2, Name = "Dave", PhoneNumber = "321-4567"}
            });
        }

        public List<Contact> GetAll()
        {
            return _contacts;
        }

        public void Add(Contact contact)
        {
            if (_contacts.Any())
            {
                contact.ContactID = _contacts.Max(c => c.ContactID) + 1;
            }
            else
            {
                contact.ContactID = 1;
            }
            _contacts.Add(contact);
        }

        public void Delete(int id)
        {
            _contacts.RemoveAll(c => c.ContactID == id);
        }

        public void Edit(Contact contact)
        {
            Delete(contact.ContactID);
            _contacts.Add(contact);
        }

        public Contact GetById(int id)
        {
            return _contacts.Find(c => c.ContactID == id);
        }
    }
}