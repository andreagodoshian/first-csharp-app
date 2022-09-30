using CustomerOrderViewer.Models;
using CustomerOrderViewer.Repository;
using System.Data.SqlClient;

namespace CustomerOrderViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CustomerOrderDetailCommand customerOrderDetailCommand = new CustomerOrderDetailCommand(@"Data Source=localhost;Initial Catalog=CustomerOrderViewer;Integrated Security=True");

                IList<CustomerOrderDetailModel> customerOrderDetailModels = customerOrderDetailCommand.GetList();

                if (customerOrderDetailModels.Any())
                {
                    foreach (CustomerOrderDetailModel x in customerOrderDetailModels)
                    {
                        Console.WriteLine(x.FirstName + " " + x.LastName + " bought " + x.Description + " for " + x.Price);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong...\n" + e.Message);
            }
        }
    }
}