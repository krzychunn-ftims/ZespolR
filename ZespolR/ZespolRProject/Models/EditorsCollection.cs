using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZespolRProject.Models
{
    public class EditorsCollection
    {
        private List<Editor> packages = new List<Editor>();

        public List<Editor> Models
        {
            set { packages = value; }
            get { return packages; }
        }

        public Editor Default
        {
            get { return new Editor(); }
        }

    }
}