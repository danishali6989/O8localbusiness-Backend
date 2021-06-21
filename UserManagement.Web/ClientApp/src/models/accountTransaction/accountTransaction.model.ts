import { AddressModel } from './../address.model';
import { AttachmentDetailModel } from '../attachment/attachment.detail.model';
import { CustomerDetailModel } from '../customer/customer.detail.model';
import { InvoiceItemModel, VendorPersonalInfoModel } from '..';

export class AccountTransactionDetail {
    public id: number;
    public vendorName: string;
    public invoiceNumber: string;
    public tax: number;
    public discount: number;
    public amount: number;
    public totalAmount: number;
    public allPurchases: number;
    public paidPurchases: number;
    public remark: string;
    public createdOn: string;
    public startDate: string; ///
    public endDate: string; ///
    public description: string; //
    public status: number; //
    public invoiceDate: string;
    public dueDate: string; //
    public vendorId: string;

    public itemTypeId: string;
    public isTaxable: string;
    public salesTaxId: string;
    public salesId: string;
    public customer: CustomerDetailModel;
    public vendor: VendorPersonalInfoModel;

    public items: Array<InvoiceItemModel>;
    public attachments: Array<AttachmentDetailModel>;
    public accountId:number;

    constructor() {
        this.customer = new CustomerDetailModel();
        this.vendor = new VendorPersonalInfoModel();
        this.items = new Array<InvoiceItemModel>();
        this.attachments = new Array<AttachmentDetailModel>();

        this.itemTypeId = '';
        this.salesTaxId = '';
        this.isTaxable = '0';
    }
}
