using Model;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6_MSSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SQLContext context = new SQLContext();
            var insts = context.Institutions.ToList();
            PrintInsts(insts);
            var lastId = insts.Any() ? insts.Max(x => x.Id) : 1;
            
            var newInst = CreateNewInst($"Inst {lastId}");

            context.Institutions.Add(newInst);
            context.SaveChanges();

            insts = context.Institutions.ToList();
            PrintInsts(insts);
        }

        private static Institution CreateNewInst(string name)
        {
            var latitude = 56.162939;
            var longitude = 10.203921;
            var text = string.Format(CultureInfo.InvariantCulture.NumberFormat, "POINT({0} {1})", longitude, latitude);
            DbGeography pointFromText = DbGeography.PointFromText(text, DbGeography.DefaultCoordinateSystemId);
            var newInst = new Institution
            {
                Name = name,
                Location = pointFromText
            };

            return newInst;
        }

        private static void PrintInsts(IEnumerable<Institution> insts)
        {            
            foreach (var inst in insts)
            {
                Console.WriteLine($"{inst.Id} - {inst.Name} - {inst.Location}");
            }
        }
    }
}
