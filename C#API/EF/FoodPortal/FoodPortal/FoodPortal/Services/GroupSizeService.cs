using FoodPortal.Interfaces;
using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Services
{
    public class GroupSizeService: IGroupSizeService
    {
        private readonly ICrud<GroupSize, IdDTO> _groupSizeRepo;

        public GroupSizeService(ICrud<GroupSize, IdDTO> groupSizeRepo)
        {
            _groupSizeRepo = groupSizeRepo;
        }

        public async Task<GroupSize> Add_GroupSize(GroupSize GroupSize)
        {
            var GroupSizes = await _groupSizeRepo.GetAll();
            GroupSize empty = new GroupSize();

            var newGroupSize = GroupSizes.SingleOrDefault(h => h.Id == GroupSize.Id);
            if (newGroupSize == null)
            {
                var myGroupSize = await _groupSizeRepo.Add(GroupSize);
                if (myGroupSize != null)
                    return myGroupSize;
            }
            return empty;
        }

        public async Task<List<GroupSize>?> View_All_GroupSizes()
        {
            var GroupSizes = await _groupSizeRepo.GetAll();
            /*if (GroupSizes != null)*/
                return GroupSizes;
           /* return null;*/
        }

        //Get a Particular GroupSize
        public async Task<GroupSize?> View_GroupSize(IdDTO idDTO)
        {
            var GroupSize = await _groupSizeRepo.GetValue(idDTO);
           /* if (GroupSize != null)*/
                return GroupSize;
           /* return null;*/
        }

        //Delete a GroupSize
        public async Task<GroupSize?> Delete_GroupSize(IdDTO idDTO)
        {
            var GroupSize = await _groupSizeRepo.Delete(idDTO);
           /* if (GroupSize != null)*/
                return GroupSize;
            /*return null;*/
        }

        //Update a GroupSize
        public async Task<GroupSize?> Update_GroupSize(GroupSize GroupSize)
        {
            var myGroupSize = await _groupSizeRepo.Update(GroupSize);
            /*if (myGroupSize != null)*/
                return myGroupSize;
            /*return null;*/
        }
    }
}
