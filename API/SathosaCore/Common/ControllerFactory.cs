
using CeatCore.Controller;
using SupremeCourtCore.Controller;
//using SupremeCourtCore.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Common
{
    public class ControllerFactory
    {
        public static UserLoginController CreateUserLoginController()
        {
            UserLoginController aa = new UserLoginControllerImpl();
            return (UserLoginController)aa;
        }

        public static UserLoginResetController CreateUserLoginResetController()
        {
            UserLoginResetController userLoginResetController = new UserLoginResetControllerimpl();
            return (UserLoginResetController)userLoginResetController;
        }

        public static CustomerLoginController CreateCustomerLoginController()
        {
            CustomerLoginController aa = new CustomerLoginControllerImpl();
            return (CustomerLoginController)aa;
        }

        public static DealerLoginController CreateDealerLoginController()
        {
            DealerLoginController aa = new DealerLoginControllerImpl();
            return (DealerLoginController)aa;
        }

        public static CustomerController CreateCustomerController()
        {
            CustomerController aa = new CustomerControllerImpl();
            return (CustomerController)aa;
        }

        public static CompanyController CreateCompanyController()
        {
            CompanyController aa = new CompanyControllerImpl();
            return (CompanyController)aa;
        }

        public static DealerCustomerController CreateDealerCustomerController()
        {
            DealerCustomerController aa = new DealerCustomerControllerImpl();
            return (DealerCustomerController)aa;
        }

        public static FittersController CreateFittersController()
        {
            FittersController aa = new FittersControllerImpl();
            return (FittersController)aa;
        }

        public static CustomerComplaintController CreateCustomerComplaintController()
        {
            CustomerComplaintController aa = new CustomerComplaintControllerImpl();
            return (CustomerComplaintController)aa;
        }

        public static CustomerOrderController CreateCustomerOrderController()
        {
            CustomerOrderController aa = new CustomerOrderControllerImpl();
            return (CustomerOrderController)aa;
        }

        public static OrderDetailsController CreateOrderDetailsController()
        {
            OrderDetailsController aa = new OrderDetailsControllerImpl();
            return (OrderDetailsController)aa;
        }

        public static ProductMasterController CreateProductMasterController()
        {
            ProductMasterController aa = new ProductMasterControllerImpl();
            return (ProductMasterController)aa;
        }

        public static ComplaintOrderController CreateComplaintOrderController()
        {
            ComplaintOrderController aa = new ComplaintOrderControllerImpl();
            return (ComplaintOrderController)aa;
        }

        public static ComplaintTypeController CreateComplaintTypeController()
        {
            ComplaintTypeController aa = new ComplaintTypeControllerImpl();
            return (ComplaintTypeController)aa;
        }

        public static ComplaintCategoryController CreateComplaintCategoryController()
        {
            ComplaintCategoryController aa = new ComplaintCategoryControllerImpl();
            return (ComplaintCategoryController)aa;
        }

        public static DistrictController CreateDistrictController()
        {
            DistrictController aa = new DistrictControllerImpl();
            return (DistrictController)aa;
        }

        public static UserTypeController CreateUserTypeController()
        {
            UserTypeController aa = new UserTypeControllerImpl();
            return (UserTypeController)aa;
        }

        public static DealerController CreateDealerController()
        {
            DealerController aa = new DealerControllerImpl();
            return (DealerController)aa;
        }

        public static TireTipsController CreateTireTipsController()
        {
            TireTipsController aa = new TireTipsControllerImpl();
            return (TireTipsController)aa;
        }

        public static DealerRatingController CreateDealerRatingController()
        {
            DealerRatingController aa = new DealerRatingControllerImpl();
            return (DealerRatingController)aa;
        }

        public static ProductRatingController CreateProductRatingController()
        {
            ProductRatingController aa = new ProductRatingControllerImpl();
            return (ProductRatingController)aa;
        }

        public static OrderFitterController CreateOrderFitterController()
        {
            OrderFitterController aa = new OrderFitterControllerImpl();
            return (OrderFitterController)aa;
        }

        public static SliderImageController CreateSliderImageController()
        {
            SliderImageController aa = new SliderImageControllerImpl();
            return (SliderImageController)aa;
        }

        public static AdminLoginController CreateAdminLoginController()
        {
            AdminLoginController aa = new AdminLoginControllerImpl();
            return (AdminLoginController)aa;
        }

        public static AdminController CreateAdminController()
        {
            AdminController aa = new AdminControllerImpl();
            return (AdminController)aa;
        }

        public static ProductLineItemController CreateProductLineItemController()
        {
            ProductLineItemController aa = new ProductLineItemControllerImpl();
            return (ProductLineItemController)aa;
        }

        public static CustomerVehicleController CreateCustomerVehicleController()
        {
            CustomerVehicleController customerVehicleController = new CustomerVehicleControllerImpl();
            return (CustomerVehicleController)customerVehicleController;
        }

        public static OrderVehicleController CreateOrderController()
        {
            OrderVehicleController orderVehicleController = new OrderVehicleControllerImpl();
            return (OrderVehicleController)orderVehicleController;
        }

    }
}
