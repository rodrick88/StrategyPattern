using System.Collections.Generic;
using Woffu;

namespace WoffuKata
{
    public class WoffuProgam
    {
        IList<Allocation> Allocations;
        public WoffuProgam(IList<Allocation> Allocations)
        {
            this.Allocations = Allocations;
        }

        public void UpdateAvailability()
        {
            for (var i = 0; i < Allocations.Count; i++)
            {
                if (Allocations[i].Name != "HomeWork" && Allocations[i].Name != "RemoteWork")
                {
                    if (Allocations[i].DaysToExpiration > 0 && Allocations[i].Availability < 20)
                    {
                        if (Allocations[i].Name != "Sickness")
                        {
                            Allocations[i].Availability = Allocations[i].Availability + 0.1M;
                        }
                    }
                }
                else
                {
                    if (Allocations[i].DaysToExpiration > 0 && Allocations[i].Availability > 0)
                    {
                        Allocations[i].Availability = Allocations[i].Availability - 0.1M;

                        if (Allocations[i].Name == "RemoteWork")
                        {
                            if (Allocations[i].DaysToExpiration < 11)
                            {
                                if (Allocations[i].Availability > 0)
                                {
                                    Allocations[i].Availability = Allocations[i].Availability - 0.1M;
                                }
                            }

                            if (Allocations[i].DaysToExpiration < 6)
                            {
                                if (Allocations[i].Availability > 0)
                                {
                                    Allocations[i].Availability = Allocations[i].Availability - 0.1M;
                                }
                            }
                        }
                    }
                }

                //if (Allocations[i].Name == "Vacation")
                //{
                //    if (Allocations[i].DaysToExpiration < 0 && Allocations[i].Availability > 0)
                //    {
                //        Allocations[i].Availability = Allocations[i].Availability - 0.1M;
                //    }
                //}

                if (Allocations[i].Name != "Sickness")
                {
                    Allocations[i].DaysToExpiration = Allocations[i].DaysToExpiration - 1;
                }

                if (Allocations[i].DaysToExpiration < 0)
                {
                    if (Allocations[i].Name != "Vacation")
                    {
                        Allocations[i].Availability = Allocations[i].Availability - Allocations[i].Availability;
                    }
                    else
                    {
                        if (Allocations[i].Availability > 0)
                        {
                            Allocations[i].Availability = Allocations[i].Availability - 0.1M;
                        }
                    }
                }
            }
        }
    }
}
