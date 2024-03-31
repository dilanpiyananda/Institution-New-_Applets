
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Trendil.Helper
{
    internal class DataRowHelper
    {
        public static T CreateItemFromRow<T>(DataRow row) where T : new()
        {
            // create a new object
            T item = new T();

            // set the item
            SetItemFromRow(item, row);

            // return 
            return item;
        }

        public static void SetItemFromRow<T>(T item, DataRow row) where T : new()
        {
            // go through each column
            foreach (DataColumn c in row.Table.Columns)
            {

                //column name convert to matching with property name
                string[] columns = c.ColumnName.Split('_').ToArray();
                string column = string.Empty;
                for (int i = 0; i < columns.Length; i++)
                {
                    column += char.ToUpper(columns[i].ToString()[0]) + columns[i].Substring(1);
                }

                // find the property for the column
                PropertyInfo p = item.GetType().GetProperty(column);



                // if exists, set the value
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(item, row[c], null);
                }
            }
        }
    }
}