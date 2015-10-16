namespace AddNewProduct
{
    using System;
    using System.Data.SqlClient;
    using System.Linq;

    public class Startup
    {
        private SqlConnection dbCon;

        public static void Main(string[] args)
        {
            var startup = new Startup();
            try
            {
                startup.ConnectToDB();
                startup.AddProduct("alabala", true);
            }
            finally
            {
                startup.DisconnectFromDB();
            }
        }

        private void AddProduct(string productName, bool discontiniued, int? supplierID = null, int? categoryID = null, string quantityPerUnit = null,
            decimal? unitPrice = null, short? unitsInStock = null, short? unitsOnOrder = null, short? reorderLevel = null)
        {
            var cmdInsertProject = new SqlCommand(
                "INSERT INTO Products(ProductName, Discontinued, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel)VALUES (@productName, @discontinued, @supplierID, @categoryID, @quantityPerUnit, @unitPrice, @unitsInStock, @unitsOnOrder, @reorderLevel)", this.dbCon);

            cmdInsertProject.Parameters.AddWithValue("@productName", productName);
            cmdInsertProject.Parameters.AddWithValue("@discontiniued", discontiniued);

            var sqlParameterSupplierId = new SqlParameter("@supplierId", supplierID);
            if (supplierID == null)
            {
                sqlParameterSupplierId.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterSupplierId);

            var sqlParameterCategoryID = new SqlParameter("@categoryID", categoryID);
            if (categoryID == null)
            {
                sqlParameterCategoryID.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterCategoryID);

            var sqlParameterQuantityPerUnit = new SqlParameter("@quantityPerUnit", quantityPerUnit);
            if (quantityPerUnit == null)
            {
                sqlParameterQuantityPerUnit.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterQuantityPerUnit);

            var sqlParameterUnitPrice = new SqlParameter("@unitPrice", unitPrice);
            if (unitPrice == null)
            {
                sqlParameterUnitPrice.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitPrice);

            var sqlParameterUnitsInStock = new SqlParameter("@unitsInStock", unitsInStock);
            if (unitsInStock == null)
            {
                sqlParameterUnitsInStock.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitsInStock);

            var sqlParameterUnitsOnOrder = new SqlParameter("@unitsOnOrder", unitsOnOrder);
            if (unitsOnOrder == null)
            {
                sqlParameterUnitsOnOrder.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterUnitsOnOrder);

            var sqlParameterReorderLevel = new SqlParameter("@reorderLevel", reorderLevel);
            if (reorderLevel == null)
            {
                sqlParameterReorderLevel.Value = DBNull.Value;
            }

            cmdInsertProject.Parameters.Add(sqlParameterReorderLevel);

            cmdInsertProject.ExecuteNonQuery();
        }

        private void ConnectToDB()
        {
            this.dbCon = new SqlConnection("Server=.\\SQL; Database=NorthWind; Integrated Security=true");
            this.dbCon.Open();
        }

        private void DisconnectFromDB()
        {
            if (this.dbCon != null)
            {
                this.dbCon.Close();
            }
        }
    }
}