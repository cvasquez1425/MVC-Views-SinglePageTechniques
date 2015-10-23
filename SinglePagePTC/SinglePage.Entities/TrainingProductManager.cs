using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglePage.Entities
{
    public class TrainingProductManager
    {
        public TrainingProductManager()
        {
            ValidationErrors = new List<KeyValuePair<string, string>>();
        }

        public bool Validate(TrainingProduct entity)
        {
            ValidationErrors.Clear();
            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                // Check for lower case
                if (entity.ProductName.ToLower() == entity.ProductName)
                {
                    ValidationErrors.Add(new KeyValuePair<string, string>("ProductName", "Product Name must not be all lowe case."));  // Business Rule failed.
                }
            }

            return (ValidationErrors.Count == 0); // return True or False
        }

        public bool Insert(TrainingProduct entity)
        {
            bool ret = false;

            ret = Validate(entity);
            if (ret)
            {
                //TODO: Create INSERT code here 
            }

            return ret;
        }

        public List<KeyValuePair<string, string>> ValidationErrors {get; set;}

        public List<TrainingProduct> Get(TrainingProduct entity)
        {
            List<TrainingProduct> ret = new List<TrainingProduct>();

            // TODO: Add your data access method here.
            ret = CreateMockData();

            if (!string.IsNullOrEmpty(entity.ProductName))
            {
                ret = ret.FindAll(p => p.ProductName.ToLower().StartsWith(entity.ProductName, StringComparison.CurrentCultureIgnoreCase));
            }

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
