using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WeatherAppFMW.Helpers;
using WeatherAppFMW.Models;

namespace WeatherAppFMW.Tests
{
    [TestClass]
    public class ForecastRange_Tests
    {
        private Mock<IForecastday> _forecastday;

        [TestInitialize]
        public void ForecastRange_Init()
        {
            _forecastday = new Mock<IForecastday>();
            _forecastday.Setup(p => p.Hour).Returns(new List<Hour>()
            {
                new Hour {
                    Time = "2022-01-11 00:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 01:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 02:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 03:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 04:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 05:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 06:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 07:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 08:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 09:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 10:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 11:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 12:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 13:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 14:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 15:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 16:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 17:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 18:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 19:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 20:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 21:00",
                    Condition = new Condition()
                    {
                        Text = "Cloudy"
                    }
                },
                new Hour {
                    Time = "2022-01-11 22:00",
                    Condition = new Condition()
                    {
                        Text = "Clear"
                    }
                },
                new Hour {
                    Time = "2022-01-11 23:00",
                    Condition = new Condition()
                    {
                        Text = "Clear"
                    }
                },
                new Hour {
                    Time = "2022-01-11 24:00",
                    Condition = new Condition()
                    {
                        Text = "Clear"
                    }
                }
            });
        }

        [TestMethod]
        [DataRow(3)]

        public void GetForecastRange_Retrieve(int hour)
        {
            List<Hour> hours = ForecastRange.GetForecastRange(_forecastday.Object, hour);
            Assert.IsTrue(hours.Count == 3);
            Assert.IsTrue(hours[0].Time.Equals("2022-01-11 03:00"));
            Assert.IsTrue(hours[1].Time.Equals("2022-01-11 04:00"));
            Assert.IsTrue(hours[2].Time.Equals("2022-01-11 05:00"));
        }

        [TestMethod]
        [DataRow(23)]

        public void GetForecastRange_RetrieveOneHour(int hour)
        {
            List<Hour> hours = ForecastRange.GetForecastRange(_forecastday.Object, hour);
            Assert.IsTrue(hours.Count == 1);
            Assert.IsTrue(hours[0].Time.Equals("2022-01-11 23:00"));
        }
    }
}
