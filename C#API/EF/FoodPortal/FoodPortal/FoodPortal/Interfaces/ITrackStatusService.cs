using FoodPortal.Models;
using FoodPortal.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FoodPortal.Interfaces
{
    public interface ITrackStatusService
    {
        Task<TrackStatus> Add_TrackStatus(TrackStatus TrackStatus);
        Task<TrackStatus?> Delete_TrackStatus(IdDTO idDTO);
        Task<TrackStatus?> Update_TrackStatus(TrackStatus TrackStatus);
        Task<TrackStatus?> View_TrackStatus(IdDTO idDTO);
        Task<List<TrackStatus>?> View_All_TrackStatuss();
        Task<List<TrackDTO>> Get_Order_Summary(string id);
    }
}
