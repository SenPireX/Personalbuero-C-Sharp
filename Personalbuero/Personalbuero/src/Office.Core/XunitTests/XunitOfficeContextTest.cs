using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Personalverwaltung.Office.Core.Tests;
using Personalverwaltung.Office.Infrastructure;

namespace Personalverwaltung.Office.Core.XunitTests;

    public class XunitOfficeContextTest : DatabaseTest
    {
        [Fact]
        public void CreateDatabaseTest()
        {
            _db.Database.EnsureCreated();
        }
    }
