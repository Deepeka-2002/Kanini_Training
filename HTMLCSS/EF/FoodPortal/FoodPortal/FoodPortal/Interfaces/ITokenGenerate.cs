using FoodPortal.Models.DTO;

namespace FoodPortal.Interfaces
{
    public interface ITokenGenerate
    {
        public string GenerateToken(UserDTO user);

    }
}
