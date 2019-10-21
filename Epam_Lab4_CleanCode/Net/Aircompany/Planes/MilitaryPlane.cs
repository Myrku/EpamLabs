using Aircompany.Models;

namespace Aircompany.Planes
{
    public class MilitaryPlane : Plane
    {
        public MilitaryType PlanType;

        public MilitaryPlane(string model, int maxSpeed, int maxFlightDistance, int maxLoadCapacity, MilitaryType type)
            : base(model, maxSpeed, maxFlightDistance, maxLoadCapacity)
        {
            PlanType = type;
        }

        public override bool Equals(object obj)
        {
            var plane = obj as MilitaryPlane;
            return plane != null &&
                   base.Equals(obj) &&
                   PlanType == plane.PlanType;
        }

        public override int GetHashCode()
        {
            var hashCode = 1701194404;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + PlanType.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString().Replace("}",
                    ", type=" + PlanType +
                    '}');
        }        
    }
}
