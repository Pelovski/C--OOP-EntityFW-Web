using System;
using EDriveRent.Models.Contracts;
using EDriveRent.Utilities.Messages;

namespace EDriveRent.Models
{
    public abstract class Route : IRoute
    {
        private string startPoint;
        private string endPoint;
        private double lenght;

        public Route(string startPoint, string endPoint, double lenght, int routeId)
        {
            this.StartPoint = startPoint;
            this.EndPoint = endPoint;
            this.lenght = lenght;
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
            get => this.lenght;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(ExceptionMessages.RouteLengthLessThanOne);
                }

                this.lenght = value;
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
