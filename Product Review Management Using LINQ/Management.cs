﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Product_Review_Management_Using_LINQ
{
    class Management
    {
        public readonly DataTable dataTable = new DataTable();

        // UC2- Retrieve Top 3 records from list.
        public void TopRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReviews in listProductReview
                                orderby productReviews.Rating descending
                                select productReviews).Take(3);
            Console.WriteLine("\nTop 3 records = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

        // UC3- Selects the record with rating grater than 3 and with product id = 1,4,9.
        public void SelectedRecords(List<ProductReview> listProductReview)
        {
            var recordedData = from productReviews in listProductReview
                               where (productReviews.ProductId == 1 || productReviews.ProductId == 4 || productReviews.ProductId == 9) && productReviews.Rating > 3
                               select productReviews;
            Console.WriteLine("\nRating grater than 3 with product id 1,4,9 = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

        // UC4- Retrieves the count of record with  the help of group by id.
        public void RetrieveCountOfRecords(List<ProductReview> listProductReview)
        {
            //lambda syntax
            var recordedData = listProductReview.GroupBy(x => x.ProductId).Select(x => new { ProductId = x.Key, Count = x.Count() });
            Console.WriteLine("\nProduct id and count = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Count);
            }
        }

        // UC5- Retrieve Only the productId and review.
        public void RetrieveProductIdAndReview(List<ProductReview> listProductReview)
        {
            //lambda syntax
            var recordedData = listProductReview.Select(x => new { ProductId = x.ProductId, Review = x.Review });
            Console.WriteLine("\nProduct id and review = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine(list.ProductId + "------" + list.Review);
            }
        }

        // UC6- Skips the top five records.
        public void SkipTopFiveRecords(List<ProductReview> listProductReview)
        {
            var recordedData = (from productReview in listProductReview
                                select productReview).Skip(5);
            Console.WriteLine("\nTop 5 records from list = ");
            foreach (var list in recordedData)
            {
                Console.WriteLine("ProductId:-" + list.ProductId + " UserId:-" + list.UserId + " Ratings:-" + list.Rating + " Review:-" + list.Review + " IsLike:-" + list.isLike);
            }
        }

        // UC8- Creates the table.
        public DataTable CreateTable(List<ProductReview> listProductReview)
        {
            dataTable.Columns.Add("ProductId");
            dataTable.Columns.Add("UserId");
            dataTable.Columns.Add("Rating");
            dataTable.Columns.Add("Review");
            dataTable.Columns.Add("isLike");
            return dataTable;
        }
    }
}
