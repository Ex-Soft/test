﻿using System;

namespace TestGrid.remote.app.models
{
    public class Staff
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }
        public int? Dep { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? NullField { get; set; }
    }
}
