using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop
{
    internal class AppDBInitializer : CreateDatabaseIfNotExists<AppDBContext>
    {
        protected override void Seed(AppDBContext context)
        {
            context.Thems.Add(new Models.Them()
            {
                Name = "Default",
                Colors = "#ED553B,#F6D55C,#3CAEA3,#20639B,#173F5F"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "بادکنک",
                Colors = "#FFD7DF,#ECCEFF,#FFE8B5,#FFC29C,#BBC0FF,#F82B97,#7DF2E4,#E2F25A,#FF9955,#4C72C8"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "شب زمستون",
                Colors = "#523f6c,#a6aed2,#c6cfde,#787fb5,#be80b1"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "بستنی",
                Colors = "#1bb79f,#d03a93,#81d7cc,#ebcdd7,#7e9a81"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "کیوی پرتقال",
                Colors = "#f4bc0f,#778b10,#f1dfbb,#bcd927,#444e0f"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "شیروانی",
                Colors = "#6b8196,#a7c7bc,#dabb8c,#ae8b89,#7d98ab"
            });
            context.Thems.Add(new Models.Them()
            {
                Name = "پاییز",
                Colors = "#ac2313,#442c0a,#ba642b,#caa58a,#f8f8f6"
            });
            context.Users.Add(new Models.User()
            {
                ThemName = "Default",
                UserName = "default",
            });
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
