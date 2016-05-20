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
            Assert.AreEqual("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
                " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
                " personalTyp='1' AND rapportradDatum>='2010-13-01' AND rapportradDatum<='2010-13-02'", Query.GetQuery("2010-13-01", "2010-13-02", 1));
        }
        [TestMethod]
        public void QueryTestOnlyFrom()
        {
            Assert.AreEqual("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
    " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
    " personalTyp='1' AND rapportradDatum>='2010-13-01'", Query.GetQuery("2010-13-01", String.Empty, 1));
        }
        [TestMethod]
        public void QueryTestOnlyTo()
        {
            Assert.AreEqual("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
     " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID AND" +
     " personalTyp='1' AND rapportradDatum<='2010-13-01'", Query.GetQuery(String.Empty, "2010-13-01", 1));
        }
        [TestMethod]
        public void QueryTestEpmty()
        {
            Assert.AreEqual("Select personalFornamn , rapportradStart,rapportradSlut,rapportradLunchStart,rapportradLunchSlut,rapportradDatum,personalTyp From snille_personaltabell" +
     " INNER JOIN  snille_rapportrader ON snille_personaltabell.personalID = snille_rapportrader.personalID", Query.GetQuery(String.Empty, String.Empty, 1));

        }

        [TestMethod]
        public void AddATwoDates()
        {
            Assert.AreEqual("AND rapportradDatum>='2011-02-02' AND rapportradDatum<='2011-02-03'", Query.AddDates("2011-02-02", "2011-02-03"));
        }
        [TestMethod]
        public void AddAOnlyFrom()
        {
            Assert.AreEqual("AND rapportradDatum>='2011-02-02'", Query.AddDates("2011-02-02",String.Empty));
        }
        [TestMethod]
        public void AddAOnlyTo()
        {
            Assert.AreEqual("AND rapportradDatum<='2011-02-03'", Query.AddDates(String.Empty, "2011-02-03"));
        }
        [TestMethod]
        public void AddAEmpty()
        {
            Assert.AreEqual(String.Empty, Query.AddDates(String.Empty,String.Empty));
        }
    }
}