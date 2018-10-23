using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoemwork6
{
    [Serializable]
    public  class OrderDetail
    {
        public OrderDetail()
        {

        }
        public OrderDetail(uint id, Goods goods, uint quantity)
        {
            this.Id = id;
            this.Goods = goods;
            this.Quantity = quantity;
        }
        /// <summary>
        /// OrderDetail's id
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// orderDetail's goods
        /// </summary>
        public Goods Goods { get; set; }

        /// <summary>
        /// goods quantity
        /// </summary>
        public uint Quantity { get; set; }

        public override bool Equals(object obj)
        {
            var detail = obj as OrderDetail;
            return detail != null &&
                Goods.Id == detail.Goods.Id &&
                Quantity == detail.Quantity;
        }

        public override int GetHashCode()
        {
            var hashCode = 1522631281;
            hashCode = hashCode * -1521134295 + Goods.Name.GetHashCode();
            hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// override ToString
        /// </summary>
        /// <returns>string:message of the OrderDetail object</returns>
        public override string ToString()
        {
            string result = "";
            result += $"orderDetailId:{Id}:  ";
            result += Goods + $", quantity:{Quantity}";
            return result;
        }

    }
}
