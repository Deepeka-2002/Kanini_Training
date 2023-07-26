using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface IAllergyDetailService
    {
        Task<List<AllergyDetail>> Add_AllergyDetail(List<AllergyDetail> AllergyDetail);
        Task<AllergyDetail?> Delete_AllergyDetail(IdDTO idDTO);
        Task<AllergyDetail?> Update_AllergyDetail(AllergyDetail AllergyDetail);

        Task<AllergyDetail?> View_AllergyDetail(IdDTO idDTO);
        Task<List<AllergyDetail>?> View_All_AllergyDetails();


    }
}
