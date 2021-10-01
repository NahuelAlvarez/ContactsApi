using ContactsApi.Context;
using ContactsApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ContactsApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContactsApiController : ControllerBase
    {
        private readonly DataContext _context;

        public ContactsApiController(DataContext context)
        {
            _context = context;
        }


        [HttpGet("getContactsAllPagination")]
        public async Task<ActionResult<PaginadorGenerico<Contact>>> GetContacsAll(string buscar,
                                                                                 string orden = "Id",
                                                                                 string tipo_orden = "ASC",
                                                                                 int pagina = 1,
                                                                                 int registros_por_pagina = 10)
        {
            List<Contact> _Contacts;
            PaginadorGenerico<Contact> _PaginadorContacts;
            _Contacts = await _context.Contacts.ToListAsync();

            if (!string.IsNullOrEmpty(buscar))
            {
                foreach (var item in buscar.Split(new char[] { ' ' },
                         StringSplitOptions.RemoveEmptyEntries))
                {
                    _Contacts = _Contacts.Where(x => x.FirstName.Contains(item) ||
                                                  x.LastName.Contains(item) ||
                                                  x.Company.Contains(item) ||
                                                  x.PhoneNumber.Contains(item) ||
                                                  x.Email.Contains(item))
                                                  .ToList();
                }
            }

            switch (orden)
            {
                case "Id":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.Id).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.Id).ToList();
                    break;

                case "FirstName":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.FirstName).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.FirstName).ToList();
                    break;

                case "LastName":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.LastName).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.LastName).ToList();
                    break;

                case "Company":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.Company).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.Company).ToList();
                    break;

                case "Email":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.Email).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.Email).ToList();
                    break;

                case "PhoneNumber":
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.PhoneNumber).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.PhoneNumber).ToList();
                    break;

                default:
                    if (tipo_orden.ToLower() == "desc")
                        _Contacts = _Contacts.OrderByDescending(x => x.Id).ToList();
                    else if (tipo_orden.ToLower() == "asc")
                        _Contacts = _Contacts.OrderBy(x => x.Id).ToList();
                    break;
            }

            int _TotalRegistros = 0;
            int _TotalPaginas = 0;
            _TotalRegistros = _Contacts.Count();

            _Contacts = _Contacts.Skip((pagina - 1) * registros_por_pagina)
                                             .Take(registros_por_pagina)
                                             .ToList();

            _TotalPaginas = (int)Math.Ceiling((double)_TotalRegistros / registros_por_pagina);

            _PaginadorContacts = new PaginadorGenerico<Contact>()
            {
                RegistrosPorPagina = registros_por_pagina,
                TotalRegistros = _TotalRegistros,
                TotalPaginas = _TotalPaginas,
                PaginaActual = pagina,
                BusquedaActual = buscar,
                OrdenActual = orden,
                TipoOrdenActual = tipo_orden,
                Resultado = _Contacts
            };

            return Ok(_PaginadorContacts);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContacts()
        {
            var response = await _context.Contacts.ToListAsync();
            return Ok(response);
        }

        [HttpGet("getById")]
        public async Task<ActionResult<Contact>> GetContactById(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null || ContactExists(id) == false)
            {
                return NotFound();
            }

            return contact;
        }

        [HttpGet("getForCompany")]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContactFromCompany(string company)
        {
            var result = await _context.Contacts.Where(c => c.Company.Equals(company)).ToListAsync();
            if (result.Count == 0)
                return NotFound();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(Guid id, Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Contact>> CreateContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContactById", new { id = contact.Id }, contact);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteContact(Guid id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return Ok(contact);
        }

        private bool ContactExists(Guid id)
        {
            return _context.Contacts.Any(e => e.Id == id);
        }
    }
}
