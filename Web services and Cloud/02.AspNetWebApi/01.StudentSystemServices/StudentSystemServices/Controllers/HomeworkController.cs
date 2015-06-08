﻿using StudentSystem.Data;
using StudentSystem.Models;
using StudentSystemServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentSystemServices.Controllers
{
    public class HomeworkController : ApiController
    {
        private StudentsSystemData data = new StudentsSystemData();

        public HttpResponseMessage GetAllHomeworks()
        {
            var homeworks = this.data.Homeworks.All().Select(HomeworkTemplate.FromHomework);

            return Request.CreateResponse(HttpStatusCode.OK, homeworks);
        }

        public HttpResponseMessage GetHomeworkById(int id)
        {
            var homeworkToGet = this.data.Homeworks.All().Where(homework => homework.Id == id).Select(HomeworkTemplate.FromHomework).FirstOrDefault();
            if (homeworkToGet == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Homework does not exist.");
            }
            return Request.CreateResponse(HttpStatusCode.OK, homeworkToGet);
        }

        public HttpResponseMessage AddHomework([FromBody]HomeworkTemplate newHomework)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid new homework.");
            }

            this.data.Homeworks.Add(new Homework()
                {
                    TimeSent = newHomework.TimeSent,
                    FileUrl = newHomework.FileUrl,
                    CourseId = newHomework.CourseId,
                    StudentIdentification = newHomework.StudentIdentification
                });
            this.data.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK, "Homework added.");
        }

        [HttpPut]
        public HttpResponseMessage UpdateFileUrl(int id, [FromBody]string newFileUrl)
        {
            var homeworkToUpdate = this.data.Homeworks.All().FirstOrDefault(homework => homework.Id == id);
            if (homeworkToUpdate == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Homework does not exist.");
            }

            homeworkToUpdate.FileUrl = newFileUrl;
            this.data.Homeworks.Update(homeworkToUpdate);
            this.data.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Hoemwork updated.");
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            var homeworkToDelete = this.data.Homeworks.All().FirstOrDefault(homework => homework.Id == id);
            if (homeworkToDelete == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Homework does not exist.");
            }

            this.data.Homeworks.Delete(homeworkToDelete);
            this.data.SaveChanges();
            return Request.CreateResponse(HttpStatusCode.OK, "Hoemwork deleted");
        }
    }
}
