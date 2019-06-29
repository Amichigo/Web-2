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
    class InitialLessonDefaultValue
    {
        private readonly GWebsiteDbContext<Tenant, Role, User, AbpZeroTemplateDbContext> _context;

        public InitialLessonDefaultValue(GWebsiteDbContext<Tenant, Role, User, AbpZeroTemplateDbContext> context)
        {
            _context = context;
        }
        public void Create()
        {
            ///////////////////////////
            //Add default Lesson Listen & watch
            //////////////////////////
            var listen = _context.Lessons.FirstOrDefault(p => p.CatName == "listen & watch");
            if (listen == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage= "assets/Listen/ListenIcon1.jpg",
                        LessonContent= "Animal House",
                        Link= "assets/Video/animal_house.mp4",
                        CatName = "listen & watch"
                    });
            }
            var listen2 = _context.Lessons.FirstOrDefault(p => p.CatName == "listen & watch");
            if (listen2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Listen/ListenIcon2.jpg",
                        LessonContent = "Baby Shark",
                        Link = "assets/Video/Baby_Shark.mp4",
                        CatName = "listen & watch"
                    });
            }
            var listen3 = _context.Lessons.FirstOrDefault(p => p.CatName == "listen & watch");
            if (listen3 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Listen/ListenIcon3.jpg",
                        LessonContent = "The alphabet song",
                        Link = "assets/Video/The_alphabet_song.mp4",
                        CatName = "listen & watch"
                    });
            }
            var listen4 = _context.Lessons.FirstOrDefault(p => p.CatName == "listen & watch");
            if (listen4 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Listen/ListenIcon4.jpg",
                        LessonContent = "Wheels on the bus",
                        Link = "assets/Video/Wheels_on_the_Bus .mp4",
                        CatName = "listen & watch"
                    });
            }

            ///////////////////////////
            //Add default Lesson read & write
            //////////////////////////
            var read = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (read == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Read/Read1.jpg",
                        LessonContent = "Helping others",
                        Link = "assets/Read/Reading1.png",
                        CatName = "read & write"
                    });
            }
            var read2 = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (read2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Read/Read2.jpg",
                        LessonContent = "Say no to bullying",
                        Link = "assets/Read/Reading2.png",
                        CatName = "read & write"
                    });
            }
            var read3 = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (read3 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Read/Read3.jpg",
                        LessonContent = "Superheroes",
                        Link = "assets/Read/Reading3.png",
                        CatName = "read & write"
                    });
            }
            var read4 = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (read4 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Read/Read4.jpg",
                        LessonContent = "Seasons",
                        Link = "assets/Read/Reading4.png",
                        CatName = "read & write"
                    });
            }
            var write = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (write == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Write/Write1.jpg",
                        LessonContent = "Problem page",
                        Link = "assets/Write/Writing1.png",
                        CatName = "read & write"
                    });
            }
            var write2 = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (write2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Write/Write2.jpg",
                        LessonContent = "Penpal letter",
                        Link = "assets/Write/Writing2.png",
                        CatName = "read & write"
                    });
            }
            var write3 = _context.Lessons.FirstOrDefault(p => p.CatName == "read & write");
            if (write3 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Write/Write3.jpg",
                        LessonContent = "Book review",
                        Link = "assets/Write/Writing3.png",
                        CatName = "read & write"
                    });
            }

            ///////////////////////////
            //Add default Lesson speak & spell
            //////////////////////////
            var speak = _context.Lessons.FirstOrDefault(p => p.CatName == "speak & spell");
            if (speak == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Banner/speak_spell.jpg",
                        LessonContent = "The television",
                        Link = "assets/Video/SpeakVid1.mp4",
                        CatName = "speak & spell"
                    });
            }
            var speak2 = _context.Lessons.FirstOrDefault(p => p.CatName == "speak & spell");
            if (speak2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Banner/speak_spell.jpg",
                        LessonContent = "The camping adventure",
                        Link = "assets/Video/SpeakVid2.mp4",
                        CatName = "speak & spell"
                    });
            }
            var spell = _context.Lessons.FirstOrDefault(p => p.CatName == "speak & spell");
            if (spell == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Banner/speak_spell.jpg",
                        LessonContent = "The spelling sports day",
                        Link = "assets/Video/SpellVid1.mp4",
                        CatName = "speak & spell"
                    });
            }
            var spell2 = _context.Lessons.FirstOrDefault(p => p.CatName == "speak & spell");
            if (spell2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Banner/speak_spell.jpg",
                        LessonContent = "The boat adventure",
                        Link = "assets/Video/SpellVid2.mp4",
                        CatName = "speak & spell"
                    });
            }

            ///////////////////////////
            //Add default Lesson gramma & vocabulary
            //////////////////////////
            var gramma = _context.Lessons.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (gramma == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Gramma/Gramma1.jpg",
                        LessonContent = "Present Simple Tense",
                        Link = "assets/Video/GrammarVid1.mp4",
                        CatName = "gramma & vocabulary"
                    });
            }
            var gramma2 = _context.Lessons.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (gramma2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Gramma/Gramma2.jpg",
                        LessonContent = "Present Continuous Tense",
                        Link = "assets/Video/GrammarVid2.mp4",
                        CatName = "gramma & vocabulary"
                    });
            }
            var gramma3 = _context.Lessons.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (gramma3 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Gramma/Gramma3.jpg",
                        LessonContent = "Nouns Countable And Uncountable",
                        Link = "assets/Video/GrammarVid3.mp4",
                        CatName = "gramma & vocabulary"
                    });
            }
            var vocabulary = _context.Lessons.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (vocabulary == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Vocabulary/Vocab1.jpg",
                        LessonContent = "Sea Animals",
                        Link = "assets/Video/VocabVid1.mp4",
                        CatName = "gramma & vocabulary"
                    });
            }
            var vocabulary2 = _context.Lessons.FirstOrDefault(p => p.CatName == "gramma & vocabulary");
            if (vocabulary2 == null)
            {
                _context.Lessons.Add(
                    new Lesson
                    {
                        IntroImage = "assets/Vocabulary/Vocab2.jpg",
                        LessonContent = "Baby Animals",
                        Link = "assets/Video/VocabVid2.mp4",
                        CatName = "gramma & vocabulary"
                    });
            }
        }
    }
}

