using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHEKHOVICH.Entities;

namespace WEB_953502_CHEKHOVICH.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
        /// <summary>
        /// Общая стоимость
        /// </summary>
        public int Price
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity * item.Value.Computer.Price);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="computer">добавляемый объект</param>
        public virtual void AddToCart(Computer computer)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(computer.ComputerId))
                Items[computer.ComputerId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(computer.ComputerId, new CartItem
                {
                    Computer = computer,
                    Quantity = 1
                });
        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Computer Computer { get; set; }
        public int Quantity { get; set; }
    }
}
