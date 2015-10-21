using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePage.Entities
{
    public class TrainingProductManager
    {

        public List<TrainingProduct> Get()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            // TODO: Add your data access method here.
            ret = CreateMockData();

            return ret;
        }
    
        private List<TrainingProduct> CreateMockData()
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            ret.Add(new TrainingProduct()
            {
                ProductId = 1,
                ProductName = "Extending Bootstrap with CSS, JavaScrip and JQuery",
                IntroductionDate = Convert.ToDateTime("10/20/2015"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 2,
                ProductName = "Build Your Own Bootstrap Business Application Template",
                IntroductionDate = Convert.ToDateTime("10/29/2015"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 3,
                ProductName = "Building Mobile Web Sites Using Web Forms, Bootstrap",
                IntroductionDate = Convert.ToDateTime("08/28/2014"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 4,
                ProductName = "How To Start and Run A Consulting Business",
                IntroductionDate = Convert.ToDateTime("09/12/2013"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 5,
                ProductName = "The Many Approaches to XML Processing in .Net Applicaition",
                IntroductionDate = Convert.ToDateTime("07/22/2013"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 6,
                ProductName = "WPF for the Business Programmer",
                IntroductionDate = Convert.ToDateTime("06/12/2009"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 7,
                ProductName = "WPF for the Visual Basic Programmer - Part I",
                IntroductionDate = Convert.ToDateTime("10/20/2015"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            ret.Add(new TrainingProduct()
            {
                ProductId = 8,
                ProductName = "WPF for the Visual Basic Programmer - Part 2",
                IntroductionDate = Convert.ToDateTime("2/18/2014"),
                Url = "http://bit.ly/LSNzc0i",
                Price = Convert.ToDecimal(29.00)
            });

            return ret;
        }
    }
}
