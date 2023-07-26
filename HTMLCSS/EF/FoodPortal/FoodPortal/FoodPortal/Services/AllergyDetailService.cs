using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class AllergyDetailService: IAllergyDetailService
    {
        private readonly ICrud<AllergyDetail, IdDTO> _AllergyDetailRepo;

        public AllergyDetailService(ICrud<AllergyDetail, IdDTO> AllergyDetailRepo)
        {
            _AllergyDetailRepo = AllergyDetailRepo;
        }

        public async Task<List<AllergyDetail>> Add_AllergyDetail(List<AllergyDetail> AllergyDetail)
        {

            List<AllergyDetail> addedAllergyDetail = new List<AllergyDetail>();

            var AllergyDetails = await _AllergyDetailRepo.GetAll();

            foreach (var allergyDetail in AllergyDetail)
            {

                Console.WriteLine(allergyDetail);

                
                var myAllergyDetail = await _AllergyDetailRepo.Add(allergyDetail);

                if (myAllergyDetail != null)
                {
                    addedAllergyDetail.Add(myAllergyDetail);
                }
               
            }
            return addedAllergyDetail;

        }

        public async Task<List<AllergyDetail>?> View_All_AllergyDetails()

        {
            var AllergyDetails = await _AllergyDetailRepo.GetAll();
            /*if (AllergyDetails != null)*/
                return AllergyDetails;
            /*return null;*/
        }

        //Get a Particular AllergyDetail
        public async Task<AllergyDetail?> View_AllergyDetail(IdDTO idDTO)
        {
            var AllergyDetail = await _AllergyDetailRepo.GetValue(idDTO);
           /* if (AllergyDetail != null)*/
                return AllergyDetail;
            /*return null;*/
        }

        //Delete a AllergyDetail
        public async Task<AllergyDetail?> Delete_AllergyDetail(IdDTO idDTO)

        {
            var AllergyDetail = await _AllergyDetailRepo.Delete(idDTO);
            /*if (AllergyDetail != null)*/
                return AllergyDetail;
            /*return null;*/
        }

        //Update a AllergyDetail
        public async Task<AllergyDetail?> Update_AllergyDetail(AllergyDetail AllergyDetail)
        {
            var myAllergyDetail = await _AllergyDetailRepo.Update(AllergyDetail);
            /*if (myAllergyDetail != null)*/
                return myAllergyDetail;
           /* return null;*/
        }
    }
}
