using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZespolRProject.Models
{
    public class Editor_Test
    {
        private TestsCollection _tests = new TestsCollection();
        private EditorsCollection _editors = new EditorsCollection();

        public TestsCollection Tests
        {
            get { return _tests; }
            set { _tests = value; }
        }

        public EditorsCollection Editors
        {
            get { return _editors; }
            set { _editors = value; }
        }

    }
}