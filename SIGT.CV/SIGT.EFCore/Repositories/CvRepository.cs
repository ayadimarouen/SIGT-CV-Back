using SIGT.Entities;
using SIGT.Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SIGT.DTO;

namespace SIGT.EFCore.Repositories
{
    public class CvRepository : GenericBaseRepository<Cv, SigtContext>,ICvRepository<Cv> , IDisposable
    {
        public CvRepository(SigtContext context) : base(context) { dbContext = context; }

        public async Task<CvDTO> ReadCV()
        {
            Cv defaultCv = await dbContext.Cv.FirstOrDefaultAsync();
            List<ExperienceDTO> experience = await buildExperience(defaultCv.Id);
            var buildCvQuery = await (from cv in dbContext.Cv
                                      where cv.Id == defaultCv.Id
                                      select new CvDTO
                                      {
                                          Title = cv.Title,
                                          FullName = cv.FullName,
                                          Age = cv.Age,
                                          Phone = cv.Phone,
                                          Address = cv.Adress,
                                          Linkedin = cv.Linkedin,
                                          Photo = cv.Photo,
                                          Email = cv.Email,
                                          Experiences = experience,
                                          Educations = dbContext.Education.Select(i => new EducationDTO
                                          {
                                              DateFrom=i.DateFrom,
                                              DateTo=i.DateTo,
                                              Institute=i.Institute,
                                              Label=i.Label
                                          }).OrderByDescending(p=>p.DateFrom).ToList(),
                                          Interests = dbContext.Interest.Select(i => new InterestDTO
                                          {
                                              Label = i.Label
                                          }).ToList(),
                                          Skills = dbContext.Skills.Select(i => new SkillsDTO
                                          {
                                              Label = i.Label
                                          }).ToList(),
                                          Languages = dbContext.Language.Select(i => new LanguageDTO
                                          {
                                              Label = i.Label,
                                              Level = i.Level
                                          }).ToList(),
                                      }).FirstOrDefaultAsync();

            return buildCvQuery;
        }

        public async Task<List<ExperienceDTO>> buildExperience (int cvId)
        {          
            List<ExperienceDTO> experienceList = new List<ExperienceDTO>();
            List<Experience> experience = await dbContext.Experience.Include(p => p.SkillsExperience).Where(p => p.CvId == cvId).OrderByDescending(p=>p.DateFrom).ToListAsync();
            foreach (Experience expr in experience)
            {
                List<string> skills = dbContext.SkillsExperience.Where(p => p.ExperienceId == expr.Id).Select(p => p.Skills.Label).ToList();
                List<TasksDTO> tasks = dbContext.Tasks.Where(p => p.ExperienceId == expr.Id).Select(p => new TasksDTO
                {
                    Label = p.Label
                }).ToList();
                ExperienceDTO buildExperience = new ExperienceDTO
                {
                    Company = expr.Company,
                    DateFrom = expr.DateFrom,
                    DateTo = expr.DateTo,
                    Title = expr.Title,
                    Skills = skills,
                    Tasks = tasks,
                };
                experienceList.Add(buildExperience);
            }
            return experienceList;           
        }

        

             
    }
    
}
