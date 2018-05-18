using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Common.Model;
using VideoStore.Business.Entities;

namespace VideoStore.Business.Components
{
    public class OrderToTransferMessage: IVisitor
    {
        private int mFromAccountNumber;
        private int mToAccountNumber;

        public OrderToTransferMessage(int pFromAccountNumber, int pToAccountNumber)
        {
            mFromAccountNumber = pFromAccountNumber;
            mToAccountNumber = pToAccountNumber;

        }

        public TransferMessage Result { get; set; }

        public void Visit(IVisitable pVisitable)
        {
            if(pVisitable is Order)
            {
                Order lOrder = pVisitable as Order;
                Result = new TransferMessage()
                {
                    OrderGuid = lOrder.OrderNumber,
                    FromAccountNumber = mFromAccountNumber,
                    ToAccountNumber = mToAccountNumber,
                    Total = lOrder.Total ?? 0,
                    Topic = "transfer"
                };
            }
        }
    }
}
