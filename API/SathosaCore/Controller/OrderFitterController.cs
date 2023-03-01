using CeatCore.Common;
using CeatCore.Domain;
using CeatCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Controller
{
    public interface OrderFitterController
    {
        int addOrderFitter(OrderFitter orderFitter);
        List<OrderFitter> getOrderFittersByCusOrderId(int cusOrderId);
    }

    public class OrderFitterControllerImpl : OrderFitterController
    {
        DBConnection dBConnection;
        OrderFitterDAO orderFitterDAO = DAOFactory.CreateOrderFitterDAO();

        public int addOrderFitter(OrderFitter orderFitter)
        {
            try
            {
                dBConnection = new DBConnection();

                return orderFitterDAO.addOrderFitter(orderFitter, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }

        public List<OrderFitter> getOrderFittersByCusOrderId(int cusOrderId)
        {
            try
            {
                dBConnection = new DBConnection();
                return orderFitterDAO.getOrderFittersByCusOrderId(cusOrderId, dBConnection);

            }
            catch (Exception)
            {
                dBConnection.RollBack();

                throw;
            }
            finally
            {
                if (dBConnection.con.State == System.Data.ConnectionState.Open)
                    dBConnection.Commit();
            }
        }
    }
}