using Domain.Interfaces;
using Domain.Models;

namespace App.Domain.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public (bool isValid, double heightInInches) ConvertHeightTextToInches(string heightText)
        {
            var feetMarkerLocation = heightText.IndexOf('\'');
            var inchesMarkerLocation = heightText.IndexOf('"');

            if (feetMarkerLocation < 0 || inchesMarkerLocation < 0
                || inchesMarkerLocation < feetMarkerLocation)
                return (false, 0);

            var heightParts = heightText.Split(new char[] { '\'', '"' });

            if (int.TryParse(heightParts[0], out int feet) == false
                || double.TryParse(heightParts[1], out double inches) == false)
                return (false, 0);

            var heightInInches = (feet * 12) + inches;
            return (true, heightInInches);
        }

        public PersonModel Create(string firstName, string lastName, string heightText)
        {
            if(!ValidateName(firstName))
                throw new ArgumentException("First name is not valid.");

            if (!ValidateName(lastName))
                throw new ArgumentException("Last name is not valid.");

            var (isValid, heightInInches) = ConvertHeightTextToInches(heightText);

            if (!isValid)
                throw new ArgumentException("Height is not valid.");

            return new PersonModel
            {
                FirstName = firstName,
                LastName = lastName,
                HeightInInches = heightInInches
            };
        }

        public IEnumerable<PersonModel> GetAll()
        {
            var sql = "select * from Person";
            return _personRepository.GetAll(sql);
        }

        public void Save(PersonModel person)
        {
            throw new NotImplementedException();
        }

        public void Update(PersonModel person)
        {
            throw new NotImplementedException();
        }

        private static bool ValidateName(string name)
        {
            if(name.Length < 2)
                return false;

            var invalidCharacters = "`~!@#$%^&*()_+=0123456789<>,.?/\\|{}[]'\"".ToCharArray();
            if (name.IndexOfAny(invalidCharacters) >= 0)
                return false;

            return true;
        }
    }
}
