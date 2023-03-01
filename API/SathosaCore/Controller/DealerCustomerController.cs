using CeatCore.Common;
using CeatCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupremeCourtCore.Controller
{
    public interface DealerCustomerController
    {
    }

    public class DealerCustomerControllerImpl : DealerCustomerController
    {
        DBConnection DBConnection;
        DealerCustomerDAO dealerCustomerDAO = DAOFactory.CreateDealerCustomerDAO();
    }
}
