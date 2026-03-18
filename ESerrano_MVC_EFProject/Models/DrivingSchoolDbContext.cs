using ESerrano_MVC_EFProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity; // MUST INCLUDE FIRST – needed for DbContext, DbSet
using System.Linq;
using System.Web;

namespace Task3_Driving_School.Models
{
    // STEP 5: Create  DbContext class – this is the main class that manages your database

    // Your Entity Framework database context class
    // This manages all tables (DbSets) and database connections

    // STEP 6: ADD DBSet property for each entity within the DbContext.
    // Inherit from DbContext and add DbSet<T> properties for each table (POCO class)
    public class DrivingSchoolDbContext : DbContext
    {
        // These DbSet<T> properties represent tables in your database

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Ref_Customer_Status> Ref_Customer_Statuses { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Ref_Lesson_Status> Ref_Lesson_Statuses { get; set; }
        public DbSet<Customer_Payment> Customer_Payments { get; set; }
        public DbSet<Ref_Payment_Methods> Ref_Payment_Methods { get; set; }

        // Constructor telling EF to use a connection string named "DrivingSchoolConnection"
        public DrivingSchoolDbContext() : base("DrivingSchoolConnection")// Make sure this matches the name in your Web.config connectionStrings section
        {
            // Tells EF how to create and seed the database
            // DropCreateDatabaseAlways wipes and recreates DB every run
            // You replaced it with a custom seeder class
            Database.SetInitializer(new DrivingSchoolDbInitialiser());
        }
    }

    // Your database initializer – runs ONLY when database is created
    // DropCreateDatabaseAlways = recreate DB every run (for testing/demo)

    // STEP 7: Configure the Connection String  in the Web.config

    //STEP 8: Set the Database Initialisation strategy DropCreateDatabaseAlways
    public class DrivingSchoolDbInitialiser : DropCreateDatabaseAlways<DrivingSchoolDbContext>
    {

