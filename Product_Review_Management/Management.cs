using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Product_Review_Management
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();

        // Retrieve top 3 best rated records from the Product Review list 
        public void Top3Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            foreach (var list in recordedData)
            {
                Console.Write("ProductID: " + list.ProductID + "\t" + "User ID: " + list.UserID + "\t" + "Rating: " + list.Rating);
                Console.Write("\t" + "Review: " + list.Review.PadRight(15) + "isLike: " + list.isLike + "\n");
            }
        }

        // Retrieve all records from the list whose rating is greater than 3 and productID is 1 or 4 or 9
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProductID == 1 || productReviews.ProductID == 4 || productReviews.ProductID == 9)
                               && productReviews.Rating > 3
                               select productReviews;
            foreach (var list in recordedData)
            {
                Console.Write("ProductID: " + list.ProductID + "\t" + "User ID: " + list.UserID + "\t" + "Rating: " + list.Rating);
                Console.Write("\t" + "Review: " + list.Review.PadRight(15) + "isLike: " + list.isLike + "\n");
            }
        }

        // Retrieve Count of reviews present for each productID
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            var recordedData = listProductReview.GroupBy(x => x.ProductID).Select(x => new { ProductID = x.Key, Count = x.Count() });
            Console.WriteLine("ProductID" + "\t" + "Count");
            foreach (var list in recordedData)
            {
                Console.WriteLine("    " + list.ProductID + " \t\t " + list.Count);
            }
        }

        // Get Product Id and reviews from the ProductReviewList
        public void GetProductIdAndReview(List<ProductReview> listProductReview)
        {
            var recordedData = from productReview in listProductReview select new { productReview.ProductID, productReview.Review };
            Console.WriteLine("ProductID" + "\t" + "Review");
            foreach (var list in recordedData)
            {
                Console.WriteLine("    " + list.ProductID + " \t\t " + list.Review);
            }
        }

        // Skip top 5 records from the ProductReviewList and display other records
        public void SkipTop5Records(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview select productReview).Skip(5);

            foreach (var list in recordedData)
            {
                Console.Write("ProductID: " + list.ProductID + "\t" + "User ID: " + list.UserID + "\t" + "Rating: " + list.Rating);
                Console.Write("\t" + "Review: " + list.Review.PadRight(15) + "isLike: " + list.isLike + "\n");
            }
        }

        // Insert values in data table from list
        public void InsertValuesInDataTable(List<ProductReview> listProductReview)
        {
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("UserID", typeof(int));
            dataTable.Columns.Add("Rating", typeof(double));
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike", typeof(bool));

            foreach (ProductReview product in listProductReview)
            {
                dataTable.Rows.Add(product.ProductID, product.UserID, product.Rating, product.Review, product.isLike);
            }
        }

        // Display values in the data table
        public void DisplayDataTable()
        {
            foreach (DataColumn col in dataTable.Columns)
            {
                Console.Write(col.ToString().PadRight(15));
            }
            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine();
                foreach (DataColumn col in dataTable.Columns)
                {
                    Console.Write(row[col].ToString().PadRight(15));
                }
            }
        }

        // Retrieve all the records from the datatable with isLike value as true 
        public void GetRecordsWithIsLikeTrue()
        {
            var query = from productReview in dataTable.AsEnumerable()
                        where productReview.Field<bool>("isLike") == true
                        select productReview;
            foreach (DataRow product in query)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + "\t" + "UserID : " + product.Field<int>("UserID")
                    + "\t" + "Rating : " + product.Field<double>("Rating") + "\t" + "Review : " + product.Field<string>("Review").PadRight(15)
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }

        // Find Average rating for each productId
        public void GetAverageRating()
        {
            var recordedData = dataTable.AsEnumerable().GroupBy(x => x.Field<int>("ProductID")).Select
                               (x => new { ProductID = x.Key, Average = x.Average(x => x.Field<double>("Rating")) });
            Console.WriteLine("Product Id    Average Rating");
            foreach (var list in recordedData)
            {
                Console.WriteLine("   " + list.ProductID + " \t\t " + Math.Round(list.Average, 2));
            }
        }

        // Get products whose review contains nice
        public void GetProductWithReviewNice()
        {
            var recordedData = from productReview in dataTable.AsEnumerable()
                               where productReview.Field<string>("Review").ToUpper().Contains("NICE")
                               select productReview;

            foreach (var product in recordedData)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + "\t" + "UserID : " + product.Field<int>("UserID")
                    + "\t" + "Rating : " + product.Field<double>("Rating") + "\t" + "Review : " + product.Field<string>("Review").PadRight(10)
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }

        // Get Records with UserID = 10 and order by rating
        public void GetRecordsWithUserIdAs10()
        {
            dataTable.Rows.Add(7, 10, 3, "Bad", false);
            dataTable.Rows.Add(9, 10, 9, "Excellent", true);
            dataTable.Rows.Add(6, 10, 8, "Nice", true);
            dataTable.Rows.Add(4, 10, 5, "Average", true);

            var recordedData = from productReview in dataTable.AsEnumerable()
                               where productReview.Field<int>("UserId") == 10
                               orderby productReview.Field<double>("Rating")
                               select productReview;

            foreach (var product in recordedData)
            {
                Console.WriteLine("ProductID : " + product.Field<int>("ProductID") + "\t" + "UserID : " + product.Field<int>("UserID")
                    + "\t" + "Rating : " + product.Field<double>("Rating") + "\t" + "Review : " + product.Field<string>("Review").PadRight(15)
                    + "isLike : " + product.Field<bool>("isLike"));
            }
        }
    }
}
