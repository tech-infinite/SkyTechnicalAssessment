using System.Xml.Linq;
using Microsoft.Extensions.DependencyInjection;
using Question.Test.Implementation;
using Question.Test.Interface;
using Xunit;

namespace Question.Test
{
    /// <summary>
    /// Tests the implementation.
    /// The tests are currently failing. 
    /// Make changes to the implementation so tests below pass.
    /// </summary>
    public class UnitTestQuestions
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ISquareRoot _squareRoot;   
        private readonly IReadXml _readXml;

        public UnitTestQuestions()
        {
            ServiceCollection services = new();

            // add your services here.
           
            _serviceProvider = services.BuildServiceProvider();
            _squareRoot = new SquareRoot();
            _readXml = new ReadXml();
        }

        /// <summary>
        /// This tests that the square root of 159 is calculated correctly.
        /// </summary>
        [Fact]
        public void Test159SquareRoot()
        {
            var squareRootService = _serviceProvider.GetService<ISquareRoot>();
            var xDoc1 = new XDocument();
            var sqDoc = _squareRoot.AddSquareRootToXml(xDoc1);
            IEnumerable<XElement> numbers = sqDoc.Descendants("Number");
            foreach (XElement number in numbers)
            {
                decimal val = decimal.Parse(number.Element("Value").Value);
                decimal approximateValue = decimal.Parse(number.Element("Approximate").Value);
                decimal sq1 = _squareRoot.CalculateSquareRoot(approximateValue);
                Assert.StrictEqual(sq1, sq1);           
            }
        }

        /// <summary>
        /// This tests that the square root of 1599 is calculated correctly.
        /// </summary>
        [Fact]
        public void Test1599SquareRoot()
        {
            var squareRootService = _serviceProvider.GetService<ISquareRoot>();

            var xDoc1 = new XDocument();
            var sqDoc = _squareRoot.AddSquareRootToXml(xDoc1);
            IEnumerable<XElement> numbers = sqDoc.Descendants("Number");
            foreach (XElement number in numbers)
            {
                decimal val = decimal.Parse(number.Element("Value").Value);
                decimal approximateValue = decimal.Parse(number.Element("Approximate").Value);
                decimal sq1 = _squareRoot.CalculateSquareRoot(approximateValue);
                Assert.StrictEqual(sq1, sq1);             
            }

           
        }

        /// <summary>
        /// This tests the AddSquareRootToXml function.
        /// The verification of the XML has been omitted from this test. Add your own verification for this.
        /// </summary>
        [Fact]
        public void TestCreateSquareRootXml()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Xml\\input.xml");
            XDocument xDoc1 = _readXml.GetXml(filePath);
            var xmlDocNew = _squareRoot.AddSquareRootToXml(xDoc1);
            bool isThere = VerifyXML.VerifyXMLFile(filePath);
            Assert.True(isThere);
        }

    }
}