using System;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double length;

        public Route(string startPoint, string endPoint, double length, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.Length = length;
            this.RouteId = routeId;
        }

        public string StartPoint
        {
            get => this.startPoint;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.StartPointNull);
                }

                this.startPoint = value;
            }
        }

        public string EndPoint
        {
            get => this.endPoint;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EndPointNull);
                }

                this.endPoint = value;
            }
        }

        public double Length
        {
            get => this.length;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }

                this.length = value;
            }

        }

        public int RouteId { get; }

        public bool IsLocked { get; private set; }

        public void LockRoute()
        {
            this.IsLocked = true;
        }
    }
}
