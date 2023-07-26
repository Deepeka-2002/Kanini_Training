using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Exceptions;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace FoodPortal.Repos
{
    public class GroupSizeRepo : ICrud<GroupSize, IdDTO>
    {
        private readonly FoodPortalContext _context;

        public GroupSizeRepo(FoodPortalContext context)
        {
            _context = context;
        }
        public async Task<GroupSize?> Add(GroupSize item)
        {
            try
            {
                var newGroupSize = _context.GroupSizes.SingleOrDefault(h => h.Id == item.Id);
                if (newGroupSize == null)
                {
                    await _context.GroupSizes.AddAsync(item);
                    await _context.SaveChangesAsync();
                    return item;
                }
                return null;
            }
            catch (SqlException se)
            {
                throw new InvalidSqlException(se.Message);
            }
        }

        public async Task<GroupSize?> Delete(IdDTO item)
        {
            try
            {
                /*var rooms = _context.Rooms.ToList();
                var myRooms = rooms.Where(r => r.H_id == item.ID);
                foreach (var value in myRooms)
                {
                    _context.Rooms.Remove(value);
                    _context.SaveChanges();
                }*/
                var GroupSizes = await _context.GroupSizes.ToListAsync();
                var myGroupSize = GroupSizes.FirstOrDefault(h => h.Id == item.IdInt);
                if (myGroupSize != null)
                {
                    _context.GroupSizes.Remove(myGroupSize);
                    await _context.SaveChangesAsync();
                    return myGroupSize;
                }
                else
                    return null;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
        }

        public async Task<List<GroupSize>?> GetAll()
        {
            try
            {
                var GroupSizes = await _context.GroupSizes.ToListAsync();
                if (GroupSizes != null)
                    return GroupSizes;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<GroupSize?> GetValue(IdDTO item)
        {
            try
            {
                var GroupSizes = await _context.GroupSizes.ToListAsync();
                var GroupSize = GroupSizes.SingleOrDefault(h => h.Id == item.IdInt);
                if (GroupSize != null)
                    return GroupSize;
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }

        public async Task<GroupSize?> Update(GroupSize item)
        {
            try
            {
                var GroupSizes = await _context.GroupSizes.ToListAsync();
                var GroupSize = GroupSizes.SingleOrDefault(h => h.Id == item.Id);
                if (GroupSize != null)
                {
                    GroupSize.GroupType = item.GroupType != null ? item.GroupType : GroupSize.GroupType;
                    GroupSize.MinValue = item.MinValue != 0 ? item.MinValue : GroupSize.MinValue;
                    GroupSize.MaxValue = item.MaxValue != 0 ? item.MaxValue : GroupSize.MaxValue;

                    _context.GroupSizes.Update(GroupSize);
                    await _context.SaveChangesAsync();
                    return GroupSize;
                }
            }
            catch (SqlException ex)
            {
                throw new InvalidSqlException(ex.Message);
            }
            return null;
        }
    }
}
