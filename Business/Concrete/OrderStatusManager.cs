//  *** OrderStatus artık enum olduğundan dolayı, orderStatusManager artık kullanılmayacak.

//using Business.Abstract;
//using Core.Utilities.Business;
//using Core.Utilities.Results;
//using DataAccess.Abstract;
//using Entities.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Business.Concrete
//{
//    //*productID var mı? *orderID var mı?
//    public class OrderStatusManager : IOrderStatusServices
//    {
//        IOrderStatusDAL _orderStatusDAL;
//        IOrderServices _orderServices;
//        IProductServices _productServices;

//        public OrderStatusManager(IOrderStatusDAL orderStatusDAL, IOrderServices orderServices, IProductServices productServices)
//        {
//            _orderStatusDAL = orderStatusDAL;
//            _orderServices = orderServices;
//            _productServices = productServices;
//        }

//        public IDataResult<List<OrderStatus>> GetAll()
//        {
//            return new SuccessDataResult<List<OrderStatus>>(_orderStatusDAL.GetAll(), "Successfully Listed");
//        }

//        public IDataResult<OrderStatus> GetByID(int ID)
//        {
//            return new SuccessDataResult<OrderStatus>(_orderStatusDAL.Get(p => p.OrderStatusID == ID));
//        }

//        public IResult Add(OrderStatus orderStatus)
//        {
//            var result = BusinessRules.Run(
//               CheckProductIDExists(orderStatus.ProductID),
//               CheckOrderIDExists(orderStatus.OrderID)
//               );

//            if (result != null)
//            {
//                return result;
//            }
//            _orderStatusDAL.Add(orderStatus);
//            return new SuccessResult("Successfully Added");
//        }

//        public IResult Update(OrderStatus orderStatus)
//        {
//            throw new NotImplementedException();
//        }

//        public IDataResult<OrderStatus> GetByOrderID(int orderID)
//        {
//            var result = BusinessRules.Run(
//              CheckOrderIDExists(orderID)
//              );

//            if (result != null)
//            {
//                return new ErrorDataResult<OrderStatus>("Invalid OrderID");
//            }
//            return new SuccessDataResult<OrderStatus>(_orderStatusDAL.Get(p => p.OrderID == orderID));
//        }

//        public IDataResult<OrderStatus> GetByProductID(int productID)
//        {
//            var result = BusinessRules.Run(
//                CheckProductIDExists(productID)
//                );

//            if (result != null)
//            {
//                return new ErrorDataResult<OrderStatus>("Invalid ProductID");
//            }
            
//            return new SuccessDataResult<OrderStatus>(_orderStatusDAL.Get(p => p.OrderStatusID == productID));
//        }

//        //Business Rules
//        private IResult CheckProductIDExists(int ProductID)
//        {
//            if (_productServices.GetByID(ProductID).Success)
//            {
//                return new SuccessResult();
//            }
//            else
//            {
//                return new ErrorResult("This Operation ID could not found!");
//            }
//        }
//        private IResult CheckOrderIDExists(int ProductID)
//        {
//            if (_productServices.GetByID(ProductID).Success)
//            {
//                return new SuccessResult();
//            }
//            else
//            {
//                return new ErrorResult("This Order ID could not found!");
//            }
//        }
//    }
//}
