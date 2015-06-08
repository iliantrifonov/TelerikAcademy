using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLTable : HTMLElement, ITable
    {
        private const string TableName = "table";
        private readonly IElement[,] elementsTable;

        public HTMLTable(int rows, int cols)
            : base(TableName)
        {
            this.elementsTable = new IElement[rows, cols];//No need to check for negative, as the array will throw an exception if that is the case anyway
        }

        public int Rows { get { return this.elementsTable.GetLength(0); } }

        public int Cols { get { return this.elementsTable.GetLength(1); } }

        public IElement this[int row, int col]
        {
            get
            {
                //No need to check for negative, as the array will throw an exception if that is the case anyway
                return this.elementsTable[row, col];
            }
            set
            {
                //No need to check for negative, as the array will throw an exception if that is the case anyway
                if (value == null)
                {
                    throw new ArgumentNullException("Table element cannot be null");
                }
                this.elementsTable[row, col] = value;
            }
        }

        public override void AddElement(IElement element)
        {
            throw new InvalidOperationException("The tables cannot have child elements");
        }

        public override IEnumerable<IElement> ChildElements
        {
            get
            {
                throw new InvalidOperationException("The tables cannot have child elements");
            }
        }

        public override void Render(StringBuilder output)
        {
            output.Append(string.Format("<{0}>", this.Name));
            for (int i = 0; i < this.elementsTable.GetLength(0); i++)
            {
                output.Append("<tr>");
                for (int k = 0; k < this.elementsTable.GetLength(1); k++)
                {
                    output.Append("<td>");
                    output.Append(this[i, k].ToString());
                    output.Append("</td>");                    
                }
                output.Append("</tr>");
            }
            output.Append(string.Format("</{0}>", this.Name));
        }
    }
}
