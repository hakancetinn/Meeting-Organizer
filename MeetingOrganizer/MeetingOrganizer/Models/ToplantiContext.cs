using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MeetingOrganizer.Models
{
    public class ToplantiContext:DbContext
    {
        public DbSet<Toplanti> Toplantis { get; set; }
    }
}