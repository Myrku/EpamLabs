using Aircompany.Models;
using Aircompany.Planes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Aircompany
{
    public class Airport
    {
        public List<Plane> Planes;

        public Airport(IEnumerable<Plane> planes)
        {
            Planes = planes.ToList();
        }

        public List<PassengerPlane> GetPassengersPlanes()
        {
            return GetPlanes<PassengerPlane>();
        }

        public List<MilitaryPlane> GetMilitaryPlanes()
        {
            return GetPlanes<MilitaryPlane>();
        }

        public PassengerPlane GetPassengerPlaneWithMaxPassengersCapacity()
        {
            return GetPlanes<PassengerPlane>().Aggregate((currentPlane, nextPlane) => currentPlane.PassengersCapacity > nextPlane.PassengersCapacity ? currentPlane : nextPlane);
        }

        public List<MilitaryPlane> GetTransportMilitaryPlanes()
        {
            return GetMilitaryPlanes().Where(militaryPlane => militaryPlane.PlanType == MilitaryType.TRANSPORT).ToList();
        }

        public Airport SortByMaxDistance()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxFlightDistance));
        }

        public Airport SortByMaxSpeed()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxSpeed));
        }

        public Airport SortByMaxLoadCapacity()
        {
            return new Airport(Planes.OrderBy(plane => plane.MaxLoadCapacity));
        }

        public List<TypePlane> GetPlanes<TypePlane>() where TypePlane : Plane
        {
            List<TypePlane> planes = new List<TypePlane>();
            foreach (var plane in Planes)
            {
                if (plane is TypePlane)
                    planes.Add((TypePlane)plane);
            }
            return planes;
        }

        public override string ToString()
        {
            return "Airport{" +
                    "planes=" + string.Join(", ", Planes.Select(x => x.PlaneModel)) +
                    '}';
        }
    }
}
