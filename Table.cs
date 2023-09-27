using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MultiTask
{
    class Table<ListType>
    {
        private IList<ListType> _list = new List<ListType>();
        private const String _NUMBER_FORM = "|{0,-12}|";
        private String[] _headNames;
        private String _strFormat = "";
        public Table(IList<ListType> newList, params String[] headNames) { 
            _list = newList;
            _headNames = headNames;
        }

        public void outputTable()
        {
            int distanceBetweenWords = (Console.BufferWidth - (12 + 2*_headNames.Length)) / _headNames.Length;
            _strFormat = "{0," + -distanceBetweenWords + "}|";
            _outpuTableHeader();

            for(int i = 0; i < _list.Count; i++)
            {
                _writeConteiner(i);
            }
        }
        private void _writeConteiner(int i)
        {
            Console.Write(String.Format(_NUMBER_FORM, i + 1));
            foreach (var item in _list[i].GetType().GetFields())
                Console.Write(String.Format(_strFormat, item.GetValue(_list[i])));
            foreach (var item in _list[i].GetType().GetProperties())
                Console.Write(String.Format(_strFormat, item.GetValue(_list[i])));
            Console.WriteLine();
        }
        private void _outpuTableHeader() { 

            String strLine = String.Format(_NUMBER_FORM, "№");

            foreach (String name in _headNames)
                strLine += String.Format(_strFormat, name);

            Console.WriteLine(new String('-',Console.BufferWidth));
            Console.WriteLine(strLine);
            Console.WriteLine(new String('-', Console.BufferWidth));
        }
    }
}