        // STEP 9: Seed the Database
        protected override void Seed(DrivingSchoolDbContext context)
        {
            base.Seed(context);

            // ------------------------------
            // CREATE ADDRESSES
            // ------------------------------
            Address address1 = new Address
            {
                Building_Number = 10,
                Street_Name = "Main St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            Address address2 = new Address
            {
                Building_Number = 55,
                Street_Name = "South St",
                City = "Wishaw",
                Postcode = "ML9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            Address address3 = new Address
            {
                Building_Number = 5,
                Street_Name = "Happy St",
                City = "Glasgow",
                Postcode = "G9 123",
                Country = "Scotland",
                Other_Address_Details = ""
            };

            // ------------------------------
            // PAYMENT METHODS
            // ------------------------------
            Ref_Payment_Methods payment_Method1 = new Ref_Payment_Methods { Payment_Method_Description = "Credit Card" };
            Ref_Payment_Methods payment_Method2 = new Ref_Payment_Methods { Payment_Method_Description = "Cash" };
            Ref_Payment_Methods payment_Method3 = new Ref_Payment_Methods { Payment_Method_Description = "Debit Card" };

            // ------------------------------
            // LESSON STATUS VALUES
            // ------------------------------
            Ref_Lesson_Status lessonstatus1 = new Ref_Lesson_Status { Lesson_Status_Description = "Completed" };
            Ref_Lesson_Status lessonstatus2 = new Ref_Lesson_Status { Lesson_Status_Description = "Cancelled" };
            Ref_Lesson_Status lessonstatus3 = new Ref_Lesson_Status { Lesson_Status_Description = "Pending" };

            // ------------------------------
            // CUSTOMER STATUS VALUES
            // ------------------------------
            Ref_Customer_Status customer_Status1 = new Ref_Customer_Status { Customer_Status_Description = "Bad" };
            Ref_Customer_Status customer_Status2 = new Ref_Customer_Status { Customer_Status_Description = "Ok" };
            Ref_Customer_Status customer_Status3 = new Ref_Customer_Status { Customer_Status_Description = "Good" };

            // ------------------------------
            // VEHICLES
            // ------------------------------
            Vehicle vehicle1 = new Vehicle { Vehicle_Details = "Manual Red Toyota Hylux 2.0L" };
            Vehicle vehicle2 = new Vehicle { Vehicle_Details = "Automatic Blue Kia Sportage 1.5L" };

            // ------------------------------
            // CUSTOMERS
            // ------------------------------
            Customer customer1 = new Customer
            {
                First_Name = "John",
                Last_Name = "Doe",
                Date_Of_Birth = new DateTime(1970, 01, 01),
                Date_Became_Customer = new DateTime(2020, 12, 19),
                Email = "johndoe@gmail.com",
                Phone_Number = "0123456789",
                Cell_Mobile_Phone_Number = "07112233445",
                Other_Customer_Details = "",
                Address = address2,
                Ref_Customer_Status = customer_Status2
            };

            Customer customer2 = new Customer
            {
                First_Name = "Jack",
                Last_Name = "Black",
                Date_Of_Birth = new DateTime(2003, 02, 05),
                Date_Became_Customer = new DateTime(2021, 07, 19),
                Email = "jack@gmail.com",
                Phone_Number = "0123456789",
                Cell_Mobile_Phone_Number = "07112233445",
                Other_Customer_Details = "",
                Address = address3,
                Ref_Customer_Status = customer_Status1
            };

            // ------------------------------
            // STAFF MEMBERS
            // ------------------------------
            Staff staff1 = new Staff
            {
                First_Name = "Mario",
                Middle_Name = "",
                Last_Name = "Andretti",
                Date_Of_Birth = new DateTime(1950, 03, 01),
                Nickname = "SuperMario",
                Date_Joined_Staff = new DateTime(1975, 01, 05),
                Date_Left_Staff = null,
                Other_Staff_Details = "",
                Address = address1
            };

            Staff staff2 = new Staff
            {
                First_Name = "Luigi",
                Middle_Name = "",
                Last_Name = "Luigi",
                Date_Of_Birth = new DateTime(1979, 03, 03),
                Nickname = "SuperLuigi",
                Date_Joined_Staff = new DateTime(2000, 01, 05),
                Date_Left_Staff = null,
                Other_Staff_Details = "",
                Address = address1
            };

            // ------------------------------
            // LESSONS
            // ------------------------------
            Lesson lesson1 = new Lesson
            {
                Customer = customer1,
                Staff = staff1,
                Lesson_Date = new DateTime(2021, 05, 01),
                Lesson_Time = new DateTime(2021, 05, 01, 10, 30, 00),
                Vehicle = vehicle1,
                Price = 30,
                Ref_Lesson_Status = lessonstatus2
            };

            Lesson lesson2 = new Lesson
            {
                Customer = customer1,
                Staff = staff1,
                Lesson_Date = new DateTime(2021, 05, 08),
                Lesson_Time = new DateTime(2021, 05, 08, 12, 00, 00),
                Vehicle = vehicle2,
                Price = 25,
                Ref_Lesson_Status = lessonstatus3
            };

            Lesson lesson3 = new Lesson
            {
                Customer = customer2,
                Staff = staff2,
                Lesson_Date = new DateTime(2021, 05, 18),
                Lesson_Time = new DateTime(2021, 05, 18, 12, 00, 00),
                Vehicle = vehicle2,
                Price = 25,
                Ref_Lesson_Status = lessonstatus3
            };

            // Add lessons to database
            context.Lessons.Add(lesson1);
            context.Lessons.Add(lesson2);
            context.Lessons.Add(lesson3); // fixed duplicate lesson2
            context.SaveChanges(); // IMPORTANT: Save before adding payments

            // ------------------------------
            // CUSTOMER PAYMENTS
            // ------------------------------
            Customer_Payment customer_Payment1 = new Customer_Payment
            {
                Datetime_Payment = new DateTime(2021, 05, 01, 11, 00, 00),
                Ammount_Payment = 25.00M,
                Ref_Payment_Methods = payment_Method1,
                Customer = customer1
            };

            Customer_Payment customer_Payment2 = new Customer_Payment
            {
                Datetime_Payment = new DateTime(2021, 09, 11, 10, 05, 06),
                Ammount_Payment = 25.00M,
                Ref_Payment_Methods = payment_Method2,
                Customer = customer2
            };

            // Add payments
            context.Customer_Payments.Add(customer_Payment1);
            context.Customer_Payments.Add(customer_Payment2);

            context.SaveChanges(); // Final save
        }
    }
}