﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Data;
using SensorLogInserterRe.Daos;

namespace SensorLogInserterRe.Models
{
    public class Driver : NotificationObject
    {

        #region DriverId変更通知プロパティ
        private int _DriverId;

        public int DriverId
        {
            get
            { return _DriverId; }
            set
            { 
                if (_DriverId == value)
                    return;
                _DriverId = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Name変更通知プロパティ
        private string _Name;

        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public List<Driver> GetDriverList()
        {
            var ret = new List<Driver>();

            var table = new DataTable();
            string query = "SELECT * FROM drivers";
            table = DatabaseAccesser.GetResult(query);

            foreach(DataRow row in table.Rows)
            {
                ret.Add(new Driver() { DriverId = row.Field<int>("driver_id"), Name = row.Field<string>("name")} );
            }

            return ret;
        }

    }
}
