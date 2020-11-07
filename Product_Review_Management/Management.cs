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
    }
}
