// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen.exe, version 0.9.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace example.avro
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Avro;
    using Avro.Specific;

    public partial class User : ISpecificRecord
    {
        public static Schema _SCHEMA = Avro.Schema.Parse("{\"type\":\"record\",\"name\":\"User\",\"namespace\":\"example.avro\",\"fields\":[{\"name\":\"name" +
                "\",\"type\":\"string\"}]}");
        private string _name;
        public virtual Schema Schema
        {
            get
            {
                return User._SCHEMA;
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        public virtual object Get(int fieldPos)
        {
            switch (fieldPos)
            {
                case 0: return this._name;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
            };
        }
        public virtual void Put(int fieldPos, object fieldValue)
        {
            switch (fieldPos)
            {
                case 0: this._name = (System.String)fieldValue; break;
                default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
            };
        }
    }
}
