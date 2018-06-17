using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZespolRProject.Models
{
    public class QuestionCollection
    {

        private List<Question> packages = new List<Question>();
        public int testID { get; set; }

        public List<Question> Models
        {
            set { packages = value; }
            get { return packages; }
        }

        public Question Default
        {
            get { return new Question(); }
        }

    }
}