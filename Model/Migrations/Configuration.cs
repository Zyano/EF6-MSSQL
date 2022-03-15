using Model.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;

namespace Model.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SQLContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            //var latitude = 56.162939;
            //var longitude = 10.203921;
            //var text = string.Format(CultureInfo.InvariantCulture.NumberFormat, "POINT({0} {1})", longitude, latitude);
            //DbGeography pointFromText = DbGeography.PointFromText(text, DbGeography.DefaultCoordinateSystemId);

            //context.Institutions.AddOrUpdate(new Institution
            //{
            //    Id = 1,
            //    Location = pointFromText,
            //    Name = "Inst 1"
            //});
        }
    }
}
