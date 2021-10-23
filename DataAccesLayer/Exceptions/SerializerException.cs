using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLayer.Exceptions
{
    class SerializerException : Exception
    {
        private string fileName;
        public string FileName
        {
            get
            {
                return fileName;
            }
        }
        public SerializerException(string fileName, string message) : base(message)
        {
            this.fileName = fileName;
        }
    }
}
