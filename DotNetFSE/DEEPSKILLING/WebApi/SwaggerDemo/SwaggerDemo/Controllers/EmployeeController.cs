using Microsoft.AspNetCore.Mvc;
using SwaggerDemo.Models;

namespace SwaggerDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="John",
                    Salary=50000,
                    Permanent=true,
                    DateOfBirth=new DateTime(1999,5,20),

                    Department=new Department
                    {
                        Id=101,
                        Name="IT"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill{Id=1,Name="C#"},
                        new Skill{Id=2,Name="SQL"}
                    }
                },

                new Employee
                {
                    Id=2,
                    Name="David",
                    Salary=60000,
                    Permanent=false,
                    DateOfBirth=new DateTime(2000,8,15),

                    Department=new Department
                    {
                        Id=102,
                        Name="HR"
                    },

                    Skills=new List<Skill>
                    {
                        new Skill{Id=3,Name="Java"},
                        new Skill{Id=4,Name="Python"}
                    }
                }
            };
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult AddEmployee([FromBody] Employee employee)
        {
            employees.Add(employee);
            return Ok(employee);
        }
    }
}