using System;
using System.Collections.Generic;
using System.Linq;

namespace Product_Review_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Product Review Management System!");
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductID=1,UserID=1,Rating=4,Review="Bad",isLike=true},
                new ProductReview(){ProductID=2,UserID=2,Rating=7,Review="Good",isLike=true},
                new ProductReview(){ProductID=2,UserID=1,Rating=10,Review="Excellent",isLike=true},
                new ProductReview(){ProductID=2,UserID=3,Rating=9,Review="Excellent",isLike=false},
                new ProductReview(){ProductID=3,UserID=1,Rating=5,Review="Average",isLike=true},
                new ProductReview(){ProductID=3,UserID=4,Rating=1,Review="Worst",isLike=true},
                new ProductReview(){ProductID=4,UserID=1,Rating=1,Review="Worst",isLike=false},
                new ProductReview(){ProductID=5,UserID=5,Rating=3,Review="Bad",isLike=true},
                new ProductReview(){ProductID=5,UserID=2,Rating=3,Review="Bad",isLike=true},
                new ProductReview(){ProductID=6,UserID=4,Rating=5,Review="Average",isLike=true},
                new ProductReview(){ProductID=6,UserID=5,Rating=5,Review="Average",isLike=true},
                new ProductReview(){ProductID=7,UserID=5,Rating=1,Review="Worst",isLike=false},
                new ProductReview(){ProductID=8,UserID=1,Rating=9,Review="Excellent",isLike=true},
                new ProductReview(){ProductID=8,UserID=3,Rating=3,Review="Bad",isLike=false},
                new ProductReview(){ProductID=6,UserID=4,Rating=4,Review="Bad",isLike=true},
                new ProductReview(){ProductID=1,UserID=2,Rating=2,Review="Worst",isLike=true},
                new ProductReview(){ProductID=9,UserID=2,Rating=6,Review="Good",isLike=true},
                new ProductReview(){ProductID=7,UserID=3,Rating=7,Review="Good",isLike=true},
                new ProductReview(){ProductID=9,UserID=2,Rating=5,Review="Average",isLike=true},
                new ProductReview(){ProductID=6,UserID=5,Rating=1,Review="Worst",isLike=true},
                new ProductReview(){ProductID=3,UserID=4,Rating=3,Review="Bad",isLike=true},
                new ProductReview(){ProductID=2,UserID=4,Rating=7,Review="Good",isLike=true},
                new ProductReview(){ProductID=7,UserID=2,Rating=4,Review="Bad",isLike=true},
                new ProductReview(){ProductID=9,UserID=6,Rating=10,Review="Excellent",isLike=true},
                new ProductReview(){ProductID=5,UserID=3,Rating=5,Review="Average",isLike=true}
            };

            Management management = new Management();

            Console.WriteLine("\nTop 3 best rated records in Product Review List : ");
            management.Top3Records(productReviewList);

            Console.WriteLine("\nRecords whose rating is greater than 3 and productID is 1 or 4 or 9 :");
            management.SelectedRecords(productReviewList);

            Console.WriteLine("\nCount of reviews present for each productID :");
            management.RetrieveCountOfRecords(productReviewList);
        }
    }
}
