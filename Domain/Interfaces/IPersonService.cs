using Domain.Models;

namespace Domain.Interfaces
{
    public interface IPersonService
    {
        (bool isValid, double heightInInches) ConvertHeightTextToInches(string heightText);
        PersonModel Create(string firstName, string lastName, string heightText);
        void Save(PersonModel person);
        void Update(PersonModel person);
        IEnumerable<PersonModel> GetAll();
    }
}