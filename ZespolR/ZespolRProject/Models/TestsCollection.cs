using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZespolRProject.Models
{
    public class TestsCollection
    {
        private List<Test> packages = new List<Test>();

        public List<Test> Models
        {
            set { packages = value; }
            get { return packages; }
        }

        public Test Default
        {
            get { return new Test(); }
        }
    }

}
}