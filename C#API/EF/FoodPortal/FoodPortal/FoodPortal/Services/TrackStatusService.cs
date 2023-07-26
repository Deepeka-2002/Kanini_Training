using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

namespace FoodPortal.Services
{
    public class TrackStatusService: ITrackStatusService
    {
        private readonly ICrud<TrackStatus, IdDTO> _trackStatusRepo;
        private readonly ICrud<Order, IdDTO> _orderRepo;
        private readonly ICrud<TimeSlot, IdDTO> _timeSlotRepo;
        private readonly ICrud<User, UserDTO> _userRepo;
        private readonly ICrud<AddOnsDetail, IdDTO> _addOnsDetailRepo;
        private readonly ICrud<PlateSize, IdDTO> _plateSizeRepo;
        private readonly ICrud<DeliveryOption, IdDTO> _deliveryOptionRepo;
        private readonly ICrud<GroupSize, IdDTO> _groupSizeRepo;
        private readonly ICrud<AddOnsMaster, IdDTO> _AddOnsMasterRepo;
        private readonly ICrud<AllergyDetail, IdDTO> _AllergyDetailRepo;
        private readonly ICrud<FoodTypeCount, IdDTO> _FoodTypeCountRepo;
        private readonly ICrud<StdFoodOrderDetail, IdDTO> _stdFoodOrderDetailRepo;
        private readonly ICrud<StdProduct, IdDTO> _StdProductRepo;
        private readonly ICrud<AllergyMaster, IdDTO> _AllergyMasterRepo;










        public TrackStatusService(ICrud<TrackStatus, IdDTO> trackStatusRepo, ICrud<User, UserDTO> userRepo, ICrud<AddOnsDetail, IdDTO> addOnsDetailRepo,
            ICrud<Order, IdDTO> orderRepo, ICrud<TimeSlot, IdDTO> timeSlotRepo, ICrud<PlateSize, IdDTO> plateSizeRepo,
            ICrud<DeliveryOption, IdDTO> deliveryOptionRepo, ICrud<GroupSize, IdDTO> groupSizeRepo,
            ICrud<AddOnsMaster, IdDTO> addOnsMasterRepo, ICrud<AllergyDetail, IdDTO> allergyDetailRepo,
            ICrud<FoodTypeCount, IdDTO> foodTypeCountRepo, ICrud<StdFoodOrderDetail, IdDTO> stdFoodOrderDetailRepo
            , ICrud<StdProduct, IdDTO> stdProductRepo, ICrud<AllergyMaster, IdDTO> AllergyMasterRepo)
        {
            _trackStatusRepo = trackStatusRepo;
            _orderRepo = orderRepo;
            _timeSlotRepo = timeSlotRepo;
            _userRepo = userRepo;
            _addOnsDetailRepo= addOnsDetailRepo;
            _plateSizeRepo=plateSizeRepo;
            _deliveryOptionRepo= deliveryOptionRepo;
            _groupSizeRepo= groupSizeRepo;
            _AddOnsMasterRepo= addOnsMasterRepo;
            _AllergyDetailRepo= allergyDetailRepo;
            _FoodTypeCountRepo= foodTypeCountRepo;
            _stdFoodOrderDetailRepo = stdFoodOrderDetailRepo;
            _StdProductRepo= stdProductRepo;
            _AllergyMasterRepo = AllergyMasterRepo;



        }

        public async Task<TrackStatus> Add_TrackStatus(TrackStatus TrackStatus)

        {
            var TrackStatuss = await _trackStatusRepo.GetAll();
            TrackStatus empty = new TrackStatus();

            var newTrackStatus = TrackStatuss.SingleOrDefault(h => h.Id == TrackStatus.Id);
            if (newTrackStatus == null)
            {
                var myTrackStatus = await _trackStatusRepo.Add(TrackStatus);
                if (myTrackStatus != null)
                    return myTrackStatus;
            }
            return empty;
        }

        public async Task<List<TrackStatus>?> View_All_TrackStatuss()

        {
            var TrackStatuss = await _trackStatusRepo.GetAll();
           /* if (TrackStatuss != null)*/
                return TrackStatuss;
            /*return null;*/
        }

