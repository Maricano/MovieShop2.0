﻿using MovieStoreDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

 
namespace MovieStoreUserUI.Models
{
    public class ShoppingCart
    {
       public List<OrderLine> orderLines { get; set;  }
       public Customer Customer { get; set; }
       
       public void AddOrderLine(Movie movie, int amount)
        {
            OrderLine line = GetOrderLines().FirstOrDefault(x => x.Movie.Id == movie.Id);
            if (line != null)
            {
                line.Amount += amount;
            }
            else
            {
                orderLines.Add(new OrderLine() { Movie = movie, Amount = amount });
            }
        }

        public void RemoveAmount(Movie movie, int amount)
        {
            OrderLine line = GetOrderLines().FirstOrDefault(x => x.Movie.Id == movie.Id);
            if (line != null)
            {
                line.Amount -= amount;
            }
            else
            {
                orderLines.Add(new OrderLine() { Movie = movie, Amount = amount });
            }
        }

        public void RemoveOrderLine(OrderLine orderLine)
        {
            GetOrderLines().Remove(orderLine);
        }
        public List<OrderLine> GetOrderLines()
        {
            if (orderLines == null)
            {
                orderLines = new List<OrderLine>();
            }
            return orderLines;
        }

        public double GetTotal()
        {
            double sum = 0;
            foreach (var item in orderLines)
            {
                sum += item.GetOrdeLineSum();
            }
            return sum;
        }

        public void CleanCart()
        {
            orderLines = null;
        }

    }
}