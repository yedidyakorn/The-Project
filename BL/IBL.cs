﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// business logic methods
/// </summary>
namespace BL
{
    public interface IBL
    {
        /// <summary>
        /// add Guest Request
        /// </summary>
        /// <param name="guestRequest"></param>
        /// <returns>bool</returns>
        bool AddGuestRequest(GuestRequest guestRequest);

        /// <summary>
        /// Update Guest Request Status
        /// </summary>
        /// <param name="GuestRequestKey"></param>
        /// <param name="requestStatus"></param>
        /// <returns>bool</returns>
        bool UpdateGuestRequestStatus(long GuestRequestKey, RequestStatus requestStatus);

        /// <summary>
        /// Delete Guest Request Status
        /// </summary>
        /// <param name="GuestRequestKey"></param>
        /// <param name="requestStatus"></param>
        /// <returns>bool</returns>
        bool DeleteGuestRequestsByKey(long key);

        /// <summary>
        /// guest request by ID
        /// </summary>
        /// <returns>guest request</returns>
        List<GuestRequest> GetGuestRequestsById(long id);

        /// <summary>
        /// guest request by Key
        /// </summary>
        /// <returns>guest request</returns>
        GuestRequest GetGuestRequestsByKey(long key);

        /// <summary>
        /// Update Guest Request
        /// </summary>
        /// <param name="GuestRequest"></param>
        /// <returns>bool</returns>
        bool UpdateGuestRequest(GuestRequest guestRequest);

        /// <summary>
        /// Add Hosting Unit
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        bool AddHostingUnit(HostingUnit hostingUnit);//הוספת יחידת אירוח

        /// <summary>
        /// Delete Hosting Unit
        /// </summary>
        /// <param name="HostingUnitKey"></param>
        /// <returns></returns>
        bool DeleteHostingUnit(long HostingUnitKey);

        /// <summary>
        /// Update Hosting Unit
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns>bool</returns>
        bool UpdateHostingUnit(HostingUnit hostingUnit);

        /// <summary>
        /// Get Hosting Units By Owner ID
        /// </summary>
        /// <returns>Hosting Unit list</returns>
        List<HostingUnit> GetHostingUnitsByOwnerId(long id);

        /// <summary>
        /// Add Order
        /// </summary>
        /// <param name="order"></param>
        /// <returns>bool</returns>
        bool AddOrder(Order order);

        /// <summary>
        /// Update Order
        /// </summary>
        /// <param name="orderKey"></param>
        /// <param name="orderStatuses"></param>
        /// <returns>bool</returns>
        bool UpdateOrder(long orderKey, OrderStatuses orderStatuses);

        /// <summary>
        /// Get Orders Status Count
        /// </summary>
        /// <returns>dynamic</returns>
        List<dynamic> GetOrdersStatusCount();

        /// <summary>
        /// Get Hosting Units List
        /// </summary>
        /// <returns>Hosting Unit list</returns>
        List<HostingUnit> GetHostingUnitsList();

        /// <summary>
        /// Get Guest Requests List
        /// </summary>
        /// <returns>Guest Requests List</returns>
        List<GuestRequest> GetGuestRequestsList();

        /// <summary>
        /// GetOrderList
        /// </summary>
        /// <returns>Order List</returns>
        List<Order> GetOrderList();

        /// <summary>
        /// GetBankBranchesList
        /// </summary>
        /// <returns>Bank Branches List</returns>
        List<BankBranch> GetBankBranchesList();

        /// <summary>
        /// find all available hosting units for specific date
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="daysNum"></param>
        /// <returns>Hosting Unit List</returns>
        List<HostingUnit> GetAllAvailableUnitsForDate(DateTime startDate, int daysNum);

        /// <summary>
        /// returns num of days between tow dates
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate">optional</param>
        /// <returns>int</returns>
        int GetDaysBetweenDates(DateTime startDate, [Optional]DateTime? endDate);

        /// <summary>
        /// find all orders with specific date range
        /// </summary>
        /// <param name="days"></param>
        /// <returns>list of orders</returns>
        List<Order> GetOrdersForDays(int days);

        /// <summary>
        /// get number of orders related to specific guest request
        /// </summary>
        /// <param name="guestRequest"></param>
        /// <returns>int</returns>
        int GetOrdersNumForGR(GuestRequest guestRequest);

        /// <summary>
        /// find all aproved orders for host unit 
        /// </summary>
        /// <param name="hostingUnit"></param>
        /// <returns></returns>
        int GetApprovedOrdersNumForHU(HostingUnit hostingUnit);

        /// <summary>
        /// guest request list grouped by area
        /// </summary>
        /// <returns>guest request grouped by area</returns>
        List<IGrouping<VecationAreas, GuestRequest>> GetGRListGroupByArea();

        /// <summary>
        /// guest request list grouped by number of vacationers
        /// </summary>
        /// <returns>guest request list grouped by number of vacationers</returns>
        List<IGrouping<int, GuestRequest>> GetGRListGroupByVacationers();

        /// <summary>
        /// hosts grouped by units number they own
        /// </summary>
        /// <returns>hosts grouped by units number they own</returns>
        List<dynamic> GetHostsByUnitsNum();

        /// <summary>
        /// get hosting units grouped by area
        /// </summary>
        /// <returns>get hosting units grouped by area</returns>
        List<IGrouping<VecationAreas, HostingUnit>> GetHUListGroupByArea();

        /// <summary>
        /// get all host units with pool
        /// </summary>
        /// <returns></returns>
        List<HostingUnit> GetAllHostUnitsWithPool();

        /// <summary>
        /// find all Guest Requests for Host Unit
        /// </summary>
        /// <returns></returns>
        List<GuestRequest> GetAllGuestRequestsForHostUnit(HostingUnit hostingUnit);

        /// <summary>
        /// Load Hosting Units Dairy
        /// </summary>
        /// <returns></returns>
        void LoadHostingUnitsDairy();

        /// <summary>
        /// calc manager fee between dates
        /// </summary>
        /// <returns></returns>
        double CalcFeeBetweenDates(DateTime fromDate, DateTime toDate);

        /// <summary>
        /// get orders by status
        /// </summary>
        /// <returns>IEnumerable<dynamic></returns>
        IEnumerable<object> GetOrdersGroupByStatus();

        /// <summary>
        ///GetOrdersGroupByCreateDate
        /// </summary>
        /// <returns>IEnumerable<dynamic></returns>
        IEnumerable<IGrouping<DateTime, Order>> GetOrdersGroupByCreateDate();
    }
}
