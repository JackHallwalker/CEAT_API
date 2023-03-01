using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface OrderFitterDAO
    {
        int addOrderFitter(OrderFitter orderFitter, DBConnection dbConnection);
        List<OrderFitter> getOrderFittersByCusOrderId(int cusOrderId, DBConnection dbConnection);
    }

    public class OrderFitterDAOImpl : OrderFitterDAO
    {
        public int addOrderFitter(OrderFitter orderFitter, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO ORDER_FITTER (CUSTOMER_ORDERS_ID, FITTERS_ID) " +
               "values(" + orderFitter.customerOrdersId + "," + orderFitter.fitterId + ") SELECT SCOPE_IDENTITY()";
            return Convert.ToInt32(dbConnection.cmd.ExecuteScalar());
        }

        public List<OrderFitter> getOrderFittersByCusOrderId(int cusOrderId, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM ORDER_FITTER ORF WHERE ORF.CUSTOMER_ORDERS_ID =" + cusOrderId;

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<OrderFitter>(dbConnection.dr);
        }

    }

}
