﻿namespace _369.Data
{
    using System;
    using Contracts;
    using System.Collections.Generic;
    using System.Text;
    class UnitRepository : IRepository
    {
        private IDictionary<string, int> amountOfUnits;

        public IDictionary<string, int> AmountOfUnits { get { return amountOfUnits; } }
        public UnitRepository()
        {
            this.amountOfUnits = new SortedDictionary<string, int>();
        }

        public string Statistics
        {
            get
            {
                StringBuilder statBuilder = new StringBuilder();
                foreach (var entry in amountOfUnits)
                {
                    statBuilder.AppendLine($"{entry.Key} -> {entry.Value}");
                }

                return statBuilder.ToString().Trim();
            }
        }

        public void AddUnit(IUnit unit)
        {
            string unitType = unit.GetType().Name;
            if (!this.amountOfUnits.ContainsKey(unitType))
            {
                this.amountOfUnits.Add(unitType, 0);
            }

            this.amountOfUnits[unitType]++;
        }

        public void RemoveUnit(string unitType)
        {
            if (this.amountOfUnits[unitType] > 0)
            {
                amountOfUnits[unitType]--;
            }
            else throw new InvalidOperationException("No such units in repository.");
        }
    }
}
