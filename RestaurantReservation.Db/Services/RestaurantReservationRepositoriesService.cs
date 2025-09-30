using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantReservation.Db.Models;
using RestaurantReservation.Db.Repositories;

namespace RestaurantReservation.Db.Services
{
    public class RestaurantReservationRepositoriesService
    {
        private readonly EmployeeRepository _employeeRepo;
        private readonly CustomerRepository _customerRepo;
        private readonly RestaurantRepository _restaurantRepo;
        private readonly ReservationRepository _reservationRepo;

        public RestaurantReservationRepositoriesService(
            EmployeeRepository employeeRepo,
            CustomerRepository customerRepo,
            RestaurantRepository restaurantRepo,
            ReservationRepository reservationRepo)
        {
            _employeeRepo = employeeRepo;
            _customerRepo = customerRepo;
            _restaurantRepo = restaurantRepo;
            _reservationRepo = reservationRepo;
        }

        // ==== Employee ====
        public async Task<List<Employee>> ListManagersAsync()
            => await _employeeRepo.ListManagersAsync();

        public async Task<decimal> CalculateAverageOrderAmountAsync(int employeeId)
            => await _employeeRepo.CalculateAverageOrderAmountAsync(employeeId);

        public async Task<List<EmployeeWithRestaurant>> GetEmployeesWithRestaurantAsync()
            => await _employeeRepo.GetEmployeesWithRestaurantAsync();

        // ==== Customer ====
        public async Task<List<Customer>> GetCustomersByPartySizeAsync(int partySize)
            => await _customerRepo.GetCustomersByPartySizeAsync(partySize);

        // ==== Reservation ====
        public async Task<List<ReservationWithDetails>> GetReservationsWithDetailsAsync()
            => await _reservationRepo.GetReservationsWithDetailsAsync();

        public async Task<List<MenuItem>> ListOrderedMenuItemsAsync(int reservationId)
            => await _reservationRepo.ListOrderedMenuItemsAsync(reservationId);

        // ==== Restaurant ====
        public async Task<decimal> CalculateTotalRevenueAsync(int restaurantId)
            => await _restaurantRepo.CalculateTotalRevenueAsync(restaurantId);
      
    }
}