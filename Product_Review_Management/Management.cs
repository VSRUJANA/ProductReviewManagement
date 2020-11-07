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
                Console.Write("\t" + "Review: " + list.Review.PadRight(15) + "isLike: " + list.isLike+"\n");
            }
        }
    }
}
