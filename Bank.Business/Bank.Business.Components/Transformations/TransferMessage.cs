using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace Bank.Business.Components.Transformations
{
    public class TransferMessage: IVisitor
    {
        //public DataPoint Result { get; set; }

        public void Visit(IVisitable pVisitable)
        {
            if (pVisitable is TransferMessage)
            {
                TransferMessage lMsg = pVisitable as TransferMessage;
                //Result = lMsg;
                //Result = new DataPoint() { DependentValue = lMsg.Price, SeriesName = lMsg.Item };
            }
        }
    }
}
