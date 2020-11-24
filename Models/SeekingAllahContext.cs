using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Term_Project_Version_1.Models
{
	public class SeekingAllahContext : DbContext
	{
		public SeekingAllahContext(DbContextOptions<SeekingAllahContext> options)
			: base(options)
		{ }
		public DbSet<Members> Membership { get; set; }
		public DbSet<Purchases> Purchases { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Members>().HasData(
				new Members
				{
					ID = 1,
					name = "Michelle Vanwettere",
					email = "michelle@vanwetteregroup.com",
					City = "Kalmthout",
					Address = "Pastoor Celensstraat 1",
					PostalCode = "2920",
					Country = "Belgium"
				},
				new Members
				{
					ID = 2,
					name = "Tito Nugauily",
					email = "tito.nugaily@gmail.com",
					City = "Alexandria",
					Address = "Mohammed Mohammed Amr Allah",
					PostalCode = "21624",
					Country = "Egypt"
				},
				new Members
				{
					ID = 3,
					name = "David Wood",
					email = "david.wood@acts17.com",
					City = "New York City",
					PostalCode = "10001",
					Country = "United States"
				},
								new Members
								{
									ID = 4,
									name = "Matthew Gibson",
									email = "mgibson@makeitrain.com",
									City = "Traverse City",
									Address = "4138 Huntington Drive",
									PostalCode = "49686",
									Country = "United States"
								},
												new Members
												{
													ID = 5,
													name = "Mohamed Ayew",
													email = "mohamedayew@gmail.com",
													City = "Los Angeles",
													Address = "4131 Benedict Canyon Dr",
													PostalCode = "91423",
													Country = "United States"
												},
																new Members
																{
																	ID = 6,
																	name = "Meda Doyle",
																	email = "mayadamohamed@gmail.com",
																	City = "Thibodaux",
																	Address = "1219 Tetreau Street",
																	PostalCode = "70301",
																	Country = "United States"
																}
			);
			modelBuilder.Entity<Purchases>().HasData(
				 new Purchases
				 {
					 ID = "SA",
					 Description="Seeking Allah Finding Jesus Paperback",
					Price = "$19.99",
					 MembersID = 1
				 },
				 new Purchases
				 {
					 ID = "SG",
					 Description = "Study Guide including hard cover book, study guide and blu-ray",
					Price = "$79.99",
					 MembersID = 6
				 },
				 new Purchases
				 {
					 ID = "FA",
					 Description = "Full Access including study guide and access to all podcasts and articles",
					 Price = "$109.99",
					 MembersID = 5
				 }
			 );
		}
	}
}
