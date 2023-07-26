using FoodPortal.Interfaces;
using FoodPortal.Models.DTO;
using FoodPortal.Models;
using FoodPortal.Repos;

namespace FoodPortal.Services
{
    public class OrderService: IOrderService
    {
        private readonly ICrud<Order, IdDTO> _orderRepo;
        private readonly ICrud<TimeSlot, IdDTO> _timeSlotRepo;


        public OrderService(ICrud<Order, IdDTO> orderRepo, ICrud<TimeSlot, IdDTO> timeSlotRepo)
        {
            _orderRepo = orderRepo;
            _timeSlotRepo = timeSlotRepo;
        }

        public async Task<Order> Add_Order(Order Order)

        {
            var Orders = await _orderRepo.GetAll();
            Order empty = new Order();

            var newOrder = Orders.SingleOrDefault(h => h.Id == Order.Id);
            if (newOrder == null)
            {
                var myOrder = await _orderRepo.Add(Order);
                if (myOrder != null)
                    return myOrder;
            }
            return empty;
        }

        public async Task<List<Order>?> View_All_Orders()
        { 
            var Orders = await _orderRepo.GetAll();
            /*if (Orders != null)*/
                return Orders;
           /* return null;*/
        }

        //Get a Particular Order
        public async Task<Order?> View_Order(IdDTO idDTO)
        {
            var Order = await _orderRepo.GetValue(idDTO);
            /*if (Order != null)*/
                return Order;
            /*return null;*/
        }

        //Delete a Order
        public async Task<Order?> Delete_Order(IdDTO idDTO)

        {
            var Order = await _orderRepo.Delete(idDTO);
            /*if (Order != null)*/
                return Order;
            /*return null;*/
        }

        //Update a Order
        public async Task<Order?> Update_Order(Order Order)
        {
            var myOrder = await _orderRepo.Update(Order);
            /*if (myOrder != null)*/
                return myOrder;
           /* return null;*/
        }

        public async Task<List<AvailabilityDTO>> GetUnAvailableDate(DateTime date)
        {
            DateTime targetDate = date;
            int targetTimeslotCount = 6;
            var orders = await _orderRepo.GetAll();

            var result = (from order in orders
                          where order.Date > targetDate
                          group order by order.Date into g
                          where g.Select(o => o.TimeSlotId).Distinct().Count() == targetTimeslotCount
                          select new AvailabilityDTO
                          {
                              UnavailableDate = g.Key,
                              Count = g.Count()
                          }).ToList();
            return result;
        }
        public async Task<List<AvailabilityDTO>> GetAvailableTimeSlot(DateTime date)
        {
            DateTime targetDate = date;

            var orders = await _orderRepo.GetAll();
            var timeSlots = await _timeSlotRepo.GetAll();


            var result = timeSlots
           .Where(ts => !orders.Any(o => o.TimeSlotId == ts.Id && o.Date == targetDate))
           .Select(ts => new FoodPortal.Models.DTO.AvailabilityDTO
           {
               UnavailableDate = null,
               Count = null,
               availableTimeSlot = ts.AddTimeSlot
           }).ToList();

            return result;

        }
    }
}
