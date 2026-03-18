using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Web;

namespace ESerrano_MVC_EFProject.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public DateTime Date_Became_Customer { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public decimal Ammount_Outstanding { get; set; }
        public string Email { get; set; }
        public string Phone_Number { get; set; }
        public string Cell_Mobile_Phone_Number { get; set; }
        public string Other_Customer_Details { get; set; }

        // Navigational properties
        [ForeignKey("Address")]//A customer has one address
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Ref_Customer_Status")]//A customer has one ref_customer_status
        public int Customer_Status_Code { get; set; }
        public Ref_Customer_Status Ref_Customer_Status { get; set; }

        public List<Customer_Payment> Customer_Payments { get; set; } //One customer has many customer payments

        public List<Lesson> Lessons { get; set; } //One customer has many lessons
    }

    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public int Building_Number { get; set; }
        public string Street_Name { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Other_Address_Details { get; set; }

        //---------------Navigational Properties---------------

        public List<Customer> Customers { get; set; } //One address has many customers
        public List<Staff> Staffs { get; set; } //One address has many staff members

    }

    public class Staff
    {
        [Key]
        public int StaffId { get; set; }
        public string Nickname { get; set; }
        public string First_Name { get; set; }
        public string Middle_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Of_Birth { get; set; }
        public DateTime Date_Joined_Staff { get; set; }
        public DateTime? Date_Left_Staff { get; set; }
        public string Other_Staff_Details { get; set; }

        //----------------Navigational Properties ------------------

        [ForeignKey("Address")]//Staff have one address
        public int? AddressId { get; set; }//make the property nullable -IMPORTANT
        public Address Address { get; set; }

        public List<Lesson> Lessons { get; set; } //One staff member has many lessons

    }

    public class Ref_Customer_Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_Status_Code { get; set; }
        public string Customer_Status_Description { get; set; }


        //---------Navigational Properties-------------

        public List<Customer> Customers { get; set; } //one Ref_Customer_Status has many customers

    }

    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        public DateTime Lesson_Date { get; set; }
        public DateTime Lesson_Time { get; set; }
        public decimal Price { get; set; }
        public string Other_Lesson_Details { get; set; }


        //-----------Navigational Properties--------- 

        [ForeignKey("Staff")]//A lesson has one staff member
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

        [ForeignKey("Customer")] //A lesson has one customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [ForeignKey("Vehicle")] //A lesson has one vehicle
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        [ForeignKey("Ref_Lesson_Status")] //A lesson has one ref_lesson_status
        public int Lesson_Status_code { get; set; }
        public Ref_Lesson_Status Ref_Lesson_Status { get; set; }
    }

    public class Vehicle
    {
        [Key]
        public int VehicleId { get; set; }
        public string Vehicle_Details { get; set; }


        //--------------Navigational Properties------------------- 

        public List<Lesson> Lessons { get; set; } //one vehicle has many lessons
    }

    public class Ref_Lesson_Status
    {
        [Key]
        public int Lesson_Status_Code { get; set; }
        public string Lesson_Status_Description { get; set; }


        //-----------Navigational Properties ---------

        public List<Lesson> Lessons { get; set; } //One ref_lesson_status has many lessons
    }

    public class Customer_Payment
    {
        //this class has a composite key: CustomerId and Dateytime_Payment

        [Column(Order = 0), Key, ForeignKey("Customer")] //A customer_payment has one customer
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        [Column(Order = 1), Key]
        public DateTime Datetime_Payment { get; set; }
        public decimal Ammount_Payment { get; set; }
        public string Other_Payment_Details { get; set; }


        //------------Navigational Properties -------------

        [ForeignKey("Ref_Payment_Methods")] //A customer-payment has one ref_payment_method
        public int Payment_Method_Code { get; set; }
        public Ref_Payment_Methods Ref_Payment_Methods { get; set; }
    }

    public class Ref_Payment_Methods
    {
        [Key]
        public int Payment_Method_Code { get; set; }
        public string Payment_Method_Description { get; set; }


        //----------Navigational Properties------------

        public List<Customer_Payment> Customer_Payments { get; set; } //One ref_payment_methods has many customer payments


    }
}