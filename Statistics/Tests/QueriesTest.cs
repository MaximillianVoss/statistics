using Microsoft.VisualStudio.TestTools.UnitTesting;
using Statistics.Classes;
using System;

namespace Statistics.Tests
{
    [TestClass]
    public class QueriesTest
    {
        [TestMethod]
        public void QueryTestFull()
        {
            Assert.AreEqual(("Select " + String.Join(", ", Common.columnNamesPersonal.ToArray()) + " From snille_personaltabell" +
            " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
            " personalTyp='1' AND rapportradDatum>='2010-13-01' AND rapportradDatum<='2010-13-02'").Replace(" ", String.Empty),
            Query.GetPersonalQuery("2010-13-01", "2010-13-02", 1, Common.columnNamesPersonal).Replace(" ", String.Empty));
        }
        [TestMethod]
        public void QueryTestOnlyFrom()
        {
            Assert.AreEqual(("Select " + String.Join(", ", Common.columnNamesPersonal.ToArray()) + " From snille_personaltabell" +
            " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
            " personalTyp='1'  AND rapportradDatum>='2010-13-01'").Replace(" ", String.Empty),
            Query.GetPersonalQuery("2010-13-01", String.Empty, 1, Common.columnNamesPersonal).Replace(" ", String.Empty));
        }
        [TestMethod]
        public void QueryTestOnlyTo()
        {
            Assert.AreEqual(("Select " + String.Join(", ", Common.columnNamesPersonal.ToArray()) + " From snille_personaltabell" +
            " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
            " personalTyp='1'  AND rapportradDatum<='2010-13-01'").Replace(" ", String.Empty),
            Query.GetPersonalQuery(String.Empty, "2010-13-01", 1, Common.columnNamesPersonal).Replace(" ", String.Empty));
        }
        [TestMethod]
        public void QueryTestEpmty()
        {
            Assert.AreEqual(("Select " + String.Join(", ", Common.columnNamesPersonal.ToArray()) + " From snille_personaltabell" +
            " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND personalTyp='1' ").Replace(" ", String.Empty),
            Query.GetPersonalQuery(String.Empty, String.Empty, 1, Common.columnNamesPersonal).Replace(" ", String.Empty));

        }
        [TestMethod]
        public void AddATwoDates()
        {
            Assert.AreEqual("AND rapportradDatum>='2011-02-02' AND rapportradDatum<='2011-02-03'", Query.AddDates("2011-02-02", "2011-02-03"));
        }
        [TestMethod]
        public void AddAOnlyFrom()
        {
            Assert.AreEqual("AND rapportradDatum>='2011-02-02'", Query.AddDates("2011-02-02", String.Empty));
        }
        [TestMethod]
        public void AddAOnlyTo()
        {
            Assert.AreEqual("AND rapportradDatum<='2011-02-03'", Query.AddDates(String.Empty, "2011-02-03"));
        }
        [TestMethod]
        public void AddAEmpty()
        {
            Assert.AreEqual(String.Empty, Query.AddDates(String.Empty, String.Empty));
        }
    }
}