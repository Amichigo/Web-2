using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.EntityFrameworkCore;
using GSoft.AbpZeroTemplate.Authorization.Roles;
using GSoft.AbpZeroTemplate.Authorization.Users;
using GSoft.AbpZeroTemplate.MultiTenancy;
using GSoft.AbpZeroTemplate.EntityFrameworkCore;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GSoft.AbpZeroTemplate.Migrations.Seed.Host
{
    class InitialPeopleCreator
    {
        private readonly GWebsiteDbContext<Tenant, Role, User, AbpZeroTemplateDbContext> _context;

        public InitialPeopleCreator(GWebsiteDbContext<Tenant, Role, User, AbpZeroTemplateDbContext> context)
        {
            _context = context;
        }
        public void Create()
        {
            var douglas = _context.Categories.FirstOrDefault(p => p.CatName == "listen & watch");
            if (douglas == null)
            {
                _context.Categories.Add(
                    new Category
                    {
                        CatName = "listen & watch",
                        CatImage = "Banner/watch_listen.jpg",
                        CatContent = "Do you like listening to songs and watching stories and videos in English? In this section you can learn to sing songs in English and watch fun stories and videos."
                    });
            }

            var douglas1 = _context.Categories.FirstOrDefault(p => p.CatName == "read & write");
            if (douglas1 == null)
            {
                _context.Categories.Add(
                    new Category
                    {
                        CatName = "read & write",
                        CatImage = "','Banner/read_write.png",
                        CatContent = "Do you want to practise your reading and writing in English? In this section you can read and write about interesting topics."
                    });
            }

            var douglas2 = _context.Categories.FirstOrDefault(p => p.CatName == "speak & spell");
            if (douglas2 == null)
            {
                _context.Categories.Add(
                    new Category
                    {
                        CatName = "speak & spell",
                        CatImage = "Banner/speak_spell.jpg",
                        CatContent = "Do you want to improve your spelling and pronunciation in English? In this section you can learn how to say and spell English words, the super space spies. Play games and watch songs and stories."
                    });
            }

            var douglas3 = _context.Categories.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (douglas3 == null)
            {
                _context.Categories.Add(
                    new Category
                    {
                        CatName = "gramma & vocabulary",
                        CatImage = "Banner/gramma_vocabulary.jpg",
                        CatContent = "Do you want to practise your English grammar and learn new words? In this section you can learn about grammar rules, play word games and watch fun videos. Watch the grammar videos, play the grammar games and print the grammar worksheets."
                    });
            }
        }
    }
}
