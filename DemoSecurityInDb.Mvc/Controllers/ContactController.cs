using DemoSecurityInDb.Mvc.Models.Entities;
using DemoSecurityInDb.Mvc.Models.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tools.Connections.Database;

namespace DemoSecurityInDb.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly Connection _connection;

        public ContactController(Connection connection)
        {
            _connection = connection;
        }

        // GET: ContactController
        public ActionResult Index()
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email] FROM [AppUserSchema].[V_Contact];", false);
            IEnumerable<Contact> contacts = _connection.ExecuteReader(command, dr => new Contact() { Id = (int)dr["Id"], LastName = (string)dr["LastName"], FirstName = (string)dr["FirstName"], Email = (string)dr["Email"] });
            return View(contacts);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateContactForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Command command = new Command("[AppUserSchema].[CSP_AddContact]", true);
            command.AddParameter("LastName", form.LastName);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            _connection.ExecuteNonQuery(command);

            return RedirectToAction("Index");
        }

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            Command command = new Command("SELECT [Id], [LastName], [FirstName], [Email] FROM [AppUserSchema].[V_Contact] WHERE Id = @Id;", false);
            command.AddParameter("Id", id);
            Contact contact = _connection.ExecuteReader(command, dr => new Contact() { Id = (int)dr["Id"], LastName = (string)dr["LastName"], FirstName = (string)dr["FirstName"], Email = (string)dr["Email"] }).SingleOrDefault();

            if(contact is null)
                return RedirectToAction("Index");

            return View(new EditContactForm() { Id = contact.Id, LastName = contact.LastName, FirstName = contact.FirstName, Email = contact.Email });
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditContactForm form)
        {
            if (!ModelState.IsValid)
                return View(form);

            Command command = new Command("[AppUserSchema].[CSP_UpdateContact]", true);
            command.AddParameter("Id", id);
            command.AddParameter("LastName", form.LastName);
            command.AddParameter("FirstName", form.FirstName);
            command.AddParameter("Email", form.Email);
            _connection.ExecuteNonQuery(command);

            return RedirectToAction("Index");
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            Command command = new Command("[AppUserSchema].[CSP_DeleteContact]", true);
            command.AddParameter("Id", id);
            _connection.ExecuteNonQuery(command);
            return RedirectToAction("Index");
        }
    }
}