        //Get a Particular TrackStatus
        public async Task<TrackStatus?> View_TrackStatus(IdDTO idDTO)
        {
            var TrackStatus = await _trackStatusRepo.GetValue(idDTO);
            /*if (TrackStatus != null)*/
                return TrackStatus;
            /*return null;*/
        }

        //Delete a TrackStatus
        public async Task<TrackStatus?> Delete_TrackStatus(IdDTO idDTO)

        {
            var TrackStatus = await _trackStatusRepo.Delete(idDTO);
           /* if (TrackStatus != null)*/
                return TrackStatus;
           /* return null;*/
        }

        //Update a TrackStatus
        public async Task<TrackStatus?> Update_TrackStatus(TrackStatus TrackStatus)
        {
            var myTrackStatus = await _trackStatusRepo.Update(TrackStatus);
            /*if (myTrackStatus != null)*/
                return myTrackStatus;
           /* return null;*/
        }

        public async Task<List<TrackDTO>> Get_Order_Summary(string id)
        {
            var track = await _trackStatusRepo.GetAll();
            var order = await _orderRepo.GetAll();
            var time = await _timeSlotRepo.GetAll();
            var user = await _userRepo.GetAll();
            var addondetail = await _addOnsDetailRepo.GetAll();
            var plate = await _plateSizeRepo.GetAll();
            var delivery = await _deliveryOptionRepo.GetAll();
            var groups = await _groupSizeRepo.GetAll();
            var addonmaster = await _AddOnsMasterRepo.GetAll();
            var allergy = await _AllergyDetailRepo.GetAll();
            var foodcount = await _FoodTypeCountRepo.GetAll();
            var stdfooddetails =await _stdFoodOrderDetailRepo.GetAll();
            var stdproducts = await _StdProductRepo.GetAll();
            var allergyMaster = await _AllergyMasterRepo.GetAll();


            var orderId = track?
                    .Where(ts => ts.Id == id)
                    .Select(ts => ts.OrderId);

            decimal? cost =0.0m ;

            string? food = "";

            var count =  (from f in foodcount
                          join p in plate on f.PlateSizeId equals p.Id
                                     join o in order on p.Id equals o.PlateSizeId
                                     join ts in track on o.Id equals ts.OrderId
                                      where ts.Id == id
                               select f).Count();
            if(count==2)
            {
                 var price = (from f in foodcount
                           join p in plate on f.PlateSizeId equals p.Id
                           join o in order on p.Id equals o.PlateSizeId
                           join ts in track on o.Id equals ts.OrderId
                              where ts.Id == id
                              select p.VegPlateCost).FirstOrDefault();
                cost = price;
                food = "Veg & Non-Veg";
            }
            else if(count==1)
            {
                var isveg = (from f in foodcount
                           join p in plate on f.PlateSizeId equals p.Id
                           join o in order on p.Id equals o.PlateSizeId
                           join ts in track on o.Id equals ts.OrderId
                             where ts.Id == id
                             select f.IsVeg).FirstOrDefault();
                if (isveg == true)
                {
                    var price = (from f in foodcount
                               join p in plate on f.PlateSizeId equals p.Id
                               join o in order on p.Id equals o.PlateSizeId
                               join ts in track on o.Id equals ts.OrderId
                                 where ts.Id == id
                                 select p.VegPlateCost).FirstOrDefault();
                    cost = price;
                    food = "Veg";

                }
                else
                {
                    var price = (from f in foodcount
                               join p in plate on f.PlateSizeId equals p.Id
                               join o in order on p.Id equals o.PlateSizeId
                               join ts in track on o.Id equals ts.OrderId
                                 where ts.Id == id
                                 select p.NonvegPlateCost).FirstOrDefault();
                    cost = price;
                    food = "Non-Veg";

                }
            }



            var result =  (from ts in track
                        join o in order on ts.OrderId equals o.Id
                        select new TrackDTO
                        {
                            OrderId = ts.OrderId,

                            TrackId = (from t2 in track
                                          join o2 in order on t2.OrderId equals o2.Id
                                       where t2.Id == id
                                       select t2.Id).FirstOrDefault(),

                            DeliveryDate=(from t3 in track
                                          join o3 in order on t3.OrderId equals o3.Id
                                          where t3.Id == id
                                          select o3.Date).FirstOrDefault(),

                            DeliveryTime=(from t4 in track
                                          join o4 in order on t4.OrderId equals o4.Id
                                          join t in time on o.TimeSlotId equals t.Id
                                          where t4.Id == id
                                          select t.AddTimeSlot).FirstOrDefault(),

                            Name=(from u in user
                                  join o5 in order on u.UserName equals o5.UserName
                                  join t5 in track on o5.Id equals t5.OrderId
                                  where t5.Id == id
                                  select u.Name).FirstOrDefault(),

                            PhoneNumber=(from u2 in user
                                         join o6 in order on u2.UserName equals o6.UserName
                                         join t6 in track on o6.Id equals t6.OrderId
                                         where t6.Id == id
                                         select u2.PhoneNumber).FirstOrDefault(),
                            
                            Email=(from u3 in user
                                   join o7 in order on u3.UserName equals o7.UserName
                                   join t7 in track on o7.Id equals t7.OrderId
                                   where t7.Id == id
                                   select u3.EmailId).FirstOrDefault(),

                            Address=(from t8 in track
                                     join o8 in order on t8.OrderId equals o8.Id
                                     where t8.Id == id
                                     select o8.Address).FirstOrDefault(),

                            Allergies = string.Join(", ", (from am in allergyMaster
                                                           join a in allergy on am.Id equals a.AllergyId
                                                           join t19 in track on a.OrdersId equals t19.OrderId
                                                           where t19.Id == id
                                                           select am.AllergyName).ToList()),

                                   PlateSize = (from p in plate
                                         join o10 in order on p.Id equals o10.PlateSizeId
                                         join t10 in track on o10.Id equals t10.OrderId
                                         where t10.Id == id
                                         select p.PlateType).FirstOrDefault(),

                            DeliveryType = (from d in delivery
                                       join o11 in order on d.Id equals o11.DeliveryOptionId
                                       join t11 in track on o11.Id equals t11.OrderId
                                            where t11.Id == id
                                            select d.DeliveryOption1).FirstOrDefault(),

                            GroupSize=(from g in groups
                                       join o12 in order on g.Id equals o12.GroupSizeId
                                       join t12 in track on o12.Id equals t12.OrderId
                                       where t12.Id == id
                                       select g.GroupType).FirstOrDefault(),

                            Count= (from f in foodcount
                                    join p2 in plate on f.PlateSizeId equals p2.Id
                                    join o13 in order on p2.Id equals o13.PlateSizeId
                                    join t13 in track on o13.Id equals t13.OrderId
                                    where t13.Id == id
                                    select f.FoodTypeCount1).FirstOrDefault(),

                            PlateCost= cost,

                            Foodtype=food,

                            Addons =(from am in addonmaster
                                    join ad in addondetail on am.Id equals ad.AddOnsId
                                    join o15 in order on ad.OrderId equals o15.Id
                                    join t15 in track on o.Id equals t15.OrderId
                                     where t15.Id == id
                                     select am.AddOnsName).FirstOrDefault(),

                            AddonsCost=(from am1 in addonmaster
                                        join ad1 in addondetail on am1.Id equals ad1.AddOnsId
                                        join o16 in order on ad1.OrderId equals o16.Id
                                        join t16 in track on o16.Id equals t16.OrderId
                                        where t16.Id == id
                                        select am1.UnitPrice).FirstOrDefault(),

                            Menu  = string.Join(", ", (from s in stdproducts
                                                       join sd in stdfooddetails on s.Id equals sd.ProductsId
                                                            join o18 in order on sd.OrderId equals o18.Id
                                                            join t18 in track on o18.Id equals t18.OrderId
                                                       where t18.Id == id
                                                       select s.ProductsName)),


                           Additional = (from am1 in addonmaster
                                              join ad1 in addondetail on am1.Id equals ad1.AddOnsId
                                              join o17 in order on ad1.OrderId equals o17.Id
                                              join t17 in track on o17.Id equals t17.OrderId
                                         where t17.Id == id
                                         select new Addons
                                              {
                                                  AddonName = am1.AddOnsName,
                                                  Price = am1.UnitPrice
                                              }).ToList(),

                        }).ToList();


            return result;
        }
}
}
