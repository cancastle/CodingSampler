using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ContactsWebAPI.Models;

namespace ContactsWebAPI.Controllers
{
    public class ContactsController : ApiController
    {
        public List<Contact> Get()
        {
            var repo = new FakeContactDatabase();
            return repo.GetAll();
        }

        public Contact Get(int id)
        {
            var repo = new FakeContactDatabase();
            return repo.GetById(id);
        }

        public HttpResponseMessage Post(Contact contact)
        {
            var repo = new FakeContactDatabase();
            repo.Add(contact);

            var response = Request.CreateResponse(HttpStatusCode.Created, contact);

            string uri = Url.Link("DefaultApi", new {id = contact.ContactID});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public HttpResponseMessage Put(Contact contact)
        {
            var repo = new FakeContactDatabase();
            repo.Edit(contact);

            var response = Request.CreateResponse(HttpStatusCode.OK, contact);

            string uri = Url.Link("DefaultApi", new {id = contact.ContactID});
            response.Headers.Location = new Uri(uri);

            return response;
        }

        public HttpResponseMessage Delete(int id)
        {
            var repo = new FakeContactDatabase();
            repo.Delete(id);

            var response = Request.CreateResponse(HttpStatusCode.OK);

            return response;
        }

    }
}
