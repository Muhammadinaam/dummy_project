using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DummyProject.Inaam;
using DummyProject.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DummyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartyController : ControllerBase
    {
        public MyDbContext Context { get; set; }
        

        public InaamForm<Party> PartyForm { get; set; }

        public PartyController(MyDbContext context)
        {
            Context = context;

            PartyForm = new InaamForm<Party>(Context);
            PartyForm.InaamFormOptions = new InaamFormOptions
            {
                ShowSubmitButton = true,
            };
            PartyForm.InaamFormElements = new List<InaamFormElement>
            {
                new InaamFormElement
                {
                    ElementType = "input_text",
                    Name = "name",
                    ModelPropertyName = "Name",
                    Label = "Name",
                    Validations = new string[]{ Validations.Required(), Validations.MinLength(3), Validations.MaxLength(10)}
                },
                new InaamFormElement
                {
                    ElementType = "input_text",
                    Name = "email",
                    ModelPropertyName = "Email",
                    Label = "Email",
                    Placeholder = "abc@abc.com",
                    Validations = new string[]{ Validations.Required(), Validations.Email() }
                }
            };
        }

        [HttpGet("get-schema-and-options")]
        public IActionResult GetSchema()
        {
            return Ok(PartyForm.GetSchemaAndOptions());
        }

        [HttpPost("add")]
        public IActionResult Add(dynamic data)
        {

            var addedObject = PartyForm.Insert(data);
            return Ok(addedObject);
        }
    }
}