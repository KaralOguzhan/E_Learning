using MyElearningProject.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using Process = MyElearningProject.DAL.Entities.Process;

namespace MyElearningProject.DAL.Context
{
	public class ELearningContext : DbContext
	{
		public DbSet<Category> Categories   { get; set; }
		public DbSet<Instructor> Instructors { get; set; }
		public DbSet<Testimonial> Testimonials { get; set; }
		public DbSet<Student> Students { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseRegister> CourseRegisters { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Review> Reviews { get; set; }
		public DbSet<Process> Processes { get; set; }
		public DbSet<CourseLink> CourseLinks { get; set; }
		public DbSet<QuadLink> quadLinks { get; set; }
		public DbSet<Admin> Admins { get; set; }

		



	}
}