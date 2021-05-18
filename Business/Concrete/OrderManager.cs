using Business.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class OrderManager : IOrderServices
    {
        //*deadline şuandan önce bir tarihte olmamalı *CustomerID var olmalı
        //Order'dan OrderItems çekilebilmeli!
        IOrderDAL _orderDAL;
        public OrderManager(IOrderDAL orderDAL) => _orderDAL = orderDAL;

        public IResult Add(Order order)
        {
            var result = BusinessRules.Run(
               CheckDeadlineIsCorrect(order.Deadline),
               CheckIfCustomerIDExists(order.UserID)
               );

            if (result != null)
            {
                return result;
            }
            _orderDAL.Add(order);
            return new SuccessResult("Successfully Added");
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(), "Successfully Listed");
        }

        public IDataResult<List<Order>> GetAllDeadLineUntilNow(DateTime deadline)
        {
            var result = BusinessRules.Run(CheckDeadlineIsCorrect(deadline));
            if (result == null)
            {
                return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(p => p.Deadline <= deadline));
            }
            else
            {
                return new ErrorDataResult<List<Order>>("Invalid Deadline!");
            }
        }

        public IDataResult<List<Order>> GetAllOrderDateUntilNow(DateTime orderDate)
        {
            var result = BusinessRules.Run(CheckDeadlineIsCorrect(orderDate));
            if (result == null)
            {
                return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(p => p.OrderDate <= orderDate));
            }
            else
            {
                return new ErrorDataResult<List<Order>>("Invalid OrderDate!");
            }
        }

        public IDataResult<Order> GetByCustomerID(int customerID)
        {
            var result = BusinessRules.Run(
                CheckIfCustomerIDExists(customerID)
                );
            if (result == null)
            {
                return new SuccessDataResult<Order>(_orderDAL.Get(p => p.UserID == customerID));
            }
            else
            {
                return new ErrorDataResult<Order>("CustomerID is invalid!");
            }

        }

        public IDataResult<Order> GetByID(int ID)
        {
            return new SuccessDataResult<Order>(_orderDAL.Get(p => p.OrderID == ID));

        }

        public IDataResult<List<Order>> GetByOrderDate(DateTime orderDate)
        {
            return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(p => p.OrderDate == orderDate));
        }

        public IDataResult<List<Order>> GetByOrderDeadline(DateTime deadLine)
        {
            var result = BusinessRules.Run(CheckDeadlineIsCorrect(deadLine));
            if(result == null)
            {
                return new SuccessDataResult<List<Order>>(_orderDAL.GetAll(p => p.Deadline == deadLine));
            }
            else
            {
                return new ErrorDataResult<List<Order>>("Invalid Deadline!");
            }
           
        }

        public IDataResult<List<OrderDetailDTO>> GetOrderDetails()
        {
            return new SuccessDataResult<List<OrderDetailDTO>>(_orderDAL.GetOrderDetails());

        }

        public IDataResult<List<OrderDetailDTO>> GetOrderDetailsByCustomerID(int ID)
        {
            return new SuccessDataResult<List<OrderDetailDTO>>(_orderDAL.GetOrderDetailsByCustomerID(ID));
        }

        public IDataResult<OrderDetailDTO> GetOrderDetailsByOrderID(int ID)
        {
            return new SuccessDataResult<OrderDetailDTO>(_orderDAL.GetOrderDetailsByOrderID(ID));
        }

        public IResult Update(Order order)
        {
            _orderDAL.Update(order);
            return new SuccessResult("Successfully Updated");
        }

        //Busines Rules
        private IResult CheckDeadlineIsCorrect(DateTime deadline)
        {
            if (deadline <= DateTime.Now)
            {
                return new ErrorResult("Deadline must be later than now!");
            }
            else
            {
                return new SuccessResult();
            }
        }

        private IResult CheckIfCustomerIDExists(int customerID)
        {
            if (_orderDAL.GetAll(p => p.UserID == customerID).Count == 1)
            {
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("There is no Customer belongs " + customerID + "you gave!");
            }
        }

    }
}
