using HallOfFame.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace HallOfFame.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationContext db;
        public PersonController(ApplicationContext context)
        {
            db = context;   
        }

        [HttpGet]
        public IActionResult GetPersons()
        {
            var persons = db.Persons.Include(person => person.Skills).ToArray();

            if (persons.Length == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK, persons);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonsWithId(long id)
        {
            var person = db.Persons.AsNoTracking()
                                    .Where(s => s.Id == id).Include(person => person.Skills);

            if (person.Count() == 0)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK, person);
        }

        [HttpPost]
        public IActionResult PostPerson(Person person)
        {

            db.Persons.Add(person);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK, person);
        }

        [HttpPut("{id}")]
        public IActionResult PutPerson(long id, Person updatedPerson)
        {
            var person = db.Persons.FirstOrDefault(s => s.Id == id);

            if (id != updatedPerson.Id)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            db.Entry(person).CurrentValues.SetValues(updatedPerson);

            var availableSkills = db.Skills.AsNoTracking()
                                           .Where(s => s.PersonId == id)
                                           .ToList();

            foreach (var availableSkill in availableSkills)
            {
                var skill = updatedPerson.Skills.SingleOrDefault(s => s.Name == availableSkill.Name);

                if (skill != null)
                {
                    db.Entry(availableSkill).CurrentValues.SetValues(skill);
                }
                else
                {
                    db.Remove(availableSkill);
                }
            }

            foreach (var newSkill in updatedPerson.Skills)
            {
                if (availableSkills.All(s => s.Name != newSkill.Name))
                {
                    person.Skills.Add(newSkill);
                }
            }

            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(long id)
        {
            var person = db.Persons.FirstOrDefault(s => s.Id == id);

            if (person == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            db.Persons.Remove(person);
            db.SaveChanges();

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}