
using CeatCore.Infrastructure;
using SupremeCourtCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Common
{
    public class DAOFactory
    {
        public static UserLoginDAO CreateUserLoginDAO()
        {
            UserLoginDAO aa = new UserLoginDAOImpl();
            return (UserLoginDAO)aa;
        }

        public static UserLoginResetDAO CreateUserLoginResetDAO()
        {
            UserLoginResetDAO userLoginResetDAO = new UserLoginResetDAOimpl();
            return (UserLoginResetDAO)userLoginResetDAO;
        }

        public static CustomerLoginDAO CreateCustomerLoginDAO()
        {
            CustomerLoginDAO aa = new CustomerLoginDAOImpl();
            return (CustomerLoginDAO)aa;
        }

        public static DealerLoginDAO CreateDealerLoginDAO()
        {
            DealerLoginDAO aa = new DealerLoginDAOImpl();
            return (DealerLoginDAO)aa;
        }

        public static CustomerDAO CreateCustomerDAO()
        {
            CustomerDAO aa = new CustomerDAOImpl();
            return (CustomerDAO)aa;
        }

        public static CompanyDAO CreateCompanyDAO()
        {
            CompanyDAO aa = new CompanyDAOImpl();
            return (CompanyDAO)aa;
        }

        public static DealerCustomerDAO CreateDealerCustomerDAO()
        {
            DealerCustomerDAO aa = new DealerCustomerDAOImpl();
            return (DealerCustomerDAO)aa;
        }

        public static DealerDAO CreateDealerDAO()
        {
            DealerDAO aa = new DealerDAOImpl();
            return (DealerDAO)aa;
        }

        public static FittersDAO CreateFittersDAO()
        {
            FittersDAO aa = new FittersDAOImpl();
            return (FittersDAO)aa;
        }

        public static CustomerComplaintDAO CreateCustomerComplaintDAO()
        {
            CustomerComplaintDAO aa = new CustomerComplaintDAOImpl();
            return (CustomerComplaintDAO)aa;
        }

        public static CustomerOrderDAO CreateCustomerOrderDAO()
        {
            CustomerOrderDAO aa = new CustomerOrderDAOImpl();
            return (CustomerOrderDAO)aa;
        }

        public static OrderDetailsDAO CreateOrderDetailsDAO()
        {
            OrderDetailsDAO aa = new OrderDetailsDAOImpl();
            return (OrderDetailsDAO)aa;
        }

        public static ProductMasterDAO CreateProductMasterDAO()
        {
            ProductMasterDAO aa = new ProductMasterDAOImpl();
            return (ProductMasterDAO)aa;
        }

        public static ComplaintOrderDAO CreateComplaintOrderDAO()
        {
            ComplaintOrderDAO aa = new ComplaintOrderDAOImpl();
            return (ComplaintOrderDAO)aa;
        }

        public static ComplaintTypeDAO CreateComplaintTypeDAO()
        {
            ComplaintTypeDAO aa = new ComplaintTypeDAOImpl();
            return (ComplaintTypeDAO)aa;
        }

        public static ComplaintCategoryDAO CreateComplaintCategoryDAO()
        {
            ComplaintCategoryDAO aa = new ComplaintCategoryDAOImpl();
            return (ComplaintCategoryDAO)aa;
        }

        public static DistrictDAO CreateDistrictDAO()
        {
            DistrictDAO aa = new DistrictDAOImpl();
            return (DistrictDAO)aa;
        }

        public static UserTypeDAO CreateUserTypeDAO()
        {
            UserTypeDAO aa = new UserTypeDAOImpl();
            return (UserTypeDAO)aa;
        }

        public static TireTipsDAO CreateTireTipsDAO()
        {
            TireTipsDAO aa = new TireTipsDAOImpl();
            return (TireTipsDAO)aa;
        }

        public static DealerRatingDAO CreateDealerRatingDAO()
        {
            DealerRatingDAO aa = new DealerRatingDAOImpl();
            return (DealerRatingDAO)aa;
        }

        public static ProductRatingDAO CreateProductRatingDAO()
        {
            ProductRatingDAO aa = new ProductRatingDAOImpl();
            return (ProductRatingDAO)aa;
        }

        public static OrderFitterDAO CreateOrderFitterDAO()
        {
            OrderFitterDAO aa = new OrderFitterDAOImpl();
            return (OrderFitterDAO)aa;
        }

        public static SliderImageDAO CreateSliderImageDAO()
        {
            SliderImageDAO aa = new SliderImageDAOImpl();
            return (SliderImageDAO)aa;
        }

        public static AdminLoginDAO CreateAdminLoginDAO()
        {
            AdminLoginDAO aa = new AdminLoginDAOImpl();
            return (AdminLoginDAO)aa;
        }

        public static AdminDAO CreateAdminDAO()
        {
            AdminDAO aa = new AdminDAOImpl();
            return (AdminDAO)aa;
        }

        public static ProductLineItemDAO CreateProductLineItemDAO()
        {
            ProductLineItemDAO aa = new ProductLineItemDAOImpl();
            return (ProductLineItemDAO)aa;
        }

        public static CustomerVehicleDAO CreateCustomerVehicleDAO()
        {
            CustomerVehicleDAO customerVehicleDAO = new CustomerVehicleDAOImpl();
            return (CustomerVehicleDAO)customerVehicleDAO;
        }

        public static OrderVehicleDAO CreateOrderVehicleDAO()
        {
            OrderVehicleDAO orderVehicleDAO = new OrderVehicleDAOImpl();
            return (OrderVehicleDAO)orderVehicleDAO;
        }
    }
}
