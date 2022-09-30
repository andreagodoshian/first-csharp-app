using CustomerOrderViewer.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderViewer.Repository
{
    internal class CustomerOrderDetailCommand
    {
        private string connectionString;

        public CustomerOrderDetailCommand(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<CustomerOrderDetailModel> GetList()
        {
            List<CustomerOrderDetailModel> customerOrderDetailModels = new List<CustomerOrderDetailModel>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT CustomerOrderId, CustomerId, FirstName, LastName, [Description], Price FROM CustomerOrderDetail", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while(reader.Read())
                            {
                                CustomerOrderDetailModel customerOrderDetailModel = new CustomerOrderDetailModel()
                                {
                                    CustomerOrderId = Convert.ToInt32(reader["CustomerOrderId"]),
                                    CustomerId = Convert.ToInt32(reader["CustomerId"]),
                                    FirstName = reader["FirstName"].ToString(),
                                    LastName = reader["LastName"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Price = Convert.ToDecimal(reader["Price"])
                                };
                                customerOrderDetailModels.Add(customerOrderDetailModel);
                            }
                        }
                    }
                }
            }
            return customerOrderDetailModels;
        }
    }
}