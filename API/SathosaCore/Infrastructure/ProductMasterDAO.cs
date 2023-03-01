using CeatCore.Common;
using CeatCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeatCore.Infrastructure
{
    public interface ProductMasterDAO
    {
        int createProduct(ProductMaster product, DBConnection dbConnection);
        int updateProduct(ProductMaster product, DBConnection dbConnection);
        //int deleteCustomerOrder(int customerOrderID, DBConnection dbConnection);
        List<ProductMaster> GetAllProducts(DBConnection dbConnection);
        ProductMaster getProductById(int id, DBConnection dbConnection);

    }

    public class ProductMasterDAOImpl : ProductMasterDAO
    {
        public int createProduct(ProductMaster product, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "INSERT INTO PRODUCT_MASTER (NAME, DESCRIPTION, WARRANTY_DESCRIPTION, WARRANTY_DURATION_NUM_OF_MONTH)" +
                "values('" + product.name + "','" + product.description + "','" + product.warrantyDescription + "'," + product.warrantyDurationNumOfMonth + ") SELECT SCOPE_IDENTITY()";
            return dbConnection.cmd.ExecuteNonQuery();
        }

        public int updateProduct(ProductMaster product, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "update PRODUCT_MASTER set NAME = '" + product.name + ", DESCRIPTION = '" + product.description + "',WARRANTY_DEACRIPTION = '"+product.warrantyDescription+ "',WARRANTY_DURATION_NUM_OF_MONTH = "+ product.warrantyDurationNumOfMonth+ " where ID = " + product.id ;

            return dbConnection.cmd.ExecuteNonQuery();
        }

        public List<ProductMaster> GetAllProducts(DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_MASTER ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.ReadCollection<ProductMaster>(dbConnection.dr);
        }

        public ProductMaster getProductById(int id, DBConnection dbConnection)
        {
            dbConnection.cmd.CommandText = "SELECT * FROM PRODUCT_MASTER WHERE ID = " + id + " ";

            dbConnection.dr = dbConnection.cmd.ExecuteReader();
            DataAccessObject dataAccessObject = new DataAccessObject();
            return dataAccessObject.GetSingleOject<ProductMaster>(dbConnection.dr);
        }
    }
}
