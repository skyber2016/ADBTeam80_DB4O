using Db4objects.Db4o;
using MidTerm2019;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADBTeam80_DB4O.Services
{
    public class DatabaseService
    {
        private IObjectContainer db { get; set; }
        private static DatabaseService _instance { get; set; }
        public IList<Company> Companies { get; set; }
        public IList<Company> GetCompanies
        {
            get
            {
                if(this.Companies.Count == 0)
                {
                    return new List<Company>()
                    {
                        new Company
                        {
                            CompanyName = "Test_OPPO",
                            City = "HCM",
                            CompanyID = Guid.Parse("ed1be26d-b180-4b2d-8a76-e7ae82025db9"),
                            HouseNumber = "280",
                            Street = "An Duong Vuong"
                        },
                        new Company
                        {
                            CompanyName = "Test_APPLE",
                            City = "HCM",
                            CompanyID = Guid.Parse("656ea3d4-9d9c-4c6a-9fcd-2037555c101b"),
                            HouseNumber = "280",
                            Street = "An Duong Vuong"
                        },
                        new Company
                        {
                            CompanyName = "Test_SAMSUNG",
                            City = "HCM",
                            CompanyID = Guid.Parse("b61854ca-609a-4877-81b9-d20bba94d2ca"),
                            HouseNumber = "280",
                            Street = "An Duong Vuong"
                        },
                        new Company
                        {
                            CompanyName = "Test_HUAWEI",
                            City = "HCM",
                            CompanyID = Guid.Parse("c9932535-cde3-4d8a-ba91-ba62821e9e52"),
                            HouseNumber = "280",
                            Street = "An Duong Vuong"
                        },
                        new Company
                        {
                            CompanyName = "Test_Note",
                            City = "HCM",
                            CompanyID = Guid.Parse("a24e0685-f2ab-4814-a567-1633c647760b"),
                            HouseNumber = "280",
                            Street = "An Duong Vuong"
                        }
                    };
                }
                return this.Companies;
            }
        }
        public static DatabaseService Instance
        {
            get
            {
                return _instance ?? (_instance = new DatabaseService());
            }
        }
        public DatabaseService()
        {
            this.Companies = new List<Company>();
            this.db = Db4oFactory.OpenFile("4101104023_EmployeeManager");
        }
        public void Insert<T>(T data)
        {
            try
            {
                this.db.Store(data);
                this.db.Commit();
            }
            catch (Exception)
            {
                this.db.Rollback();
            }
        }
        public IEnumerable<T> Get<T>()
        {
            return this.db.Query<T>();
        }
    }
}
