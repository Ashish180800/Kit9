using Microsoft.AspNetCore.Mvc;
 using System;
 using System.Collections.Generic;
 using System.Data;
 using System.Data.SqlClient;
 using System.Linq;
 using Kit9.Models;


namespace Kit9.Controllers
{
        public class ProductController : Controller
        {
            private ApplicationContext db = new ApplicationContext();

            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Search(FormCollection form)
            {
                // Retrieve user input from the form
                string productName = form["ProductName"];
                string size = form["Size"];
                decimal? price = !string.IsNullOrEmpty(form["Price"]) ? decimal.Parse(form["Price"]) : (decimal?)null;
                DateTime? mfgDate = !string.IsNullOrEmpty(form["MfgDate"]) ? DateTime.Parse(form["MfgDate"]) : (DateTime?)null;
                string category = form["Category"];
                string conjunction = form["Conjunction"]; // AND or OR

                // Create SQL parameters for the stored procedure
                var parameters = new List<SqlParameter>
            {
                new SqlParameter("@ProductName", productName ?? (object)DBNull.Value),
                new SqlParameter("@Size", size ?? (object)DBNull.Value),
                new SqlParameter("@Price", price ?? (object)DBNull.Value),
                new SqlParameter("@MfgDate", mfgDate ?? (object)DBNull.Value),
                new SqlParameter("@Category", category ?? (object)DBNull.Value)
            };

                string query = "EXEC SearchProducts @ProductName, @Size, @Price, @MfgDate, @Category";

                if (conjunction == "OR")
                {
                    // Change the stored procedure to use OR logic (modify the stored procedure accordingly)
                    query = "EXEC SearchProducts_OR @ProductName, @Size, @Price, @MfgDate, @Category";
                }

                // Execute the stored procedure and retrieve results
                var results = db.Database.SqlQuery<Product>(query, parameters.ToArray()).ToList();

                return View("Index", results);
            }
        }
}
