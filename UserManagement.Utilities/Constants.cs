﻿namespace UserManagement.Utilities
{
    public class Constants
    {
        public const string DateFormat = "MM/dd/yyyy";

        public const int DefaultPageSize = 10;

        public enum RecordStatus { Created, Active, Inactive, Deleted }

        public enum BillPaymentMode { Cash, Transfer, Cheque , CreditCard }

        public enum PaymentMode { Cash, Transfer, Check }

        public enum InvoiceStatus { Pending, Paid, Deleted ,Overdue}
        public enum BillStatus { Pending, Paid, Deleted, Overdue }
        public enum ContactType { Customer, Vendor }
        public enum TransactionType {CustomerAdvancePayment, InvoicePayment, VendorAdvancePayment, BillPayment, AccountIncome, AccountExpence, CreditMemo}
        public enum TransactionStatus { Pending, Paid }
        public enum InvoiceType { Service, Product }
        public enum ProjectTransactionType { Invoice, Bill }
        public struct Account
        {
            public const int AccountReceiveable = 1;
            public const int AccountPayable = 2;
        }

        public struct UserType
        {
            public const string Admin = "Administrator";
            public const string Employee = "Employee";
        }

        public struct EmailTemplateType
        {
            public const string ToCustomerOnRegistration = "to_customer_on_registration.html";
            public const string ToAdminOnCustomerRegistration = "to_admin_on_customer_registration.html";
        }
        public const string SessionKeyName = "CompanyTenantId";
        public string SessionInfo_Name { get; private set; }

        /*public static class Global
        {
            /// <summary>
            /// Global variable storing important stuff.
            /// </summary>
            static string _HeaderData;

            /// <summary>
            /// Get or set the static important data.
            /// </summary>
            public static string HeaderData
            {
                get
                {
                    return _HeaderData;
                }
                set
                {
                    _HeaderData = value;
                }
            }
        }*/
    }
}
